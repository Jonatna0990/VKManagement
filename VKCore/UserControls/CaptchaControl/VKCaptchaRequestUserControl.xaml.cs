﻿using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using VKCore.API.Core;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace VKCore.UserControls.CaptchaControl
{
    public sealed partial class VKCaptchaRequestUserControl
    {
        private VKCaptchaUserRequest _captchaUserRequest;
        private Action<VKCaptchaUserResponse> _callback;


        public VKCaptchaRequestUserControl()
        {
            this.InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ValidateCaptcha();
        }

        private void ValidateCaptcha()
        {
            _callback.Invoke(new VKCaptchaUserResponse()
            {
                EnteredString = textBoxCaptcha.Text,
                IsCancelled = false,
                Request = _captchaUserRequest
            });
            Visibility = Visibility.Collapsed;
        }

        public void ShowCaptchaRequest(VKCaptchaUserRequest captchaUserRequest, Action<VKCaptchaUserResponse> callback)
        {

            textBoxCaptcha.Text = string.Empty;
            imageCaptcha.Source = new BitmapImage(new Uri(captchaUserRequest.Url));
            _captchaUserRequest = captchaUserRequest;
            _callback = callback;
            ShowInPopup(Window.Current.Bounds.Width, Window.Current.Bounds.Height);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _callback.Invoke(new VKCaptchaUserResponse()
            {
                IsCancelled = true,
                Request = _captchaUserRequest
            });

            Visibility = Visibility.Collapsed;
        }

        private void textBoxCaptcha_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                ValidateCaptcha();
        }

    }
}
