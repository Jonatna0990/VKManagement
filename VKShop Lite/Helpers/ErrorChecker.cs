using System;
using VKCore.API.Error;
using VKShop_Lite.UserControls.PopupControl;

namespace VKShop_Lite.Helpers
{
    public static class ErrorChecker
    {
        public static void Check(ErrorType eroor, bool show_error=false)
        {
            switch (eroor)
            {
                case ErrorType.UnknownError: { } break;
                case ErrorType.AppIsDisabledError: { } break;
                case ErrorType.UnknownMethodError: { } break;
                case ErrorType.InvalidSignatureError: { } break;
                case ErrorType.UserAuthFailedError: { } break;
                case ErrorType.TooManyRequestsError: { }break;
                case ErrorType.NoPermissionError: { } break;
                case ErrorType.BadRequestError: { } break;
                case ErrorType.TooManyActionError: { } break;
                case ErrorType.InternalServerError: { } break;
                case ErrorType.TestModeError: { } break;
                case ErrorType.CaptchaNeedError: { } break;
                case ErrorType.AccessDeniedError: { } break;
                case ErrorType.HTTPSNeddError: { } break;
                case ErrorType.NeedUserValidationError: { } break;
                case ErrorType.ContentAvailableError: { } break;
                case ErrorType.StandaloneActionError: { } break;
                case ErrorType.MethodDisabledError: { } break;
                case ErrorType.NeedUserConfirmError: { } break;

                case ErrorType.RequestParametersError: { } break;
                case ErrorType.InvalidAPPIDError: { } break;
                case ErrorType.GroupJoinLimitError: { } break;
                case ErrorType.CanNotSaveFile: { } break;

                case ErrorType.InvalidUserID: { } break;
                case ErrorType.InvalidAlbumIdError: { } break;
                case ErrorType.InvalidServerError: { } break;
                case ErrorType.InvalidHashError: { } break;
                case ErrorType.InvalidPhotosIdsError: { } break;
                case ErrorType.InvalidGroupId: { } break;
                case ErrorType.InvalidPhotoFormatError: { } break;
                case ErrorType.InvalidTimestampError: { } break;

                case ErrorType.AccessDeniedAlbumError: { } break;
                case ErrorType.AccessDeniedAudioError: { } break;
                case ErrorType.AccessDeniedGroupError: { } break;
                case ErrorType.AccessDeniedVideoError: { } break;
                case ErrorType.AccessDeniedMarketError: { } break;
                case ErrorType.AccessDeniedWallError: { } break;
                case ErrorType.AccessDeniedWallCommentError: { } break;
                case ErrorType.AccessDeniedCommentError: { } break;
                case ErrorType.AccessDeniedAddCommentError: { } break;
                case ErrorType.WallPostLimitError: { } break;
                case ErrorType.AdsPostRecentlyError: { } break;
                case ErrorType.TooManyRecipientsError: { } break;
                case ErrorType.AccessDeniedLinkAddError: { } break;
                case ErrorType.AccessDeniedGroupListError: { } break;

                case ErrorType.AlbumFullError: { } break;
                case ErrorType.AlbumLimitError: { } break;

                case ErrorType.CreatorRightsChangeError: { } break;
                case ErrorType.UserNotJoinGroupError: { } break;
                case ErrorType.AdminLimitError: { } break;

                case ErrorType.VideoAlreadyAddError: { } break;
                case ErrorType.VideoCommentDisabledError: { } break;

                case ErrorType.BlacklistSendError: { } break;
                case ErrorType.FirstMessageFromGroupError: { } break;
                case ErrorType.AccessDeniedMessageFromGroupError: { } break;

                case ErrorType.DocIdError: { } break;
                case ErrorType.DocDeleteAccessDeniedError: { } break;
                case ErrorType.DocNameError: { } break;
                case ErrorType.DocAccessDeniedError: { } break;

                case ErrorType.GroupScreenNameError: { } break;

                case ErrorType.CatalogAvailableError: { } break;
                case ErrorType.AccessDeniedCatalogCategoryError: { } break;

                case ErrorType.MarketProductRecoveryError: { } break;
                case ErrorType.MarketCommentsError: { } break;
                case ErrorType.MarketAlbumSearchError: { } break;
                case ErrorType.MarketProductSearchError: { } break;
                case ErrorType.MarketProductTooAddError: { } break;
                case ErrorType.MarketProductLimitError: { } break;
                case ErrorType.MarketAlbumLimitError: { } break;
                default:  { } break;
            }
            
        }
      
    }
}
