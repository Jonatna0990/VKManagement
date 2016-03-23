using System;
using System.Diagnostics;
using Windows.Networking.PushNotifications;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using Microsoft.QueryStringDotNET;
using NotificationsExtensions.Toasts;
using VKShop_Lite.UserControls.MessagesControl.Emoji;
using VKShop_Lite.ViewModels.Settings;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace VKShop_Lite.Views.Settings
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }
        //SettingsViewModel

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.DataContext = new SettingsViewModel();
        }

        private async void GetID()
        {
            var deviceInformation = new EasClientDeviceInformation();
            string Id = deviceInformation.Id.ToString();
            Debug.WriteLine(Id);

            PushNotificationChannel channel = null;

            channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
        }
        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        { GetID();
            /*


            string title = "Andrew sent you a picture";
            string content = "Check this out, Happy Canyon in Utah!";
            string image = "http://blogs.msdn.com/cfs-filesystemfile.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-01-71-81-permanent/2727.happycanyon1_5B00_1_5D00_.jpg";
            string logo = "ms-appdata:///local/Andrew.jpg";
            int conversationId = 384928;

            // Construct the visuals of the toast
            ToastVisual visual = new ToastVisual()
            {
                TitleText = new ToastText()
                {
                    Text = title
                },

                BodyTextLine1 = new ToastText()
                {
                    Text = content
                },

                InlineImages =
                {
                    new ToastImage()
                    {
                        Source = new ToastImageSource(image)
                    },
                    new ToastImage()
                    {
                        Source = new ToastImageSource(image)
                    }
                },

                AppLogoOverride = new ToastAppLogo()
                {
                    Source = new ToastImageSource(logo),
                    Crop = ToastImageCrop.Circle
                }
            };

            // Construct the actions for the toast (inputs and buttons)
            ToastActionsCustom actions = new ToastActionsCustom()
            {
                Inputs =
                {
                    new ToastTextBox("tbReply")
                    {
                        PlaceholderContent = "Type a response"
                    }
                },

                Buttons =
                {
                    new ToastButton("Reply", new QueryString()
                    {
                        { "action", "reply" },
                        { "conversationId", conversationId.ToString() }

                    }.ToString())
                    {
                        ActivationType = ToastActivationType.Background,
                        ImageUri = "Assets/Reply.png",

                        // Reference the text box's ID in order to
                        // place this button next to the text box
                        TextBoxId = "tbReply"
                    },

                    new ToastButton("Like", new QueryString()
                    {
                        { "action", "like" },
                        { "conversationId", conversationId.ToString() }

                    }.ToString())
                    {
                        ActivationType = ToastActivationType.Background
                    },

                    new ToastButton("View", new QueryString()
                    {
                        { "action", "viewImage" },
                        { "imageUrl", image }

                    }.ToString())
                }
            };


            // Now we can construct the final toast content
            ToastContent toastContent = new ToastContent()
            {
                Visual = visual,
                Actions = actions,

                // Arguments when the user taps body of toast
                Launch = new QueryString()
                {
                    { "action", "viewConversation" },
                    { "conversationId", conversationId.ToString() }

                }.ToString()
            };


            // And create the toast notification
            ToastNotification notification = new ToastNotification(toastContent.GetXml());


            // And then send the toast
            ToastNotificationManager.CreateToastNotifier().Show(notification);*/
        }
    }
}
