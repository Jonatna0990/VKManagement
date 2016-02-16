using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;
using Windows.System;
using VKCore.Util;

namespace VKCore.API.SDK
{
    public static class VKAppLaunchAuthorizationHelper
    {
        private static readonly string _launchUriStrFrm = @"vkappconnect://authorize?State={0}&ClientId={1}&Scope={2}&Revoke={3}&RedirectUri={4}";

        public static async Task AuthorizeVKApp(
            string state,
            string clientId, 
            List<string> scopeList,
            bool revoke)
        {
            string redirectUri = await GetRedirectUri();

            var uriString = string.Format(_launchUriStrFrm,
                WebUtility.UrlEncode(state == null ? string.Empty : state),
                clientId,
                StrUtil.GetCommaSeparated(scopeList),
                revoke,
                redirectUri);

            var fallbackUri = string.Format(VKSDK.VK_AUTH_STR_FRM,
                VKSDK.Instance.CurrentAppID,
               scopeList.GetCommaSeparated(),
               WebUtility.UrlEncode("vk" + clientId + "://authorize" ),
               VKSDK.API_VERSION, 
               revoke ? 1 : 0);

            try
            {

                await Launcher.LaunchUriAsync(new Uri(uriString), new LauncherOptions() { FallbackUri = new Uri(fallbackUri) });

            }
            catch (Exception)
            {
      

            }


        }

        private static async Task<string> GetRedirectUri()
        {
            return await GetVKLoginCallbackSchemeName() + "://authorize";
        }

        async private static Task<string> GetVKLoginCallbackSchemeName()
        {
            string result = await GetFilteredManifestAppAttributeValue("Protocol", "Name", "vk");
            return result;
        }

        internal async static Task<string> GetFilteredManifestAppAttributeValue(string node, string attribute, string prefix)
        {


            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///VKConfig.xml"));
            using (Stream strm = await file.OpenStreamForReadAsync())

            {
                var xml = XElement.Load(strm);
                var filteredAttributeValue = (from app in xml.Descendants(node)
                                              let xAttribute = app.Attribute(attribute)
                                              where xAttribute != null
                                              select xAttribute.Value).FirstOrDefault(a => a.StartsWith(prefix));

                if (string.IsNullOrWhiteSpace(filteredAttributeValue))
                {
                    return string.Empty;
                }

                return filteredAttributeValue;
            }
        }
    }
}
