using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.Storage;
using Windows.System.UserProfile;
using Windows.UI.Xaml;
using VKCore.API.Core;
using VKCore.UserControls;
using VKCore.Util;

namespace VKCore.API.SDK
{
    public class VKSDK
    {
        public const String SDK_VERSION = "1.0.0";
        public const String API_VERSION = "5.45";

        private static readonly string PLATFORM_ID = "winphone";


        private static VKSDK _instance;

        /// <summary>
        /// SDK instance
        /// </summary>
        internal static VKSDK Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VKSDK();
                }
                return _instance;
            }

        }

        /// <summary>
        /// Access token for API-requests
        /// </summary>
        protected VKAccessToken AccessToken;
        

        /// <summary>
        /// Default SDK access token key for storing value in IsolatedStorage.
        /// You shouldn't modify this key or value directly in IsolatedStorage.
        /// </summary>
        private const String VKSDK_ACCESS_TOKEN_ISOLATEDSTORAGE_KEY = "VKSDK_ACCESS_TOKEN_DONTTOUCH";
        internal static readonly string VK_AUTH_STR_FRM = "https://oauth.vk.com/authorize?client_id={0}&scope={1}&redirect_uri={2}&display=mobile&v={3}&response_type=token&revoke={4}";

        /// <summary>
        /// Your VK app ID. 
        /// If you don't have one, create a standalone app here: https://vk.com/editapp?act=create 
        /// </summary>
        internal String CurrentAppID;

        internal static string DeviceId
        {
            get
            {
                return AdvertisingManager.AdvertisingId;

            }
        }

        /// <summary>
        /// Initialize SDK
        /// </summary>
        /// <param name="appId">Your VK app ID. 
        /// If you don't have one, create a standalone app here: https://vk.com/editapp?act=create </param>
        public static void Initialize(String appId)
        {
            Logger = new DefaultLogger();

            if (String.IsNullOrEmpty(appId))
            {
                throw new Exception("VKSDK could not initialize. " +
                                    "Application ID cannot be null or empty. " +
                                    "If you don't have one, create a standalone app here: https://vk.com/editapp?act=create");
            }





            Instance.CurrentAppID = appId;
        }

        /// <summary>
        /// Initialize SDK with custom token key (e.g. saved from other source or for some test reasons)
        /// </summary>
        /// <param name="appId">Your VK app ID. 
        /// If you don't have one, create a standalone app here: https://vk.com/editapp?act=create </param>
        /// <param name="token">Custom-created access token</param>
        public static void Initialize(String appId, VKAccessToken token)
        {
            Initialize(appId);
            Instance.AccessToken = token;
            Instance.PerformTokenCheck(token, true);
        }

        public static Action<VKCaptchaUserRequest, Action<VKCaptchaUserResponse>> CaptchaRequest { private get; set; }

        //    public static Action<ValidationUserRequest, Action<ValidationUserResponse>> ValidationRequest { private get; set; }



        /// <summary>
        /// Invokes when existing token has expired
        /// </summary>
        public static event EventHandler<VKAccessTokenExpiredEventArgs> AccessTokenExpired = delegate { };

        /// <summary>
        /// Invokes when user authorization has been canceled
        /// </summary>
        public static event EventHandler<VKAccessDeniedEventArgs> AccessDenied = delegate { };

        /// <summary>
        /// Invokes when new access token has been received
        /// </summary>
        public static event EventHandler<VKAccessTokenReceivedEventArgs> AccessTokenReceived = delegate { };

        /// <summary>
        /// Invokes when predefined token has been received and accepted
        /// </summary>
        public static event EventHandler<VKAccessTokenAcceptedEventArgs> AccessTokenAccepted = delegate { };

        /// <summary>
        /// Invokes when access token has been renewed (e.g. user passed validation)
        /// </summary>
        public static event EventHandler<AccessTokenRenewedEventArgs> AccessTokenRenewed = delegate { };

        /// <summary>
        /// Invoked if current app installation is the installation from the VK mobile games catalog
        /// </summary>
        public static event EventHandler MobileCatalogInstallationDetected = delegate { };

        public static IVKLogger Logger;

        /// <summary>
        /// Starts authorization process. Opens and requests for access if VK App is installed. 
        /// Otherwise SDK will navigate current app to SDK navigation page and start OAuth in WebBrowser.
        /// </summary>
        /// <param name="scopeList">List of permissions for your app</param>
        /// <param name="revoke">If true user will be allowed to logout and change user</param>
        /// <param name="forceOAuth">SDK will use only OAuth authorization via WebBrowser</param>
        public static void Authorize(List<String> scopeList, bool revoke = false, bool forceOAuth = false,
            LoginType loginType = LoginType.WebView)
        {
            try
            {
                CheckConditions();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return;
            }

            if (scopeList == null)
                scopeList = new List<string>();

            // Force OFFLINE scope using
            if (!scopeList.Contains(VKScope.OFFLINE))
                scopeList.Add(VKScope.OFFLINE);


            switch (loginType)
            {
                case LoginType.VKApp:
           
                    break;
                default:

                    var loginUserControl = new VKLoginUserControl();

                    loginUserControl.Scopes = scopeList;
                    loginUserControl.Revoke = revoke;

                    loginUserControl.ShowInPopup(Window.Current.Bounds.Width,
                         Window.Current.Bounds.Height);

                    break;
            }


        }



        /// <summary>
        /// Starts authorization process. Opens and requests for access if VK App is installed. 
        /// Otherwise SDK will navigate current app to SDK navigation page and start OAuth in WebBrowser.
        /// </summary>
        /// <param name="scopeList">List of permissions for your app</param>
        /// <param name="revoke">If true user will be allowed to logout and change user</param>
        /// <param name="forceOAuth">SDK will use only OAuth authorization via WebBrowser</param>
        public static void AuthorizeAdminMessages(string group_ids)
        {
            List<String> scopeList = new List<string>() {"messages","docs", "photos"};
            try
            {
                CheckConditions();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return;
            }
            var loginUserControl = new VKGetMessagesToken();
            loginUserControl.Scopes = scopeList;
            loginUserControl.GroupsIds = group_ids;
            loginUserControl.ShowInPopup(Window.Current.Bounds.Width, Window.Current.Bounds.Height);
            
        }

        private static void AuthorizeVKApp(List<string> scopeList, bool revoke)
        {
            VKAppLaunchAuthorizationHelper.AuthorizeVKApp("", Instance.CurrentAppID, scopeList, revoke);
        }


        private enum CheckTokenResult
        {
            None,
            Success,
            Error
        };

        private static void CheckConditions()
        {

        }



        /// <summary>
        /// Check new access token and assign as instance token 
        /// </summary>
        /// <param name="tokenParams">Params of token</param>
        /// <param name="isTokenBeingRenewed">Flag indicating token renewal</param>
        /// <returns>Success if token has been assigned or error</returns>
        private static CheckTokenResult CheckAndSetToken(Dictionary<String, String> tokenParams, bool isTokenBeingRenewed)
        {
            var token = VKAccessToken.TokenFromParameters(tokenParams);
            if (token == null || token.AccessToken == null)
            {
                if (tokenParams.ContainsKey(VKAccessToken.SUCCESS))
                    return CheckTokenResult.Success;

                var error = new VKError { error_code = (int)VKResultCode.UserAuthorizationFailed };

                return CheckTokenResult.Error;
            }
            else
            {
                SetAccessToken(token, isTokenBeingRenewed);
                return CheckTokenResult.Success;
            }


        }

        /// <summary>
        /// Save API access token in IsolatedStorage with default key.
        /// </summary>
        /// <param name="token">Access token to be used for API requests</param>
        /// <param name="renew">Is token being renewed. Raises different event handlers (AccessTokenReceived or AccessTokenRenewed)</param>
        public static void SetAccessToken(VKAccessToken token, bool renew = false)
        {
            if (Instance.AccessToken == null ||
                (Instance.AccessToken.AccessToken != token.AccessToken ||
                 Instance.AccessToken.ExpiresIn != token.ExpiresIn))
            {
                Instance.AccessToken = token;

                if (!renew)
                    AccessTokenReceived(null, new VKAccessTokenReceivedEventArgs { NewToken = token });
                else
                    AccessTokenRenewed(null, new AccessTokenRenewedEventArgs { Token = token });

                Instance.AccessToken.SaveTokenToIsolatedStorage(VKSDK_ACCESS_TOKEN_ISOLATEDSTORAGE_KEY);
            }
        }
        public static void SetAccessTokenForMessages(VKAccessToken token, string group_id)
        {
            ApplicationData.Current.LocalSettings.Values[group_id] = token.AccessToken;
        }

        /// <summary>
        /// Get access token to be used for API requests.
        /// </summary>
        /// <returns>Received access token, null if user has not been authorized yet</returns>
        public static VKAccessToken GetAccessToken()
        {
            if (Instance.AccessToken != null)
            {
                if (Instance.AccessToken.IsExpired)
                    AccessTokenExpired(null, new VKAccessTokenExpiredEventArgs { ExpiredToken = Instance.AccessToken });

                return Instance.AccessToken;
            }

            return null;
        }

        public static VKAccessToken GetAccessTokenForMessages(string group_id)
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(group_id))
            {
                return null;
            }
            String tokenString = ApplicationData.Current.LocalSettings.Values[group_id].ToString();
            return new VKAccessToken() {AccessToken = tokenString};
            
        }

        public static int GetGroupId(string token)
        {
            int temp = 0;
            if (!ApplicationData.Current.LocalSettings.Values.Values.Contains(token))
            {
                return temp;
            }
            foreach (var a in ApplicationData.Current.LocalSettings.Values)
            {
                if (a.Value == token)
                {
                    temp = Convert.ToInt32(a.Key);
                }
            }
            return temp;

        }
        public static bool IsHasToken(string group_id)
        {
            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey(group_id))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Notify SDK that user denied login
        /// </summary>
        /// <param name="error">Description of error while authorizing user</param>
        public static void SetAccessTokenError(VKError error)
        {
            AccessDenied(null, new VKAccessDeniedEventArgs { AuthorizationError = error });
        }

        private bool PerformTokenCheck(VKAccessToken token, bool isUserDefinedToken = false)
        {
            if (token == null) return false;

            if (token.IsExpired)
            {
                AccessTokenExpired(null, new VKAccessTokenExpiredEventArgs { ExpiredToken = token });
                return false;
            }
            if (token.AccessToken != null)
            {
                if (isUserDefinedToken)
                    AccessTokenAccepted(null, new VKAccessTokenAcceptedEventArgs { Token = token });
                return true;
            }

            var error = new VKError { error_code = (int)VKResultCode.InvalidToken };
            AccessDenied(null, new VKAccessDeniedEventArgs { AuthorizationError = error });
            return false;
        }

        public static bool WakeUpSession()
        {
            bool result = true;

            var token = VKAccessToken.TokenFromIsolatedStorage(VKSDK_ACCESS_TOKEN_ISOLATEDSTORAGE_KEY);

            if (!Instance.PerformTokenCheck(token))
            {
                result = false;
            }
            else
            {
                Instance.AccessToken = token;
            }
            

            return result;
        }

    



        /// <summary>
        /// Removes active token from memory and IsolatedStorage at default key.
        /// </summary>
        public static void Logout()
        {
            Instance.AccessToken = null;

            VKAccessToken.RemoveTokenInIsolatedStorage(VKSDK_ACCESS_TOKEN_ISOLATEDSTORAGE_KEY);

            VKUtil.ClearCookies();
        }

        public static bool IsLoggedIn
        {
            get { return Instance.AccessToken != null && !Instance.AccessToken.IsExpired; }
        }


        internal static void ProcessLoginResult(string result, bool wasValidating, Action<VKValidationResponse> validationCallback)
        {
            bool success = false;

            if (result == null)
            {
                SetAccessTokenError(new VKError { error_code = (int)VKResultCode.UserAuthorizationFailed });
            }
            else
            {
                var tokenParams = VKUtil.ExplodeQueryString(result);
                if (CheckAndSetToken(tokenParams, wasValidating) == CheckTokenResult.Success)
                {
                    success = true;

                    
                }
                else
                {
                    SetAccessTokenError(new VKError { error_code = (int)VKResultCode.UserAuthorizationFailed });
                }                
            }

            if (validationCallback != null)
            {
                validationCallback(new VKValidationResponse { IsSucceeded = success });
            }
        }
        internal static void ProcessLoginResultForMessaging(string result, bool wasValidating, Action<VKValidationResponse> validationCallback)
        {
            bool success = false;

            if (result == null)
            {
                SetAccessTokenError(new VKError { error_code = (int)VKResultCode.UserAuthorizationFailed });
            }
            else
            {
                var tokenParams = VKUtil.ExplodeQueryString(result);
                if (!result.Contains(@"{""error"":{"))
                {
                    success = true;
                    foreach (var t in tokenParams)
                    {
                        if (t.Key.Contains("access_token_"))
                        {
                            var a = GetGroupIdFromString(t.Key);
                            SetAccessTokenForMessages(new VKAccessToken() { AccessToken = t.Value}, a );
                            
                        }
                        
                        // SetAccessTokenForMessages(t.Value, t.Key);
                    }
                }
                else
                {
                    SetAccessTokenError(new VKError { error_code = (int)VKResultCode.UserAuthorizationFailed });
                }
            }

            if (validationCallback != null)
            {
                validationCallback(new VKValidationResponse { IsSucceeded = success });
            }
        }

        private static string GetGroupIdFromString(string param)
        {
            if (string.IsNullOrEmpty(param)) return "";
            int len = param.Length-13;
            int ind = param.LastIndexOf("_")+1;
            return param.Substring(ind, len);
        }
        internal static void InvokeCaptchaRequest(VKCaptchaUserRequest request, Action<VKCaptchaUserResponse> callback)
        {
            if (CaptchaRequest == null)
            {
                // no handlers are registered

                callback(
                    new VKCaptchaUserResponse()
                    {
                        Request = request,
                        EnteredString = string.Empty,
                        IsCancelled = true
                    });
            }
            else
            {
                VKExecute.ExecuteOnUIThread(() =>
                {
                    CaptchaRequest(request,
                                   callback);
                });
            }
        }

        internal static void InvokeValidationRequest(VKValidationRequest request, Action<VKValidationResponse> callback)
        {
            VKExecute.ExecuteOnUIThread(() =>
                {

                    var loginUserControl = new VKLoginUserControl();

                    loginUserControl.ValidationUri = request.ValidationUri;
                    loginUserControl.ValidationCallback = callback;

                    loginUserControl.ShowInPopup(Window.Current.Bounds.Width,
                         Window.Current.Bounds.Height); 

                });

        }
    }
}
