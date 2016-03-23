using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VKCore.API.Core;
using VKCore.API.SDK;

namespace VKCore.API.VKModels.LongPollServer
{
    public sealed class LongPollService
    {


        public delegate void MessageHandler(object sender, LongPollMessageEventArgs e);
        public delegate void UserStatusHandler(object sender, LongPollUserStatusEventArgs e);
        public delegate void MessageChatHandler(object sender, LongPollMessageChatEventArgs e);
        public delegate void MessageFlagsHandler(object sender, LongPollMessageFlagsEventArgs e);
        public delegate void MessageDeleteHandler(object sender, LongPollDeleteMessageEventArgs e);
        public delegate void UserHandler(object sender, LongPollUserEventArgs e);
        public delegate void ChatUpdate(object sender, LongPollChatChangeEventArgs e);
        /// <summary>
        /// Событие вызывается тогда, когда пользователь прочитал сообщение(я)
        /// </summary>
        public event MessageHandler ReadMessage;
        /// <summary>
        /// Событие вызывается тогда, когда произошла замена флагов сообщения
        /// </summary>
        public event MessageFlagsHandler MessageUpdate;
        /// <summary>
        /// Событие вызывается тогда, когда произошла установка флагов сообщения
        /// </summary>
        public event MessageFlagsHandler MessageFlagSet;
        /// <summary>
        /// Событие вызывается тогда, когда произошёл сброс флагов сообщения
        /// </summary>
        public event MessageFlagsHandler MessageFlagReset;
        /// <summary>
        /// Событие вызывается тогда, когда пользователь добавил новое сообщение
        /// </summary>
        public event MessageHandler AddNewMessage;
        /// <summary>
        /// Событие вызывается тогда, когда пользователь начал набирать сообщение в беседе
        /// </summary>
        public event UserHandler WriteNewMessageChat;
        /// <summary>
        /// Событие вызывается тогда, когда пользователь добавил новое сообщение в беседу
        /// </summary>
        public event MessageChatHandler AddNewMessageChat;
        /// <summary>
        ///  Событие вызывается тогда, один из параметров (состав, тема)беседы $chat_id были изменены.
        ///  $self - были ли изменения вызваны самим пользователем
        /// </summary>
        public event ChatUpdate ChatChange;
        /// <summary>
        /// Событие вызывается тогда, когда пользователь удалил сообщение(я)
        /// </summary>
        public event MessageDeleteHandler DeleteMessage;
        /// <summary>
        /// Событие вызывается тогда, когда пользователь начал набирать сообщение
        /// </summary>
        public event UserHandler WriteMessage;
        /// <summary>
        /// Событие вызывается тогда, когда пользователь начал набирать сообщение
        /// </summary>
        public event UserHandler StopWriteMessage;
        /// <summary>
        /// Событие вызывается тогда, когда пользователь вышел из сети
        /// </summary>
        public event UserStatusHandler MakeOffline;
        /// <summary>
        /// Событие вызывается тогда, когда пользователь стал онлайн
        /// </summary>
        public event UserStatusHandler MakeOnline;


        private bool IsStopPooling { get; set; }


