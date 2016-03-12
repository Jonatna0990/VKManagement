using System.Collections.Generic;

namespace VKCore.API.Error
{

   public  class VKErrorClass
    {
        public const int USER_AUTHORIZATION_FAILED = 5;
        public const int CAPTCHA_REQUIRED = 14;
        public const int VALIDATION_REQUIRED = 17;
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public List<RequestParam> request_params { get; set; }
        public string captcha_sid { get; set; }
        public string captcha_img { get; set; }
        public string redirect_uri { get; set; }
        public ErrorType error_type
        {
            get 
            
            {
                switch (error_code)
                {
                    case 1: return ErrorType.UnknownError;
                    case 2: return ErrorType.AppIsDisabledError;
                    case 3: return ErrorType.UnknownMethodError;
                    case 4: return ErrorType.InvalidSignatureError;
                    case 5: return ErrorType.UserAuthFailedError;
                    case 6: return ErrorType.TooManyRequestsError;
                    case 7: return ErrorType.NoPermissionError;
                    case 8: return ErrorType.BadRequestError;
                    case 9: return ErrorType.TooManyActionError;
                    case 10: return ErrorType.InternalServerError;
                    case 11: return ErrorType.TestModeError;
                    case 14: return ErrorType.CaptchaNeedError;
                    case 15: return ErrorType.AccessDeniedError;
                    case 16: return ErrorType.HTTPSNeddError;
                    case 17: return ErrorType.NeedUserValidationError;
                    case 19: return ErrorType.ContentAvailableError;
                    case 20: return ErrorType.StandaloneActionError;
                    case 23: return ErrorType.MethodDisabledError;
                    case 24: return ErrorType.NeedUserConfirmError;

                    case 100: return ErrorType.RequestParametersError;
                    case 101: return ErrorType.InvalidAPPIDError;
                    case 103: return ErrorType.GroupJoinLimitError;
                    case 105: return ErrorType.CanNotSaveFile;
                        
                    case 113: return ErrorType.InvalidUserID;
                    case 114: return ErrorType.InvalidAlbumIdError;
                    case 118: return ErrorType.InvalidServerError;
                    case 121: return ErrorType.InvalidHashError;
                    case 122: return ErrorType.InvalidPhotosIdsError;
                    case 125: return ErrorType.InvalidGroupId;
                    case 129: return ErrorType.InvalidPhotoFormatError;
                    case 150: return ErrorType.InvalidTimestampError;
                    case 174: return ErrorType.AddHimselfToFriendError;
                    case 175: return ErrorType.AddBlacklistInFriendError;
                    case 176: return ErrorType.AddFriendInBlacklistError;

                    case 200: return ErrorType.AccessDeniedAlbumError;
                    case 201: return ErrorType.AccessDeniedAudioError;
                    case 203: return ErrorType.AccessDeniedGroupError;
                    case 204: return ErrorType.AccessDeniedVideoError;
                    case 205: return ErrorType.AccessDeniedMarketError;
                    case 210: return ErrorType.AccessDeniedWallError;
                    case 211: return ErrorType.AccessDeniedWallCommentError;
                    case 212: return ErrorType.AccessDeniedCommentError;
                    case 213: return ErrorType.AccessDeniedAddCommentError;
                    case 214: return ErrorType.WallPostLimitError;
                    case 219: return ErrorType.AdsPostRecentlyError;
                    case 220: return ErrorType.TooManyRecipientsError;
                    case 222: return ErrorType.AccessDeniedLinkAddError;
                    case 260: return ErrorType.AccessDeniedGroupListError;

                    case 300: return ErrorType.AlbumFullError;
                    case 302: return ErrorType.AlbumLimitError;

                    case 700: return ErrorType.CreatorRightsChangeError;
                    case 701: return ErrorType.UserNotJoinGroupError;
                    case 702: return ErrorType.AdminLimitError;

                    case 800: return ErrorType.VideoAlreadyAddError;
                    case 801: return ErrorType.VideoCommentDisabledError;

                    case 900: return ErrorType.BlacklistSendError;
                    case 901: return ErrorType.FirstMessageFromGroupError;
                    case 902: return  ErrorType.AccessDeniedMessageFromGroupError;

                    case 1150: return ErrorType.DocIdError;
                    case 1151: return ErrorType.DocDeleteAccessDeniedError;
                    case 1152: return ErrorType.DocNameError;
                    case 1153: return ErrorType.DocAccessDeniedError;

                    case 1260: return ErrorType.GroupScreenNameError;

                    case 1310: return ErrorType.CatalogAvailableError;
                    case 1311: return ErrorType.AccessDeniedCatalogCategoryError;

                    case 1400: return ErrorType.MarketProductRecoveryError;
                    case 1401: return ErrorType.MarketCommentsError;
                    case 1402: return ErrorType.MarketAlbumSearchError;
                    case 1403: return ErrorType.MarketProductSearchError;
                    case 1404: return ErrorType.MarketProductTooAddError;
                    case 1405: return ErrorType.MarketProductLimitError;
                    case 1407: return ErrorType.MarketAlbumLimitError;
                    default: return ErrorType.UnknownError;
                
                }
            
            
            }
        
        }
    }
   public class RequestParam
   {
       public string key { get; set; }
       public string value { get; set; }
   }
   public static class CaptchaValidate
   {
       public static void OpenCaptchaWindows()
       { }
       public static void SendCaptcha()
       { }
       public static void CheckCaptchaEnter()
       { }
   
   
   }
   public enum ErrorType
   { 
       //1 - Произошла неизвестная ошибка.
       UnknownError,
       //2 - Приложение выключено.
       AppIsDisabledError,
       //3 - Передан неизвестный метод.
       UnknownMethodError,
       //4 - Неверная подпись.
       InvalidSignatureError,
       //5 - Авторизация пользователя не удалась.
       UserAuthFailedError,
       //6 - Слишком много запросов в секунду.
       TooManyRequestsError,
       //7 - Нет прав для выполнения этого действия.
       NoPermissionError,
       //8 - Неверный запрос.
       BadRequestError,
       //9 - Слишком много однотипных действий.
       TooManyActionError,
       //10 - Произошла внутренняя ошибка сервера.
       InternalServerError,
       //11 - В тестовом режиме приложение должно быть выключено или пользователь должен быть залогинен.
       TestModeError,
       //14 - Требуется ввод кода с картинки (Captcha).
       CaptchaNeedError,
       //15 - Доступ запрещён.
       AccessDeniedError,
       //16 - Требуется выполнение запросов по протоколу HTTPS, т.к. пользователь включил настройку, требующую работу через безопасное соединение. 
       HTTPSNeddError,
       //17 - Требуется валидация пользователя. 
       NeedUserValidationError,
       //19 - Контент недоступен
       ContentAvailableError,
       //20 - Данное действие запрещено для не Standalone приложений. 
       StandaloneActionError,
       //23 - Метод был выключен. 
       MethodDisabledError,
       //24 - Требуется подтверждение со стороны пользователя. 
       NeedUserConfirmError,
       //100 - Один из необходимых параметров был не передан или неверен. 
       RequestParametersError,
       //101 - Неверный API ID приложения. 
       InvalidAPPIDError,
       //103 - Превышено ограничение на количество вступлений
       GroupJoinLimitError,
       //105 - Невозможно сохранить файл
       CanNotSaveFile,
       //113 - Неверный идентификатор пользователя.
       InvalidUserID,
       //114 - Недопустимый идентификатор альбома
       InvalidAlbumIdError,
       //118 - Недопустимый сервер
       InvalidServerError,
       //121 - Неверный хэш
       InvalidHashError,
       //122 - Неверные идентификаторы фотографий.
       InvalidPhotosIdsError,
       //125 - Недопустимый идентификатор сообщества
       InvalidGroupId,
       //129 - Недопустимый формат фотографии
       InvalidPhotoFormatError,
       //150 - Неверный timestamp. 
       InvalidTimestampError,
       //174 - Невозможно добавить в друзья самого себя. 
       AddHimselfToFriendError,
       //175 - Невозможно добавить в друзья пользователя, который занес Вас в свой черный список. 
       AddBlacklistInFriendError,
       //176 - Невозможно добавить в друзья пользователя, который занесен в Ваш черный список. 
       AddFriendInBlacklistError,
       //200 - Доступ к альбому запрещён. 
       AccessDeniedAlbumError,
       //201 - Доступ к аудио запрещён. 
       AccessDeniedAudioError,
       //203 - Доступ к группе запрещён. 
       AccessDeniedGroupError,
       //204 - Доступ к видео запрещён
       AccessDeniedVideoError,
       //205 - Доступ к товарам запрещён. 
       AccessDeniedMarketError,
       //210 - Нет доступа к стене
       AccessDeniedWallError,
       //211 - Нет доступа к комментариям на этой стене
       AccessDeniedWallCommentError,
       //212 - Нет доступа к комментариям записи
       AccessDeniedCommentError,
       //213 - Нет доступа к комментированию записи
       AccessDeniedAddCommentError,
       //214 - Публикация запрещена. Превышен лимит на число публикаций в сутки, либо на указанное время уже запланирована другая запись
       WallPostLimitError,
       //219 - Рекламный пост уже недавно публиковался
       AdsPostRecentlyError,
       //220 - Слишком много получателей
       TooManyRecipientsError,
       //222 - Запрещено размещать ссылки
       AccessDeniedLinkAddError,
       //260 - Доступ к запрошенному списку групп ограничен настройками приватности пользователя
       AccessDeniedGroupListError,
       //300 - Альбом переполнен. 
       AlbumFullError,
       //302 - Создано максимальное количество альбомов. 
       AlbumLimitError,
       //700 - Невозможно изменить полномочия создателя. 
       CreatorRightsChangeError,
       //701 - Пользователь должен состоять в сообществе. 
       UserNotJoinGroupError,
       //702 - Достигнут лимит на количество руководителей в сообществе
       AdminLimitError,
       //800 - Это видео уже добавлено
       VideoAlreadyAddError,
       //801 - Комментарии для видео закрыты
       VideoCommentDisabledError,
       //900 - Нельзя отправлять сообщение пользователю из черного списка 
       BlacklistSendError,
       //901 - Нельзя первым писать пользователю от имени сообщества
       FirstMessageFromGroupError,
       //902 - Нельзя отправлять сообщения этому пользователю в связи с настройками приватности 
       AccessDeniedMessageFromGroupError,
       //1150 - Неверный идентификатор документа 
       DocIdError,
       //1152 - Не передано название документа 
       DocNameError,
       //1151 - Нет доступа к удалению документов
       DocDeleteAccessDeniedError,
       //1153 - Нет доступа к документу
       DocAccessDeniedError,
       //1260 - Invalid screen name 
       GroupScreenNameError,
       //1310 - Каталог не доступен для пользователя 
       CatalogAvailableError,
       //1311 - Категории каталога не доступны для пользователя
       AccessDeniedCatalogCategoryError,
       //1400 - Товар невозможно восстановить, прошло слишком много времени с момента удаления
       MarketProductRecoveryError,
       //1401 - Комментарии магазина выключены
       MarketCommentsError,
       //1402 - Подборка с заданным идентификатором не найдена
       MarketAlbumSearchError,
       //1403 - Товар с заданным идентификатором не найден
       MarketProductSearchError,
       //1404 - Товар уже добавлен в выбранную подборку
       MarketProductTooAddError,
       //1405 - Превышен лимит на количество товаров
       MarketProductLimitError,
       //1407 - Превышен лимит на количество подборок.
       MarketAlbumLimitError
    }


}
