using System;
using System.Collections.Generic;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Microsoft.QueryStringDotNET;
using NotificationsExtensions.Toasts;
using VKShop_Lite.UserControls.PopupControl;

namespace VKShop_Lite.Helpers
{
    public class MessagesHelper
    {
        public static async void ShowMessage(string title, string content)
        {
            PopupEx popup = new PopupEx(title, content);
            await popup.ShowAsync();
        }

         public static async void ShowDialogMessage( string title, string content, Dictionary<string,Action> comandActions)
         {
             if (comandActions != null)
            {
                var dialog = new MessageDialog(content, title);

                foreach (var t in comandActions)
                {
                    dialog.Commands.Add(new UICommand(t.Key) { Id = t.Key });

                }
                var result = await dialog.ShowAsync();
                string selectedCommand = result.Id.ToString();
                if (!string.IsNullOrEmpty(selectedCommand))
                {
                    comandActions[selectedCommand]?.Invoke();

                }


            }
           
         }

         public static void SendToastNotification()
        {

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
            ToastNotificationManager.CreateToastNotifier().Show(notification);
        }
    }
}
