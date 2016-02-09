using System;

namespace VKCore.Converters.ProfileConverter
{
   public static class UserDataConvert
    {
       public static string UserDataCounter(UserDataType type, int count, bool return_name)
       {
           string str_count = count.ToString();
           switch (type)
           {

               case UserDataType.Audios: 
                   {
                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " аудиозапись" : "аудиозапись";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " аудиозаписей" : "аудиозаписей";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " аудиозаписи" : "аудиозаписи";
                           }
                           else return (return_name) ? count + " аудиозаписей" : "аудиозаписей"; 
                           
                       
                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " аудиозапись" : "аудиозапись";
                           }
                           else if (count >= 2 && count <=4)
                           {
                               return (return_name) ? count + " аудиозаписи" : "аудиозаписи";
                           }
                           else return (return_name) ? count + " аудиозаписей" : "аудиозаписей";
                           

                       }
                   
                   }; 
               case UserDataType.Docs: 
                   {
                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " документ" : "документ";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " документов" : "документов";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " документа" : "документа";
                           }
                           else return (return_name) ? count + " аудиозаписей" : "документов"; 


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " документ" : "документ";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " документа" : "документа";
                           }
                           else return (return_name) ? count + " аудиозаписей" : "документов"; 


                       }
                   
                   }; 
               case UserDataType.Followers: 
                   {
                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " подписчик" : "подписчик";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " подписчиков" : "подписчиков";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " подписчика" : "подписчика";
                           }
                           else return (return_name) ? count + " подписчиков" : "подписчиков";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " подписчик" : "подписчик";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " подписчика" : "подписчика";
                           }
                           else return (return_name) ? count + " подписчиков" : "подписчиков";


                       }
                   
                   }; 
               case UserDataType.Frineds: 
                   {
                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " друг" : "друг";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " друзей" : "друзей";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " друга" : "друга";
                           }
                           else return (return_name) ? count + " друзей" : "друзей"; 


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " друг" : "друг";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " друга" : "друга";
                           }
                           else return (return_name) ? count + " друзей" : "друзей"; 


                       }
                   
                   }; 
               case UserDataType.Groups: 
                   {
                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " группа" : "группа";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " групп" : "групп";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " группы" : "группы";
                           }
                           else return (return_name) ? count + " групп" : "групп"; 


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " группа" : "группа";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " группы" : "группы";
                           }
                           else return (return_name) ? count + " групп" : "групп"; 


                       }
                   
                   
                   }; 
               case UserDataType.Messages: 
                   {
                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " сообщение" : "сообщение";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " сообщений" : "сообщений";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " сообщения" : "сообщения";
                           }
                           else return (return_name) ? count + " сообщений" : "сообщений";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " сообщение" : "сообщение";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " сообщений" : "сообщений";
                           }
                           else return (return_name) ? count + " сообщений" : "сообщений";


                       }
                   
                   }; 
             
               case UserDataType.News: 
                   {
                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " новость" : "новость";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " новостей" : "новостей";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " новости" : "новости";
                           }
                           else return (return_name) ? count + " новостей" : "новостей";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " новость" : "новость";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " новости" : "новости";
                           }
                           else return (return_name) ? count + " новостей" : "новостей";


                       }
                   
                   }; 
               case UserDataType.Photos: 
                   {
                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " фотография" : "фотография";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " фотографий" : "фотографий";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " фотографии" : "фотографии";
                           }
                           else return (return_name) ? count + " фотографий" : "фотографий"; 


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " фотография" : "фотография";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " фотографии" : "фотографии";
                           }
                           else return (return_name) ? count + " фотографий" : "фотографий"; 


                       }
                   
                   }; 
               case UserDataType.Videos: 
                   {

                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " видеозапись" : "видеозапись";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " видеозаписей" : "видеозаписей";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " видеозаписи" : "видеозаписи";
                           }
                           else return (return_name) ? count + " видеозаписей" : "видеозаписей";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " видеозапись" : "видеозапись";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " видеозаписи" : "видеозаписи";
                           }
                           else return (return_name) ? count + " видеозаписей" : "видеозаписей";


                       }
                   };
               case UserDataType.Mutual:
                   {

                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " общий" : "общий";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           else return (return_name) ? count + " общих" : "общих";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " общий" : "общий";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           return (return_name) ? count + " общих" : "общих";


                       }
                   };
               case UserDataType.Seconds:
                   {

                       if (str_count.Length == 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " секудна" : "секудна";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " секунды" : "секунды";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " секунд" : "секунд";
                           }
                           else return (return_name) ? count + " общих" : "общих";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " общий" : "общий";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           return (return_name) ? count + " общих" : "общих";


                       }
                   };
               case UserDataType.Minutes:
                   {

                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " общий" : "общий";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           else return (return_name) ? count + " общих" : "общих";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " общий" : "общий";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           return (return_name) ? count + " общих" : "общих";


                       }
                   };
               case UserDataType.Hours:
                   {

                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " общий" : "общий";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           else return (return_name) ? count + " общих" : "общих";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " общий" : "общий";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           return (return_name) ? count + " общих" : "общих";


                       }
                   };
               case UserDataType.Days:
                   {

                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " общий" : "общий";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           else return (return_name) ? count + " общих" : "общих";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " общий" : "общий";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " общих" : "общих";
                           }
                           return (return_name) ? count + " общих" : "общих";


                       }
                   };
               case UserDataType.Attachments:
                   {

                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " вложение" : "вложение";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " вложений" : "вложений";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " вложения" : "вложения";
                           }
                           else return (return_name) ? count + " вложений" : "вложений";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " вложение" : "вложение";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " вложения" : "вложения";
                           }
                           return (return_name) ? count + " вложений" : "вложений";


                       }
                   };
               case UserDataType.Topics:
                   {

                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " обсуждение" : "обсуждение";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " обсуждений" : "обсуждений";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " обсуждения" : "обсуждения";
                           }
                           else return (return_name) ? count + " обсуждений" : "обсуждений";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " обсуждение" : "обсуждение";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " обсуждения" : "обсуждения";
                           }
                           return (return_name) ? count + " обсуждений" : "обсуждений";


                       }
                   };
               case UserDataType.Counters:
                   {

                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " участник" : "участник";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " участников" : "участников";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " участника" : "участника";
                           }
                           else return (return_name) ? count + " участников" : "участников";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " участник" : "участник";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " участника" : "участника";
                           }
                           return (return_name) ? count + " участников" : "участников";


                       }
                   };
               case UserDataType.FwdMessages:
                   {

                       if (str_count.Length >= 2)
                       {

                           if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 1 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 11)
                           {
                               return (return_name) ? count + " пересланное сообщение" : "пересланное сообщение";
                           }
                           else if (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 0 || Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) == 11)
                           {
                               return (return_name) ? count + " пересланных сообщений" : "пересланных сообщений";
                           }
                           else if (((Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 2 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 12)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 3 && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 13)
                               || (Convert.ToInt32(str_count.Substring(str_count.Length - 1, 1)) == 4) && Convert.ToInt32(str_count.Substring(str_count.Length - 2, 2)) != 14) && count > 20)
                           {
                               return (return_name) ? count + " пересланных сообщений" : "пересланных сообщений";
                           }
                           else return (return_name) ? count + " пересланных сообщени" : "пересланных сообщений";


                       }
                       else
                       {
                           if (count == 1)
                           {
                               return (return_name) ? count + " пересланное сообщение" : "пересланное сообщение";
                           }
                           else if (count >= 2 && count <= 4)
                           {
                               return (return_name) ? count + " пересланных сообщения" : "пересланных сообщения";
                           }
                           return (return_name) ? count + " пересланных сообщений" : "пересланных сообщений";


                       }
                   }; 

           
           }
           return "";
       
       }
    

    }

    public enum UserDataType
    {
        Messages, 
        Frineds,
        Followers,
        Audios,
        Videos,
        Photos,
        Docs,
        Groups,
        News,
        Mutual,
        Seconds,
        Minutes,
        Hours,
        Days,
        Attachments,
        FwdMessages,
        Topics,
        Counters
    }
}
