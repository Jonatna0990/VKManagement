using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.System.Profile;
using Windows.UI.Xaml.Controls;

namespace VKCore.Helpers
{
    public enum DeviceType 
    {
        Mobile,
        Desktop,
        Xbox,
        Unknow
    }
    public static class DeviceInfoHelper
    {
        public static DeviceType GetDeviceType()
        {
            DeviceType type = DeviceType.Unknow;
            var str = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
            switch (str)
            {
                case "Windows.Mobile":
                    type = DeviceType.Mobile;
                    break;
                case "Windows.Desktop":
                    type = DeviceType.Desktop;
                    break;
                case "Windows.Xbox":
                    type = DeviceType.Xbox;
                    break;
                default:
                    break;
            }
           

            return type;
        }

    
        public static string GetDeviceId()
        {
            return CryptographicBuffer.EncodeToBase64String(HardwareIdentification.GetPackageSpecificToken(null).Id);
        }

        public static async Task<string> GetOSVersion()
        {
            TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
            WebView webView = new WebView();
            webView.NavigationCompleted += (async (sender, e) => {
                try
                {
                    string str = "";
                    string str1 = await webView.InvokeScriptAsync("GetUserAgent", null);
                    int num = str1.ToLower().IndexOf("windows");
                    if (num > 0)
                    {
                        int num1 = str1.IndexOf(";", num);
                        if (num1 > num)
                        {
                            str = str1.Substring(num, num1 - num);
                        }
                    }
                    taskCompletionSource.TrySetResult(str);
                    str = null;
                }
                catch (Exception exception)
                {
                    taskCompletionSource.TrySetException(exception);
                }
            });
            
            webView.NavigateToString("<html><head><script type='text/javascript'>function GetUserAgent(){return navigator.userAgent;}</script></head></html>");
            return await taskCompletionSource.Task;
        }
 
    }
}
