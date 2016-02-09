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
                    case 20: return ErrorType.StandaloneActionError;
                    case 23: return ErrorType.MethodDisabledError;
                    case 24: return ErrorType.NeedUserConfirmError;
                    case 100: return ErrorType.RequestParametersError;
                    case 101: return ErrorType.InvalidAPPIDError;
                    case 113: return ErrorType.InvalidUserID;
                    case 150: return ErrorType.InvalidTimestampError;
                    case 200: return ErrorType.AccessDeniedAlbumError;
                    case 201: return ErrorType.AccessDeniedAudioError;
                    case 203: return ErrorType.AccessDeniedGroupError;
                    case 300: return ErrorType.AlbumFullError;
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
       //113 - Неверный идентификатор пользователя.
       InvalidUserID,
       //150 - Неверный timestamp. 
       InvalidTimestampError,
       //200 - Доступ к альбому запрещён. 
       AccessDeniedAlbumError,
       //201 - Доступ к аудио запрещён. 
       AccessDeniedAudioError,
       //203 - Доступ к группе запрещён. 
       AccessDeniedGroupError,
       //300 - Альбом переполнен. 
       AlbumFullError
   
   }


}
