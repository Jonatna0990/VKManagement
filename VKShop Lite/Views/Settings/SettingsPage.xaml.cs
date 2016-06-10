using System.Diagnostics;
using Windows.Networking.PushNotifications;
using Windows.Security.Cryptography;
using Windows.System.Profile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using VKCore.Helpers;
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

        public static string GetDeviceId()
        {
           
            return CryptographicBuffer.EncodeToBase64String(HardwareIdentification.GetPackageSpecificToken(null).Id);
          
        }
       /* private async void ChannelCreate_OnClick(object sender, RoutedEventArgs e)
        {
            string path =
                "Endpoint=sb://vkgm-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=6ANU0bwZMtD0dqxc28NSIF27/3Amh01ZnaKu7HH7Gyg=";
            string path1 =
                "Endpoint=sb://vkgm-ns.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=c/S8B2Pjj+knkplIqRTL8dNSm2ChGGgpcg36a3RU4wE=";
            PushNotificationChannel channel = null;
              channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
             channel.PushNotificationReceived += Channel_PushNotificationReceived;

            try
            {
                
         
                var hub = new NotificationHub("vkmanagenemtpush", path1);

                var result = await hub.RegisterNativeAsync(channel.Uri);
                HardwareToken token = HardwareIdentification.GetPackageSpecificToken(null);
                IBuffer hardwareId = token.Id;
                HashAlgorithmProvider hasher = HashAlgorithmProvider.OpenAlgorithm("MD5");
                IBuffer hashed = hasher.HashData(hardwareId);
                string hashedString = CryptographicBuffer.EncodeToHexString(hashed);
                // Displays the registration ID so you know it was successful
                if (result.RegistrationId != null && !string.IsNullOrEmpty(hashedString))
                {
                    VKRequest.Dispatch<int>(
                      new VKRequestParameters(
                        SAccount.account_registerDevice, "token", result.ChannelUri, "device_id", DeviceInfo.Instance.Id),
                      (res) =>
                      {
                          var q = res.ResultCode;
                          if (res.ResultCode == VKResultCode.Succeeded)
                          {
                              var a = res;
                          }
                      });

               Debug.WriteLine(GetDeviceId());

                }

            }

            catch (Exception ex)
            {
                 
            }

        }
        */
    
    }
 }
