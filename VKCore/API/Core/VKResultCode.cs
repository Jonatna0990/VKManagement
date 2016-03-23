namespace VKCore.API.Core
{

    public enum VKResultCode
    {
        // didn't get response at all
        CommunicationFailed = -1,

        Succeeded = 0,

        // error codes from vk https://vk.com/dev/errors
        UnknownError = 1,
        AppDisabled = 2,
        UnknownMethod = 3,
        IncorrectSignature = 4,
        UserAuthorizationFailed = 5,
        TooManyRequestsPerSecond = 6,
        NotAllowed = 7,
        WrongSyntax = 8,
        FloodControlEnabled = 9,
        InternalServerError = 10,
        TestModeError = 11,
        CaptchaRequired = 14,
        AccessDenied = 15,
        HttpsRequired = 16,
        ValidationRequired = 17,
        ContentAvailableError = 19,


        StandaloneActionError = 20,
        MethodDisabledError = 23,
        NeedUserConfirmError = 24,

        WrongParameter = 100,

        InvalidUserId = 113,
        InvalidAppIdError = 101,
        GroupJoinLimitError = 103,
        CanNotSaveFile = 105,

        InvalidAlbumIdError = 114,
        InvalidServerError = 118,

        InvalidHashError = 121,
        InvalidPhotosIdsError = 122,
        InvalidGroupId = 125,
        InvalidPhotoFormatError = 129,

        InvalidTimestampError = 150,

        AddHimselfToFriendError = 174,
        AddBlacklistInFriendError = 175,
        AddFriendInBlacklistError = 176,

        AlbumAccessDenied = 200,
        AudioAccessDenied = 201,
        AccessDeniedVideoError = 204,
        AccessDeniedMarketError = 205,

        AccessDeniedWallError = 210,
        AccessDeniedWallCommentError = 211,
        AccessDeniedCommentError = 212,
        AccessDeniedAddCommentError = 213,
        WallPostLimitError = 214,
        AdsPostRecentlyError = 219,

        TooManyRecipientsError = 220,
        AccessDeniedLinkAddError = 222,
        AccessDeniedGroupListError = 260,

        GroupAccessDenied = 203,
        AlbumLimitReached = 300,
        AlbumLimitError = 302,

        CreatorRightsChangeError = 700,
        UserNotJoinGroupError = 701,
        AdminLimitError = 702,

        VideoAlreadyAddError = 800,
        VideoCommentDisabledError = 801,

        BlacklistSendError = 900,
        FirstMessageFromGroupError = 901,
        AccessDeniedMessageFromGroupError = 902,

        DocIdError = 1150,
        DocDeleteAccessDeniedError = 1151,
        DocNameError = 1152,
        DocAccessDeniedError = 1153,

        GroupScreenNameError = 1260,

        CatalogAvailableError = 1310,
        AccessDeniedCatalogCategoryError = 1311,

        MarketProductRecoveryError = 1400,
        MarketCommentsError = 1401,
        MarketAlbumSearchError = 1402,
        MarketProductSearchError = 1403,
        MarketProductTooAddError = 1404,
        MarketProductLimitError = 1405,
        MarketAlbumLimitError = 1407,

        CaptchaControlCancelled = 100002,
        ValidationCanceslledOrFailed = 100003,
        DeserializationError = -10000,
        InvalidToken = -10001,  
    }
}
