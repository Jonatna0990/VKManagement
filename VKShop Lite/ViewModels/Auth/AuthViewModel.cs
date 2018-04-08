using System;
using System.Collections.Generic;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using VKCore.API.Core;
using VKCore.API.SDK;
using VKCore.UserControls.CaptchaControl;
using VKShop_Lite.Common;
using VKShop_Lite.ViewModels.Base;
using VKShop_Lite.Views.Main;

namespace VKShop_Lite.ViewModels.Auth
{
    public class AuthViewModel : BaseViewModel
    {
        private Visibility _contentVisibility;

        public Visibility ContentVisibility
        {
            get { return _contentVisibility; }
            set { _contentVisibility = value; RaisePropertyChanged("ContentVisibility"); }
        }

        public AuthViewModel( )
        {
            VKSDK.Initialize(APISettings.app_id);
            VKSDK.AccessTokenReceived += (sender, args) =>
            {
                UpdateUIState();
            };
            VKSDK.WakeUpSession();
            VKSDK.CaptchaRequest = CaptchaRequest;
            UpdateUIState();
            ButtonClickCommand = new DelegateCommand(s =>
            {
                //143572991 
                List<String> _scope = VKScope.ParseVKPermissionsFromInteger(135213086);
                ContentVisibility = Visibility.Collapsed;
                VKSDK.Authorize(_scope, false, false);
            });
        }
        private void CaptchaRequest(VKCaptchaUserRequest captchaUserRequest, Action<VKCaptchaUserResponse> action)
        {
            new VKCaptchaRequestUserControl().ShowCaptchaRequest(captchaUserRequest, action);
        }
        private void UpdateUIState()
        {
            bool isLoggedIn = VKSDK.IsLoggedIn;

            if (isLoggedIn)
            {
                Frame scenarioFrame = Window.Current.Content as Frame;
                Scenario s = new Scenario { ClassType = typeof(UserMainPage) };
                if (scenarioFrame != null) scenarioFrame.Navigate(s.ClassType);
            }

        }
        public ICommand ButtonClickCommand { get; private set; }
      
    }
}

