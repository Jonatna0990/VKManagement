﻿using System;
using System.Collections.Generic;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.Util;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKCore.UserControls
{
    public sealed partial class VKLoginUserControl
    {
        private const String REDIRECT_URL = "https://oauth.vk.com/blank.html";
        private List<string> _scopes;
        private bool _revoke;
        private Popup _parentPopup;
        private Action<VKValidationResponse> _validationCallback;
        private bool _isValidating = false;
        private bool _processedResult = false;
        private string _validationUri;

        private static VKLoginUserControl _currentlyShownInstance;

        public string ValidationUri
        {
            get
            {
                return _validationUri;
            }
            set
            {
                _validationUri = value;
                _isValidating = _validationUri != null;
            }
        }

        internal Action<VKValidationResponse> ValidationCallback
        {
            get
            {
                return _validationCallback;
            }
            set
            {
                _validationCallback = value;
            }
        }

        public static VKLoginUserControl CurrentlyShownInstance
        {
            get
            {
                return _currentlyShownInstance;
            }
        }


        public List<string> Scopes
        {
            get
            {
                return _scopes;
            }
            set
            {
                _scopes = value;
            }
        }

        public bool Revoke
        {
            get
            {
                return _revoke;
            }
            set
            {
                _revoke = value;
            }
        }

        public VKLoginUserControl()
        {


            this.InitializeComponent();
            var str = Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily;
            if (str == "Windows.Mobile")
            {
                var bar = StatusBar.GetForCurrentView();
                bar.HideAsync();
            }

        }

        protected override void PrepareForLoad()
        {
            InitializeWebBrowser();
        }

        private void InitializeWebBrowser()
        {
            var urlToLoad = _validationUri ??
            string.Format(
               "https://oauth.vk.com/authorize?" +
               "client_id={0}&" +
               "scope={1}&" +
               "redirect_uri={2}&" +
               "display=mobile&" +
               "v={3}&" +
               "response_type=token&" +
               "revoke={4}",
               VKSDK.Instance.CurrentAppID, _scopes.GetCommaSeparated(), REDIRECT_URL, VKSDK.API_VERSION, _revoke ? 1 : 0);

            webView.NavigationStarting += BrowserOnNavigating;
            webView.NavigationCompleted += BrowserOnLoadCompleted;

            webView.Navigate(new Uri(urlToLoad));
        }

        private void BrowserOnLoadCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (!args.IsSuccess)
            {
                progressBar.Visibility = Visibility.Collapsed;
                errorTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                webView.NavigationCompleted -= BrowserOnLoadCompleted;
                webView.Visibility = Visibility.Visible;
                progressBar.Visibility = Visibility.Collapsed;
            }
        }

        private void BrowserOnNavigating(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            var url = args.Uri.AbsoluteUri;
            if (url.StartsWith(REDIRECT_URL) && !_processedResult)
            {
                var result = url.Substring(url.IndexOf('#') + 1);

                _processedResult = true;
                VKSDK.ProcessLoginResult(result, _isValidating, _validationCallback);
                this.IsShown = false;
            }
        }

        protected override void OnClosing()
        {
            base.OnClosing();
            if (!_processedResult)
            {
                VKSDK.ProcessLoginResult(null, _isValidating, _validationCallback);
            }
        }
    }
}
