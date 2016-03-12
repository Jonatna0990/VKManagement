using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKCore.API.VKModels.LongPollServer;

namespace VKCore.Helpers
{
    public static class MessageFlagsHelper
    {

        public static List<VkLongPollMessageFlags> CheckFlags(int flags)
        {

            List<VkLongPollMessageFlags> t = new List<VkLongPollMessageFlags>();
            if (flags > 0 && flags < 1024)
            {
                if ((flags & 512) != 0) // MEDIA сообщение содержит медиаконтент 
                    t.Add(VkLongPollMessageFlags.Media);
                if ((flags & 256) != 0) // FIXED сообщение проверено пользователем на спам
                    t.Add(VkLongPollMessageFlags.Fixed);
                if ((flags & 128) != 0) // DELЕTЕD сообщение удалено (в корзине)
                    t.Add(VkLongPollMessageFlags.Deleted);
                if ((flags & 64) != 0) // SPAM сообщение помечено как "Спам"
                    t.Add(VkLongPollMessageFlags.Spam);
                if ((flags & 32) != 0) // FRIENDS сообщение отправлено другом
                    t.Add(VkLongPollMessageFlags.Friends);
                if ((flags & 16) != 0) // CHAT сообщение отправлено через чат
                    t.Add(VkLongPollMessageFlags.Chat);
                if ((flags & 8) != 0) // IMPORTANT помеченное сообщение
                    t.Add(VkLongPollMessageFlags.Important);
                if ((flags & 4) != 0) //REPLIED на сообщение был создан ответ
                    t.Add(VkLongPollMessageFlags.Replied);
                if ((flags & 2) != 0) //OUTBOX исходящее сообщение
                    t.Add(VkLongPollMessageFlags.Outbox);
                if ((flags & 1) != 0) //UNREAD сообщение не NotReadVisibility
                    t.Add(VkLongPollMessageFlags.Unread);
            }

            return t;
        }
    }
}