        private static LongPollService instance;
        private static LongPollService group_instance;
        private static object _lock = new object();
        private static object group_lock = new object();
        public static LongPollService Instatce
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null) instance = new LongPollService();
                    }
                }
                return instance;
            }
        }
        public static LongPollService GroupInstatce(long group_id)
        {
               
                if (group_instance == null)
                {
                    lock (group_lock)
                    {
                        if (group_instance == null) group_instance = new LongPollService(group_id) ;
                    }
                }
                return group_instance;
            
        }
        private LongPollService(long group_id=0)
        {

             if(!IsStopPooling)
            LongPollServerConnect(group_id);
        }


        public static bool IsInternet()
        {
            bool internet = false;
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            if (connections != null)
            {
                if(connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess) internet = true;
                else if (connections.IsWlanConnectionProfile) internet = true;
                else if (connections.IsWwanConnectionProfile) internet = true;
            }
            else internet = false;
          
            return internet;
        }
        public async Task<JObject> Execute(string uri)
        {
            if (!IsInternet())
                return null;
            Debug.WriteLine("Invoking " + uri);
            JObject response = null;
            var httpClient = new HttpClient();
            HttpResponseMessage responseMessage = await httpClient.GetAsync(uri);
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(content))
                response = JObject.Parse(content);
            return response;
        }

        private async void LongPollServerConnect(long group_id = 0)
        {
            string token = "";
            if (group_id != 0) token = VKSDK.GetAccessTokenForMessages(group_id.ToString()).AccessToken;
            else token = VKSDK.GetAccessToken().AccessToken;


            JObject o = await Execute(string.Format("{0}{1}?access_token={2}", APISettings.APIURL, SMessages.messages_getLongPollServer, token));
            
            if (o == null) return;
            JObject main_item = o["response"] as JObject;
            if (main_item != null)
            {
                var t = JsonConvert.DeserializeObject<LongPollServerClass>(main_item.ToString());
                await StartPolling(t);
            }
        }

        private string temp = "";

        public async Task StartPolling(LongPollServerClass server)
        {

            try
            {
                var resp = await Execute(string.Format("http://{0}?act=a_check&key={1}&ts={2}&wait=25&mode=106&version=1",
                                server.server, server.key, server.ts));


                LongPollServerClass respons = resp.ToObject<LongPollServerClass>();
                //Время действия ключа для подключения к LongPoll серверу истекло
                if (respons.failed != 0)
                {
                    //Есть ли в ответе данные, необходимые для переподключения LongPollServer
                    if (respons.ts != 0)
                    {
                        await StartPolling(new LongPollServerClass() { server = server.server, key = server.key, ts = respons.ts });
                    }
                    else
                    {
                        LongPollServerConnect();
                    }

                }
                //Нет ошибок можно проверить содержимое сообщений
                else
                {

                    if (respons.updates != null && respons.updates.Count != 0)
                    {
                        foreach (JArray t in respons.updates)
                        {
                            try
                            {
                                FromJson(t, server);
                            }
                            catch (Exception ex)
                            {

                                Debug.WriteLine("Error: " + ex.Message + " " + ex.Source);
                            }

                        }

                    }
                    else
                    {

                    }
                    if (!IsStopPooling) await StartPolling(new LongPollServerClass() { server = server.server, key = server.key, ts = respons.ts });


                }


            }
            catch (Exception ex)
            {
                var r = ex;
            }


        }
        private const int ChatIdMask = 2000000000;
        public void FromJson(JArray json, LongPollServerClass sender)
        {

            var messageType = json[0].Value<int>();

            switch (messageType)
            {
                //удаление сообщения с указанным local_id
                case 0:
                    DeleteMessage?.Invoke(sender, new LongPollDeleteMessageEventArgs(json[1].Value<Int32>()));
                    break;

                //замена флагов сообщения
                case 1:
                    MessageUpdate?.Invoke(sender, new LongPollMessageFlagsEventArgs(json[1].Value<Int32>(), json[2].Value<Int32>()));
                    break;

                //установка флагов сообщения
                case 2:
                    MessageFlagSet?.Invoke(sender, new LongPollMessageFlagsEventArgs(json[1].Value<Int32>(), json[2].Value<Int32>(), (json.Count > 2) ? json[3].Value<Int32>() : 0));
                    break;

                //сброс флагов сообщения
                case 3:
                    MessageFlagReset?.Invoke(sender, new LongPollMessageFlagsEventArgs(json[1].Value<Int32>(), json[2].Value<Int32>(), (json.Count > 2) ? json[3].Value<Int32>() : 0));
                    break;

                //добавление нового сообщения
                case 4:
                    //сообщение в чат
                    if (json[3].Value<long>() > ChatIdMask)
                    {
                        AddNewMessageChat?.Invoke(sender, new LongPollMessageChatEventArgs(json[1].Value<Int32>(), json[2].Value<int>(), json[3].Value<Int64>(), json[4].Value<Int64>(), json[5].Value<string>(), json[6].Value<string>()));

                    }
                    //обычное соообщение
                    else
                    {
                        AddNewMessage?.Invoke(sender, new LongPollMessageEventArgs(json[1].Value<Int32>(), json[2].Value<int>(), json[3].Value<Int64>(), json[4].Value<Int64>(), json[5].Value<string>(), json[6].Value<string>()));

                    }
                    //TODO forwards & attachments
                    break;
                //прочтение сообщения
                case 6:
                case 7:
                    ReadMessage?.Invoke(sender, new LongPollMessageEventArgs(json[2].Value<Int32>()));
                    break;
                //друг стал онлайн
                case 8:
                    MakeOnline?.Invoke(sender, new LongPollUserStatusEventArgs(Math.Abs(json[1].Value<Int32>()), json[2].Value<Int32>()));
                    break;

                //друг стал оффлайн
                case 9:
                    MakeOffline?.Invoke(sender, new LongPollUserStatusEventArgs(Math.Abs(json[1].Value<Int32>()), 0, json[2].Value<Int32>()));
                    break;

                //один из параметров (состав, тема) беседы был изменен
                case 51:
                    ChatChange?.Invoke(sender, new LongPollChatChangeEventArgs(json[1].Value<Int32>(), json[2].Value<Int32>()));
                    break;
                //пользователь начал набирать текст в диалоге
                case 61:
                    {
                        WriteMessage?.Invoke(sender, new LongPollUserEventArgs(Math.Abs(json[1].Value<Int32>())));

                    }
                    break;
                //пользователь начал набирать текст в беседе
                case 62:
                    WriteNewMessageChat?.Invoke(sender, new LongPollUserEventArgs(json[1].Value<Int32>(), json[2].Value<Int32>()));
                    break;
                //новый счетчик непрочитанных в левом меню
                case 80:
                    {
                        var t = json;
                    }
                    break;
                //изменились настройки оповещений, где peerId — $peer_id чата/собеседника, sound — 1 || 0, включены/выключены звуковые оповещения, 
                //disabled_until — выключение оповещений на необходимый срок (-1: навсегда, 0: включены, other: timestamp, когда нужно включить).
                case 114:
                    {
                        var t = json;
                    }
                    break;
                default:
                    break;
            }

        }

    }
    /// <summary>
    /// Тип события, возвращаемого LongPoll-сервером
    /// </summary>
    public enum VkLongPollMessageType
    {
        /// <summary>
        /// Неизвестный тип
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// Удаление сообщения
        /// </summary>
        MessageDelete = 0,
        /// <summary>
        /// Замена флагов сообщения
        /// </summary>
        MessageUpdate = 1,
        /// <summary>
        /// Установка флагов сообщения
        /// </summary>
        MessageFlagSet = 2,
        /// <summary>
        /// Сброс флагов сообщения
        /// </summary>
        MessageFlagReset = 3,
        /// <summary>
        /// Добавление нового сообщения
        /// </summary>
        MessageAdd = 4,
        /// <summary>
        /// Друг стал онлайн
        /// </summary>
        FriendOnline = 8,
        /// <summary>
        /// Друг стал оффлайн
        /// </summary>
        FriendOffline = 9,
        /// <summary>
        /// Один из параметров (состав, тема) беседы был изменен
        /// </summary>
        ConversationChange = 51,
        /// <summary>
        /// Пользователь начал набирать текст в диалоге
        /// </summary>
        DialogUserTyping = 61,
        /// <summary>
        /// Пользователь начал набирать текст в беседе
        /// </summary>
        ConsersationUserTyping = 62,
        /// <summary>
        /// Пользователь совершил звонок
        /// </summary>
        UserCall = 70
    }

    /// <summary>
    /// Флаги сообщений, возвращаемых LongPoll-сервером
    /// </summary>
    [Flags]
    public enum VkLongPollMessageFlags
    {
        Error = -1,
        /// <summary>
        /// Сообщение не прочитано
        /// </summary>
        Unread = 1,
        /// <summary>
        /// Исходящее сообщение
        /// </summary>
        Outbox = 2,
        /// <summary>
        /// На сообщение был создан ответ
        /// </summary>
        Replied = 4,
        /// <summary>
        /// Помеченное сообщение
        /// </summary>
        Important = 8,
        /// <summary>
        /// Сообщение отправлено через чат
        /// </summary>
        Chat = 16,
        /// <summary>
        /// Сообщение отправлено другом
        /// </summary>
        Friends = 32,
        /// <summary>
        /// Сообщение помечено как спам
        /// </summary>
        Spam = 64,
        /// <summary>
        /// Сообщение удалено (в корзине)
        /// </summary>
        Deleted = 128,
        /// <summary>
        /// Сообщение проверено пользователем на спам
        /// </summary>
        Fixed = 256,
        /// <summary>
        /// Сообщение содержит медиаконтент
        /// </summary>
        Media = 512
    }
}
