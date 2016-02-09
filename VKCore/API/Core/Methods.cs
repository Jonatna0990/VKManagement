namespace VKCore.API.Core
{

    /// <summary>
    /// Структуры, хранящие значения для отправки запросов
    /// </summary>
    public struct APISettings 
        {
            public const string app_id = "5220139";
            public const string app_secret = "RgT0WD8mxw8oZJou95mB";
            public const string APIURL = "https://api.vk.com/method/";
     
        }
        public struct SMessages
        {   
            public const string messages_get = "messages.get";
            public const string messages_getHistory = "messages.getHistory";
            public const string messages_setActivity = "messages.setActivity";
            public const string messages_marsAsRead = "messages.markAsRead";
            public const string messages_send = "messages.send";
            public const string messages_getdialogs = "messages.getDialogs";
            public const string messages_getById = "messages.getById";
            public const string messages_search = "messages.search";
            public const string messages_getLongPollServer = "messages.getLongPollServer";
        }
        public struct SUsers
        {
            public const string user_get = "users.get";
            public const string user_search = "users.search";
            public const string user_isAppUser = "users.isAppUser";
            public const string user_getSubscriptions = "users.getSubscriptions";
            public const string user_getFollowers = "users.getFollowers";
            public const string users_report = "users.report";
            public const string user_getNearby = "users.getNearby"; 
        }
        public struct SGroups
        {
            public const string groups_isMember = "groups.isMember";
            public const string groups_getById = "groups.getById";
            public const string groups_get = "groups.get";
            public const string groups_getMembers = "groups.getMembers";
            public const string groups_join = "groups.join";
            public const string groups_leave = "groups.leave";
            public const string groups_search = "groups.search";
            public const string groups_getInvites = "groups.getInvites";
            public const string groups_getInvitedUsers = "groups.getInvitedUsers";
            public const string groups_banUser = "groups.banUser";
            public const string groups_unbanUser = "groups.unbanUser";
            public const string groups_getBanned = "groups.getBanned";
            public const string groups_create = "groups.create";
            public const string groups_edit = "groups.edit";
            public const string groups_editPlace = "groups.editPlace";
            public const string groups_getSettings = "groups.getSettings";
            public const string groups_getRequests = "groups.getRequests";
            public const string groups_editManager = "groups.editManager";
            public const string groups_invite = "groups.invite";
            public const string groups_addLink = "groups.addLink";
            public const string groups_deleteLink = "groups.deleteLink";
            public const string groups_editLink = "groups.editLink";
            public const string groups_reorderLink = "groups.reorderLink";
            public const string groups_removeUser = "groups.removeUser";
            public const string groups_approveRequest = "groups.approveRequest";

        }
        public struct SFriends
        {
            public const string friends_get = "friends.get";
            public const string friends_getOnline = "friends.getOnline";
            public const string friends_getMutual = "friends.getMutual";
            public const string friends_getRecent = "friends.getRecent";
            public const string friends_getRequests = "friends.getRequests";
            public const string friends_add = "friends.add";
            public const string friends_edit = "friends.edit";
            public const string friends_delete = "friends.delete";
            public const string friends_getLists = "friends.getLists";
            public const string friends_addList = "friends.addList";
            public const string friends_editList = "friends.editList";
            public const string friends_deleteList = "friends.deleteList";
            public const string friends_getAppUsers = "friends.getAppUsers";
            public const string friends_getByPhones = "friends.getByPhones";
            public const string friends_deleteAllRequests = "friends.deleteAllRequests";
            public const string friends_getSuggestions = "friends.getSuggestions";
            public const string friends_areFriends = "friends.areFriends";
            public const string friends_getAvailableForCall = "friends.getAvailableForCall";
        }
        public struct SWall
        {
              public const string wall_get = "wall.get";
              public const string wall_search = "wall.search";
              public const string wall_getById = "wall.getById";
              public const string wall_post = "wall.post";
              public const string wall_repost = "wall.repost";
              public const string wall_getReposts = "wall.getReposts";
              public const string wall_edit = "wall.edit";
              public const string wall_delete = "wall.delete";
              public const string wall_restore = "wall.restore";
              public const string wall_pin = "wall.pin";
              public const string wall_unpin = "wall.unpin";
              public const string wall_getComments = "wall.getComments";
              public const string wall_addComment = "wall.addComment";
              public const string wall_editComment = "wall.editComment";
              public const string wall_deleteComment = "wall.deleteComment";
              public const string wall_restoreComment = "wall.restoreComment";
              public const string wall_reportPost = "wall.reportPost";
              public const string wall_reportComment = "wall.reportComment";
        }
        public struct SPhotos
        {
            public const string photos_createAlbum = "photos.createAlbum";
            public const string photos_editAlbum = "photos.editAlbum";
            public const string photos_getAlbums = "photos.getAlbums";
            public const string photos_get = "photos.get";
            public const string photos_getAlbumsCount = "photos.getAlbumsCount";
            public const string photos_getProfile = "photos.getProfile";
            public const string photos_getById = "photos.getById";
            public const string photos_getUploadServer = "photos.getUploadServer";
            public const string photos_getOwnerPhotoUploadServer = "photos.getOwnerPhotoUploadServer";
            public const string photos_getChatUploadServer = "photos.getChatUploadServer";
            public const string photos_saveOwnerPhoto = "photos.saveOwnerPhoto";
            public const string photos_saveWallPhoto = "photos.saveWallPhoto";
            public const string photos_getWallUploadServer = "photos.getWallUploadServer";
            public const string photos_getMessagesUploadServer = "photos.getMessagesUploadServer";
            public const string photos_saveMessagesPhoto = "photos.saveMessagesPhoto";
            public const string photos_report = "photos.report";
            public const string photos_reportComment = "photos.reportComment";
            public const string photos_search = "photos.search";
            public const string photos_save = "photos.save";
            public const string photos_copy = "photos.copy";
            public const string photos_edit = "photos.edit";
            public const string photos_move = "photos.move";
            public const string photos_makeCover = "photos.makeCover";
            public const string photos_reorderAlbums = "photos.reorderAlbums";
            public const string photos_reorderPhotos = "photos.reorderPhotos";
            public const string photos_getAll = "photos.getAll";
            public const string photos_getUserPhotos = "photos.getUserPhotos";
            public const string photos_deleteAlbum = "photos.deleteAlbum";
            public const string photos_delete = "photos.delete";
            public const string photos_confirmTag = "photos.confirmTag";
            public const string photos_getComments = "photos.getComments";
            public const string photos_getAllComments = "photos.getAllComments";
            public const string photos_createComment = "photos.createComment";
            public const string photos_deleteComment = "photos.deleteComment";
            public const string photos_restoreComment = "photos.restoreComment";
            public const string photos_editComment = "photos.editComment";
            public const string photos_getTags = "photos.getTags";
            public const string photos_putTag = "photos.putTag";
            public const string photos_removeTag = "photos.removeTag";
            public const string photos_getNewTags = "photos.getNewTags";
        }
        public struct SVideos
        {
            public const string video_get = "video.get";
            public const string video_edit = "video.edit";
            public const string video_add = "video.add";
            public const string video_save = "video.save";
            public const string video_delete = "video.delete";
            public const string video_restore = "video.restore";
            public const string video_search= "video.";
            public const string video_getUserVideos = "video.getUserVideos";
            public const string video_addAlbum = "video.addAlbum";
            public const string video_editAlbum = "video.editAlbum";
            public const string video_deleteAlbum = "video.deleteAlbum";
            public const string video_moveToAlbum = "video.moveToAlbum";
            public const string video_addToAlbum = "video.addToAlbum";
            public const string video_removeFromAlbum = "video.removeFromAlbum";
            public const string video_getAlbumsByVideo = "video.getAlbumsByVideo";
            public const string video_getComments = "video.getComments";
            public const string video_createComment = "video.createComment";
            public const string video_deleteComment = "video.deleteComment";
            public const string video_restoreComment = "video.restoreComment";
            public const string video_editComment = "video.editComment";
            public const string video_getTags = "video.getTags";
            public const string video_putTag = "video.putTag";
            public const string video_removeTag = "video.removeTag";
            public const string video_getNewTags = "video.getNewTags";
            public const string video_report = "video.report";
            public const string video_reportComment = "video.reportComment";
        }
        public struct SAudios
        {
            public const string audio_get = "audio.get";
            public const string audio_getById = "audio.getById";
            public const string audio_getLyrics = "audio.getLyrics";
            public const string audio_search = "audio.search";
            public const string audio_getUploadServer = "audio.getUploadServer";
            public const string audio_save = "audio.save";
            public const string audio_add = "audio.";
            public const string audio_delete = "audio.delete";
            public const string audio_edit = "audio.edit";
            public const string audio_reorder = "audio.reorder";
            public const string audio_restore = "audio.restore";
            public const string audio_getAlbums = "audio.getAlbums";
            public const string audio_addAlbum = "audio.addAlbum";
            public const string audio_editAlbum = "audio.editAlbum";
            public const string audio_deleteAlbum = "audio.deleteAlbum";
            public const string audio_moveToAlbum = "audio.moveToAlbum";
            public const string audio_setBroadcast = "audio.setBroadcast";
            public const string audio_getBroadcastList = "audio.getBroadcastList";
            public const string audio_getRecommendations = "audio.getPopular";
            public const string audio_getCount = "audio.getCount";
        
        }
        public struct SNews
        {
            public const string newsfeed_get = "newsfeed.get";
            public const string newsfeed_getRecommended = "newsfeed.getRecommended";
            public const string newsfeed_getComments = "newsfeed.getComments";
            public const string newsfeed_getMentions = "newsfeed.getMentions";
            public const string newsfeed_getBanned = "newsfeed.getBanned";
            public const string newsfeed_addBan = "newsfeed.addBan";
            public const string newsfeed_deleteBan = "newsfeed.deleteBan";
            public const string newsfeed_ignoreItem = "newsfeed.ignoreItem";
            public const string newsfeed_unignoreItem = "newsfeed.unignoreItem";
            public const string newsfeed_search = "newsfeed.search";
            public const string newsfeed_getLists = "newsfeed.getLists";
            public const string newsfeed_saveList = "newsfeed.saveList";
            public const string newsfeed_deleteList = "newsfeed.deleteList";
            public const string newsfeed_unsubscribe = "newsfeed.unsubscribe";
            public const string newsfeed_getSuggestedSources = "newsfeed.getSuggestedSources";
        }
        public struct SLikes
        {
            public const string likes_getList = "likes.getList";
            public const string likes_add = "likes.add";
            public const string likes_delete = "likes.delete";
            public const string likes_isLiked = "likes.isLiked";
        }
        public struct SAccount
        {
            public const string account_getCounters = "account.getCounters";
            public const string account_setNameInMenu = "account.setNameInMenu";
            public const string account_setOnline = "account.setOnline";
            public const string account_setOffline = "account.setOffline";
            public const string account_lookupContacts = "account.lookupContacts";
            public const string account_registerDevice = "account.registerDevice";
            public const string account_unregisterDevice = "account.unregisterDevice";
            public const string account_setSilenceMode = "account.setSilenceMode";
            public const string account_getPushSettings = "account.getPushSettings";
            public const string account_getAppPermissions = "account.getAppPermissions";
            public const string account_getActiveOffers = "account.getActiveOffers";
            public const string account_banUser = "account.banUser";
            public const string account_unbanUser = "account.unbanUser";
            public const string account_getBanned = "account.getBanned";
            public const string account_getInfo = "account.getInfo";
            public const string account_setInfo = "account.setInfo";
            public const string account_changePassword = "account.changePassword";
            public const string account_getProfileInfo = "account.getProfileInfosave";
            public const string account_saveProfileInfo = "account.ProfileInfo";
        }
        public struct SAuth
        {
            public const string auth_checkPhone = "auth.checkPhone";
            public const string auth_signup = "auth.signup";
            public const string auth_confirm = "auth.confirm";
            public const string auth_restore = "auth.restore";

        }
        public struct SStatus
        {
            public const string status_get = "status.get";
            public const string status_set = "status.set";
        }
        public struct SPages
        {
            public const string pages_get = "pages.get";
            public const string pages_save = "pages.save";
            public const string pages_saveAccess = "pages.saveAccess";
            public const string pages_getHistory = "pages.getHistory";
            public const string pages_getTitles = "pages.getTitles";
            public const string pages_getVersion = "pages.getVersion";
            public const string pages_parseWiki = "pages.parseWiki";
            public const string pages_clearCache = "pages.clearCache";
        }
        public struct SBoard
        {
            public const string board_getTopics = "board.getTopics";
            public const string board_getComments = "board.getComments";
            public const string board_addTopic = "board.addTopic";
            public const string board_addComment = "board.addComment";
            public const string board_deleteTopic = "board.deleteTopic";
            public const string board_editTopic = "board.editTopic";
            public const string board_editComment = "board.editComment";
            public const string board_restoreComment = "board.restoreComment";
            public const string board_deleteComment = "board.deleteComment";
            public const string board_openTopic = "board.openTopic";
            public const string board_closeTopic = "board.closeTopic";
            public const string board_fixTopic = "board.fixTopic";
            public const string board_unfixTopic = "board.unfixTopic";
     
        }
        public struct SNotes
        {
            public const string notes_get = "notes.get";
            public const string notes_getById = "notes.getById";
            public const string notes_getFriendsNotes = "notes.getFriendsNotes";
            public const string notes_add = "notes.add";
            public const string notes_edit = "notes.edit";
            public const string notes_delete = "notes.delete";
            public const string notes_createComment = "notes.createComment";
            public const string notes_editComment = "notes.editComment";
            public const string notes_deleteComment = "notes.deleteComment";
            public const string notes_restoreComment = "notes.restoreComment";
        }
        public struct SPlaces
        {
            public const string places_add = "places.add";
            public const string places_getById = "places.getById";
            public const string places_search = "places.search";
            public const string places_checkin = "places.checkin";
            public const string places_getCheckins = "places.getCheckins";
            public const string places_getTypes = "places.getTypes";
        }
        public struct SPolls
        {
            public const string polls_getById = "polls.getById";
            public const string polls_addVote = "polls.addVote";
            public const string polls_deleteVote = "polls.deleteVote";
            public const string polls_getVoters = "polls.getVoters";
            public const string polls_create = "polls.create";
            public const string polls_edit = "polls.edit";
        }
        public struct SDocs
        {
            public const string docs_get = "docs.get";
            public const string docs_getById = "docs.getById";
            public const string docs_getUploadServer = "docs.getUploadServer";
            public const string docs_getWallUploadServer = "docs.getWallUploadServer";
            public const string docs_save = "docs.save";
            public const string docs_delete = "docs.delete";
            public const string docs_add = "docs.add";

        }
        public struct SFaves
        {
            public const string fave_getUsers = "fave.getUsers";
            public const string fave_getPhotos = "fave.getPhotos";
            public const string fave_getPosts = "fave.getPosts";
            public const string fave_getVideos = "fave.getVideos";
            public const string fave_getLinks = "fave.getLinks";
        }
        public struct SNotifications
        {
            public const string notifications_get = "notifications.get";
            public const string notifications_markAsViewed = "notifications.markAsViewed";

        }
        public struct SSearch
        {
            public const string search_getHints = "search.getHints";
        }
        public struct SExecute
        {
            
            public const string execute_get_news = "execute.GetUserNews";
            public const string execute_get_user_photo = "execute.GetUserPhoto";
            public const string execute_mutual_friends = "execute.GetMutualFriends";
            public const string execute_get_fwd_user = "execute.GetFwdUser";
            public const string execute_get_chat = "execute.GetChatConversation";
            public const string load_user_info = "execute.LoadUserInfo";
            public const string load_top_panel = "execute.TopPanel";
            public const string get_friends_request = "execute.GetFriendsRequests";
            public const string get_news = "execute.GetNews";
            public const string get_messages = "execute.GetMessages";
            public const string get_history = "execute.GetHistory";
            public const string get_wall = "execute.GetUserWall";
            public const string get_faves_users = "execute.FavesGetUsers";
            public const string get_group_info = "execute.LoadGroupInfo";
            public const string get_invited_groups = "execute.GetInvitedGroups";
        }
        public enum FriendsOrder
        { 
            Name, Hints, Random, Mobile
        }
    
}
