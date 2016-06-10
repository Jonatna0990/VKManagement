using VKCore.API.SDK;

namespace VKCore.Localization
{
    public sealed class LocalizationsClass
    {
        public static string _1hour
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "1 час";
                }
                if (lang == "en")
                {
                    return "1 hour";
                }
                if (lang == "uk")
                {
                    return "1 година";
                }
                if (lang == "be")
                {
                    return "1 гадзіна";
                }
                return "";
            }
        }

        public static string _24hours
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "24 часа";
                }
                if (lang == "en")
                {
                    return "24 hours";
                }
                if (lang == "uk")
                {
                    return "24 години";
                }
                if (lang == "be")
                {
                    return "24 гадзіны";
                }
                return "";
            }
        }

        public static string _7days
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "7 дней";
                }
                if (lang == "en")
                {
                    return "7 days";
                }
                if (lang == "uk")
                {
                    return "7 днів";
                }
                if (lang == "be")
                {
                    return "7 дзён";
                }
                return "";
            }
        }

        public static string _Like
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "«Мне нравится»";
                }
                if (lang == "en")
                {
                    return "\"Like\"";
                }
                if (lang == "uk")
                {
                    return "«Мені подобається»";
                }
                if (lang == "be")
                {
                    return "«Мне падабаецца»";
                }
                return "";
            }
        }

        public static string About
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "О приложении";
                }
                if (lang == "en")
                {
                    return "About";
                }
                if (lang == "uk")
                {
                    return "Про додаток";
                }
                if (lang == "be")
                {
                    return "Пра дадатак";
                }
                return "";
            }
        }

        public static string AboutMe
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "О себе";
                }
                if (lang == "en")
                {
                    return "About me";
                }
                if (lang == "uk")
                {
                    return "Про себе";
                }
                if (lang == "be")
                {
                    return "Пра сябе";
                }
                return "";
            }
        }

        public static string Accept
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Принять";
                }
                if (lang == "en")
                {
                    return "Accept";
                }
                if (lang == "uk")
                {
                    return "Прийняти";
                }
                if (lang == "be")
                {
                    return "Прыняць";
                }
                return "";
            }
        }

        public static string AcceptedRequests
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Принятые заявки";
                }
                if (lang == "en")
                {
                    return "Accepted requests";
                }
                if (lang == "uk")
                {
                    return "Прийняті заявки";
                }
                if (lang == "be")
                {
                    return "Прынятыя заяўкі";
                }
                return "";
            }
        }

        public static string acceptedYourFriendRequest_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "приняла Вашу заявку в друзья";
                }
                if (lang == "en")
                {
                    return "accepted your friend request";
                }
                if (lang == "uk")
                {
                    return "прийняла Вашу заявку в друзі";
                }
                if (lang == "be")
                {
                    return "прыняла Вашу заяўку ў сябры";
                }
                return "";
            }
        }

        public static string acceptedYourFriendRequest_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "принял Вашу заявку в друзья";
                }
                if (lang == "en")
                {
                    return "accepted your friend request";
                }
                if (lang == "uk")
                {
                    return "прийняв Вашу заявку в друзі";
                }
                if (lang == "be")
                {
                    return "прыняў Вашу заяўку ў сябры";
                }
                return "";
            }
        }

        public static string acceptedYourFriendRequests
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "приняли Ваши заявки в друзья";
                }
                if (lang == "en")
                {
                    return "accepted your friend requests";
                }
                if (lang == "uk")
                {
                    return "прийняли Ваші заявки в друзі";
                }
                if (lang == "be")
                {
                    return "прынялі Вашы заяўкі ў сябры";
                }
                return "";
            }
        }

        public static string AcceptInvitation
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Принять приглашение";
                }
                if (lang == "en")
                {
                    return "Accept invitation";
                }
                if (lang == "uk")
                {
                    return "Прийняти запрошення";
                }
                if (lang == "be")
                {
                    return "Прыняць запрашэнне";
                }
                return "";
            }
        }

        public static string AcceptRequest
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Принять заявку";
                }
                if (lang == "en")
                {
                    return "Accept request";
                }
                if (lang == "uk")
                {
                    return "Прийняти заявку";
                }
                if (lang == "be")
                {
                    return "Прыняць заяўку";
                }
                return "";
            }
        }

        public static string AccessToThisPageWasRestrictedByUser
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Доступ к странице ограничен пользователем.";
                }
                if (lang == "en")
                {
                    return "Access to this page was restricted by user.";
                }
                if (lang == "uk")
                {
                    return "Доступ до сторінки обмежений користувачем.";
                }
                if (lang == "be")
                {
                    return "Доступ да старонкі абмежаваны карыстальнікам.";
                }
                return "";
            }
        }

        public static string Account
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Аккаунт";
                }
                if (lang == "en")
                {
                    return "Account";
                }
                if (lang == "uk")
                {
                    return "Акаунт";
                }
                if (lang == "be")
                {
                    return "Акаўнт";
                }
                return "";
            }
        }

        public static string Actions
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Действия";
                }
                if (lang == "en")
                {
                    return "Actions";
                }
                if (lang == "uk")
                {
                    return "Дії";
                }
                if (lang == "be")
                {
                    return "Дзеянні";
                }
                return "";
            }
        }

        public static string ActivelySearching
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "В активном поиске";
                }
                if (lang == "en")
                {
                    return "Actively searching";
                }
                if (lang == "uk")
                {
                    return "В активному пошуку";
                }
                if (lang == "be")
                {
                    return "У актыўным пошуку";
                }
                return "";
            }
        }

        public static string Activity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Деятельность";
                }
                if (lang == "en")
                {
                    return "Activity";
                }
                if (lang == "uk")
                {
                    return "Діяльність";
                }
                if (lang == "be")
                {
                    return "Дзейнасць";
                }
                return "";
            }
        }

        public static string Add
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить";
                }
                if (lang == "en")
                {
                    return "Add";
                }
                if (lang == "uk")
                {
                    return "Додати";
                }
                if (lang == "be")
                {
                    return "Дадаць";
                }
                return "";
            }
        }

        public static string AddConversationPerson
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить собеседника";
                }
                if (lang == "en")
                {
                    return "Add person";
                }
                if (lang == "uk")
                {
                    return "Додати співрозмовника";
                }
                if (lang == "be")
                {
                    return "Дадаць суразмоўцу";
                }
                return "";
            }
        }

        public static string AddDocument
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить документ";
                }
                if (lang == "en")
                {
                    return "Add document";
                }
                if (lang == "uk")
                {
                    return "Додати документ";
                }
                if (lang == "be")
                {
                    return "Дадаць дакумент";
                }
                return "";
            }
        }

        public static string Added
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавлено";
                }
                if (lang == "en")
                {
                    return "Added";
                }
                if (lang == "uk")
                {
                    return "Додано";
                }
                if (lang == "be")
                {
                    return "Дададзены";
                }
                return "";
            }
        }

        public static string AddingOfThisAudioFailed
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось добавить эту аудиозапись.";
                }
                if (lang == "en")
                {
                    return "Adding of this audio failed.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося додати цей аудіозапис.";
                }
                if (lang == "be")
                {
                    return "Не атрымалася дадаць гэты аўдыязапіс.";
                }
                return "";
            }
        }

        public static string AddingOfThisDocumentFailed
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось добавить этот документ.";
                }
                if (lang == "en")
                {
                    return "Adding of this document failed.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося додати цей документ.";
                }
                if (lang == "be")
                {
                    return "Не атрымалася дадаць гэты дакумент.";
                }
                return "";
            }
        }

        public static string AddingOfThisPhotoFailed
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось добавить эту фотографию.";
                }
                if (lang == "en")
                {
                    return "Adding of this photo failed.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося додати цей фотографію.";
                }
                if (lang == "be")
                {
                    return "Не атрымалася дадаць гэты фотаздымак.";
                }
                return "";
            }
        }

        public static string AddingOfThisVideoFailed
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось добавить эту видеозапись.";
                }
                if (lang == "en")
                {
                    return "Adding of this video failed.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося додати цей відеозапис.";
                }
                if (lang == "be")
                {
                    return "Не атрымалась дадаць гэты відэазапіс.";
                }
                return "";
            }
        }

        public static string AddLink
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить ссылку";
                }
                if (lang == "en")
                {
                    return "Add link";
                }
                if (lang == "uk")
                {
                    return "Додати посилання";
                }
                if (lang == "be")
                {
                    return "Дадаць спасылку";
                }
                return "";
            }
        }

        public static string AddPhotos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить фотографии";
                }
                if (lang == "en")
                {
                    return "Add photos";
                }
                if (lang == "uk")
                {
                    return "Додати фотографії";
                }
                if (lang == "be")
                {
                    return "Дадаць фотаздымкі";
                }
                return "";
            }
        }

        public static string AddToAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить в альбом";
                }
                if (lang == "en")
                {
                    return "Add to album";
                }
                if (lang == "uk")
                {
                    return "Додати в альбом";
                }
                if (lang == "be")
                {
                    return "Дадаць у альбом";
                }
                return "";
            }
        }

        public static string AddToBookmarks
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить в закладки";
                }
                if (lang == "en")
                {
                    return "Add to bookmarks";
                }
                if (lang == "uk")
                {
                    return "Додати до закладок";
                }
                if (lang == "be")
                {
                    return "Дадаць у закладкі";
                }
                return "";
            }
        }

        public static string AddToFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить в друзья";
                }
                if (lang == "en")
                {
                    return "Add to friends";
                }
                if (lang == "uk")
                {
                    return "Долучити до друзів";
                }
                if (lang == "be")
                {
                    return "Дадаць да сяброў";
                }
                return "";
            }
        }

        public static string AddToList
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить в список";
                }
                if (lang == "en")
                {
                    return "Add to list";
                }
                if (lang == "uk")
                {
                    return "Додати в список";
                }
                if (lang == "be")
                {
                    return "Дадаць у спіс";
                }
                return "";
            }
        }

        public static string AddToMe
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить себе";
                }
                if (lang == "en")
                {
                    return "Add to me";
                }
                if (lang == "uk")
                {
                    return "Додати собі";
                }
                if (lang == "be")
                {
                    return "Дадаць сабе";
                }
                return "";
            }
        }

        public static string AddViaLink
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить по ссылке";
                }
                if (lang == "en")
                {
                    return "Add via link";
                }
                if (lang == "uk")
                {
                    return "Додати по посиланню";
                }
                if (lang == "be")
                {
                    return "Дадаць па спасылцы";
                }
                return "";
            }
        }

        public static string AddVideo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Добавить видеозапись";
                }
                if (lang == "en")
                {
                    return "Add video";
                }
                if (lang == "uk")
                {
                    return "Додати відеозапис";
                }
                if (lang == "be")
                {
                    return "Дадаць відэазапіс";
                }
                return "";
            }
        }

        public static string Administration
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Администрация";
                }
                if (lang == "en")
                {
                    return "Administration";
                }
                if (lang == "uk")
                {
                    return "Адміністрація";
                }
                if (lang == "be")
                {
                    return "Адміністрацыя";
                }
                return "";
            }
        }

        public static string Administrator
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Администратор";
                }
                if (lang == "en")
                {
                    return "Administrator";
                }
                if (lang == "uk")
                {
                    return "Адміністратор";
                }
                if (lang == "be")
                {
                    return "Адміністратар";
                }
                return "";
            }
        }

        public static string AdultContent
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Материал для взрослых";
                }
                if (lang == "en")
                {
                    return "Adult content";
                }
                if (lang == "uk")
                {
                    return "Матеріал для дорослих";
                }
                if (lang == "be")
                {
                    return "Матэрыял для дарослых";
                }
                return "";
            }
        }

        public static string AdvancedSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Расширенный поиск";
                }
                if (lang == "en")
                {
                    return "Advanced search";
                }
                if (lang == "uk")
                {
                    return "Розширений пошук";
                }
                if (lang == "be")
                {
                    return "Пашыраны пошук";
                }
                return "";
            }
        }

        public static string Age
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Возраст";
                }
                if (lang == "en")
                {
                    return "Age";
                }
                if (lang == "uk")
                {
                    return "Вік";
                }
                if (lang == "be")
                {
                    return "Узрост";
                }
                return "";
            }
        }

        public static string album1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "альбом";
                }
                if (lang == "en")
                {
                    return "album";
                }
                if (lang == "uk")
                {
                    return "альбом";
                }
                if (lang == "be")
                {
                    return "альбом";
                }
                return "";
            }
        }

        public static string album2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "альбома";
                }
                if (lang == "en")
                {
                    return "albums";
                }
                if (lang == "uk")
                {
                    return "альбоми";
                }
                if (lang == "be")
                {
                    return "альбомы";
                }
                return "";
            }
        }

        public static string album3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "альбомов";
                }
                if (lang == "en")
                {
                    return "albums";
                }
                if (lang == "uk")
                {
                    return "альбомів";
                }
                if (lang == "be")
                {
                    return "альбомаў";
                }
                return "";
            }
        }

        public static string AlbumCreating
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Создание альбома";
                }
                if (lang == "en")
                {
                    return "Album creating";
                }
                if (lang == "uk")
                {
                    return "Створення альбома";
                }
                if (lang == "be")
                {
                    return "Стварэнне альбома";
                }
                return "";
            }
        }

        public static string Albums
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Альбомы";
                }
                if (lang == "en")
                {
                    return "Albums";
                }
                if (lang == "uk")
                {
                    return "Альбоми";
                }
                if (lang == "be")
                {
                    return "Альбомы";
                }
                return "";
            }
        }

        public static string All
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Все";
                }
                if (lang == "en")
                {
                    return "All";
                }
                if (lang == "uk")
                {
                    return "Всі";
                }
                if (lang == "be")
                {
                    return "Усе";
                }
                return "";
            }
        }

        public static string AllAudios
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Все аудиозаписи";
                }
                if (lang == "en")
                {
                    return "All audios";
                }
                if (lang == "uk")
                {
                    return "Всі аудіозаписи";
                }
                if (lang == "be")
                {
                    return "Усе аўдыязапісы";
                }
                return "";
            }
        }

        public static string AllDocuments
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Все документы";
                }
                if (lang == "en")
                {
                    return "All documents";
                }
                if (lang == "uk")
                {
                    return "Всі документи";
                }
                if (lang == "be")
                {
                    return "Усе дакументы";
                }
                return "";
            }
        }

        public static string AllFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Все друзья";
                }
                if (lang == "en")
                {
                    return "All friends";
                }
                if (lang == "uk")
                {
                    return "Всі друзі";
                }
                if (lang == "be")
                {
                    return "Усе сябры";
                }
                return "";
            }
        }

        public static string AllPhotos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Все фотографии";
                }
                if (lang == "en")
                {
                    return "All photos";
                }
                if (lang == "uk")
                {
                    return "Всі фотографії";
                }
                if (lang == "be")
                {
                    return "Усе фотаздымкі";
                }
                return "";
            }
        }

        public static string AllPosts
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Все записи";
                }
                if (lang == "en")
                {
                    return "All posts";
                }
                if (lang == "uk")
                {
                    return "Всі записи";
                }
                if (lang == "be")
                {
                    return "Усе запісы";
                }
                return "";
            }
        }

        public static string AllUsers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Все пользователи";
                }
                if (lang == "en")
                {
                    return "All users";
                }
                if (lang == "uk")
                {
                    return "Всі користувачі";
                }
                if (lang == "be")
                {
                    return "Усе карыстальнікі";
                }
                return "";
            }
        }

        public static string AllVideos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Все видеозаписи";
                }
                if (lang == "en")
                {
                    return "All videos";
                }
                if (lang == "uk")
                {
                    return "Всі відеозаписи";
                }
                if (lang == "be")
                {
                    return "Усе відэазапісы";
                }
                return "";
            }
        }

        public static string AlternativePhone
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Дополнительный телефон";
                }
                if (lang == "en")
                {
                    return "Alternative phone";
                }
                if (lang == "uk")
                {
                    return "Додатковий телефон";
                }
                if (lang == "be")
                {
                    return "Дадатковы тэлефон";
                }
                return "";
            }
        }

        public static string AmongArtists
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Среди исполнителей";
                }
                if (lang == "en")
                {
                    return "Among artists";
                }
                if (lang == "uk")
                {
                    return "Серед виконавців";
                }
                if (lang == "be")
                {
                    return "Сярод выканаўцаў";
                }
                return "";
            }
        }

        public static string andOther
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "и ещё";
                }
                if (lang == "en")
                {
                    return "and other";
                }
                if (lang == "uk")
                {
                    return "і ще";
                }
                if (lang == "be")
                {
                    return "і яшчэ";
                }
                return "";
            }
        }

        public static string AnonymousPoll
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Анонимное голосование";
                }
                if (lang == "en")
                {
                    return "Anonymous poll";
                }
                if (lang == "uk")
                {
                    return "Анонімне голосування";
                }
                if (lang == "be")
                {
                    return "Ананімнае галасаванне";
                }
                return "";
            }
        }

        public static string Any
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Любой";
                }
                if (lang == "en")
                {
                    return "Any";
                }
                if (lang == "uk")
                {
                    return "Будь-який";
                }
                if (lang == "be")
                {
                    return "Любы";
                }
                return "";
            }
        }

        public static string Apathetic
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Индифферентные";
                }
                if (lang == "en")
                {
                    return "Apathetic";
                }
                if (lang == "uk")
                {
                    return "Індиферентні";
                }
                if (lang == "be")
                {
                    return "Індыферэнтныя";
                }
                return "";
            }
        }

        public static string Application
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Приложение";
                }
                if (lang == "en")
                {
                    return "Application";
                }
                if (lang == "uk")
                {
                    return "Додаток";
                }
                if (lang == "be")
                {
                    return "Дадатак";
                }
                return "";
            }
        }

        public static string areTyping
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "набирают сообщения";
                }
                if (lang == "en")
                {
                    return "are typing";
                }
                if (lang == "uk")
                {
                    return "набирають повідомлення";
                }
                if (lang == "be")
                {
                    return "пішуць паведамленне";
                }
                return "";
            }
        }

        public static string Artist
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Исполнитель";
                }
                if (lang == "en")
                {
                    return "Artist";
                }
                if (lang == "uk")
                {
                    return "Виконавець";
                }
                if (lang == "be")
                {
                    return "Выканаўца";
                }
                return "";
            }
        }

        public static string At
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "в";
                }
                if (lang == "en")
                {
                    return "at";
                }
                if (lang == "uk")
                {
                    return "о";
                }
                if (lang == "be")
                {
                    return "у";
                }
                return "";
            }
        }

        public static string Attach
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Прикрепить";
                }
                if (lang == "en")
                {
                    return "Attach";
                }
                if (lang == "uk")
                {
                    return "Прикріпити";
                }
                if (lang == "be")
                {
                    return "Прымацаваць";
                }
                return "";
            }
        }

        public static string attachment1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "вложение";
                }
                if (lang == "en")
                {
                    return "attachment";
                }
                if (lang == "uk")
                {
                    return "вкладення";
                }
                if (lang == "be")
                {
                    return "улажэнне";
                }
                return "";
            }
        }

        public static string attachment2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "вложения";
                }
                if (lang == "en")
                {
                    return "attachments";
                }
                if (lang == "uk")
                {
                    return "вкладення";
                }
                if (lang == "be")
                {
                    return "улажэнні";
                }
                return "";
            }
        }

        public static string attachment3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "вложений";
                }
                if (lang == "en")
                {
                    return "attachments";
                }
                if (lang == "uk")
                {
                    return "вкладень";
                }
                if (lang == "be")
                {
                    return "улажэнняў";
                }
                return "";
            }
        }

        public static string Attachments
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вложения";
                }
                if (lang == "en")
                {
                    return "Attachments";
                }
                if (lang == "uk")
                {
                    return "Вкладення";
                }
                if (lang == "be")
                {
                    return "Улажэнні";
                }
                return "";
            }
        }

        public static string Audio
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Аудиозапись";
                }
                if (lang == "en")
                {
                    return "Audio";
                }
                if (lang == "uk")
                {
                    return "Аудіозапис";
                }
                if (lang == "be")
                {
                    return "Аўдыязапіс";
                }
                return "";
            }
        }

        public static string audio1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "аудиозапись";
                }
                if (lang == "en")
                {
                    return "audio";
                }
                if (lang == "uk")
                {
                    return "аудіозапис";
                }
                if (lang == "be")
                {
                    return "аўдыязапіс";
                }
                return "";
            }
        }

        public static string audio2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "аудиозаписи";
                }
                if (lang == "en")
                {
                    return "audios";
                }
                if (lang == "uk")
                {
                    return "аудіозаписи";
                }
                if (lang == "be")
                {
                    return "аўдыязапісы";
                }
                return "";
            }
        }

        public static string audio3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "аудиозаписей";
                }
                if (lang == "en")
                {
                    return "audios";
                }
                if (lang == "uk")
                {
                    return "аудіозаписів";
                }
                if (lang == "be")
                {
                    return "аўдыязапісаў";
                }
                return "";
            }
        }

        public static string AudioCaching
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Кэширование аудиозаписей";
                }
                if (lang == "en")
                {
                    return "Audios caching";
                }
                if (lang == "uk")
                {
                    return "Кешування аудіозаписів";
                }
                if (lang == "be")
                {
                    return "Кэшынг аўдыязапісаў";
                }
                return "";
            }
        }

        public static string AudioEditing
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменение аудиозаписи";
                }
                if (lang == "en")
                {
                    return "Audio editing";
                }
                if (lang == "uk")
                {
                    return "Зміна аудіозапису";
                }
                if (lang == "be")
                {
                    return "Змена аўдыязапісу";
                }
                return "";
            }
        }

        public static string Audios
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Аудиозаписи";
                }
                if (lang == "en")
                {
                    return "Audios";
                }
                if (lang == "uk")
                {
                    return "Аудіозаписи";
                }
                if (lang == "be")
                {
                    return "Аўдыязапісы";
                }
                return "";
            }
        }

        public static string B
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Б";
                }
                if (lang == "en")
                {
                    return "B";
                }
                if (lang == "uk")
                {
                    return "Б";
                }
                if (lang == "be")
                {
                    return "Б";
                }
                return "";
            }
        }

        public static string BeautyAndArt
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Красота и искусство";
                }
                if (lang == "en")
                {
                    return "Beauty and art";
                }
                if (lang == "uk")
                {
                    return "Краса і мистецтво";
                }
                if (lang == "be")
                {
                    return "Прыгажосць і мастацтва";
                }
                return "";
            }
        }

        public static string BestFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Лучшие друзья";
                }
                if (lang == "en")
                {
                    return "Best friends";
                }
                if (lang == "uk")
                {
                    return "Найкращі друзі";
                }
                if (lang == "be")
                {
                    return "Лепшыя сябры";
                }
                return "";
            }
        }

        public static string Birthday
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "День рождения";
                }
                if (lang == "en")
                {
                    return "Birthday";
                }
                if (lang == "uk")
                {
                    return "День народження";
                }
                if (lang == "be")
                {
                    return "Дзень нараджэння";
                }
                return "";
            }
        }

        public static string Birthdays
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Дни рождения";
                }
                if (lang == "en")
                {
                    return "Birthdays";
                }
                if (lang == "uk")
                {
                    return "Дні народження";
                }
                if (lang == "be")
                {
                    return "Дні нараджэння";
                }
                return "";
            }
        }

        public static string Blacklist
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Чёрный список";
                }
                if (lang == "en")
                {
                    return "Blacklist";
                }
                if (lang == "uk")
                {
                    return "Чорний список";
                }
                if (lang == "be")
                {
                    return "Чорны спiс";
                }
                return "";
            }
        }

        public static string Block
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Заблокировать";
                }
                if (lang == "en")
                {
                    return "Block";
                }
                if (lang == "uk")
                {
                    return "Заблокувати";
                }
                if (lang == "be")
                {
                    return "Заблакаваць";
                }
                return "";
            }
        }

        public static string Bookmarks
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Закладки";
                }
                if (lang == "en")
                {
                    return "Bookmarks";
                }
                if (lang == "uk")
                {
                    return "Закладки";
                }
                if (lang == "be")
                {
                    return "Закладкі";
                }
                return "";
            }
        }

        public static string Broadcast
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Транслировать";
                }
                if (lang == "en")
                {
                    return "Broadcast";
                }
                if (lang == "uk")
                {
                    return "Транслювати";
                }
                if (lang == "be")
                {
                    return "Трансліраваць";
                }
                return "";
            }
        }

        public static string BuyFor
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Купить за";
                }
                if (lang == "en")
                {
                    return "Buy for";
                }
                if (lang == "uk")
                {
                    return "Придбати за";
                }
                if (lang == "be")
                {
                    return "Купіць за";
                }
                return "";
            }
        }

        public static string ByAddingDate
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "По дате добавления";
                }
                if (lang == "en")
                {
                    return "By adding date";
                }
                if (lang == "uk")
                {
                    return "За датою додавання";
                }
                if (lang == "be")
                {
                    return "Па даце дадання";
                }
                return "";
            }
        }

        public static string ByDuration
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "По длительности";
                }
                if (lang == "en")
                {
                    return "By duration";
                }
                if (lang == "uk")
                {
                    return "За тривалістю";
                }
                if (lang == "be")
                {
                    return "Па працягласці";
                }
                return "";
            }
        }

        public static string ByRelevance
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "По релевантности";
                }
                if (lang == "en")
                {
                    return "By relevance";
                }
                if (lang == "uk")
                {
                    return "За релевантністю";
                }
                if (lang == "be")
                {
                    return "Па рэлевантнасці";
                }
                return "";
            }
        }

        public static string Cached
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Кэшированные";
                }
                if (lang == "en")
                {
                    return "Cached";
                }
                if (lang == "uk")
                {
                    return "Кешовані";
                }
                if (lang == "be")
                {
                    return "Кэшыраваныя";
                }
                return "";
            }
        }

        public static string Cancel
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отмена";
                }
                if (lang == "en")
                {
                    return "Cancel";
                }
                if (lang == "uk")
                {
                    return "Скасувати";
                }
                if (lang == "be")
                {
                    return "Адмена";
                }
                return "";
            }
        }

        public static string CancelRequest
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отменить заявку";
                }
                if (lang == "en")
                {
                    return "Cancel request";
                }
                if (lang == "uk")
                {
                    return "Скасувати заявку";
                }
                if (lang == "be")
                {
                    return "Скасаваць заяўку";
                }
                return "";
            }
        }

        public static string CareerAndMoney
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Карьера и деньги";
                }
                if (lang == "en")
                {
                    return "Career and money";
                }
                if (lang == "uk")
                {
                    return "Кар'єра і гроші";
                }
                if (lang == "be")
                {
                    return "Кар'ера і грошы";
                }
                return "";
            }
        }

        public static string Centrist
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Умеренные";
                }
                if (lang == "en")
                {
                    return "Centrist";
                }
                if (lang == "uk")
                {
                    return "Помірні";
                }
                if (lang == "be")
                {
                    return "Памяркоўныя";
                }
                return "";
            }
        }

        public static string ChangeCover
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Обновить фотографию";
                }
                if (lang == "en")
                {
                    return "Change cover";
                }
                if (lang == "uk")
                {
                    return "Оновити фотографію";
                }
                if (lang == "be")
                {
                    return "Абнавіць фотаздымак";
                }
                return "";
            }
        }

        public static string changedConversationCover_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "обновила фотографию беседы";
                }
                if (lang == "en")
                {
                    return "сhanged conversation cover";
                }
                if (lang == "uk")
                {
                    return "оновила фотографію бесіди";
                }
                if (lang == "be")
                {
                    return "абнавіла фотаздымак гутаркі";
                }
                return "";
            }
        }

        public static string changedConversationCover_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "обновил фотографию беседы";
                }
                if (lang == "en")
                {
                    return "сhanged conversation cover";
                }
                if (lang == "uk")
                {
                    return "оновив фотографію бесіди";
                }
                if (lang == "be")
                {
                    return "абнавіў фотаздымак гутаркі";
                }
                return "";
            }
        }

        public static string changedConversationNameTo_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "изменила название беседы на";
                }
                if (lang == "en")
                {
                    return "changed conversation name to";
                }
                if (lang == "uk")
                {
                    return "змінила назву бесіди на";
                }
                if (lang == "be")
                {
                    return "змяніла назву гутаркі на";
                }
                return "";
            }
        }

        public static string changedConversationNameTo_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "изменил название беседы на";
                }
                if (lang == "en")
                {
                    return "changed conversation name to";
                }
                if (lang == "uk")
                {
                    return "змінив назву бесіди на";
                }
                if (lang == "be")
                {
                    return "змяніў назву размовы на";
                }
                return "";
            }
        }

        public static string ChangePassword
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменить пароль";
                }
                if (lang == "en")
                {
                    return "Change password";
                }
                if (lang == "uk")
                {
                    return "Змінити пароль";
                }
                if (lang == "be")
                {
                    return "Змяніць пароль";
                }
                return "";
            }
        }

        public static string ChildPornography
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Детская порнография";
                }
                if (lang == "en")
                {
                    return "Child pornography";
                }
                if (lang == "uk")
                {
                    return "Дитяча порнографія";
                }
                if (lang == "be")
                {
                    return "Дзіцячая парнаграфія";
                }
                return "";
            }
        }

        public static string Children
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Дети";
                }
                if (lang == "en")
                {
                    return "Children";
                }
                if (lang == "uk")
                {
                    return "Діти";
                }
                if (lang == "be")
                {
                    return "Дзеці";
                }
                return "";
            }
        }

        public static string ChooseAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выберите альбом для помещения";
                }
                if (lang == "en")
                {
                    return "Choose album";
                }
                if (lang == "uk")
                {
                    return "Виберіть альбом для поміщення";
                }
                if (lang == "be")
                {
                    return "Выберыце альбом для змяшчэння";
                }
                return "";
            }
        }

        public static string ChooseAudioFileFromYourComputer
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выберите аудиозапись на Вашем компьютере";
                }
                if (lang == "en")
                {
                    return "Choose audio file from your computer";
                }
                if (lang == "uk")
                {
                    return "Виберіть аудіозапис на Вашому комп'ютері";
                }
                if (lang == "be")
                {
                    return "Выберыце аўдыязапіс на Вашым камп'ютары";
                }
                return "";
            }
        }

        public static string ChooseCity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выбор города";
                }
                if (lang == "en")
                {
                    return "Choose city";
                }
                if (lang == "uk")
                {
                    return "Вибір міста";
                }
                if (lang == "be")
                {
                    return "Выбар горада";
                }
                return "";
            }
        }

        public static string ChooseCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выберите сообщество";
                }
                if (lang == "en")
                {
                    return "Choose community";
                }
                if (lang == "uk")
                {
                    return "Виберіть спільноту";
                }
                if (lang == "be")
                {
                    return "Выберыце суполку";
                }
                return "";
            }
        }

        public static string ChooseCountry
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выбор страны";
                }
                if (lang == "en")
                {
                    return "Choose country";
                }
                if (lang == "uk")
                {
                    return "Вибір країни";
                }
                if (lang == "be")
                {
                    return "Выбар краіны";
                }
                return "";
            }
        }

        public static string ChooseDocumentFileFromYourComputer
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выберите документ на Вашем компьютере";
                }
                if (lang == "en")
                {
                    return "Choose document file from your computer";
                }
                if (lang == "uk")
                {
                    return "Виберіть документ на Вашому комп'ютері";
                }
                if (lang == "be")
                {
                    return "Выберыце дакумент на Вашым камп'ютары";
                }
                return "";
            }
        }

        public static string ChooseFile
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выбрать файл";
                }
                if (lang == "en")
                {
                    return "Choose file";
                }
                if (lang == "uk")
                {
                    return "Вибрати файл";
                }
                if (lang == "be")
                {
                    return "Выбраць файл";
                }
                return "";
            }
        }

        public static string ChooseGiftFor
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выберите подарок для";
                }
                if (lang == "en")
                {
                    return "Choose gift for";
                }
                if (lang == "uk")
                {
                    return "Виберіть подарунок для";
                }
                if (lang == "be")
                {
                    return "Выберыце падарунак для";
                }
                return "";
            }
        }

        public static string ChooseRecipient
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выберите получателя";
                }
                if (lang == "en")
                {
                    return "Choose recipient";
                }
                if (lang == "uk")
                {
                    return "Виберіть одержувача";
                }
                if (lang == "be")
                {
                    return "Выберыце атрымальніка";
                }
                return "";
            }
        }

        public static string ChooseStatus
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выбор статуса";
                }
                if (lang == "en")
                {
                    return "Choose status";
                }
                if (lang == "uk")
                {
                    return "Вибір статусу";
                }
                if (lang == "be")
                {
                    return "Выбар статусу";
                }
                return "";
            }
        }

        public static string ChooseTheAudience
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выберите аудиторию";
                }
                if (lang == "en")
                {
                    return "Choose audience";
                }
                if (lang == "uk")
                {
                    return "Виберіть аудиторію";
                }
                if (lang == "be")
                {
                    return "Выберыце аўдыторыю";
                }
                return "";
            }
        }

        public static string ChooseType
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выбор типа";
                }
                if (lang == "en")
                {
                    return "Choose type";
                }
                if (lang == "uk")
                {
                    return "Вибір типу";
                }
                if (lang == "be")
                {
                    return "Выбар тыпу";
                }
                return "";
            }
        }

        public static string ChooseVideoFileFromYourComputer
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выберите видеозапись на Вашем компьютере";
                }
                if (lang == "en")
                {
                    return "Choose video file from your computer";
                }
                if (lang == "uk")
                {
                    return "Виберіть відеозапис на Вашому комп'ютері";
                }
                if (lang == "be")
                {
                    return "Выберыце відэазапіс на Вашым камп'ютары";
                }
                return "";
            }
        }

        public static string City
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Город";
                }
                if (lang == "en")
                {
                    return "City";
                }
                if (lang == "uk")
                {
                    return "Місто";
                }
                if (lang == "be")
                {
                    return "Горад";
                }
                return "";
            }
        }

        public static string ClearAudiosCaching
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Очистить аудиокэш";
                }
                if (lang == "en")
                {
                    return "Clear audios caching";
                }
                if (lang == "uk")
                {
                    return "Очистити аудіокеш";
                }
                if (lang == "be")
                {
                    return "Ачысціць аўдыякэш";
                }
                return "";
            }
        }

        public static string ClearSelection
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сбросить выделение";
                }
                if (lang == "en")
                {
                    return "Clear selection";
                }
                if (lang == "uk")
                {
                    return "Скинути виділення";
                }
                if (lang == "be")
                {
                    return "Скінуць вылучэнне";
                }
                return "";
            }
        }

        public static string Close
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Закрыть";
                }
                if (lang == "en")
                {
                    return "Close";
                }
                if (lang == "uk")
                {
                    return "Закрити";
                }
                if (lang == "be")
                {
                    return "Закрыць";
                }
                return "";
            }
        }

        public static string Collegues
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Коллеги";
                }
                if (lang == "en")
                {
                    return "Collegues";
                }
                if (lang == "uk")
                {
                    return "Колеги";
                }
                if (lang == "be")
                {
                    return "Калегі";
                }
                return "";
            }
        }

        public static string Comment
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Комментарий";
                }
                if (lang == "en")
                {
                    return "Comment";
                }
                if (lang == "uk")
                {
                    return "Коментар";
                }
                if (lang == "be")
                {
                    return "Каментарый";
                }
                return "";
            }
        }

        public static string comment1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "комментарий";
                }
                if (lang == "en")
                {
                    return "comment";
                }
                if (lang == "uk")
                {
                    return "коментар";
                }
                if (lang == "be")
                {
                    return "каментарый";
                }
                return "";
            }
        }

        public static string comment2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "комментария";
                }
                if (lang == "en")
                {
                    return "comments";
                }
                if (lang == "uk")
                {
                    return "коментарі";
                }
                if (lang == "be")
                {
                    return "каментарыі";
                }
                return "";
            }
        }

        public static string comment3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "комментариев";
                }
                if (lang == "en")
                {
                    return "comments";
                }
                if (lang == "uk")
                {
                    return "коментарів";
                }
                if (lang == "be")
                {
                    return "каментарыяў";
                }
                return "";
            }
        }

        public static string Comments
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Комментарии";
                }
                if (lang == "en")
                {
                    return "Comments";
                }
                if (lang == "uk")
                {
                    return "Коментарі";
                }
                if (lang == "be")
                {
                    return "Каментарыі";
                }
                return "";
            }
        }

        public static string CommentToPost
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Комментарий к записи";
                }
                if (lang == "en")
                {
                    return "Comment to post";
                }
                if (lang == "uk")
                {
                    return "Коментар до запису";
                }
                if (lang == "be")
                {
                    return "Каментарый да запісу";
                }
                return "";
            }
        }

        public static string Communist
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Коммунистические";
                }
                if (lang == "en")
                {
                    return "Communist";
                }
                if (lang == "uk")
                {
                    return "Комуністичні";
                }
                if (lang == "be")
                {
                    return "Камуністычныя";
                }
                return "";
            }
        }

        public static string Communities
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сообщества";
                }
                if (lang == "en")
                {
                    return "Communities";
                }
                if (lang == "uk")
                {
                    return "Спільноти";
                }
                if (lang == "be")
                {
                    return "Суполкі";
                }
                return "";
            }
        }

        public static string CommunitiesInvitations
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Приглашения в сообщества";
                }
                if (lang == "en")
                {
                    return "Communities invitations";
                }
                if (lang == "uk")
                {
                    return "Запрошення в спільноти";
                }
                if (lang == "be")
                {
                    return "Запрашэнні ў суполкі";
                }
                return "";
            }
        }

        public static string CommunitiesSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поиск сообществ";
                }
                if (lang == "en")
                {
                    return "Communities search";
                }
                if (lang == "uk")
                {
                    return "Пошук спільнот";
                }
                if (lang == "be")
                {
                    return "Пошук суполак";
                }
                return "";
            }
        }

        public static string community1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сообщество";
                }
                if (lang == "en")
                {
                    return "community";
                }
                if (lang == "uk")
                {
                    return "спільнота";
                }
                if (lang == "be")
                {
                    return "суполка";
                }
                return "";
            }
        }

        public static string community2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сообщества";
                }
                if (lang == "en")
                {
                    return "communities";
                }
                if (lang == "uk")
                {
                    return "спільноти";
                }
                if (lang == "be")
                {
                    return "суполкі";
                }
                return "";
            }
        }

        public static string community3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сообществ";
                }
                if (lang == "en")
                {
                    return "communities";
                }
                if (lang == "uk")
                {
                    return "спільнот";
                }
                if (lang == "be")
                {
                    return "суполак";
                }
                return "";
            }
        }

        public static string CommunityMembers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Участники сообщества";
                }
                if (lang == "en")
                {
                    return "Community members";
                }
                if (lang == "uk")
                {
                    return "Учасники спільноти";
                }
                if (lang == "be")
                {
                    return "Удзельнікі суполкі";
                }
                return "";
            }
        }

        public static string communityPhotoWasUpdated
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "обновлена фотография сообщества";
                }
                if (lang == "en")
                {
                    return "community photo was updated";
                }
                if (lang == "uk")
                {
                    return "оновлена ​​фотографія спільноти";
                }
                if (lang == "be")
                {
                    return "абноўлены фотаздымак суполкі";
                }
                return "";
            }
        }

        public static string CommunityType
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Тип сообщества";
                }
                if (lang == "en")
                {
                    return "Сommunity type";
                }
                if (lang == "uk")
                {
                    return "Тип спільноти";
                }
                if (lang == "be")
                {
                    return "Тып суполкі";
                }
                return "";
            }
        }

        public static string CommunityWasBlockedByAdministration
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сообщество заблокировано администрацией.";
                }
                if (lang == "en")
                {
                    return "Community was blocked by administration.";
                }
                if (lang == "uk")
                {
                    return "Спільнота заблокована адміністрацією.";
                }
                if (lang == "be")
                {
                    return "Суполка заблакавана адміністрацыяй.";
                }
                return "";
            }
        }

        public static string Company
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Место работы";
                }
                if (lang == "en")
                {
                    return "Company";
                }
                if (lang == "uk")
                {
                    return "Місце роботи";
                }
                if (lang == "be")
                {
                    return "Месца працы";
                }
                return "";
            }
        }

        public static string Compromisable
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Компромиссное";
                }
                if (lang == "en")
                {
                    return "Compromisable";
                }
                if (lang == "uk")
                {
                    return "Компромісне";
                }
                if (lang == "be")
                {
                    return "Кампраміснае";
                }
                return "";
            }
        }

        public static string Confirm
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Продолжить";
                }
                if (lang == "en")
                {
                    return "Confirm";
                }
                if (lang == "uk")
                {
                    return "Продовжити";
                }
                if (lang == "be")
                {
                    return "Працягнуць";
                }
                return "";
            }
        }

        public static string Conservative
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Консервативные";
                }
                if (lang == "en")
                {
                    return "Conservative";
                }
                if (lang == "uk")
                {
                    return "Консервативні";
                }
                if (lang == "be")
                {
                    return "Кансерватыўныя";
                }
                return "";
            }
        }

        public static string Contacts
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Контакты";
                }
                if (lang == "en")
                {
                    return "Contacts";
                }
                if (lang == "uk")
                {
                    return "Контакти";
                }
                if (lang == "be")
                {
                    return "Кантакты";
                }
                return "";
            }
        }

        public static string ConversationCreator
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Создатель беседы";
                }
                if (lang == "en")
                {
                    return "Conversation creator";
                }
                if (lang == "uk")
                {
                    return "Творець бесіди";
                }
                if (lang == "be")
                {
                    return "Стваральнік гутаркі";
                }
                return "";
            }
        }

        public static string ConversationIsNotSelected
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Диалог не выбран";
                }
                if (lang == "en")
                {
                    return "Conversation is not selected";
                }
                if (lang == "uk")
                {
                    return "Діалог не обраний";
                }
                if (lang == "be")
                {
                    return "Дыялог не выбраны";
                }
                return "";
            }
        }

        public static string ConversationName
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Название беседы";
                }
                if (lang == "en")
                {
                    return "Conversation name";
                }
                if (lang == "uk")
                {
                    return "Назва бесіди";
                }
                if (lang == "be")
                {
                    return "Назва гутаркі";
                }
                return "";
            }
        }

        public static string Conversations
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Диалоги";
                }
                if (lang == "en")
                {
                    return "Conversations";
                }
                if (lang == "uk")
                {
                    return "Діалоги";
                }
                if (lang == "be")
                {
                    return "Дыялогі";
                }
                return "";
            }
        }

        public static string ConversationsSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поиск диалогов";
                }
                if (lang == "en")
                {
                    return "Conversations search";
                }
                if (lang == "uk")
                {
                    return "Пошук діалогів";
                }
                if (lang == "be")
                {
                    return "Пошук дыялогаў";
                }
                return "";
            }
        }

        public static string Copies
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Копии";
                }
                if (lang == "en")
                {
                    return "Copies";
                }
                if (lang == "uk")
                {
                    return "Копії";
                }
                if (lang == "be")
                {
                    return "Копіі";
                }
                return "";
            }
        }

        public static string CopyLink
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Скопировать ссылку";
                }
                if (lang == "en")
                {
                    return "Copy link";
                }
                if (lang == "uk")
                {
                    return "Копіювати посилання";
                }
                if (lang == "be")
                {
                    return "Скапіраваць спасылку";
                }
                return "";
            }
        }

        public static string CopyText
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Скопировать текст";
                }
                if (lang == "en")
                {
                    return "Copy text";
                }
                if (lang == "uk")
                {
                    return "Копіювати текст";
                }
                if (lang == "be")
                {
                    return "Скапіраваць тэкст";
                }
                return "";
            }
        }

        public static string Country
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Страна";
                }
                if (lang == "en")
                {
                    return "Country";
                }
                if (lang == "uk")
                {
                    return "Країна";
                }
                if (lang == "be")
                {
                    return "Краіна";
                }
                return "";
            }
        }

        public static string CourageAndPersistence
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Смелость и упорство";
                }
                if (lang == "en")
                {
                    return "Courage and persistence";
                }
                if (lang == "uk")
                {
                    return "Сміливість і завзятість";
                }
                if (lang == "be")
                {
                    return "Смеласць і ўпартасць";
                }
                return "";
            }
        }

        public static string CreateAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Создать альбом";
                }
                if (lang == "en")
                {
                    return "Create album";
                }
                if (lang == "uk")
                {
                    return "Створити альбом";
                }
                if (lang == "be")
                {
                    return "Стварыць альбом";
                }
                return "";
            }
        }

        public static string CreateComment
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Комментировать";
                }
                if (lang == "en")
                {
                    return "Comment";
                }
                if (lang == "uk")
                {
                    return "Коментувати";
                }
                if (lang == "be")
                {
                    return "Каментаваць";
                }
                return "";
            }
        }

        public static string CreateConversation
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Создать беседу";
                }
                if (lang == "en")
                {
                    return "Create conversation";
                }
                if (lang == "uk")
                {
                    return "Створити бесіду";
                }
                if (lang == "be")
                {
                    return "Стварыць гутарку";
                }
                return "";
            }
        }

        public static string CreateList
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Создать список";
                }
                if (lang == "en")
                {
                    return "Create list";
                }
                if (lang == "uk")
                {
                    return "Створити список";
                }
                if (lang == "be")
                {
                    return "Стварыць спіс";
                }
                return "";
            }
        }

        public static string createTheConversation_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "создала беседу";
                }
                if (lang == "en")
                {
                    return "created the conversation";
                }
                if (lang == "uk")
                {
                    return "створила бесіду";
                }
                if (lang == "be")
                {
                    return "стварыла гутарку";
                }
                return "";
            }
        }

        public static string createTheConversation_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "создал беседу";
                }
                if (lang == "en")
                {
                    return "created the conversation";
                }
                if (lang == "uk")
                {
                    return "створив бесіду";
                }
                if (lang == "be")
                {
                    return "стварыў гутарку";
                }
                return "";
            }
        }

        public static string CurrentPassword
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Старый пароль";
                }
                if (lang == "en")
                {
                    return "Current password";
                }
                if (lang == "uk")
                {
                    return "Старий пароль";
                }
                if (lang == "be")
                {
                    return "Стары пароль";
                }
                return "";
            }
        }

        public static string CustomScaling
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Адаптивное масштабирование";
                }
                if (lang == "en")
                {
                    return "Adaptive scaling";
                }
                if (lang == "uk")
                {
                    return "Адаптивне масштабування";
                }
                if (lang == "be")
                {
                    return "Адаптыўнае маштабаванне";
                }
                return "";
            }
        }

        public static string CustomScalingHint
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Для правильного переключения масштабирования приложение сейчас будет автоматически закрыто.";
                }
                if (lang == "en")
                {
                    return "In order to properly switch over scaling the app will close automatically.";
                }
                if (lang == "uk")
                {
                    return "Для правильного перемикання масштабування додаток зараз буде автоматично закрито.";
                }
                if (lang == "be")
                {
                    return "Для правільнага пераключэння маштабавання дадатак зараз будзе аўтаматычна закрыты.";
                }
                return "";
            }
        }

        public static string Dating
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Встречается";
                }
                if (lang == "en")
                {
                    return "Dating";
                }
                if (lang == "uk")
                {
                    return "Зустрічається";
                }
                if (lang == "be")
                {
                    return "Сустракацца";
                }
                return "";
            }
        }

        public static string DatingWith
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Встречается с";
                }
                if (lang == "en")
                {
                    return "Dating";
                }
                if (lang == "uk")
                {
                    return "Зустрічається з";
                }
                if (lang == "be")
                {
                    return "Сустракаецца з";
                }
                return "";
            }
        }

        public static string Decline
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отклонить";
                }
                if (lang == "en")
                {
                    return "Decline";
                }
                if (lang == "uk")
                {
                    return "Відхилити";
                }
                if (lang == "be")
                {
                    return "Адхіліць";
                }
                return "";
            }
        }

        public static string Delete
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить";
                }
                if (lang == "en")
                {
                    return "Delete";
                }
                if (lang == "uk")
                {
                    return "Видалити";
                }
                if (lang == "be")
                {
                    return "Выдаліць";
                }
                return "";
            }
        }

        public static string DeleteAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить альбом";
                }
                if (lang == "en")
                {
                    return "Delete album";
                }
                if (lang == "uk")
                {
                    return "Видалити альбом";
                }
                if (lang == "be")
                {
                    return "Выдаліць альбом";
                }
                return "";
            }
        }

        public static string DeleteAudio
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить аудиозапись";
                }
                if (lang == "en")
                {
                    return "Delete audio";
                }
                if (lang == "uk")
                {
                    return "Видалити аудіозапис";
                }
                if (lang == "be")
                {
                    return "Выдаліць аўдыязапіс";
                }
                return "";
            }
        }

        public static string DeleteComment
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить комментарий";
                }
                if (lang == "en")
                {
                    return "Delete comment";
                }
                if (lang == "uk")
                {
                    return "Видалити коментар";
                }
                if (lang == "be")
                {
                    return "Выдаліць каментарый";
                }
                return "";
            }
        }

        public static string DeleteConversation
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить диалог";
                }
                if (lang == "en")
                {
                    return "Delete conversation";
                }
                if (lang == "uk")
                {
                    return "Видалити діалог";
                }
                if (lang == "be")
                {
                    return "Выдаліць дыялог";
                }
                return "";
            }
        }

        public static string deleteConversationCover_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "удалила фотографию беседы";
                }
                if (lang == "en")
                {
                    return "deleted conversation cover";
                }
                if (lang == "uk")
                {
                    return "видалила фотографію бесіди";
                }
                if (lang == "be")
                {
                    return "выдаліла фотаздымак гутаркі";
                }
                return "";
            }
        }

        public static string deleteConversationCover_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "удалил фотографию беседы";
                }
                if (lang == "en")
                {
                    return "deleted conversation cover";
                }
                if (lang == "uk")
                {
                    return "видалив фотографію бесіди";
                }
                if (lang == "be")
                {
                    return "выдаліў фотаздымак гутаркі";
                }
                return "";
            }
        }

        public static string DeleteCover
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить фотографию";
                }
                if (lang == "en")
                {
                    return "Delete cover";
                }
                if (lang == "uk")
                {
                    return "Видалити фотографію";
                }
                if (lang == "be")
                {
                    return "Выдаліць фотаздымак";
                }
                return "";
            }
        }

        public static string DeleteDocument
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить документ";
                }
                if (lang == "en")
                {
                    return "Delete document";
                }
                if (lang == "uk")
                {
                    return "Видалити документ";
                }
                if (lang == "be")
                {
                    return "Выдаліць дакумент";
                }
                return "";
            }
        }

        public static string deletedPageWithTheseWords_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "удалила страницу со словами";
                }
                if (lang == "en")
                {
                    return "deleted her page with these words";
                }
                if (lang == "uk")
                {
                    return "видалила сторінку зі словами";
                }
                if (lang == "be")
                {
                    return "выдаліла старонку са словамі";
                }
                return "";
            }
        }

        public static string deletedPageWithTheseWords_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "удалил страницу со словами";
                }
                if (lang == "en")
                {
                    return "deleted his page with these words";
                }
                if (lang == "uk")
                {
                    return "видалив сторінку зі словами";
                }
                if (lang == "be")
                {
                    return "выдаліў старонку са словамі";
                }
                return "";
            }
        }

        public static string DeleteList
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить список";
                }
                if (lang == "en")
                {
                    return "Delete list";
                }
                if (lang == "uk")
                {
                    return "Видалити список";
                }
                if (lang == "be")
                {
                    return "Выдаліць спіс";
                }
                return "";
            }
        }

        public static string DeleteMessage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить сообщение";
                }
                if (lang == "en")
                {
                    return "Delete message";
                }
                if (lang == "uk")
                {
                    return "Видалити повідомлення";
                }
                if (lang == "be")
                {
                    return "Выдаліць паведамленне";
                }
                return "";
            }
        }

        public static string DeleteMessages
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить сообщения";
                }
                if (lang == "en")
                {
                    return "Delete messages";
                }
                if (lang == "uk")
                {
                    return "Видалити повідомлення";
                }
                if (lang == "be")
                {
                    return "Выдаліць паведамленні";
                }
                return "";
            }
        }

        public static string DeletePhoto
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить фотографию";
                }
                if (lang == "en")
                {
                    return "Delete photo";
                }
                if (lang == "uk")
                {
                    return "Видалити фотографію";
                }
                if (lang == "be")
                {
                    return "Выдаліць фотаздымак";
                }
                return "";
            }
        }

        public static string DeletePost
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить запись";
                }
                if (lang == "en")
                {
                    return "Delete post";
                }
                if (lang == "uk")
                {
                    return "Видалити запис";
                }
                if (lang == "be")
                {
                    return "Выдаліць запіс";
                }
                return "";
            }
        }

        public static string DeleteVideo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Удалить видеозапись";
                }
                if (lang == "en")
                {
                    return "Delete video";
                }
                if (lang == "uk")
                {
                    return "Видалити відеозапис";
                }
                if (lang == "be")
                {
                    return "Выдаліць відэазапіс";
                }
                return "";
            }
        }

        public static string Description
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Описание";
                }
                if (lang == "en")
                {
                    return "Description";
                }
                if (lang == "uk")
                {
                    return "Опис";
                }
                if (lang == "be")
                {
                    return "Апісанне";
                }
                return "";
            }
        }

        public static string Dev_MikhailLikhachyov
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Михаил Лихачёв";
                }
                if (lang == "en")
                {
                    return "Mikhail Likhachyov";
                }
                if (lang == "uk")
                {
                    return "Михайло Лихачов";
                }
                if (lang == "be")
                {
                    return "Міхаіл Ліхачоў";
                }
                return "";
            }
        }

        public static string Dev_SergeyMoskvin
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сергей Москвин";
                }
                if (lang == "en")
                {
                    return "Sergey Moskvin";
                }
                if (lang == "uk")
                {
                    return "Сергій Москвін";
                }
                if (lang == "be")
                {
                    return "Сяргей Масквін";
                }
                return "";
            }
        }

        public static string Developers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Разработчики";
                }
                if (lang == "en")
                {
                    return "Developers";
                }
                if (lang == "uk")
                {
                    return "Розробники";
                }
                if (lang == "be")
                {
                    return "Распрацоўнікі";
                }
                return "";
            }
        }

        public static string DisabledStickers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отключенные стикеры";
                }
                if (lang == "en")
                {
                    return "Disabled stickers";
                }
                if (lang == "uk")
                {
                    return "Відключені стікери";
                }
                if (lang == "be")
                {
                    return "Адключаныя стыкеры";
                }
                return "";
            }
        }

        public static string DiscussionInCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Обсуждение в сообществе";
                }
                if (lang == "en")
                {
                    return "Discussion in community";
                }
                if (lang == "uk")
                {
                    return "Обговорення в спільноті";
                }
                if (lang == "be")
                {
                    return "Абмеркаванне ў суполцы";
                }
                return "";
            }
        }

        public static string Discussions
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Обсуждения";
                }
                if (lang == "en")
                {
                    return "Discussions";
                }
                if (lang == "uk")
                {
                    return "Обговорення";
                }
                if (lang == "be")
                {
                    return "Абмеркаванні";
                }
                return "";
            }
        }

        public static string Document
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Документ";
                }
                if (lang == "en")
                {
                    return "Document";
                }
                if (lang == "uk")
                {
                    return "Документ";
                }
                if (lang == "be")
                {
                    return "Дакумент";
                }
                return "";
            }
        }

        public static string document1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "документ";
                }
                if (lang == "en")
                {
                    return "document";
                }
                if (lang == "uk")
                {
                    return "документ";
                }
                if (lang == "be")
                {
                    return "дакумент";
                }
                return "";
            }
        }

        public static string document2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "документа";
                }
                if (lang == "en")
                {
                    return "documents";
                }
                if (lang == "uk")
                {
                    return "документи";
                }
                if (lang == "be")
                {
                    return "дакументы";
                }
                return "";
            }
        }

        public static string document3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "документов";
                }
                if (lang == "en")
                {
                    return "documents";
                }
                if (lang == "uk")
                {
                    return "документів";
                }
                if (lang == "be")
                {
                    return "дакументаў";
                }
                return "";
            }
        }

        public static string Documents
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Документы";
                }
                if (lang == "en")
                {
                    return "Documents";
                }
                if (lang == "uk")
                {
                    return "Документи";
                }
                if (lang == "be")
                {
                    return "Дакументы";
                }
                return "";
            }
        }

        public static string DoNotBroadcast
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не транслировать";
                }
                if (lang == "en")
                {
                    return "Do not broadcast";
                }
                if (lang == "uk")
                {
                    return "Не транслювати";
                }
                if (lang == "be")
                {
                    return "Не трансліраваць";
                }
                return "";
            }
        }

        public static string DoNotDisturb
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не беспокоить";
                }
                if (lang == "en")
                {
                    return "Do not disturb";
                }
                if (lang == "uk")
                {
                    return "Не турбувати";
                }
                if (lang == "be")
                {
                    return "Не турбаваць";
                }
                return "";
            }
        }

        public static string DoNotShowInSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не выводить при поиске";
                }
                if (lang == "en")
                {
                    return "Do not show in search";
                }
                if (lang == "uk")
                {
                    return "Не виводити при пошуку";
                }
                if (lang == "be")
                {
                    return "Не выводзіць пры пошуку";
                }
                return "";
            }
        }

        public static string DownloadOriginalFile
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Загрузить оригинал";
                }
                if (lang == "en")
                {
                    return "Download original file";
                }
                if (lang == "uk")
                {
                    return "Завантажити оригінал";
                }
                if (lang == "be")
                {
                    return "Загрузіць арыгінал";
                }
                return "";
            }
        }

        public static string DrugsAdvocacy
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пропаганда наркотиков";
                }
                if (lang == "en")
                {
                    return "Drug advocacy";
                }
                if (lang == "uk")
                {
                    return "Пропаганда наркотиків";
                }
                if (lang == "be")
                {
                    return "Прапаганда наркотыкаў";
                }
                return "";
            }
        }

        public static string Duration
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Длительность";
                }
                if (lang == "en")
                {
                    return "Duration";
                }
                if (lang == "uk")
                {
                    return "Тривалість";
                }
                if (lang == "be")
                {
                    return "Працягласць";
                }
                return "";
            }
        }

        public static string Edit
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменить";
                }
                if (lang == "en")
                {
                    return "Edit";
                }
                if (lang == "uk")
                {
                    return "Змінити";
                }
                if (lang == "be")
                {
                    return "Змяніць";
                }
                return "";
            }
        }

        public static string EditAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменить альбом";
                }
                if (lang == "en")
                {
                    return "Edit album";
                }
                if (lang == "uk")
                {
                    return "Змінити альбом";
                }
                if (lang == "be")
                {
                    return "Змяніць альбом";
                }
                return "";
            }
        }

        public static string EditAudio
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменить аудиозапись";
                }
                if (lang == "en")
                {
                    return "Edit audio";
                }
                if (lang == "uk")
                {
                    return "Змінити аудіозапис";
                }
                if (lang == "be")
                {
                    return "Змяніць аўдыязапіс";
                }
                return "";
            }
        }

        public static string EditConversationName
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменить название беседы";
                }
                if (lang == "en")
                {
                    return "Edit conversation name";
                }
                if (lang == "uk")
                {
                    return "Змінити назву бесіди";
                }
                if (lang == "be")
                {
                    return "Змяніць назву гутаркі";
                }
                return "";
            }
        }

        public static string EditingAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменение альбома";
                }
                if (lang == "en")
                {
                    return "Editing album";
                }
                if (lang == "uk")
                {
                    return "Зміна альбому";
                }
                if (lang == "be")
                {
                    return "Змяненне альбома";
                }
                return "";
            }
        }

        public static string EditPhoto
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменить фотографию";
                }
                if (lang == "en")
                {
                    return "Edit photo";
                }
                if (lang == "uk")
                {
                    return "Змінити фотографії";
                }
                if (lang == "be")
                {
                    return "Змяніць фотаздымак";
                }
                return "";
            }
        }

        public static string EditStatusMessage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменить статус";
                }
                if (lang == "en")
                {
                    return "Edit status message";
                }
                if (lang == "uk")
                {
                    return "Змінити статус";
                }
                if (lang == "be")
                {
                    return "Змяніць статус";
                }
                return "";
            }
        }

        public static string EditVideo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменить видеозапись";
                }
                if (lang == "en")
                {
                    return "Edit video";
                }
                if (lang == "uk")
                {
                    return "Змінити відеозапис";
                }
                if (lang == "be")
                {
                    return "Змяніць відэазапіс";
                }
                return "";
            }
        }

        public static string EducationalInstitution
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Место учёбы";
                }
                if (lang == "en")
                {
                    return "Educational institution";
                }
                if (lang == "uk")
                {
                    return "Місце навчання";
                }
                if (lang == "be")
                {
                    return "Месца навучання";
                }
                return "";
            }
        }

        public static string EndTime
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Окончание";
                }
                if (lang == "en")
                {
                    return "End time";
                }
                if (lang == "uk")
                {
                    return "Кінець";
                }
                if (lang == "be")
                {
                    return "Заканчэнне";
                }
                return "";
            }
        }

        public static string Engaged_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Помолвлена";
                }
                if (lang == "en")
                {
                    return "Engaged";
                }
                if (lang == "uk")
                {
                    return "Заручена";
                }
                if (lang == "be")
                {
                    return "Заручаная";
                }
                return "";
            }
        }

        public static string Engaged_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Помолвлен";
                }
                if (lang == "en")
                {
                    return "Engaged";
                }
                if (lang == "uk")
                {
                    return "Заручений";
                }
                if (lang == "be")
                {
                    return "Заручаны";
                }
                return "";
            }
        }

        public static string EngagedTo_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Помолвлена с";
                }
                if (lang == "en")
                {
                    return "Engaged to";
                }
                if (lang == "uk")
                {
                    return "Заручена з";
                }
                if (lang == "be")
                {
                    return "Заручана з";
                }
                return "";
            }
        }

        public static string EngagedTo_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Помолвлен с";
                }
                if (lang == "en")
                {
                    return "Engaged to";
                }
                if (lang == "uk")
                {
                    return "Заручений з";
                }
                if (lang == "be")
                {
                    return "Заручаны з";
                }
                return "";
            }
        }

        public static string EnterChatName
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Введите название беседы";
                }
                if (lang == "en")
                {
                    return "Type conversation title";
                }
                if (lang == "uk")
                {
                    return "Введіть назву бесiди";
                }
                if (lang == "be")
                {
                    return "Увядзіце назву гутаркі";
                }
                return "";
            }
        }

        public static string EntertainmentAndLeisure
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Развлечения и отдых";
                }
                if (lang == "en")
                {
                    return "Entertainment and leisure";
                }
                if (lang == "uk")
                {
                    return "Розваги та відпочинок";
                }
                if (lang == "be")
                {
                    return "Забавы і адпачынак";
                }
                return "";
            }
        }

        public static string Event
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Мероприятие";
                }
                if (lang == "en")
                {
                    return "Event";
                }
                if (lang == "uk")
                {
                    return "Захід";
                }
                if (lang == "be")
                {
                    return "Мерапрыемства";
                }
                return "";
            }
        }

        public static string Events
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Мероприятия";
                }
                if (lang == "en")
                {
                    return "Events";
                }
                if (lang == "uk")
                {
                    return "Заходи";
                }
                if (lang == "be")
                {
                    return "Мерапрыемствы";
                }
                return "";
            }
        }

        public static string Extremism
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Насилие\\экстремизм";
                }
                if (lang == "en")
                {
                    return "Violence/extremism";
                }
                if (lang == "uk")
                {
                    return "Насильство\\екстремізм";
                }
                if (lang == "be")
                {
                    return "Гвалт\\экстрэмізм";
                }
                return "";
            }
        }

        public static string FameAndInfluence
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Слава и влияние";
                }
                if (lang == "en")
                {
                    return "Fame and influence";
                }
                if (lang == "uk")
                {
                    return "Слава і вплив";
                }
                if (lang == "be")
                {
                    return "Слава і ўплыў";
                }
                return "";
            }
        }

        public static string FamilyAndChildren
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Семья и дети";
                }
                if (lang == "en")
                {
                    return "Family and children";
                }
                if (lang == "uk")
                {
                    return "Сім'я і діти";
                }
                if (lang == "be")
                {
                    return "Сям'я і дзеці";
                }
                return "";
            }
        }

        public static string FavoriteBooks
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Любимые книги";
                }
                if (lang == "en")
                {
                    return "Favorite books";
                }
                if (lang == "uk")
                {
                    return "Улюблені книги";
                }
                if (lang == "be")
                {
                    return "Улюбёные кнігі";
                }
                return "";
            }
        }

        public static string FavoriteGames
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Любимые игры";
                }
                if (lang == "en")
                {
                    return "Favorite games";
                }
                if (lang == "uk")
                {
                    return "Улюблені ігри";
                }
                if (lang == "be")
                {
                    return "Улюбёныя гульні";
                }
                return "";
            }
        }

        public static string FavoriteMovies
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Любимые фильмы";
                }
                if (lang == "en")
                {
                    return "Favorite movies";
                }
                if (lang == "uk")
                {
                    return "Улюблені фільми";
                }
                if (lang == "be")
                {
                    return "Улюбёныя фільмы";
                }
                return "";
            }
        }

        public static string FavoriteMusic
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Любимая музыка";
                }
                if (lang == "en")
                {
                    return "Favorite music";
                }
                if (lang == "uk")
                {
                    return "Улюблена музика";
                }
                if (lang == "be")
                {
                    return "Улюбёная музыка";
                }
                return "";
            }
        }

        public static string FavoriteQuotes
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Любимые цитаты";
                }
                if (lang == "en")
                {
                    return "Favorite quotes";
                }
                if (lang == "uk")
                {
                    return "Улюблені цитати";
                }
                if (lang == "be")
                {
                    return "Улюбёныя цытаты";
                }
                return "";
            }
        }

        public static string FavoriteTVShows
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Любимые телешоу";
                }
                if (lang == "en")
                {
                    return "Favorite TV shows";
                }
                if (lang == "uk")
                {
                    return "Улюблені телешоу";
                }
                if (lang == "be")
                {
                    return "Улюбёные тэлешоу";
                }
                return "";
            }
        }

        public static string Favourites
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Понравилось";
                }
                if (lang == "en")
                {
                    return "Favorites";
                }
                if (lang == "uk")
                {
                    return "Сподобалося";
                }
                if (lang == "be")
                {
                    return "Спадабалася";
                }
                return "";
            }
        }

        public static string Feed
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Лента";
                }
                if (lang == "en")
                {
                    return "Feed";
                }
                if (lang == "uk")
                {
                    return "Стрічка";
                }
                if (lang == "be")
                {
                    return "Стужка";
                }
                return "";
            }
        }

        public static string feed1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "ответ";
                }
                if (lang == "en")
                {
                    return "feedback item";
                }
                if (lang == "uk")
                {
                    return "відповідь";
                }
                if (lang == "be")
                {
                    return "адказ";
                }
                return "";
            }
        }

        public static string feed2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "ответа";
                }
                if (lang == "en")
                {
                    return "feedback items";
                }
                if (lang == "uk")
                {
                    return "відповіді";
                }
                if (lang == "be")
                {
                    return "адказы";
                }
                return "";
            }
        }

        public static string feed3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "ответов";
                }
                if (lang == "en")
                {
                    return "feedback items";
                }
                if (lang == "uk")
                {
                    return "відповідей";
                }
                if (lang == "be")
                {
                    return "адказаў";
                }
                return "";
            }
        }

        public static string Feedback
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ответы";
                }
                if (lang == "en")
                {
                    return "Feedback";
                }
                if (lang == "uk")
                {
                    return "Відповіді";
                }
                if (lang == "be")
                {
                    return "Адказы";
                }
                return "";
            }
        }

        public static string Female
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Женский";
                }
                if (lang == "en")
                {
                    return "Female";
                }
                if (lang == "uk")
                {
                    return "Жіноча";
                }
                if (lang == "be")
                {
                    return "Жаночы";
                }
                return "";
            }
        }

        public static string Filter
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фильтр";
                }
                if (lang == "en")
                {
                    return "Filter";
                }
                if (lang == "uk")
                {
                    return "Фільтр";
                }
                if (lang == "be")
                {
                    return "Фільтр";
                }
                return "";
            }
        }

        public static string FindFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Найти друзей";
                }
                if (lang == "en")
                {
                    return "Find friends";
                }
                if (lang == "uk")
                {
                    return "Знайти друзів";
                }
                if (lang == "be")
                {
                    return "Знайсці сяброў";
                }
                return "";
            }
        }

        public static string FindVKUsers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Найти пользователей ВКонтакте";
                }
                if (lang == "en")
                {
                    return "Find VK users";
                }
                if (lang == "uk")
                {
                    return "Знайти користувачів ВКонтакті";
                }
                if (lang == "be")
                {
                    return "Знайсці карыстальнікаў УКантакце";
                }
                return "";
            }
        }

        public static string Follow
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подписаться";
                }
                if (lang == "en")
                {
                    return "Follow";
                }
                if (lang == "uk")
                {
                    return "Підписатися";
                }
                if (lang == "be")
                {
                    return "Падпісацца";
                }
                return "";
            }
        }

        public static string Followers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подписчики";
                }
                if (lang == "en")
                {
                    return "Followers";
                }
                if (lang == "uk")
                {
                    return "Підписники";
                }
                if (lang == "be")
                {
                    return "Падпісчыкі";
                }
                return "";
            }
        }

        public static string ForeignOnly
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Только зарубежные";
                }
                if (lang == "en")
                {
                    return "Foreign only";
                }
                if (lang == "uk")
                {
                    return "Тільки зарубіжні";
                }
                if (lang == "be")
                {
                    return "Толькі замежныя";
                }
                return "";
            }
        }

        public static string forever
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "навсегда";
                }
                if (lang == "en")
                {
                    return "forever";
                }
                if (lang == "uk")
                {
                    return "назавжди";
                }
                if (lang == "be")
                {
                    return "назаўжды";
                }
                return "";
            }
        }

        public static string Forever
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Навсегда";
                }
                if (lang == "en")
                {
                    return "Forever";
                }
                if (lang == "uk")
                {
                    return "Назавжди";
                }
                if (lang == "be")
                {
                    return "Назаўжды";
                }
                return "";
            }
        }

        public static string ForFriendsOnly
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Только для друзей";
                }
                if (lang == "en")
                {
                    return "For friends only";
                }
                if (lang == "uk")
                {
                    return "Тільки для друзів";
                }
                if (lang == "be")
                {
                    return "Толькі для сяброў";
                }
                return "";
            }
        }

        public static string ForgotPassword_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Забыли пароль?";
                }
                if (lang == "en")
                {
                    return "Forgot password?";
                }
                if (lang == "uk")
                {
                    return "Забули пароль?";
                }
                if (lang == "be")
                {
                    return "Забыліся на пароль?";
                }
                return "";
            }
        }

        public static string ForwardedMessage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пересланное сообщение";
                }
                if (lang == "en")
                {
                    return "Forwarded message";
                }
                if (lang == "uk")
                {
                    return "Переслане повідомлення";
                }
                if (lang == "be")
                {
                    return "Перасланае паведамленне";
                }
                return "";
            }
        }

        public static string ForwardedMessages
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пересланные сообщения";
                }
                if (lang == "en")
                {
                    return "Forwarded messages";
                }
                if (lang == "uk")
                {
                    return "Переслані повідомлення";
                }
                if (lang == "be")
                {
                    return "Перасланыя паведамленні";
                }
                return "";
            }
        }

        public static string FoundationDate
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Дата основания";
                }
                if (lang == "en")
                {
                    return "Foundation date";
                }
                if (lang == "uk")
                {
                    return "Дата заснування";
                }
                if (lang == "be")
                {
                    return "Дата заснавання";
                }
                return "";
            }
        }

        public static string friendRequest1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "заявка в друзья";
                }
                if (lang == "en")
                {
                    return "friend request";
                }
                if (lang == "uk")
                {
                    return "заявка в друзі";
                }
                if (lang == "be")
                {
                    return "заяўка ў сябры";
                }
                return "";
            }
        }

        public static string friendRequest2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "заявки в друзья";
                }
                if (lang == "en")
                {
                    return "friend requests";
                }
                if (lang == "uk")
                {
                    return "заявки в друзі";
                }
                if (lang == "be")
                {
                    return "заяўкі ў сябры";
                }
                return "";
            }
        }

        public static string friendRequest3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "заявок в друзья";
                }
                if (lang == "en")
                {
                    return "friend requests";
                }
                if (lang == "uk")
                {
                    return "заявок в друзі";
                }
                if (lang == "be")
                {
                    return "заявак у сябры";
                }
                return "";
            }
        }

        public static string Friends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Друзья";
                }
                if (lang == "en")
                {
                    return "Friends";
                }
                if (lang == "uk")
                {
                    return "Друзі";
                }
                if (lang == "be")
                {
                    return "Сябры";
                }
                return "";
            }
        }

        public static string FriendsAndCommunitiesSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поиск друзей и сообществ";
                }
                if (lang == "en")
                {
                    return "Friends and communities search";
                }
                if (lang == "uk")
                {
                    return "Пошук друзів та спільнот";
                }
                if (lang == "be")
                {
                    return "Пошук сяброў і суполак";
                }
                return "";
            }
        }

        public static string FriendsAndFollowers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Друзья и подписчики";
                }
                if (lang == "en")
                {
                    return "Friends and followers";
                }
                if (lang == "uk")
                {
                    return "Друзі та підписники";
                }
                if (lang == "be")
                {
                    return "Сябры і падпісчыкі";
                }
                return "";
            }
        }

        public static string FriendsAndTheirFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Друзья и их друзья";
                }
                if (lang == "en")
                {
                    return "Friends and their friends";
                }
                if (lang == "uk")
                {
                    return "Друзі та їхні друзі";
                }
                if (lang == "be")
                {
                    return "Сябры і іх сябры";
                }
                return "";
            }
        }

        public static string FriendsLists
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Списки друзей";
                }
                if (lang == "en")
                {
                    return "Friends lists";
                }
                if (lang == "uk")
                {
                    return "Списки друзів";
                }
                if (lang == "be")
                {
                    return "Спісы сяброў";
                }
                return "";
            }
        }

        public static string FriendsOnly
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Только друзья";
                }
                if (lang == "en")
                {
                    return "Friends only";
                }
                if (lang == "uk")
                {
                    return "Тільки друзі";
                }
                if (lang == "be")
                {
                    return "Толькі сябры";
                }
                return "";
            }
        }

        public static string FriendsRequests
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Заявки в друзья";
                }
                if (lang == "en")
                {
                    return "Friends requests";
                }
                if (lang == "uk")
                {
                    return "Заявки в друзі";
                }
                if (lang == "be")
                {
                    return "Заяўкі ў сябры";
                }
                return "";
            }
        }

        public static string FriendsSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поиск друзей";
                }
                if (lang == "en")
                {
                    return "Friends search";
                }
                if (lang == "uk")
                {
                    return "Пошук друзів";
                }
                if (lang == "be")
                {
                    return "Пошук сяброў";
                }
                return "";
            }
        }

        public static string FriendsSuggestions
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Рекомендации друзей";
                }
                if (lang == "en")
                {
                    return "Friends suggestions";
                }
                if (lang == "uk")
                {
                    return "Рекомендації друзів";
                }
                if (lang == "be")
                {
                    return "Рэкамендацыі сяброў";
                }
                return "";
            }
        }

        public static string From
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "От";
                }
                if (lang == "en")
                {
                    return "From";
                }
                if (lang == "uk")
                {
                    return "Від";
                }
                if (lang == "be")
                {
                    return "Ад";
                }
                return "";
            }
        }

        public static string from1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "с";
                }
                if (lang == "en")
                {
                    return "from";
                }
                if (lang == "uk")
                {
                    return "з";
                }
                if (lang == "be")
                {
                    return "з";
                }
                return "";
            }
        }

        public static string from2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "от";
                }
                if (lang == "en")
                {
                    return "from";
                }
                if (lang == "uk")
                {
                    return "від";
                }
                if (lang == "be")
                {
                    return "ад";
                }
                return "";
            }
        }

        public static string FromCamera
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "С камеры";
                }
                if (lang == "en")
                {
                    return "From camera";
                }
                if (lang == "uk")
                {
                    return "З камери";
                }
                if (lang == "be")
                {
                    return "З камеры";
                }
                return "";
            }
        }

        public static string FromDisk
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "С диска";
                }
                if (lang == "en")
                {
                    return "From disk";
                }
                if (lang == "uk")
                {
                    return "З диска";
                }
                if (lang == "be")
                {
                    return "З дыска";
                }
                return "";
            }
        }

        public static string FromDocs
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Из документов";
                }
                if (lang == "en")
                {
                    return "From documents";
                }
                if (lang == "uk")
                {
                    return "З документів";
                }
                if (lang == "be")
                {
                    return "З дакументаў";
                }
                return "";
            }
        }

        public static string FromPhotos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Из фотографий";
                }
                if (lang == "en")
                {
                    return "From photos";
                }
                if (lang == "uk")
                {
                    return "З фотографій";
                }
                if (lang == "be")
                {
                    return "З фотаздымкаў";
                }
                return "";
            }
        }

        public static string FromVideos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Из видеозаписей";
                }
                if (lang == "en")
                {
                    return "From videos";
                }
                if (lang == "uk")
                {
                    return "З відеозаписів";
                }
                if (lang == "be")
                {
                    return "З відэазапісаў";
                }
                return "";
            }
        }

        public static string G
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "г.";
                }
                if (lang == "en")
                {
                    return "";
                }
                if (lang == "uk")
                {
                    return "р.";
                }
                if (lang == "be")
                {
                    return "г.";
                }
                return "";
            }
        }

        public static string GB
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "ГБ";
                }
                if (lang == "en")
                {
                    return "GB";
                }
                if (lang == "uk")
                {
                    return "ГБ";
                }
                if (lang == "be")
                {
                    return "ГБ";
                }
                return "";
            }
        }

        public static string Genre
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Жанр";
                }
                if (lang == "en")
                {
                    return "Genre";
                }
                if (lang == "uk")
                {
                    return "Жанр";
                }
                if (lang == "be")
                {
                    return "Жанр";
                }
                return "";
            }
        }

        public static string Gift
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подарок";
                }
                if (lang == "en")
                {
                    return "Gift";
                }
                if (lang == "uk")
                {
                    return "Подарунок";
                }
                if (lang == "be")
                {
                    return "Падарунак";
                }
                return "";
            }
        }

        public static string Gifts
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подарки";
                }
                if (lang == "en")
                {
                    return "Gifts";
                }
                if (lang == "uk")
                {
                    return "Подарунки";
                }
                if (lang == "be")
                {
                    return "Падарункі";
                }
                return "";
            }
        }

        public static string GiftsOf
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подарки";
                }
                if (lang == "en")
                {
                    return "Gifts of";
                }
                if (lang == "uk")
                {
                    return "Подарунки";
                }
                if (lang == "be")
                {
                    return "Падарункі";
                }
                return "";
            }
        }

        public static string GlobalSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Глобальный поиск";
                }
                if (lang == "en")
                {
                    return "Global search";
                }
                if (lang == "uk")
                {
                    return "Глобальний пошук";
                }
                if (lang == "be")
                {
                    return "Глабальны пошук";
                }
                return "";
            }
        }

        public static string Grandchildren
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Внуки";
                }
                if (lang == "en")
                {
                    return "Grandchildren";
                }
                if (lang == "uk")
                {
                    return "Онуки";
                }
                if (lang == "be")
                {
                    return "Унукі";
                }
                return "";
            }
        }

        public static string Grandparents
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Дедушки, бабушки";
                }
                if (lang == "en")
                {
                    return "Grandparents";
                }
                if (lang == "uk")
                {
                    return "Дідусі, бабусі";
                }
                if (lang == "be")
                {
                    return "Дзядулі, бабулі";
                }
                return "";
            }
        }

        public static string Group
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Группа";
                }
                if (lang == "en")
                {
                    return "Group";
                }
                if (lang == "uk")
                {
                    return "Група";
                }
                if (lang == "be")
                {
                    return "Група";
                }
                return "";
            }
        }

        public static string HasBoyfriend
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Есть друг";
                }
                if (lang == "en")
                {
                    return "In relationship";
                }
                if (lang == "uk")
                {
                    return "Є хлопець";
                }
                if (lang == "be")
                {
                    return "Ёсць хлопец";
                }
                return "";
            }
        }

        public static string HasGirlfriend
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Есть подруга";
                }
                if (lang == "en")
                {
                    return "In relationship";
                }
                if (lang == "uk")
                {
                    return "Є дівчина";
                }
                if (lang == "be")
                {
                    return "Ёсць дзяўчына";
                }
                return "";
            }
        }

        public static string HealthAndBeauty
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Красота и здоровье";
                }
                if (lang == "en")
                {
                    return "Health and beauty";
                }
                if (lang == "uk")
                {
                    return "Краса і здоров'я";
                }
                if (lang == "be")
                {
                    return "Прыгажосць і здароўе";
                }
                return "";
            }
        }

        public static string Hide
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Скрыть";
                }
                if (lang == "en")
                {
                    return "Hide";
                }
                if (lang == "uk")
                {
                    return "Приховати";
                }
                if (lang == "be")
                {
                    return "Схаваць";
                }
                return "";
            }
        }

        public static string HideAll
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Скрыть все";
                }
                if (lang == "en")
                {
                    return "Hide all";
                }
                if (lang == "uk")
                {
                    return "Приховати все";
                }
                if (lang == "be")
                {
                    return "Схаваць усе";
                }
                return "";
            }
        }

        public static string HighQuality
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Высокое качество";
                }
                if (lang == "en")
                {
                    return "High quality";
                }
                if (lang == "uk")
                {
                    return "Висока якість";
                }
                if (lang == "be")
                {
                    return "Высокая якасць";
                }
                return "";
            }
        }

        public static string hourAgo1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "час назад";
                }
                if (lang == "en")
                {
                    return "hour ago";
                }
                if (lang == "uk")
                {
                    return "годину тому";
                }
                if (lang == "be")
                {
                    return "гадзіну таму";
                }
                return "";
            }
        }

        public static string hourAgo2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "часа назад";
                }
                if (lang == "en")
                {
                    return "hours ago";
                }
                if (lang == "uk")
                {
                    return "години тому";
                }
                if (lang == "be")
                {
                    return "гадзіны таму";
                }
                return "";
            }
        }

        public static string HumorAndLoveForLife
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Юмор и жизнелюбие";
                }
                if (lang == "en")
                {
                    return "Humor and love for life";
                }
                if (lang == "uk")
                {
                    return "Гумор і життєлюбність";
                }
                if (lang == "be")
                {
                    return "Гумар і жыццялюбства";
                }
                return "";
            }
        }

        public static string IMayAttend
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Возможно, пойду";
                }
                if (lang == "en")
                {
                    return "I may attend";
                }
                if (lang == "uk")
                {
                    return "Можливо, піду";
                }
                if (lang == "be")
                {
                    return "Магчыма пайду";
                }
                return "";
            }
        }

        public static string ImportantInOthers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Главное в людях";
                }
                if (lang == "en")
                {
                    return "Important in others";
                }
                if (lang == "uk")
                {
                    return "Головне в людях";
                }
                if (lang == "be")
                {
                    return "Галоўнае ў людзях";
                }
                return "";
            }
        }

        public static string ImprovingTheWorld
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Совершенствование мира";
                }
                if (lang == "en")
                {
                    return "Improving the world";
                }
                if (lang == "uk")
                {
                    return "Удосконалення світу";
                }
                if (lang == "be")
                {
                    return "Удасканаленне свету";
                }
                return "";
            }
        }

        public static string InAppNotifications
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Всплывающие оповещения внутри приложения";
                }
                if (lang == "en")
                {
                    return "In-app notifications";
                }
                if (lang == "uk")
                {
                    return "Вигулькові сповiщення всерединi додатка";
                }
                if (lang == "be")
                {
                    return "Выплыўныя апавяшчэнні ўнутры дадатку";
                }
                return "";
            }
        }

        public static string inCommentsOn
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "в комментариях к";
                }
                if (lang == "en")
                {
                    return "in comments on";
                }
                if (lang == "uk")
                {
                    return "в коментарях до";
                }
                if (lang == "be")
                {
                    return "у каментарыях да";
                }
                return "";
            }
        }

        public static string inCommentsOnPost
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "в комментариях к записи";
                }
                if (lang == "en")
                {
                    return "in comments on post";
                }
                if (lang == "uk")
                {
                    return "в коментарях до запису";
                }
                if (lang == "be")
                {
                    return "у каментарыях да запісу";
                }
                return "";
            }
        }

        public static string inCommentsOnVideo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "в комментариях к видеозаписи";
                }
                if (lang == "en")
                {
                    return "in comments on video";
                }
                if (lang == "uk")
                {
                    return "в коментарях до відеозапису";
                }
                if (lang == "be")
                {
                    return "у каментарыях да відэазапісу";
                }
                return "";
            }
        }

        public static string InLove_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Влюблена";
                }
                if (lang == "en")
                {
                    return "In love";
                }
                if (lang == "uk")
                {
                    return "Закохана";
                }
                if (lang == "be")
                {
                    return "Закаханая";
                }
                return "";
            }
        }

        public static string InLove_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Влюблён";
                }
                if (lang == "en")
                {
                    return "In love";
                }
                if (lang == "uk")
                {
                    return "Закоханий";
                }
                if (lang == "be")
                {
                    return "Закаханы";
                }
                return "";
            }
        }

        public static string InLoveWith_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Влюблена в";
                }
                if (lang == "en")
                {
                    return "In love with";
                }
                if (lang == "uk")
                {
                    return "Закохана в";
                }
                if (lang == "be")
                {
                    return "Закахана ў";
                }
                return "";
            }
        }

        public static string InLoveWith_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Влюблён в";
                }
                if (lang == "en")
                {
                    return "In love with";
                }
                if (lang == "uk")
                {
                    return "Закоханий в";
                }
                if (lang == "be")
                {
                    return "Закаханы ў";
                }
                return "";
            }
        }

        public static string inReplyToYourComment
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "в ответ на Ваш комментарий";
                }
                if (lang == "en")
                {
                    return "in reply to your comment";
                }
                if (lang == "uk")
                {
                    return "у відповідь на Ваш коментар";
                }
                if (lang == "be")
                {
                    return "у адказ на Ваш каментарый";
                }
                return "";
            }
        }

        public static string InspiredBy
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Источники вдохновения";
                }
                if (lang == "en")
                {
                    return "Inspired by";
                }
                if (lang == "uk")
                {
                    return "Джерела натхнення";
                }
                if (lang == "be")
                {
                    return "Крыніцы натхнення";
                }
                return "";
            }
        }

        public static string IntellectAndCreativity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ум и креативность";
                }
                if (lang == "en")
                {
                    return "Intellect and creativity";
                }
                if (lang == "uk")
                {
                    return "Розум і креативність";
                }
                if (lang == "be")
                {
                    return "Розум і крэатыўнасць";
                }
                return "";
            }
        }

        public static string Interests
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Интересы";
                }
                if (lang == "en")
                {
                    return "Interests";
                }
                if (lang == "uk")
                {
                    return "Інтереси";
                }
                if (lang == "be")
                {
                    return "Інтарэсы";
                }
                return "";
            }
        }

        public static string InterfaceLanguage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Язык интерфейса";
                }
                if (lang == "en")
                {
                    return "Interface language";
                }
                if (lang == "uk")
                {
                    return "Мова інтерфейсу";
                }
                if (lang == "be")
                {
                    return "Мова інтэрфейсу";
                }
                return "";
            }
        }

        public static string invitation1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "приглашение";
                }
                if (lang == "en")
                {
                    return "invitation";
                }
                if (lang == "uk")
                {
                    return "запрошення";
                }
                if (lang == "be")
                {
                    return "запрашэнне";
                }
                return "";
            }
        }

        public static string invitation2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "приглашения";
                }
                if (lang == "en")
                {
                    return "invitations";
                }
                if (lang == "uk")
                {
                    return "запрошення";
                }
                if (lang == "be")
                {
                    return "запрашэнні";
                }
                return "";
            }
        }

        public static string invitation3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "приглашений";
                }
                if (lang == "en")
                {
                    return "invitations";
                }
                if (lang == "uk")
                {
                    return "запрошень";
                }
                if (lang == "be")
                {
                    return "запрашэнняў";
                }
                return "";
            }
        }

        public static string InvitationFrom
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Приглашение от";
                }
                if (lang == "en")
                {
                    return "Invitation from";
                }
                if (lang == "uk")
                {
                    return "Запрошення від";
                }
                if (lang == "be")
                {
                    return "Запрашэнне ад";
                }
                return "";
            }
        }

        public static string Invitations
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Приглашения";
                }
                if (lang == "en")
                {
                    return "Invitations";
                }
                if (lang == "uk")
                {
                    return "Запрошення";
                }
                if (lang == "be")
                {
                    return "Запрашэнні";
                }
                return "";
            }
        }

        public static string Invited_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пригласила";
                }
                if (lang == "en")
                {
                    return "Invited";
                }
                if (lang == "uk")
                {
                    return "Запросила";
                }
                if (lang == "be")
                {
                    return "Запрасіла";
                }
                return "";
            }
        }

        public static string Invited_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пригласил";
                }
                if (lang == "en")
                {
                    return "Invited";
                }
                if (lang == "uk")
                {
                    return "Запросив";
                }
                if (lang == "be")
                {
                    return "Запрасіў";
                }
                return "";
            }
        }

        public static string InviteFriend
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пригласить друга";
                }
                if (lang == "en")
                {
                    return "Invite friend";
                }
                if (lang == "uk")
                {
                    return "Запросити друга";
                }
                if (lang == "be")
                {
                    return "Запрасіць сябра";
                }
                return "";
            }
        }

        public static string isTyping
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "набирает сообщение";
                }
                if (lang == "en")
                {
                    return "is typing";
                }
                if (lang == "uk")
                {
                    return "набирає повідомлення";
                }
                if (lang == "be")
                {
                    return "піша паведамленне";
                }
                return "";
            }
        }

        public static string ItIsComplicated
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Всё сложно";
                }
                if (lang == "en")
                {
                    return "It is complicated";
                }
                if (lang == "uk")
                {
                    return "Все складно";
                }
                if (lang == "be")
                {
                    return "Усё складана";
                }
                return "";
            }
        }

        public static string IWillBeThere
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Точно пойду";
                }
                if (lang == "en")
                {
                    return "I will be there";
                }
                if (lang == "uk")
                {
                    return "Точно піду";
                }
                if (lang == "be")
                {
                    return "Дакладна пайду";
                }
                return "";
            }
        }

        public static string JoinCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вступить в сообщество";
                }
                if (lang == "en")
                {
                    return "Join community";
                }
                if (lang == "uk")
                {
                    return "Вступити до спільноти";
                }
                if (lang == "be")
                {
                    return "Далучыцца да суполкі";
                }
                return "";
            }
        }

        public static string KB
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "КБ";
                }
                if (lang == "en")
                {
                    return "KB";
                }
                if (lang == "uk")
                {
                    return "КБ";
                }
                if (lang == "be")
                {
                    return "КБ";
                }
                return "";
            }
        }

        public static string KeepAllAsFollowers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Оставить всех в подписчиках";
                }
                if (lang == "en")
                {
                    return "Keep all as followers";
                }
                if (lang == "uk")
                {
                    return "Залишити всіх в підписниках";
                }
                if (lang == "be")
                {
                    return "Пакінуць усіх у падпісчыках";
                }
                return "";
            }
        }

        public static string KindnessAndHonesty
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Доброта и честность";
                }
                if (lang == "en")
                {
                    return "Kindness and honesty";
                }
                if (lang == "uk")
                {
                    return "Доброта і чесність";
                }
                if (lang == "be")
                {
                    return "Дабрыня і сумленнасць";
                }
                return "";
            }
        }

        public static string Languages
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Языки";
                }
                if (lang == "en")
                {
                    return "Languages";
                }
                if (lang == "uk")
                {
                    return "Мови";
                }
                if (lang == "be")
                {
                    return "Мовы";
                }
                return "";
            }
        }

        public static string lastSeen_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "была в сети";
                }
                if (lang == "en")
                {
                    return "last seen";
                }
                if (lang == "uk")
                {
                    return "була у мережі";
                }
                if (lang == "be")
                {
                    return "была тут";
                }
                return "";
            }
        }

        public static string lastSeen_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "был в сети";
                }
                if (lang == "en")
                {
                    return "last seen";
                }
                if (lang == "uk")
                {
                    return "був у мережі";
                }
                if (lang == "be")
                {
                    return "быў тут";
                }
                return "";
            }
        }

        public static string LeaveCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Покинуть сообщество";
                }
                if (lang == "en")
                {
                    return "Leave community";
                }
                if (lang == "uk")
                {
                    return "Покинути спільноту";
                }
                if (lang == "be")
                {
                    return "Пакінуць суполку";
                }
                return "";
            }
        }

        public static string LeaveConversation
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Покинуть беседу";
                }
                if (lang == "en")
                {
                    return "Leave conversation";
                }
                if (lang == "uk")
                {
                    return "Покинути бесіду";
                }
                if (lang == "be")
                {
                    return "Пакінуць гутарку";
                }
                return "";
            }
        }

        public static string leftConversation_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "покинула беседу";
                }
                if (lang == "en")
                {
                    return "left conversation";
                }
                if (lang == "uk")
                {
                    return "покинула бесіду";
                }
                if (lang == "be")
                {
                    return "пакінула гутарку";
                }
                return "";
            }
        }

        public static string leftConversation_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "покинул беседу";
                }
                if (lang == "en")
                {
                    return "left conversation";
                }
                if (lang == "uk")
                {
                    return "покинув бесіду";
                }
                if (lang == "be")
                {
                    return "пакінуў гутарку";
                }
                return "";
            }
        }

        public static string Liberal
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Либеральные";
                }
                if (lang == "en")
                {
                    return "Liberal";
                }
                if (lang == "uk")
                {
                    return "Ліберальні";
                }
                if (lang == "be")
                {
                    return "Ліберальныя";
                }
                return "";
            }
        }

        public static string Libertarian
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Либертарианские";
                }
                if (lang == "en")
                {
                    return "Libertarian";
                }
                if (lang == "uk")
                {
                    return "Лібертаріанські";
                }
                if (lang == "be")
                {
                    return "Лібертарыянскія";
                }
                return "";
            }
        }

        public static string Like
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Мне нравится";
                }
                if (lang == "en")
                {
                    return "Like";
                }
                if (lang == "uk")
                {
                    return "Мені подобається";
                }
                if (lang == "be")
                {
                    return "Мне падабаецца";
                }
                return "";
            }
        }

        public static string likedYourComment_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценила Ваш комментарий";
                }
                if (lang == "en")
                {
                    return "liked your comment";
                }
                if (lang == "uk")
                {
                    return "оцінила Ваш коментар";
                }
                if (lang == "be")
                {
                    return "ацаніла Ваш каментарый";
                }
                return "";
            }
        }

        public static string likedYourComment_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценил Ваш комментарий";
                }
                if (lang == "en")
                {
                    return "liked your comment";
                }
                if (lang == "uk")
                {
                    return "оцінив Ваш коментар";
                }
                if (lang == "be")
                {
                    return "ацаніў Ваш каментарый";
                }
                return "";
            }
        }

        public static string likedYourComment_S
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценили Ваш комментарий";
                }
                if (lang == "en")
                {
                    return "liked your comment";
                }
                if (lang == "uk")
                {
                    return "оцінили Ваш коментар";
                }
                if (lang == "be")
                {
                    return "ацанілі Ваш каментарый";
                }
                return "";
            }
        }

        public static string likedYourPhoto_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценила Вашу фотографию";
                }
                if (lang == "en")
                {
                    return "liked your photo";
                }
                if (lang == "uk")
                {
                    return "оцінила Вашу фотографію";
                }
                if (lang == "be")
                {
                    return "ацаніла Ваш фотаздымак";
                }
                return "";
            }
        }

        public static string likedYourPhoto_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценил Вашу фотографию";
                }
                if (lang == "en")
                {
                    return "liked your photo";
                }
                if (lang == "uk")
                {
                    return "оцінив Вашу фотографію";
                }
                if (lang == "be")
                {
                    return "ацаніў Ваш фотаздымак";
                }
                return "";
            }
        }

        public static string likedYourPhoto_S
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценили Вашу фотографию";
                }
                if (lang == "en")
                {
                    return "liked your photo";
                }
                if (lang == "uk")
                {
                    return "оцінили Вашу фотографію";
                }
                if (lang == "be")
                {
                    return "ацанілі Ваш фотаздымак";
                }
                return "";
            }
        }

        public static string likedYourPost_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценила Вашу запись";
                }
                if (lang == "en")
                {
                    return "liked your post";
                }
                if (lang == "uk")
                {
                    return "оцінила Ваш запис";
                }
                if (lang == "be")
                {
                    return "ацаніла Ваш запіс";
                }
                return "";
            }
        }

        public static string likedYourPost_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценил Вашу запись";
                }
                if (lang == "en")
                {
                    return "liked your post";
                }
                if (lang == "uk")
                {
                    return "оцінив Ваш запис";
                }
                if (lang == "be")
                {
                    return "ацаніў Ваш запіс";
                }
                return "";
            }
        }

        public static string likedYourPost_S
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценили Вашу запись";
                }
                if (lang == "en")
                {
                    return "liked your post";
                }
                if (lang == "uk")
                {
                    return "оцінили Ваш запис";
                }
                if (lang == "be")
                {
                    return "ацанілі Ваш запіс";
                }
                return "";
            }
        }

        public static string likedYourVideo_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценила Вашу видеозапись";
                }
                if (lang == "en")
                {
                    return "liked your video";
                }
                if (lang == "uk")
                {
                    return "оцінила Ваш відеозапис";
                }
                if (lang == "be")
                {
                    return "ацаніла Ваш відэазапіс";
                }
                return "";
            }
        }

        public static string likedYourVideo_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценил Вашу видеозапись";
                }
                if (lang == "en")
                {
                    return "liked your video";
                }
                if (lang == "uk")
                {
                    return "оцінив Ваш відеозапис";
                }
                if (lang == "be")
                {
                    return "ацаніў Ваш відэазапіс";
                }
                return "";
            }
        }

        public static string likedYourVideo_S
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "оценили Вашу видеозапись";
                }
                if (lang == "en")
                {
                    return "liked your video";
                }
                if (lang == "uk")
                {
                    return "оцінили Ваш відеозапис";
                }
                if (lang == "be")
                {
                    return "ацанілі Ваш відэазапіс";
                }
                return "";
            }
        }

        public static string Likes
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Оценили";
                }
                if (lang == "en")
                {
                    return "Likes";
                }
                if (lang == "uk")
                {
                    return "Оцінили";
                }
                if (lang == "be")
                {
                    return "Ацанілі";
                }
                return "";
            }
        }

        public static string Link
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ссылка";
                }
                if (lang == "en")
                {
                    return "Link";
                }
                if (lang == "uk")
                {
                    return "Посилання";
                }
                if (lang == "be")
                {
                    return "Спасылка";
                }
                return "";
            }
        }

        public static string Links
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ссылки";
                }
                if (lang == "en")
                {
                    return "Links";
                }
                if (lang == "uk")
                {
                    return "Посилання";
                }
                if (lang == "be")
                {
                    return "Спасылкі";
                }
                return "";
            }
        }

        public static string Loading
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Загрузка";
                }
                if (lang == "en")
                {
                    return "Loading";
                }
                if (lang == "uk")
                {
                    return "Завантаження";
                }
                if (lang == "be")
                {
                    return "Загрузка";
                }
                return "";
            }
        }

        public static string LogIn
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Войти";
                }
                if (lang == "en")
                {
                    return "Log in";
                }
                if (lang == "uk")
                {
                    return "Увійти";
                }
                if (lang == "be")
                {
                    return "Увайсці";
                }
                return "";
            }
        }

        public static string LogInConfirmationError
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ошибка подтверждения входа";
                }
                if (lang == "en")
                {
                    return "Log in confirmation error";
                }
                if (lang == "uk")
                {
                    return "Помилка підтвердження входу";
                }
                if (lang == "be")
                {
                    return "Памылка пацверджання ўваходу";
                }
                return "";
            }
        }

        public static string LogOut
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выйти";
                }
                if (lang == "en")
                {
                    return "Log out";
                }
                if (lang == "uk")
                {
                    return "Вийти";
                }
                if (lang == "be")
                {
                    return "Выйсці";
                }
                return "";
            }
        }

        public static string Long
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Длинные";
                }
                if (lang == "en")
                {
                    return "Long";
                }
                if (lang == "uk")
                {
                    return "Довгі";
                }
                if (lang == "be")
                {
                    return "Доўгія";
                }
                return "";
            }
        }

        public static string Long_AudioRules
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "• Файл не должен нарушать авторские и смежные права\n• Максимальный допустимый объем файла – 200 МБ\n• Поддерживается только формат MP3";
                }
                if (lang == "en")
                {
                    return "• File must not violate copyrighting laws and neighbouring rights\n• Maximum file size is 200 MB\n• Only MP3 format is supported";
                }
                if (lang == "uk")
                {
                    return "• Файл не повинен порушувати авторські та суміжні права\n• Максимальний допустимий розмір файлу – 200 MБ\n• Підтримується тільки формат MP3";
                }
                if (lang == "be")
                {
                    return "• Файл не павінен парушаць аўтарскія і сумежныя правы\n• Максімальны дапушчальны аб'ём файла – 200 МБ\n• Падтрымліваецца толькі фармат MP3";
                }
                return "";
            }
        }

        public static string Long_AudioWasRemovedByRequest
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Эта аудиозапись была изъята по запросу правообладателя и не может быть загружена.";
                }
                if (lang == "en")
                {
                    return "This audio was removed by request of the rights holder and cannot be uploaded.";
                }
                if (lang == "uk")
                {
                    return "Цей аудіозапис був вилучений за запитом правовласника і не може бути завантажений.";
                }
                if (lang == "be")
                {
                    return "Гэты аўдыязапіс быў зняты па запыце праваўладальніка і не можа быць загружаны.";
                }
                return "";
            }
        }

        public static string Long_AuthorizationError
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ошибка авторизации. Возможно, был изменён пароль.";
                }
                if (lang == "en")
                {
                    return "Authorization error. Password might have been changed.";
                }
                if (lang == "uk")
                {
                    return "Помилка авторизації. Можливо, був змінений пароль.";
                }
                if (lang == "be")
                {
                    return "Памылка аўтарызацыі. Магчыма, быў зменены пароль.";
                }
                return "";
            }
        }

        public static string Long_BlacklistAdding
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете добавить пользователя в чёрный список, открыв меню действий на его странице.";
                }
                if (lang == "en")
                {
                    return "You can add a user to blacklist by opening the actions menu on his page.";
                }
                if (lang == "uk")
                {
                    return "Ви можете додати користувача в чорний список, відкривши меню дій на його сторінці.";
                }
                if (lang == "be")
                {
                    return "Вы можаце дадаць карыстальніка ў чорны спіс, адкрыўшы меню дзеянняў на яго старонцы.";
                }
                return "";
            }
        }

        public static string Long_BrowserVideo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Воспроизвести эту видеозапись Вы можете только в браузере.";
                }
                if (lang == "en")
                {
                    return "You can play this video in browser only.";
                }
                if (lang == "uk")
                {
                    return "Відтворити цей відеозапис Ви можете тільки в браузері.";
                }
                if (lang == "be")
                {
                    return "Прайграць гэты відэазапіс Вы можаце толькі ў браўзеры.";
                }
                return "";
            }
        }

        public static string Long_CacheClearing
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Все кэшированые аудиозаписи будут удалены из памяти.";
                }
                if (lang == "en")
                {
                    return "All the cached audios will be deleted from memory.";
                }
                if (lang == "uk")
                {
                    return "Всі кешовані аудіозаписи будуть видалені з пам'яті.";
                }
                if (lang == "be")
                {
                    return "Усе кэшыраваныя аўдыязапісы будуць выдалены з памяці.";
                }
                return "";
            }
        }

        public static string Long_ChangingPasswordCurrentWrong
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Старый пароль введён неверно";
                }
                if (lang == "en")
                {
                    return "Current password was typed wrong";
                }
                if (lang == "uk")
                {
                    return "Старий пароль введений неправильно";
                }
                if (lang == "be")
                {
                    return "Стары пароль уведзены няправільна";
                }
                return "";
            }
        }

        public static string Long_ChangingPasswordError
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось изменить пароль";
                }
                if (lang == "en")
                {
                    return "Password changing failed";
                }
                if (lang == "uk")
                {
                    return "Не вдалося змінити пароль";
                }
                if (lang == "be")
                {
                    return "Не ўдалося змяніць пароль";
                }
                return "";
            }
        }

        public static string Long_ChangingPasswordLeastSix
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новый пароль должен содержать не менее 6 символов";
                }
                if (lang == "en")
                {
                    return "Your password must contain least 6 characters";
                }
                if (lang == "uk")
                {
                    return "Новий пароль повинен містити не менше 6 символів";
                }
                if (lang == "be")
                {
                    return "Новы пароль павінен змяшчаць не менш за 6 сімвалаў";
                }
                return "";
            }
        }

        public static string Long_ChangingPasswordRepeatedWrong
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новый пароль повторён неверно";
                }
                if (lang == "en")
                {
                    return "New password was repeated wrong";
                }
                if (lang == "uk")
                {
                    return "Новий пароль повторений неправильно";
                }
                if (lang == "be")
                {
                    return "Новы пароль паўтораны няправільна";
                }
                return "";
            }
        }

        public static string Long_ChooseConversation
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выберите диалог из списка слева, чтобы начать общаться";
                }
                if (lang == "en")
                {
                    return "Choose a conversation from the list on the left to start communicating";
                }
                if (lang == "uk")
                {
                    return "Виберіть діалог зі списку ліворуч, щоб почати спілкуватися";
                }
                if (lang == "be")
                {
                    return "Выберыце дыялог са спіса злева, каб пачаць размову";
                }
                return "";
            }
        }

        public static string Long_DocumentRules
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "• Максимальный допустимый объем файла – 2 ГБ\n• Поддерживаются форматы DOC, DOCX, XLS, XLSX, PPT, PPTX, RTF, PDF, PNG, JPG, GIF, PSD, MP3, DJVU, FB2, PS и другие";
                }
                if (lang == "en")
                {
                    return "• Maximum file size is 2 GB\n• Supported formats are DOC, DOCX, XLS, XLSX, PPT, PPTX, RTF, PDF, PNG, JPG, GIF, PSD, MP3, DJVU, FB2, PS, etc.";
                }
                if (lang == "uk")
                {
                    return "• Максимальний допустимий розмір файлу – 2 ГБ\n• Підтримуються формати DOC, DOCX, XLS, XLSX, PPT, PPTX, RTF, PDF, PNG, JPG, GIF, PSD, MP3, DJVU, FB2, PS та інші";
                }
                if (lang == "be")
                {
                    return "• Максімальны дапушчальны аб'ём файла – 2 ГБ\n• Падтрымліваюцца фарматы DOC, DOCX, XLS, XLSX, PPT, PPTX, RTF, PDF, PNG, JPG, GIF, PSD, MP3, DJVU, FB2, PS і іншыя";
                }
                return "";
            }
        }

        public static string Long_DoNotCloseThisWindow
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пожалуйста, не закрывайте это окно, пока файл не загрузится.";
                }
                if (lang == "en")
                {
                    return "Please do not close this window while the file is uploading.";
                }
                if (lang == "uk")
                {
                    return "Будь ласка, не закривайте це вікно, поки файл не завантажиться.";
                }
                if (lang == "be")
                {
                    return "Калі ласка, не закрывайце гэтае акно, пакуль файл не загрузіцца.";
                }
                return "";
            }
        }

        public static string Long_ForwardMessageHint
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Чтобы переслать сообщение, выберите диалог из списка слева";
                }
                if (lang == "en")
                {
                    return "Choose a conversation from the list on the left to forward message";
                }
                if (lang == "uk")
                {
                    return "Щоб переслати повідомлення, виберіть діалог зі списку ліворуч";
                }
                if (lang == "be")
                {
                    return "Каб пераслаць паведамленне, выберыце дыялог са спіса злева.";
                }
                return "";
            }
        }

        public static string Long_ForwardMessagesHint
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Чтобы переслать сообщения, выберите диалог из списка слева";
                }
                if (lang == "en")
                {
                    return "Choose a conversation from the list on the left to forward messages";
                }
                if (lang == "uk")
                {
                    return "Щоб переслати повідомлення, виберіть діалог зі списку ліворуч";
                }
                if (lang == "be")
                {
                    return "Каб пераслаць паведамленні, выберыце дыялог са спіса злева.";
                }
                return "";
            }
        }

        public static string Long_GiftHint
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Показывать текст и моё имя только получателю";
                }
                if (lang == "en")
                {
                    return "Show text and my name to recipient only";
                }
                if (lang == "uk")
                {
                    return "Показувати текст і моє ім'я тільки одержувачу";
                }
                if (lang == "be")
                {
                    return "Паказваць тэкст і маё імя толькі атрымальніку";
                }
                return "";
            }
        }

        public static string Long_HttpsHint
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "При включенном шифровании трафика злоумышленники не смогут перехватить Ваши данные. Этот режим необходимо включать при использовании ненадёжных каналов связи — например, бесплатных или публичных сетей Wi-Fi. Однако шифрование трафика может существенно замедлять работу приложения, поэтому его стоит использовать только в небезопасных сетях.";
                }
                if (lang == "en")
                {
                    return "With traffic encryption enabled trespassers cannot intercept your data. This mode should be enabled while using unreliable communications channels — e.g., free or public Wi-Fi. However, traffic encryption can significantly slow down your application, that is why it should only be enabled while using insecure networks.";
                }
                if (lang == "uk")
                {
                    return "При включеному шифруванні трафіку зловмисники не зможуть перехопити Ваші дані. Цей режим необхідно вмикати при використанні ненадійних каналів зв'язку — наприклад, безкоштовних або публічних мереж Wi-Fi. Однак шифрування трафіку може істотно сповільнювати роботу додатку, тому його варто використовувати тільки в небезпечних мережах.";
                }
                if (lang == "be")
                {
                    return "Пры ўключаным шыфраванні трафіка злачынцы не змогуць перахапіць Вашы даныя. Гэты рэжым неабходна ўключаць пры выкарыстанні ненадзейных каналаў сувязі — напрыклад, бясплатных або публічных сетак Wi-Fi. Аднак шыфраванне трафіка можа істотна запавольваць працу дадатку, таму яго варта выкарыстоўваць толькі ў небяспечных сетках.";
                }
                return "";
            }
        }

        public static string Long_LanguageSwitchingHint
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Для правильного переключения между языками интерфейса приложение сейчас будет автоматически закрыто.";
                }
                if (lang == "en")
                {
                    return "In order to properly change the interface language the app will close automatically.";
                }
                if (lang == "uk")
                {
                    return "Для правильного перемикання між мовами інтерфейсу додаток зараз буде автоматично закрито.";
                }
                if (lang == "be")
                {
                    return "Для правільнага пераключэння паміж мовамі інтэрфэйса дадатак зараз будзе аўтаматычна закрыты.";
                }
                return "";
            }
        }

        public static string Long_NoExecutableFile
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы не можете загрузить файл, являющийся исполняемым.";
                }
                if (lang == "en")
                {
                    return "You cannot upload an executable file.";
                }
                if (lang == "uk")
                {
                    return "Ви не можете завантажити файл, який є виконуваним.";
                }
                if (lang == "be")
                {
                    return "Вы не можаце загрузіць файл, які з'яўляецца выканальным.";
                }
                return "";
            }
        }

        public static string Long_NoMoreThan10
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете прикрепить к одной записи не более 10 вложений.";
                }
                if (lang == "en")
                {
                    return "You can attach no more than 10 attachments to a post.";
                }
                if (lang == "uk")
                {
                    return "Ви можете прикріпити до одного запису не більше 10 вкладень.";
                }
                if (lang == "be")
                {
                    return "Вы можаце прымацаваць да аднаго запісу не больш за 10 улажэнняў.";
                }
                return "";
            }
        }

        public static string Long_NoMoreThan2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете прикрепить к одному комментарию не более 2 вложений.";
                }
                if (lang == "en")
                {
                    return "You cab attach no more that 2 attachments to a comment.";
                }
                if (lang == "uk")
                {
                    return "Ви можете прикріпити до одного коментарю не більше 2 вкладень.";
                }
                if (lang == "be")
                {
                    return "Вы можаце прымацаваць да аднаго каментарыя не больш за 2 улажэнні.";
                }
                return "";
            }
        }

        public static string Long_NoMoreThan200MB
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы не можете загрузить файл, размер которого превышает 200 МБ.";
                }
                if (lang == "en")
                {
                    return "You cannot upload file that is larger than 200 MB.";
                }
                if (lang == "uk")
                {
                    return "Ви не можете завантажити файл, розмір якого перевищує 200 МБ.";
                }
                if (lang == "be")
                {
                    return "Вы не можаце загрузіць файл, памер якога перавышае 200 МБ.";
                }
                return "";
            }
        }

        public static string Long_NoMoreThan2GB
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы не можете загрузить видеозапись, размер которой превышает 2 ГБ.";
                }
                if (lang == "en")
                {
                    return "You cannot upload video file that is larger than 2 GB.";
                }
                if (lang == "uk")
                {
                    return "Ви не можете завантажити відеозапис, розмір якого перевищує 2 ГБ.";
                }
                if (lang == "be")
                {
                    return "Вы не можаце загрузіць відэазапіс, памер якога перавышае 2 ГБ.";
                }
                return "";
            }
        }

        public static string Long_NoVotes
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "На Вашем счёте недостаточно голосов.";
                }
                if (lang == "en")
                {
                    return "There are not enough votes on your account.";
                }
                if (lang == "uk")
                {
                    return "На Вашому рахунку недостатньо голосів.";
                }
                if (lang == "be")
                {
                    return "На Вашым рахунку недастаткова галасоў.";
                }
                return "";
            }
        }

        public static string Long_OpenDiscussionError
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось открыть это обсуждение. Возможно, оно было удалено.";
                }
                if (lang == "en")
                {
                    return "Opening of this discussion failed. It might have been deleted.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося відкрити це обговорення. Можливо, воно було видалено.";
                }
                if (lang == "be")
                {
                    return "Не ўдалося адкрыць гэтае абмеркаванне. Магчыма, яно было выдалена.";
                }
                return "";
            }
        }

        public static string Long_OpenPhotoError
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось открыть эту фотографию. Возможно, она была удалена.";
                }
                if (lang == "en")
                {
                    return "Opening of this photo failed. It might have been deleted.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося відкрити цю фотографію. Можливо, вона була видалена.";
                }
                if (lang == "be")
                {
                    return "Не ўдалося адкрыць гэты фотаздымак. Магчыма, ён быў выдалены.";
                }
                return "";
            }
        }

        public static string Long_OpenPostError
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось открыть эту запись. Возможно, она была удалена.";
                }
                if (lang == "en")
                {
                    return "Opening of this post failed. It might have been deleted. ";
                }
                if (lang == "uk")
                {
                    return "Не вдалося відкрити цей запис. Можливо, він був видалений.";
                }
                if (lang == "be")
                {
                    return "Не ўдалося адкрыць гэты запіс. Магчыма, ён быў выдалены.";
                }
                return "";
            }
        }

        public static string Long_OpenVideoError
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось открыть эту видеозапись. Возможно, она была удалена.";
                }
                if (lang == "en")
                {
                    return "Opening of this video failed. It might have been deleted.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося відкрити цей відеозапис. Можливо, він був видалений.";
                }
                if (lang == "be")
                {
                    return "Не ўдалося адкрыць гэты відэазапіс. Магчыма, ён быў выдалены.";
                }
                return "";
            }
        }

        public static string Long_PrivateCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Частное сообщество, доступ только по приглашениям.";
                }
                if (lang == "en")
                {
                    return "Private community, access is by invitations only.";
                }
                if (lang == "uk")
                {
                    return "Приватна спільнота, доступ тільки за запрошеннями.";
                }
                if (lang == "be")
                {
                    return "Прыватная суполка, доступ толькі па запрашэннях.";
                }
                return "";
            }
        }

        public static string Long_PrivateGift
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сообщение и имя отправителя видны только Вам";
                }
                if (lang == "en")
                {
                    return "only you can see the sender's name and message";
                }
                if (lang == "uk")
                {
                    return "повідомлення та ім'я надсилача бачите лише Ви";
                }
                if (lang == "be")
                {
                    return "паведамленне і імя адпраўніка бачныя толькі Вам";
                }
                return "";
            }
        }

        public static string Long_Profile100
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Официальная страница администрации ВКонтакте. Используется только для персональных оповещений.";
                }
                if (lang == "en")
                {
                    return "Official page of VK administration. It is only used for personal notifications.";
                }
                if (lang == "uk")
                {
                    return "Офіційна сторінка адміністрації ВКонтакті. Використовується тільки для персональних сповіщень.";
                }
                if (lang == "be")
                {
                    return "Афіцыйная старонка адміністрацыі УКантакце. Выкарыстоўваецца толькі для асабістых апавяшчэнняў.";
                }
                return "";
            }
        }

        public static string Long_Profile101
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Страница используется для обратной совместимости сервиса комментариев от имени сообщества.";
                }
                if (lang == "en")
                {
                    return "This page is used to provide backward compatibility for comments by communities.";
                }
                if (lang == "uk")
                {
                    return "Сторінка використовується для зворотної сумісності сервісу коментарів від імені спільноти.";
                }
                if (lang == "be")
                {
                    return "Старонка выкарыстоўваецца для зваротнай сумяшчальнасці сэрвісу каментарыяў ад імя суполкі.";
                }
                return "";
            }
        }

        public static string Long_Profile333
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Официальная страница мобильной поддержки ВКонтакте.";
                }
                if (lang == "en")
                {
                    return "Official page of VK mobile support.";
                }
                if (lang == "uk")
                {
                    return "Офіційна сторінка мобільної підтримки ВКонтакті.";
                }
                if (lang == "be")
                {
                    return "Афіцыйная старонка мабільнай падтрымкі УКантакце.";
                }
                return "";
            }
        }

        public static string Long_ReportWasSended
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Жалоба отправлена и будет рассмотрена в ближайшее время.";
                }
                if (lang == "en")
                {
                    return "Report has been sent and will be considered as soon as possible.";
                }
                if (lang == "uk")
                {
                    return "Скаргу надіслано, ​​і вона буде розглянута найближчим часом.";
                }
                if (lang == "be")
                {
                    return "Скарга дасланая і будзе разгледзена ў бліжэйшы час.";
                }
                return "";
            }
        }

        public static string Long_ShareError1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "При попытке поделиться произошла ошибка. Пожалуйста, авторизуйтесь.";
                }
                if (lang == "en")
                {
                    return "Error occured while attempting to share. Please, log in.";
                }
                if (lang == "uk")
                {
                    return "При спробі поділитися сталася помилка. Будь ласка, увійдіть.";
                }
                if (lang == "be")
                {
                    return "Пры спробе падзяліцца адбылася памылка. Калі ласка, аўтарызуйцеся.";
                }
                return "";
            }
        }

        public static string Long_ShareError2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "При попытке поделиться произошла ошибка. Пожалуйста, попробуйте ещё раз позже.";
                }
                if (lang == "en")
                {
                    return "Error occured while attempting to share. Please, try again later.";
                }
                if (lang == "uk")
                {
                    return "При спробі поділитися сталася помилка. Будь ласка, спробуйте ще раз пізніше.";
                }
                if (lang == "be")
                {
                    return "Пры спробе падзяліцца адбылася памылка. Калі ласка, паспрабуйце яшчэ раз пазней.";
                }
                return "";
            }
        }

        public static string Long_ShareError3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "При попытке поделиться произошла ошибка. Вы можете отправить не более 10 вложений сразу.";
                }
                if (lang == "en")
                {
                    return "Error occured while attempting to share. You can send no more than 10 attachments at once.";
                }
                if (lang == "uk")
                {
                    return "При спробі поділитися сталася помилка. Ви можете надіслати не більше 10 вкладень відразу.";
                }
                if (lang == "be")
                {
                    return "Пры спробе падзяліцца адбылася памылка. Вы можаце даслаць не больш за 10 укладанняў адразу.";
                }
                return "";
            }
        }

        public static string Long_TrainingsAudioCache
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете слушать ранее проигрывавшуюся музыку даже без соединения с интернетом. Для этого откройте кэшированные аудиозаписи.";
                }
                if (lang == "en")
                {
                    return "You can listen to the earlier played music even without an internet connection. Open cached audios to do this.";
                }
                if (lang == "uk")
                {
                    return "Ви можете слухати музику, яка раніше відвторювалася навіть без з'єднання з інтернетом. Для цього відкрийте кешування аудіозаписів.";
                }
                if (lang == "be")
                {
                    return "Вы можаце слухаць музыку, якая раней прайгравалася нават без злучэння з Інтэрнэтам. Для гэтага адкрыйце кэшыраваныя аўдыязапісы.";
                }
                return "";
            }
        }

        public static string Long_TrainingsAudioSwitchByMouse
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете быстро переключать аудиозаписи при помощи прокрутки в этой области.";
                }
                if (lang == "en")
                {
                    return "You can quickly switch over the audios by scrolling in this field.";
                }
                if (lang == "uk")
                {
                    return "Ви можете швидко перемикати аудіозаписи за допомогою прокрутки у цій частині.";
                }
                if (lang == "be")
                {
                    return "Вы можаце хутка пераключаць аўдыязапісы з дапамогай пракруткі ў гэтай вобласці.";
                }
                return "";
            }
        }

        public static string Long_TrainingsAudioSwitchByTouch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете быстро переключать аудиозаписи, проводя пальцем в этой области.";
                }
                if (lang == "en")
                {
                    return "You can quickly switch over the audios by swiping in this field.";
                }
                if (lang == "uk")
                {
                    return "Ви можете швидко перемикати аудіозаписи, проводячи пальцем у цій частині.";
                }
                if (lang == "be")
                {
                    return "Вы можаце хутка пераключаць аўдыязапісы, праводзячы пальцам у гэтай вобласці.";
                }
                return "";
            }
        }

        public static string Long_TrainingsBoards
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете перейти сразу к последнему комментарию в обсуждении, нажав в области информации о нём.";
                }
                if (lang == "en")
                {
                    return "You can directly go to the last comment of a discussion by tapping in the field of information about it.";
                }
                if (lang == "uk")
                {
                    return "Ви можете перейти відразу до останнього коментарю в обговоренні, натиснувши в частині інформації про нього.";
                }
                if (lang == "be")
                {
                    return "Вы можаце перайсці адразу да апошняга каментарыя ў абмеркаванні, націснуўшы ў вобласці інфармацыі пра яго.";
                }
                return "";
            }
        }

        public static string Long_TrainingsBottomBarByMouse
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "В некоторых случаях Вы можете получить доступ к дополнительным функциям управления, открыв специальную панель внизу, для этого нажав правую кнопку мыши.";
                }
                if (lang == "en")
                {
                    return "In some cases, you can get an access to additional management functions by tapping the right mouse button and opening the special bar below.";
                }
                if (lang == "uk")
                {
                    return "У деяких випадках Ви можете отримати доступ до додаткових функцій керування, відкривши спеціальну панель внизу, для цього натиснувши праву кнопку миші.";
                }
                if (lang == "be")
                {
                    return "У некаторых выпадках Вы можаце атрымаць доступ да дадатковых функцый кіравання, адкрыўшы спецыяльную панэль унізе, для гэтага націснуўшы правую кнопку мышы.";
                }
                return "";
            }
        }

        public static string Long_TrainingsBottomBarByTouch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "В некоторых случаях Вы можете получить доступ к дополнительным функциям управления, открыв специальную панель внизу, для этого проведя пальцем от нижнего края экрана.";
                }
                if (lang == "en")
                {
                    return "In some cases, you can get an access to additional management functions by swiping from the bottom part of the screen and opening the special bar below.";
                }
                if (lang == "uk")
                {
                    return "У деяких випадках Ви можете отримати доступ до додаткових функцій керування, відкривши спеціальну панель внизу, для цього провівши пальцем від нижнього краю екрана.";
                }
                if (lang == "be")
                {
                    return "У некаторых выпадках Вы можаце атрымаць доступ да дадатковых функцый кіравання, адкрыўшы спецыяльную панэль унізе, для гэтага правёўшы пальцам ад ніжняга краю экрана.";
                }
                return "";
            }
        }

        public static string Long_TrainingsDiscussionScroll
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете быстро перейти к противоположному концу обсуждения, нажав на эту кнопку.";
                }
                if (lang == "en")
                {
                    return "You can quickly go to the opposite end of a discussion by tapping this button.";
                }
                if (lang == "uk")
                {
                    return "Ви можете швидко перейти до протилежного кінця обговорення, натиснувши на цю кнопку.";
                }
                if (lang == "be")
                {
                    return "Вы можаце хутка перайсці да супрацьлеглага канца абмеркавання, націснуўшы на гэтую кнопку.";
                }
                return "";
            }
        }

        public static string Long_TrainingsMenuHolding
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете перейти в другой раздел, сохранив возможность последующего возврата назад. Удерживайте для этого нужный пункт меню.";
                }
                if (lang == "en")
                {
                    return "You can go to another section while keeping the possibility to return back at a later stage. Hold the desired menu item to do this.";
                }
                if (lang == "uk")
                {
                    return "Ви можете перейти в інший розділ, зберігши можливість подальшого повернення назад. Утримуйте для цього потрібний пункт меню.";
                }
                if (lang == "be")
                {
                    return "Вы можаце перайсці ў іншы раздзел, захаваўшы магчымасць далейшага звароту назад. Утрымліваце для гэтага патрэбны пункт меню.";
                }
                return "";
            }
        }

        public static string Long_TrainingsTitleTap
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете быстро прокрутить содержимое любой страницы в начало, нажав на её заголовок.";
                }
                if (lang == "en")
                {
                    return "You can quickly scroll any page content to the beginning by tapping on its title.";
                }
                if (lang == "uk")
                {
                    return "Ви можете швидко прокрутити вміст будь-якої сторінки на початок, натиснувши на її заголовок.";
                }
                if (lang == "be")
                {
                    return "Вы можаце хутка пракруціць змест любой старонкі на пачатак, націснуўшы на яе загаловак.";
                }
                return "";
            }
        }

        public static string Long_TrainingsTopBarByMouse
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Если меню приложения слева недоступно ввиду малого размера окна, Вы всегда можете открыть его, нажав правую кнопку мыши.";
                }
                if (lang == "en")
                {
                    return "If the app menu on the left side is not available because of the small size of the window, you can always open it by tapping the right mouse button.";
                }
                if (lang == "uk")
                {
                    return "Якщо меню додатка ліворуч недоступне через малий розмір вікна, Ви завжди можете відкрити його, натиснувши праву кнопку миші.";
                }
                if (lang == "be")
                {
                    return "Калі меню дадатку злева недаступнае з-за малога памеру акна, Вы заўсёды можаце адкрыць яго, націснуўшы правую кнопку мышы.";
                }
                return "";
            }
        }

        public static string Long_TrainingsTopBarByTouch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Если меню приложения слева недоступно ввиду малого размера окна, Вы всегда можете открыть его, проведя пальцем от верхнего края экрана.";
                }
                if (lang == "en")
                {
                    return "If the app menu on the left side is not available because of the small size of the window, you can always open it by swiping from the upper side of the screen.";
                }
                if (lang == "uk")
                {
                    return "Якщо меню додатка ліворуч недоступне через малий розмір вікна, Ви завжди можете відкрити його, провівши пальцем від верхнього краю екрана.";
                }
                if (lang == "be")
                {
                    return "Калі меню дадатку злева недаступнае з-за малога памеру акна, Вы заўсёды можаце адкрыць яго, правёўшы пальцам ад верхняга краю экрана.";
                }
                return "";
            }
        }

        public static string Long_VideoRules
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "• Файл не должен нарушать авторские и смежные права\n• Не должен содержать порнографические изображения несовершеннолетних\n• Не должен содержать сцены жестокости или насилия\n• Не должен противоречить законодательству РФ и Правилам ВКонтакте\n• Максимальный допустимый объем файла – 2 ГБ\n• Поддерживаются форматы AVI, MP4, 3GP, MPEG, MOV, MP3, FLV или WMV";
                }
                if (lang == "en")
                {
                    return "• File must not violate copyrighting laws and neighbouring rights\n• Must not contain underages pornographic images\n• Must not contain violence and brute force scenes\n• Must not be contrary to legislation of Russian Federation and VK terms\n• Maximum file size is 2 GB\n• Supported formats are AVI, MP4, 3GP, MPEG, MOV, MP3, FLV or WMV";
                }
                if (lang == "uk")
                {
                    return "• Файл не повинен порушувати авторські та суміжні права\n• Не повинен містити порнографічні зображення неповнолітніх\n• Не повинен містити сцени жорстокості або насильства\n• Не повинен суперечити законодавству РФ і Правилам ВКонтакті\n• Максимальний допустимий обсяг файлу – 2 ГБ\n• Підтримуються формати AVI, MP4, 3GP, MPEG, MOV, MP3, FLV або WMV";
                }
                if (lang == "be")
                {
                    return "• Файл не павінен парушаць аўтарскія і сумежныя правы\n• Не павінен змяшчаць парнаграфічныя выявы непаўналетніх\n• Не павінен змяшчаць сцэны жорсткасці або гвалту\n• Не павінен супярэчыць заканадаўству РФ і Правілам УКантакце\n• Максімальны дапушчальны аб'ём файла – 2 ГБ\n• Падтрымліваюцца фарматы AVI, MP4, 3GP, MPEG, MOV, MP3, FLV або WMV";
                }
                return "";
            }
        }

        public static string Long_YouCanSwitchOff1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете скрыть уведомления от этой беседы.";
                }
                if (lang == "en")
                {
                    return "You can hide the notifications of this conversation.";
                }
                if (lang == "uk")
                {
                    return "Ви можете приховати повідомлення від цієї бесіди.";
                }
                if (lang == "be")
                {
                    return "Вы можаце схаваць апавяшчэнні ад гэтай гутаркі.";
                }
                return "";
            }
        }

        public static string Long_YouCanSwitchOff2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы можете скрыть уведомления от этого пользователя.";
                }
                if (lang == "en")
                {
                    return "You can hide this user’s notifications.";
                }
                if (lang == "uk")
                {
                    return "Ви можете приховати повідомлення від цього користувача.";
                }
                if (lang == "be")
                {
                    return "Вы можаце схаваць апавяшчэнні ад гэтага карыстальніка.";
                }
                return "";
            }
        }

        public static string Loop
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Зацикливать воспроизведение";
                }
                if (lang == "en")
                {
                    return "Loop";
                }
                if (lang == "uk")
                {
                    return "Зациклювати відтворення";
                }
                if (lang == "be")
                {
                    return "Зацыкліваць прайграванне";
                }
                return "";
            }
        }

        public static string LoopOff
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не повторять";
                }
                if (lang == "en")
                {
                    return "Loop off";
                }
                if (lang == "uk")
                {
                    return "Не повторювати";
                }
                if (lang == "be")
                {
                    return "Не паўтараць";
                }
                return "";
            }
        }

        public static string LoopOn
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Повторять";
                }
                if (lang == "en")
                {
                    return "Loop on";
                }
                if (lang == "uk")
                {
                    return "Повторювати";
                }
                if (lang == "be")
                {
                    return "Паўтараць";
                }
                return "";
            }
        }

        public static string Lyrics
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Слова песни";
                }
                if (lang == "en")
                {
                    return "Lyrics";
                }
                if (lang == "uk")
                {
                    return "Слова пісні";
                }
                if (lang == "be")
                {
                    return "Словы песні";
                }
                return "";
            }
        }

        public static string Male
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Мужской";
                }
                if (lang == "en")
                {
                    return "Male";
                }
                if (lang == "uk")
                {
                    return "Чоловіча";
                }
                if (lang == "be")
                {
                    return "Мужчынскі";
                }
                return "";
            }
        }

        public static string Manage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Управление";
                }
                if (lang == "en")
                {
                    return "Manage";
                }
                if (lang == "uk")
                {
                    return "Керування";
                }
                if (lang == "be")
                {
                    return "Кіраванне";
                }
                return "";
            }
        }

        public static string Map
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Карта";
                }
                if (lang == "en")
                {
                    return "Map";
                }
                if (lang == "uk")
                {
                    return "Мапа";
                }
                if (lang == "be")
                {
                    return "Карта";
                }
                return "";
            }
        }

        public static string Map_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Карту";
                }
                if (lang == "en")
                {
                    return "Map";
                }
                if (lang == "uk")
                {
                    return "Мапу";
                }
                if (lang == "be")
                {
                    return "Карту";
                }
                return "";
            }
        }

        public static string MapsMode
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Режим карты";
                }
                if (lang == "en")
                {
                    return "Maps mode";
                }
                if (lang == "uk")
                {
                    return "Режим мапи";
                }
                if (lang == "be")
                {
                    return "Рэжым карты";
                }
                return "";
            }
        }

        public static string Married_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Замужем";
                }
                if (lang == "en")
                {
                    return "Married";
                }
                if (lang == "uk")
                {
                    return "Заміжня";
                }
                if (lang == "be")
                {
                    return "Замужам";
                }
                return "";
            }
        }

        public static string Married_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Женат";
                }
                if (lang == "en")
                {
                    return "Married";
                }
                if (lang == "uk")
                {
                    return "Одружений";
                }
                if (lang == "be")
                {
                    return "Жанаты";
                }
                return "";
            }
        }

        public static string MarriedTo_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Замужем за";
                }
                if (lang == "en")
                {
                    return "Married to";
                }
                if (lang == "uk")
                {
                    return "Одружена з";
                }
                if (lang == "be")
                {
                    return "Замужам за";
                }
                return "";
            }
        }

        public static string MarriedTo_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Женат на";
                }
                if (lang == "en")
                {
                    return "Married to";
                }
                if (lang == "uk")
                {
                    return "Одружений на";
                }
                if (lang == "be")
                {
                    return "Жанаты з";
                }
                return "";
            }
        }

        public static string MB
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "МБ";
                }
                if (lang == "en")
                {
                    return "MB";
                }
                if (lang == "uk")
                {
                    return "МБ";
                }
                if (lang == "be")
                {
                    return "МБ";
                }
                return "";
            }
        }

        public static string member1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "участник";
                }
                if (lang == "en")
                {
                    return "member";
                }
                if (lang == "uk")
                {
                    return "учасник";
                }
                if (lang == "be")
                {
                    return "удзельнік";
                }
                return "";
            }
        }

        public static string member2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "участника";
                }
                if (lang == "en")
                {
                    return "members";
                }
                if (lang == "uk")
                {
                    return "учасника";
                }
                if (lang == "be")
                {
                    return "удзельнікі";
                }
                return "";
            }
        }

        public static string member3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "участников";
                }
                if (lang == "en")
                {
                    return "members";
                }
                if (lang == "uk")
                {
                    return "учасників";
                }
                if (lang == "be")
                {
                    return "удзельнікаў";
                }
                return "";
            }
        }

        public static string Members
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Участники";
                }
                if (lang == "en")
                {
                    return "Members";
                }
                if (lang == "uk")
                {
                    return "Учасники";
                }
                if (lang == "be")
                {
                    return "Удзельнікі";
                }
                return "";
            }
        }

        public static string Mentions
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Упоминания";
                }
                if (lang == "en")
                {
                    return "Mentions";
                }
                if (lang == "uk")
                {
                    return "Згадки";
                }
                if (lang == "be")
                {
                    return "Згадкі";
                }
                return "";
            }
        }

        public static string message1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сообщение";
                }
                if (lang == "en")
                {
                    return "message";
                }
                if (lang == "uk")
                {
                    return "повідомлення";
                }
                if (lang == "be")
                {
                    return "паведамленне";
                }
                return "";
            }
        }

        public static string message2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сообщения";
                }
                if (lang == "en")
                {
                    return "messages";
                }
                if (lang == "uk")
                {
                    return "повідомлення";
                }
                if (lang == "be")
                {
                    return "паведамленні";
                }
                return "";
            }
        }

        public static string message3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сообщений";
                }
                if (lang == "en")
                {
                    return "messages";
                }
                if (lang == "uk")
                {
                    return "повідомлень";
                }
                if (lang == "be")
                {
                    return "паведамленняў";
                }
                return "";
            }
        }

        public static string Messages
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сообщения";
                }
                if (lang == "en")
                {
                    return "Messages";
                }
                if (lang == "uk")
                {
                    return "Повідомлення";
                }
                if (lang == "be")
                {
                    return "Паведамленні";
                }
                return "";
            }
        }

        public static string minuteAgo1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "минуту назад";
                }
                if (lang == "en")
                {
                    return "minute ago";
                }
                if (lang == "uk")
                {
                    return "хвилину тому";
                }
                if (lang == "be")
                {
                    return "хвіліну таму";
                }
                return "";
            }
        }

        public static string minuteAgo2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "минуты назад";
                }
                if (lang == "en")
                {
                    return "minutes ago";
                }
                if (lang == "uk")
                {
                    return "хвилини тому";
                }
                if (lang == "be")
                {
                    return "хвіліны таму";
                }
                return "";
            }
        }

        public static string minuteAgo3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "минут назад";
                }
                if (lang == "en")
                {
                    return "minutes ago";
                }
                if (lang == "uk")
                {
                    return "хвилин тому";
                }
                if (lang == "be")
                {
                    return "хвілін таму";
                }
                return "";
            }
        }

        public static string Mobile
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Мобильный телефон";
                }
                if (lang == "en")
                {
                    return "Mobile";
                }
                if (lang == "uk")
                {
                    return "Мобільний телефон";
                }
                if (lang == "be")
                {
                    return "Мабільны тэлефон";
                }
                return "";
            }
        }

        public static string MobileVersionOfSite
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Мобильная версия сайта";
                }
                if (lang == "en")
                {
                    return "Mobile version of site";
                }
                if (lang == "uk")
                {
                    return "Мобільна версія сайту";
                }
                if (lang == "be")
                {
                    return "Мабільная версія сайта";
                }
                return "";
            }
        }

        public static string Monarchist
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Монархические";
                }
                if (lang == "en")
                {
                    return "Monarchist";
                }
                if (lang == "uk")
                {
                    return "Монархічні";
                }
                if (lang == "be")
                {
                    return "Манархічныя";
                }
                return "";
            }
        }

        public static string Move
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Перенести";
                }
                if (lang == "en")
                {
                    return "Move";
                }
                if (lang == "uk")
                {
                    return "Перенести";
                }
                if (lang == "be")
                {
                    return "Перанесці";
                }
                return "";
            }
        }

        public static string Mutual
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Общие";
                }
                if (lang == "en")
                {
                    return "Mutual";
                }
                if (lang == "uk")
                {
                    return "Спільні";
                }
                if (lang == "be")
                {
                    return "Агульныя";
                }
                return "";
            }
        }

        public static string mutualFriend1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "общий друг";
                }
                if (lang == "en")
                {
                    return "mutual friend";
                }
                if (lang == "uk")
                {
                    return "спільний друг";
                }
                if (lang == "be")
                {
                    return "агульны сябар";
                }
                return "";
            }
        }

        public static string mutualFriend2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "общих друга";
                }
                if (lang == "en")
                {
                    return "mutual friends";
                }
                if (lang == "uk")
                {
                    return "спільних друзiв";
                }
                if (lang == "be")
                {
                    return "агульныя сябры";
                }
                return "";
            }
        }

        public static string mutualFriend3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "общих друзей";
                }
                if (lang == "en")
                {
                    return "mutual friends";
                }
                if (lang == "uk")
                {
                    return "спільних друзів";
                }
                if (lang == "be")
                {
                    return "агульных сяброў";
                }
                return "";
            }
        }

        public static string MutualFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Общие друзья";
                }
                if (lang == "en")
                {
                    return "Mutual friends";
                }
                if (lang == "uk")
                {
                    return "Спільні друзі";
                }
                if (lang == "be")
                {
                    return "Агульныя сябры";
                }
                return "";
            }
        }

        public static string MyPosts
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Мои записи";
                }
                if (lang == "en")
                {
                    return "My posts";
                }
                if (lang == "uk")
                {
                    return "Мої записи";
                }
                if (lang == "be")
                {
                    return "Мае запісы";
                }
                return "";
            }
        }

        public static string MyStickers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Мои стикеры";
                }
                if (lang == "en")
                {
                    return "My stickers";
                }
                if (lang == "uk")
                {
                    return "Мої стікери";
                }
                if (lang == "be")
                {
                    return "Мае стыкеры";
                }
                return "";
            }
        }

        public static string NativeTown
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Родной город";
                }
                if (lang == "en")
                {
                    return "Native town";
                }
                if (lang == "uk")
                {
                    return "Рідне місто";
                }
                if (lang == "be")
                {
                    return "Родны горад";
                }
                return "";
            }
        }

        public static string Negative
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Негативное";
                }
                if (lang == "en")
                {
                    return "Negative";
                }
                if (lang == "uk")
                {
                    return "Негативне";
                }
                if (lang == "be")
                {
                    return "Негатыўнае";
                }
                return "";
            }
        }

        public static string Neutral
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нейтральное";
                }
                if (lang == "en")
                {
                    return "Neutral";
                }
                if (lang == "uk")
                {
                    return "Нейтральне";
                }
                if (lang == "be")
                {
                    return "Нейтральнае";
                }
                return "";
            }
        }

        public static string NewAudio
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новая аудиозапись";
                }
                if (lang == "en")
                {
                    return "New audio";
                }
                if (lang == "uk")
                {
                    return "Новий аудіозапис";
                }
                if (lang == "be")
                {
                    return "Новы аўдыязапіс";
                }
                return "";
            }
        }

        public static string NewDocument
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новый документ";
                }
                if (lang == "en")
                {
                    return "New document";
                }
                if (lang == "uk")
                {
                    return "Новий документ";
                }
                if (lang == "be")
                {
                    return "Новы дакумент";
                }
                return "";
            }
        }

        public static string NewFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новые друзья";
                }
                if (lang == "en")
                {
                    return "New friends";
                }
                if (lang == "uk")
                {
                    return "Нові друзі";
                }
                if (lang == "be")
                {
                    return "Новыя сябры";
                }
                return "";
            }
        }

        public static string newLine
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "перенос строки";
                }
                if (lang == "en")
                {
                    return "new line";
                }
                if (lang == "uk")
                {
                    return "перенесення рядка";
                }
                if (lang == "be")
                {
                    return "перанос радка";
                }
                return "";
            }
        }

        public static string NewMessages
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новые сообщения";
                }
                if (lang == "en")
                {
                    return "New messages";
                }
                if (lang == "uk")
                {
                    return "Нові повідомлення";
                }
                if (lang == "be")
                {
                    return "Новыя паведамленні";
                }
                return "";
            }
        }

        public static string NewPassword
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новый пароль";
                }
                if (lang == "en")
                {
                    return "New password";
                }
                if (lang == "uk")
                {
                    return "Новий пароль";
                }
                if (lang == "be")
                {
                    return "Новы пароль";
                }
                return "";
            }
        }

        public static string NewPost
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новая запись";
                }
                if (lang == "en")
                {
                    return "New post";
                }
                if (lang == "uk")
                {
                    return "Новий запис";
                }
                if (lang == "be")
                {
                    return "Новы запіс";
                }
                return "";
            }
        }

        public static string News
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новости";
                }
                if (lang == "en")
                {
                    return "News";
                }
                if (lang == "uk")
                {
                    return "Новини";
                }
                if (lang == "be")
                {
                    return "Навіны";
                }
                return "";
            }
        }

        public static string newsItemSuggestedByYou
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "предложенная Вами новость";
                }
                if (lang == "en")
                {
                    return "news item suggested by you";
                }
                if (lang == "uk")
                {
                    return "запропонована Вами новина";
                }
                if (lang == "be")
                {
                    return "прапанаваная Вамі навіна";
                }
                return "";
            }
        }

        public static string NewsSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поиск по новостям";
                }
                if (lang == "en")
                {
                    return "News search";
                }
                if (lang == "uk")
                {
                    return "Пошук по новинах";
                }
                if (lang == "be")
                {
                    return "Пошук па навінах";
                }
                return "";
            }
        }

        public static string NewVideo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Новая видеозапись";
                }
                if (lang == "en")
                {
                    return "New video";
                }
                if (lang == "uk")
                {
                    return "Новий відеозапис";
                }
                if (lang == "be")
                {
                    return "Новы відэазапіс";
                }
                return "";
            }
        }

        public static string No
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет";
                }
                if (lang == "en")
                {
                    return "No";
                }
                if (lang == "uk")
                {
                    return "Немає";
                }
                if (lang == "be")
                {
                    return "Няма";
                }
                return "";
            }
        }

        public static string NoAlbums
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет альбомов";
                }
                if (lang == "en")
                {
                    return "No albums";
                }
                if (lang == "uk")
                {
                    return "Немає альбомів";
                }
                if (lang == "be")
                {
                    return "Няма альбомаў";
                }
                return "";
            }
        }

        public static string NoAudios
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет аудиозаписей";
                }
                if (lang == "en")
                {
                    return "No audios";
                }
                if (lang == "uk")
                {
                    return "Немає аудіозаписів";
                }
                if (lang == "be")
                {
                    return "Няма аўдыязапісаў";
                }
                return "";
            }
        }

        public static string NoBirthdays
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет дней рождения";
                }
                if (lang == "en")
                {
                    return "No birthdays";
                }
                if (lang == "uk")
                {
                    return "Немає днів народження";
                }
                if (lang == "be")
                {
                    return "Няма дзён нараджэння";
                }
                return "";
            }
        }

        public static string NoBlocked
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет заблокированных";
                }
                if (lang == "en")
                {
                    return "No blocked";
                }
                if (lang == "uk")
                {
                    return "Немає заблокованих";
                }
                if (lang == "be")
                {
                    return "Няма заблакаваных";
                }
                return "";
            }
        }

        public static string NoBookmarks
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет закладок";
                }
                if (lang == "en")
                {
                    return "No bookmarks";
                }
                if (lang == "uk")
                {
                    return "Немає закладок";
                }
                if (lang == "be")
                {
                    return "Няма закладак";
                }
                return "";
            }
        }

        public static string NoComments
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет комментариев";
                }
                if (lang == "en")
                {
                    return "No comments";
                }
                if (lang == "uk")
                {
                    return "Немає коментарів";
                }
                if (lang == "be")
                {
                    return "Няма каментарыяў";
                }
                return "";
            }
        }

        public static string NoCommunities
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет сообществ";
                }
                if (lang == "en")
                {
                    return "No communities";
                }
                if (lang == "uk")
                {
                    return "Немає спільнот";
                }
                if (lang == "be")
                {
                    return "Няма суполак";
                }
                return "";
            }
        }

        public static string NoConversations
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет диалогов";
                }
                if (lang == "en")
                {
                    return "No conversations";
                }
                if (lang == "uk")
                {
                    return "Немає діалогів";
                }
                if (lang == "be")
                {
                    return "Няма дыялогаў";
                }
                return "";
            }
        }

        public static string NoDiscussions
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет обсуждений";
                }
                if (lang == "en")
                {
                    return "No discussions";
                }
                if (lang == "uk")
                {
                    return "Немає обговорень";
                }
                if (lang == "be")
                {
                    return "Няма абмеркаванняў";
                }
                return "";
            }
        }

        public static string NoDocuments
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет документов";
                }
                if (lang == "en")
                {
                    return "No documents";
                }
                if (lang == "uk")
                {
                    return "Немає документів";
                }
                if (lang == "be")
                {
                    return "Няма дакументаў";
                }
                return "";
            }
        }

        public static string NoFeedback
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет ответов";
                }
                if (lang == "en")
                {
                    return "No feedback";
                }
                if (lang == "uk")
                {
                    return "Немає відповідей";
                }
                if (lang == "be")
                {
                    return "Няма адказаў";
                }
                return "";
            }
        }

        public static string NoFollowers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет подписчиков";
                }
                if (lang == "en")
                {
                    return "No followers";
                }
                if (lang == "uk")
                {
                    return "Немає підписників";
                }
                if (lang == "be")
                {
                    return "Няма падпісчыкаў";
                }
                return "";
            }
        }

        public static string NoFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет друзей";
                }
                if (lang == "en")
                {
                    return "No friends";
                }
                if (lang == "uk")
                {
                    return "Немає друзів";
                }
                if (lang == "be")
                {
                    return "Няма сяброў";
                }
                return "";
            }
        }

        public static string NoFriendsOnline
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет друзей онлайн";
                }
                if (lang == "en")
                {
                    return "No friends online";
                }
                if (lang == "uk")
                {
                    return "Немає друзів онлайн";
                }
                if (lang == "be")
                {
                    return "Няма сяброў у сетцы";
                }
                return "";
            }
        }

        public static string NoGifts
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет подарков";
                }
                if (lang == "en")
                {
                    return "No gifts";
                }
                if (lang == "uk")
                {
                    return "Немає подарунків";
                }
                if (lang == "be")
                {
                    return "Няма падарункаў";
                }
                return "";
            }
        }

        public static string NoLikes
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет оценивших";
                }
                if (lang == "en")
                {
                    return "No likes";
                }
                if (lang == "uk")
                {
                    return "Немає оцінивших";
                }
                if (lang == "be")
                {
                    return "Ніхто не ацаніў";
                }
                return "";
            }
        }

        public static string NoMembers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет участников";
                }
                if (lang == "en")
                {
                    return "No members";
                }
                if (lang == "uk")
                {
                    return "Немає учасників";
                }
                if (lang == "be")
                {
                    return "Няма удзельнікаў";
                }
                return "";
            }
        }

        public static string NoMessages
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет сообщений";
                }
                if (lang == "en")
                {
                    return "No messages";
                }
                if (lang == "uk")
                {
                    return "Немає повідомлень";
                }
                if (lang == "be")
                {
                    return "Няма паведамленняў";
                }
                return "";
            }
        }

        public static string NoNews
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет новостей";
                }
                if (lang == "en")
                {
                    return "No news";
                }
                if (lang == "uk")
                {
                    return "Немає новин";
                }
                if (lang == "be")
                {
                    return "Няма навін";
                }
                return "";
            }
        }

        public static string NoPhotos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет фотографий";
                }
                if (lang == "en")
                {
                    return "No photos";
                }
                if (lang == "uk")
                {
                    return "Немає фотографій";
                }
                if (lang == "be")
                {
                    return "Няма фотаздымкаў";
                }
                return "";
            }
        }

        public static string NoPosts
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет записей";
                }
                if (lang == "en")
                {
                    return "No posts";
                }
                if (lang == "uk")
                {
                    return "Немає записів";
                }
                if (lang == "be")
                {
                    return "Няма запісаў";
                }
                return "";
            }
        }

        public static string NoResults
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет результатов";
                }
                if (lang == "en")
                {
                    return "No results";
                }
                if (lang == "uk")
                {
                    return "Немає результатів";
                }
                if (lang == "be")
                {
                    return "Няма рэзультатаў";
                }
                return "";
            }
        }

        public static string NoSubscriptions
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет подписок";
                }
                if (lang == "en")
                {
                    return "No subscriptions";
                }
                if (lang == "uk")
                {
                    return "Немає підписок";
                }
                if (lang == "be")
                {
                    return "Няма падпісак";
                }
                return "";
            }
        }

        public static string NoSuggestedFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет возможных друзей";
                }
                if (lang == "en")
                {
                    return "No suggested friends";
                }
                if (lang == "uk")
                {
                    return "Немає можливих друзів";
                }
                if (lang == "be")
                {
                    return "Няма магчымых сяброў";
                }
                return "";
            }
        }

        public static string Note
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Заметка";
                }
                if (lang == "en")
                {
                    return "Note";
                }
                if (lang == "uk")
                {
                    return "Нотатка";
                }
                if (lang == "be")
                {
                    return "Нататка";
                }
                return "";
            }
        }

        public static string Notes
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Заметки";
                }
                if (lang == "en")
                {
                    return "Notes";
                }
                if (lang == "uk")
                {
                    return "Нотатки";
                }
                if (lang == "be")
                {
                    return "Нататкі";
                }
                return "";
            }
        }

        public static string NoteworthyPages
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Интересные страницы";
                }
                if (lang == "en")
                {
                    return "Noteworthy pages";
                }
                if (lang == "uk")
                {
                    return "Цікаві сторінки";
                }
                if (lang == "be")
                {
                    return "Цікавыя старонкі";
                }
                return "";
            }
        }

        public static string NoThanks
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не могу пойти";
                }
                if (lang == "en")
                {
                    return "No, thanks";
                }
                if (lang == "uk")
                {
                    return "Неможу піти";
                }
                if (lang == "be")
                {
                    return "Не магу пайсці";
                }
                return "";
            }
        }

        public static string Notifications
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Уведомления";
                }
                if (lang == "en")
                {
                    return "Notifications";
                }
                if (lang == "uk")
                {
                    return "Сповіщення";
                }
                if (lang == "be")
                {
                    return "Апавяшчэнні";
                }
                return "";
            }
        }

        public static string NotificationsAreDisabled
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Уведомления отключены";
                }
                if (lang == "en")
                {
                    return "Notifications are disabled";
                }
                if (lang == "uk")
                {
                    return "Сповіщення відключені";
                }
                if (lang == "be")
                {
                    return "Апавяшчэнні адключаны";
                }
                return "";
            }
        }

        public static string NotificationsAreDisabledUntil
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Уведомления отключены до";
                }
                if (lang == "en")
                {
                    return "Notifications are disabled until";
                }
                if (lang == "uk")
                {
                    return "Сповіщення відключені до";
                }
                if (lang == "be")
                {
                    return "Апавяшчэнні адключаны да";
                }
                return "";
            }
        }

        public static string NotificationsSettings
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Настройки уведомлений";
                }
                if (lang == "en")
                {
                    return "Notifications settings";
                }
                if (lang == "uk")
                {
                    return "Налаштування сповіщень";
                }
                if (lang == "be")
                {
                    return "Налады апавяшчэнняў";
                }
                return "";
            }
        }

        public static string NotificationsTypes
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Типы уведомлений";
                }
                if (lang == "en")
                {
                    return "Notifications types";
                }
                if (lang == "uk")
                {
                    return "Типи сповіщень";
                }
                if (lang == "be")
                {
                    return "Тыпы апавяшчэнняў";
                }
                return "";
            }
        }

        public static string NotInteresting
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не интересно";
                }
                if (lang == "en")
                {
                    return "Not interesting";
                }
                if (lang == "uk")
                {
                    return "Не цікаво";
                }
                if (lang == "be")
                {
                    return "Нецікава";
                }
                return "";
            }
        }

        public static string NotMarried_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не замужем";
                }
                if (lang == "en")
                {
                    return "Not married";
                }
                if (lang == "uk")
                {
                    return "Не заміжня";
                }
                if (lang == "be")
                {
                    return "Не замужам";
                }
                return "";
            }
        }

        public static string NotMarried_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не женат";
                }
                if (lang == "en")
                {
                    return "Not married";
                }
                if (lang == "uk")
                {
                    return "Неодружений";
                }
                if (lang == "be")
                {
                    return "Не жанаты";
                }
                return "";
            }
        }

        public static string NoVideos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Нет видеозаписей";
                }
                if (lang == "en")
                {
                    return "No videos";
                }
                if (lang == "uk")
                {
                    return "Немає відеозаписів";
                }
                if (lang == "be")
                {
                    return "Няма відэазапісаў";
                }
                return "";
            }
        }

        public static string ofCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сообщества";
                }
                if (lang == "en")
                {
                    return "of community";
                }
                if (lang == "uk")
                {
                    return "спільноти";
                }
                if (lang == "be")
                {
                    return "суполкі";
                }
                return "";
            }
        }

        public static string Off
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выключено";
                }
                if (lang == "en")
                {
                    return "Off";
                }
                if (lang == "uk")
                {
                    return "Вимкнено";
                }
                if (lang == "be")
                {
                    return "Адключана";
                }
                return "";
            }
        }

        public static string OffensiveBehavior
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Оскорбительное поведение";
                }
                if (lang == "en")
                {
                    return "Offensive behavior";
                }
                if (lang == "uk")
                {
                    return "Образлива поведінка";
                }
                if (lang == "be")
                {
                    return "Абразлівыя паводзіны";
                }
                return "";
            }
        }

        public static string OfficialCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Официальное сообщество";
                }
                if (lang == "en")
                {
                    return "Official community";
                }
                if (lang == "uk")
                {
                    return "Офіційна спільнота";
                }
                if (lang == "be")
                {
                    return "Афіцыйная суполка";
                }
                return "";
            }
        }

        public static string On
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Включено";
                }
                if (lang == "en")
                {
                    return "On";
                }
                if (lang == "uk")
                {
                    return "Увімкнено";
                }
                if (lang == "be")
                {
                    return "Уключана";
                }
                return "";
            }
        }

        public static string Online
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Онлайн";
                }
                if (lang == "en")
                {
                    return "Online";
                }
                if (lang == "uk")
                {
                    return "Онлайн";
                }
                if (lang == "be")
                {
                    return "У сетцы";
                }
                return "";
            }
        }

        public static string OnlineNow
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сейчас в сети";
                }
                if (lang == "en")
                {
                    return "Online now";
                }
                if (lang == "uk")
                {
                    return "Зараз у мережі";
                }
                if (lang == "be")
                {
                    return "Зараз у сетцы";
                }
                return "";
            }
        }

        public static string OnlyMe
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Только я";
                }
                if (lang == "en")
                {
                    return "Only me";
                }
                if (lang == "uk")
                {
                    return "Тільки я";
                }
                if (lang == "be")
                {
                    return "Толькі я";
                }
                return "";
            }
        }

        public static string onYourWall
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "на Вашей стене";
                }
                if (lang == "en")
                {
                    return "on your wall";
                }
                if (lang == "uk")
                {
                    return "на Вашій стіні";
                }
                if (lang == "be")
                {
                    return "на Вашай сцяне";
                }
                return "";
            }
        }

        public static string OpenInBrowser
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Открыть в браузере";
                }
                if (lang == "en")
                {
                    return "Open in browser";
                }
                if (lang == "uk")
                {
                    return "Відкрити у браузері";
                }
                if (lang == "be")
                {
                    return "Адкрыць у браўзеры";
                }
                return "";
            }
        }

        public static string OpenLink
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Открыть ссылку";
                }
                if (lang == "en")
                {
                    return "Open link";
                }
                if (lang == "uk")
                {
                    return "Відкрити посилання";
                }
                if (lang == "be")
                {
                    return "Адкрыць спасылку";
                }
                return "";
            }
        }

        public static string outOf
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "из";
                }
                if (lang == "en")
                {
                    return "out of";
                }
                if (lang == "uk")
                {
                    return "з";
                }
                if (lang == "be")
                {
                    return "з";
                }
                return "";
            }
        }

        public static string Page
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Страница";
                }
                if (lang == "en")
                {
                    return "Page";
                }
                if (lang == "uk")
                {
                    return "Сторінка";
                }
                if (lang == "be")
                {
                    return "Старонка";
                }
                return "";
            }
        }

        public static string PageWasBlockedByAdministration
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Страница заблокирована администрацией.";
                }
                if (lang == "en")
                {
                    return "Page was blocked by administration.";
                }
                if (lang == "uk")
                {
                    return "Сторінка заблокована адміністрацією.";
                }
                if (lang == "be")
                {
                    return "Старонка заблакавана адміністрацыяй.";
                }
                return "";
            }
        }

        public static string PageWasDeletedByUser
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Страница удалена пользователем.";
                }
                if (lang == "en")
                {
                    return "Page was deleted by user.";
                }
                if (lang == "uk")
                {
                    return "Сторінка видалена користувачем.";
                }
                if (lang == "be")
                {
                    return "Старонка выдалена карыстальнікам.";
                }
                return "";
            }
        }

        public static string Parameters
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Параметры";
                }
                if (lang == "en")
                {
                    return "Options";
                }
                if (lang == "uk")
                {
                    return "Параметри";
                }
                if (lang == "be")
                {
                    return "Параметры";
                }
                return "";
            }
        }

        public static string Parents
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Родители";
                }
                if (lang == "en")
                {
                    return "Parents";
                }
                if (lang == "uk")
                {
                    return "Батьки";
                }
                if (lang == "be")
                {
                    return "Бацькі";
                }
                return "";
            }
        }

        public static string Password
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пароль";
                }
                if (lang == "en")
                {
                    return "Password";
                }
                if (lang == "uk")
                {
                    return "Пароль";
                }
                if (lang == "be")
                {
                    return "Пароль";
                }
                return "";
            }
        }

        public static string PasswordChanging
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменение пароля";
                }
                if (lang == "en")
                {
                    return "Password changing";
                }
                if (lang == "uk")
                {
                    return "Зміна пароля";
                }
                if (lang == "be")
                {
                    return "Змена пароля";
                }
                return "";
            }
        }

        public static string PasteVideoLink
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вставьте ссылку на видео";
                }
                if (lang == "en")
                {
                    return "Paste video link";
                }
                if (lang == "uk")
                {
                    return "Вставте посилання на відео";
                }
                if (lang == "be")
                {
                    return "Устаўце спасылку на відэа";
                }
                return "";
            }
        }

        public static string PasteVKLink
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вставьте ссылку на страницу ВКонтакте";
                }
                if (lang == "en")
                {
                    return "Paste a link to VK page";
                }
                if (lang == "uk")
                {
                    return "Вставте посилання на сторiнку ВКонтактi";
                }
                if (lang == "be")
                {
                    return "Устаўце спасылку на старонку УКантакце";
                }
                return "";
            }
        }

        public static string People
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Люди";
                }
                if (lang == "en")
                {
                    return "People";
                }
                if (lang == "uk")
                {
                    return "Люди";
                }
                if (lang == "be")
                {
                    return "Людзі";
                }
                return "";
            }
        }

        public static string person1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "человек";
                }
                if (lang == "en")
                {
                    return "person";
                }
                if (lang == "uk")
                {
                    return "людина";
                }
                if (lang == "be")
                {
                    return "чалавек";
                }
                return "";
            }
        }

        public static string person2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "человека";
                }
                if (lang == "en")
                {
                    return "people";
                }
                if (lang == "uk")
                {
                    return "людини";
                }
                if (lang == "be")
                {
                    return "чалавекі";
                }
                return "";
            }
        }

        public static string PersonalDevelopment
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Саморазвитие";
                }
                if (lang == "en")
                {
                    return "Personal development";
                }
                if (lang == "uk")
                {
                    return "Саморозвиток";
                }
                if (lang == "be")
                {
                    return "Самаразвіццё";
                }
                return "";
            }
        }

        public static string PersonalPriority
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Главное в жизни";
                }
                if (lang == "en")
                {
                    return "Personal priority";
                }
                if (lang == "uk")
                {
                    return "Головне в житті";
                }
                if (lang == "be")
                {
                    return "Галоўнае ў жыцці";
                }
                return "";
            }
        }

        public static string PersonJoinedConversation_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "пригласила";
                }
                if (lang == "en")
                {
                    return "invited";
                }
                if (lang == "uk")
                {
                    return "запросила";
                }
                if (lang == "be")
                {
                    return "запрасіла";
                }
                return "";
            }
        }

        public static string PersonJoinedConversation_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "пригласил";
                }
                if (lang == "en")
                {
                    return "invited";
                }
                if (lang == "uk")
                {
                    return "запросив";
                }
                if (lang == "be")
                {
                    return "запрасіў";
                }
                return "";
            }
        }

        public static string personVoted1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "человек проголосовал";
                }
                if (lang == "en")
                {
                    return "person voted";
                }
                if (lang == "uk")
                {
                    return "людина проголосувала";
                }
                if (lang == "be")
                {
                    return "чалавек прагаласаваў";
                }
                return "";
            }
        }

        public static string personVoted2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "человека проголосовало";
                }
                if (lang == "en")
                {
                    return "people voted";
                }
                if (lang == "uk")
                {
                    return "людини проголосувало";
                }
                if (lang == "be")
                {
                    return "чалавекі прагаласавалі";
                }
                return "";
            }
        }

        public static string personVoted3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "человек проголосовало";
                }
                if (lang == "en")
                {
                    return "people voted";
                }
                if (lang == "uk")
                {
                    return "людей проголосувало";
                }
                if (lang == "be")
                {
                    return "чалавек прагаласавала";
                }
                return "";
            }
        }

        public static string Phonebook
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Телефонная книга";
                }
                if (lang == "en")
                {
                    return "Phonebook";
                }
                if (lang == "uk")
                {
                    return "Телефонна книга";
                }
                if (lang == "be")
                {
                    return "Тэлефонная кніга";
                }
                return "";
            }
        }

        public static string PhoneNumberOrEmail
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Номер телефона или E-Mail";
                }
                if (lang == "en")
                {
                    return "Phone number or E-Mail";
                }
                if (lang == "uk")
                {
                    return "Номер телефону або E-Mail";
                }
                if (lang == "be")
                {
                    return "Нумар тэлефона або E-Mail";
                }
                return "";
            }
        }

        public static string Photo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фотография";
                }
                if (lang == "en")
                {
                    return "Photo";
                }
                if (lang == "uk")
                {
                    return "Фотографія";
                }
                if (lang == "be")
                {
                    return "Фотаздымак";
                }
                return "";
            }
        }

        public static string Photo_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фотографию";
                }
                if (lang == "en")
                {
                    return "Photo";
                }
                if (lang == "uk")
                {
                    return "Фотографію";
                }
                if (lang == "be")
                {
                    return "Фотаздымак";
                }
                return "";
            }
        }

        public static string photo1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "фотография";
                }
                if (lang == "en")
                {
                    return "photo";
                }
                if (lang == "uk")
                {
                    return "фотографiя";
                }
                if (lang == "be")
                {
                    return "фотаздымак";
                }
                return "";
            }
        }

        public static string photo2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "фотографии";
                }
                if (lang == "en")
                {
                    return "photos";
                }
                if (lang == "uk")
                {
                    return "фотографії";
                }
                if (lang == "be")
                {
                    return "фотаздымкі";
                }
                return "";
            }
        }

        public static string photo3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "фотографий";
                }
                if (lang == "en")
                {
                    return "photos";
                }
                if (lang == "uk")
                {
                    return "фотографій";
                }
                if (lang == "be")
                {
                    return "фотаздымкаў";
                }
                return "";
            }
        }

        public static string PhotoAlbums
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фотоальбомы";
                }
                if (lang == "en")
                {
                    return "Photo albums";
                }
                if (lang == "uk")
                {
                    return "Фотоальбоми";
                }
                if (lang == "be")
                {
                    return "Фотаальбомы";
                }
                return "";
            }
        }

        public static string PhotoEditing
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменение фотографии";
                }
                if (lang == "en")
                {
                    return "Photo editing";
                }
                if (lang == "uk")
                {
                    return "Зміна фотографії";
                }
                if (lang == "be")
                {
                    return "Змена фотаздымка";
                }
                return "";
            }
        }

        public static string Photos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фотографии";
                }
                if (lang == "en")
                {
                    return "Photos";
                }
                if (lang == "uk")
                {
                    return "Фотографії";
                }
                if (lang == "be")
                {
                    return "Фотаздымкі";
                }
                return "";
            }
        }

        public static string Photos_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фото";
                }
                if (lang == "en")
                {
                    return "Photos";
                }
                if (lang == "uk")
                {
                    return "Фото";
                }
                if (lang == "be")
                {
                    return "Фота";
                }
                return "";
            }
        }

        public static string PhotoSending
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отправка фотографии";
                }
                if (lang == "en")
                {
                    return "Photo sending";
                }
                if (lang == "uk")
                {
                    return "Надсилання фотографії";
                }
                if (lang == "be")
                {
                    return "Адпраўка фотаздымка";
                }
                return "";
            }
        }

        public static string PhotosFromWall
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фотографии со стены";
                }
                if (lang == "en")
                {
                    return "Photos from wall";
                }
                if (lang == "uk")
                {
                    return "Фотографії зі стіни";
                }
                if (lang == "be")
                {
                    return "Фотаздымкі са сцяны";
                }
                return "";
            }
        }

        public static string PhotosOf
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фотографии с";
                }
                if (lang == "en")
                {
                    return "Photos of";
                }
                if (lang == "uk")
                {
                    return "Фотографії з";
                }
                if (lang == "be")
                {
                    return "Фотаздымкі з";
                }
                return "";
            }
        }

        public static string PhotosOfMe
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фотографии со мной";
                }
                if (lang == "en")
                {
                    return "Photos of me";
                }
                if (lang == "uk")
                {
                    return "Фотографії зі мною";
                }
                if (lang == "be")
                {
                    return "Фотаздымкі са мной";
                }
                return "";
            }
        }

        public static string Pin
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Закрепить";
                }
                if (lang == "en")
                {
                    return "Pin";
                }
                if (lang == "uk")
                {
                    return "Закріпити";
                }
                if (lang == "be")
                {
                    return "Замацаваць";
                }
                return "";
            }
        }

        public static string Place
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Место";
                }
                if (lang == "en")
                {
                    return "Place";
                }
                if (lang == "uk")
                {
                    return "Місце";
                }
                if (lang == "be")
                {
                    return "Месца";
                }
                return "";
            }
        }

        public static string PoliticalViews
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Политические предпочтения";
                }
                if (lang == "en")
                {
                    return "Political views";
                }
                if (lang == "uk")
                {
                    return "Політичні уподобання";
                }
                if (lang == "be")
                {
                    return "Палітычныя погляды";
                }
                return "";
            }
        }

        public static string Popular
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Популярное";
                }
                if (lang == "en")
                {
                    return "Popular";
                }
                if (lang == "uk")
                {
                    return "Популярне";
                }
                if (lang == "be")
                {
                    return "Папулярнае";
                }
                return "";
            }
        }

        public static string Pornography
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Порнография";
                }
                if (lang == "en")
                {
                    return "Pornography";
                }
                if (lang == "uk")
                {
                    return "Порнографія";
                }
                if (lang == "be")
                {
                    return "Парнаграфія";
                }
                return "";
            }
        }

        public static string Positive
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Положительное";
                }
                if (lang == "en")
                {
                    return "Positive";
                }
                if (lang == "uk")
                {
                    return "Позитивне";
                }
                if (lang == "be")
                {
                    return "Станоўчае";
                }
                return "";
            }
        }

        public static string Post
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Запись";
                }
                if (lang == "en")
                {
                    return "Post";
                }
                if (lang == "uk")
                {
                    return "Запис";
                }
                if (lang == "be")
                {
                    return "Запіс";
                }
                return "";
            }
        }

        public static string PostAsCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "От имени группы";
                }
                if (lang == "en")
                {
                    return "Post as community";
                }
                if (lang == "uk")
                {
                    return "Від імені спільноти";
                }
                if (lang == "be")
                {
                    return "Ад імя суполкі";
                }
                return "";
            }
        }

        public static string PostingOfThisCommentFailed
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось опубликовать этот комментарий.";
                }
                if (lang == "en")
                {
                    return "Posting of this comment failed.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося опублікувати цей коментар.";
                }
                if (lang == "be")
                {
                    return "Не атрымалася апублікаваць гэты каментарый.";
                }
                return "";
            }
        }

        public static string PostOnCommunityWall
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Опубликовать на стене сообщества";
                }
                if (lang == "en")
                {
                    return "Post on community wall";
                }
                if (lang == "uk")
                {
                    return "Опублікувати на стіні спільноти";
                }
                if (lang == "be")
                {
                    return "Апублікаваць на сцяне суполкі";
                }
                return "";
            }
        }

        public static string PostOnMyPage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Опубликовать на моей странице";
                }
                if (lang == "en")
                {
                    return "Post on my page";
                }
                if (lang == "uk")
                {
                    return "Опублікувати на моїй сторінці";
                }
                if (lang == "be")
                {
                    return "Апублікаваць на маёй старонцы";
                }
                return "";
            }
        }

        public static string PostOnMyWall
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Опубликовать на моей стене";
                }
                if (lang == "en")
                {
                    return "Post on my wall";
                }
                if (lang == "uk")
                {
                    return "Опублікувати на моїй стіні";
                }
                if (lang == "be")
                {
                    return "Апублікаваць на маёй сцяне";
                }
                return "";
            }
        }

        public static string PostOnUsersWall
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Опубликовать на стене пользователя";
                }
                if (lang == "en")
                {
                    return "Post on user’s wall";
                }
                if (lang == "uk")
                {
                    return "Опублікувати на стіні користувача";
                }
                if (lang == "be")
                {
                    return "Апублікаваць на сцяне карыстальніка";
                }
                return "";
            }
        }

        public static string PostOnWall
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Запись на стене";
                }
                if (lang == "en")
                {
                    return "Post on wall";
                }
                if (lang == "uk")
                {
                    return "Запис на стіні";
                }
                if (lang == "be")
                {
                    return "Запіс на сцяне";
                }
                return "";
            }
        }

        public static string PostPublishing
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Публикация записи";
                }
                if (lang == "en")
                {
                    return "Post publishing";
                }
                if (lang == "uk")
                {
                    return "Публікація запису";
                }
                if (lang == "be")
                {
                    return "Публікацыя запісу";
                }
                return "";
            }
        }

        public static string Posts
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Записи";
                }
                if (lang == "en")
                {
                    return "Posts";
                }
                if (lang == "uk")
                {
                    return "Записи";
                }
                if (lang == "be")
                {
                    return "Запісы";
                }
                return "";
            }
        }

        public static string PostSending
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отправка записи";
                }
                if (lang == "en")
                {
                    return "Post sending";
                }
                if (lang == "uk")
                {
                    return "Надсилання запису";
                }
                if (lang == "be")
                {
                    return "Адпраўка запісу";
                }
                return "";
            }
        }

        public static string PreviewMessageTextInPushNotifications
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Предпросмотр во всплывающих оповещениях";
                }
                if (lang == "en")
                {
                    return "Preview message text in push notifications";
                }
                if (lang == "uk")
                {
                    return "Попередній перегляд повідомлень у вигулькових сповіщеннях";
                }
                if (lang == "be")
                {
                    return "Перадпрагляд у выплыўных апавяшчэннях";
                }
                return "";
            }
        }

        public static string Price
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Стоимость";
                }
                if (lang == "en")
                {
                    return "Price";
                }
                if (lang == "uk")
                {
                    return "Вартість";
                }
                if (lang == "be")
                {
                    return "Кошт";
                }
                return "";
            }
        }

        public static string PrivacyPolicy
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Политика конфиденциальности";
                }
                if (lang == "en")
                {
                    return "Privacy policy";
                }
                if (lang == "uk")
                {
                    return "Політика конфіденційності";
                }
                if (lang == "be")
                {
                    return "Палітыка канфідэнцыяльнасці";
                }
                return "";
            }
        }

        public static string ProfilePhoto
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фотография со страницы";
                }
                if (lang == "en")
                {
                    return "Profile photo";
                }
                if (lang == "uk")
                {
                    return "Фотографія зі сторінки";
                }
                if (lang == "be")
                {
                    return "Фотаздымак са старонкі";
                }
                return "";
            }
        }

        public static string ProfilePhotos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Фотографии со страницы";
                }
                if (lang == "en")
                {
                    return "Profile photos";
                }
                if (lang == "uk")
                {
                    return "Фотографії зі сторінки";
                }
                if (lang == "be")
                {
                    return "Фотаздымкі са старонкі";
                }
                return "";
            }
        }

        public static string PublicPage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Публичная страница";
                }
                if (lang == "en")
                {
                    return "Public page";
                }
                if (lang == "uk")
                {
                    return "Публічна сторінка";
                }
                if (lang == "be")
                {
                    return "Публічная старонка";
                }
                return "";
            }
        }

        public static string PublicPoll
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Открытое голосование";
                }
                if (lang == "en")
                {
                    return "Public poll";
                }
                if (lang == "uk")
                {
                    return "Відкрите голосування";
                }
                if (lang == "be")
                {
                    return "Адкрытае галасаванне";
                }
                return "";
            }
        }

        public static string PublishingOfThisPostFailed
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось опубликовать эту запись.";
                }
                if (lang == "en")
                {
                    return "Publishing of this post failed.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося опублікувати цей запис.";
                }
                if (lang == "be")
                {
                    return "Не ўдалося апублікаваць гэты запіс.";
                }
                return "";
            }
        }

        public static string RateTheApp
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Оценить приложение";
                }
                if (lang == "en")
                {
                    return "Rate the app";
                }
                if (lang == "uk")
                {
                    return "Оцінити додаток";
                }
                if (lang == "be")
                {
                    return "Ацаніць дадатак";
                }
                return "";
            }
        }

        public static string Recipient
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Получатель";
                }
                if (lang == "en")
                {
                    return "Recipient";
                }
                if (lang == "uk")
                {
                    return "Отримувач";
                }
                if (lang == "be")
                {
                    return "Атрымальнік";
                }
                return "";
            }
        }

        public static string Refresh
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Обновить";
                }
                if (lang == "en")
                {
                    return "Refresh";
                }
                if (lang == "uk")
                {
                    return "Оновити";
                }
                if (lang == "be")
                {
                    return "Абнавіць";
                }
                return "";
            }
        }

        public static string Region
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Регион";
                }
                if (lang == "en")
                {
                    return "Region";
                }
                if (lang == "uk")
                {
                    return "Регіон";
                }
                if (lang == "be")
                {
                    return "Рэгіён";
                }
                return "";
            }
        }

        public static string RelationshipStatus
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Семейное положение";
                }
                if (lang == "en")
                {
                    return "Relationship status";
                }
                if (lang == "uk")
                {
                    return "Сімейний стан";
                }
                if (lang == "be")
                {
                    return "Сямейнае становішча";
                }
                return "";
            }
        }

        public static string Relatives
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Родственники";
                }
                if (lang == "en")
                {
                    return "Relatives";
                }
                if (lang == "uk")
                {
                    return "Родичі";
                }
                if (lang == "be")
                {
                    return "Сваякі";
                }
                return "";
            }
        }

        public static string Remove1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Исключить";
                }
                if (lang == "en")
                {
                    return "Remove";
                }
                if (lang == "uk")
                {
                    return "Виключити";
                }
                if (lang == "be")
                {
                    return "Выключыць";
                }
                return "";
            }
        }

        public static string Remove2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Убрать";
                }
                if (lang == "en")
                {
                    return "Remove";
                }
                if (lang == "uk")
                {
                    return "Прибрати";
                }
                if (lang == "be")
                {
                    return "Прыбраць";
                }
                return "";
            }
        }

        public static string removed_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "исключила";
                }
                if (lang == "en")
                {
                    return "removed";
                }
                if (lang == "uk")
                {
                    return "виключила";
                }
                if (lang == "be")
                {
                    return "выключыла";
                }
                return "";
            }
        }

        public static string removed_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "исключил";
                }
                if (lang == "en")
                {
                    return "removed";
                }
                if (lang == "uk")
                {
                    return "виключив";
                }
                if (lang == "be")
                {
                    return "выключыў";
                }
                return "";
            }
        }

        public static string RemoveFromAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Убрать из альбома";
                }
                if (lang == "en")
                {
                    return "Remove from album";
                }
                if (lang == "uk")
                {
                    return "Прибрати з альбому";
                }
                if (lang == "be")
                {
                    return "Прыбраць з альбома";
                }
                return "";
            }
        }

        public static string RemoveFromBookmarks
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Убрать из закладок";
                }
                if (lang == "en")
                {
                    return "Remove from bookmarks";
                }
                if (lang == "uk")
                {
                    return "Прибрати з закладок";
                }
                if (lang == "be")
                {
                    return "Прыбраць з закладак";
                }
                return "";
            }
        }

        public static string RemoveFromFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Убрать из друзей";
                }
                if (lang == "en")
                {
                    return "Remove from friends";
                }
                if (lang == "uk")
                {
                    return "Прибрати з друзів";
                }
                if (lang == "be")
                {
                    return "Прибрати з сяброў";
                }
                return "";
            }
        }

        public static string RemoveFromList
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Убрать из списка";
                }
                if (lang == "en")
                {
                    return "Remove from list";
                }
                if (lang == "uk")
                {
                    return "Прибрати зі списку";
                }
                if (lang == "be")
                {
                    return "Прыбраць са спіса";
                }
                return "";
            }
        }

        public static string RenameAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Переименовать альбом";
                }
                if (lang == "en")
                {
                    return "Rename album";
                }
                if (lang == "uk")
                {
                    return "Перейменувати альбом";
                }
                if (lang == "be")
                {
                    return "Перайменаваць альбом";
                }
                return "";
            }
        }

        public static string RenameList
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Переименовать список";
                }
                if (lang == "en")
                {
                    return "Rename list";
                }
                if (lang == "uk")
                {
                    return "Перейменувати список";
                }
                if (lang == "be")
                {
                    return "Перайменаваць спіс";
                }
                return "";
            }
        }

        public static string Repeat
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Повторить";
                }
                if (lang == "en")
                {
                    return "Retry";
                }
                if (lang == "uk")
                {
                    return "Повторити";
                }
                if (lang == "be")
                {
                    return "Паўтарыць";
                }
                return "";
            }
        }

        public static string RepeatPassword
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Повторите пароль";
                }
                if (lang == "en")
                {
                    return "Repeat password";
                }
                if (lang == "uk")
                {
                    return "Повторіть пароль";
                }
                if (lang == "be")
                {
                    return "Паўтарыце пароль";
                }
                return "";
            }
        }

        public static string Reply
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ответить";
                }
                if (lang == "en")
                {
                    return "Reply";
                }
                if (lang == "uk")
                {
                    return "Відповісти";
                }
                if (lang == "be")
                {
                    return "Адказаць";
                }
                return "";
            }
        }

        public static string Report
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пожаловаться";
                }
                if (lang == "en")
                {
                    return "Report";
                }
                if (lang == "uk")
                {
                    return "Поскаржитися";
                }
                if (lang == "be")
                {
                    return "Паскардзіцца";
                }
                return "";
            }
        }

        public static string ReportSpam
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Это спам";
                }
                if (lang == "en")
                {
                    return "Report spam";
                }
                if (lang == "uk")
                {
                    return "Це спам";
                }
                if (lang == "be")
                {
                    return "Гэта спам";
                }
                return "";
            }
        }

        public static string returnedToConversation_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "вернулась в беседу";
                }
                if (lang == "en")
                {
                    return "returned to conversation";
                }
                if (lang == "uk")
                {
                    return "повернулась в бесіду";
                }
                if (lang == "be")
                {
                    return "вярнулася да гутаркі";
                }
                return "";
            }
        }

        public static string returnedToConversation_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "вернулся в беседу";
                }
                if (lang == "en")
                {
                    return "returned to conversation";
                }
                if (lang == "uk")
                {
                    return "повернувся в бесіду";
                }
                if (lang == "be")
                {
                    return "вярнуўся да гутаркі";
                }
                return "";
            }
        }

        public static string SafeSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Безопасный поиск";
                }
                if (lang == "en")
                {
                    return "Safe search";
                }
                if (lang == "uk")
                {
                    return "Безпечний пошук";
                }
                if (lang == "be")
                {
                    return "Бяспечны пошук";
                }
                return "";
            }
        }

        public static string Satellite
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Спутник";
                }
                if (lang == "en")
                {
                    return "Satellite";
                }
                if (lang == "uk")
                {
                    return "Супутник";
                }
                if (lang == "be")
                {
                    return "Спадарожнік";
                }
                return "";
            }
        }

        public static string Save
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сохранить";
                }
                if (lang == "en")
                {
                    return "Save";
                }
                if (lang == "uk")
                {
                    return "Зберегти";
                }
                if (lang == "be")
                {
                    return "Захаваць";
                }
                return "";
            }
        }

        public static string SavedPhotos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сохранённые фотографии";
                }
                if (lang == "en")
                {
                    return "Saved photos";
                }
                if (lang == "uk")
                {
                    return "Збережені фотографії";
                }
                if (lang == "be")
                {
                    return "Захаваныя фотаздымкі";
                }
                return "";
            }
        }

        public static string SaveToAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сохранить в альбом";
                }
                if (lang == "en")
                {
                    return "Save to album";
                }
                if (lang == "uk")
                {
                    return "Зберегти в альбом";
                }
                if (lang == "be")
                {
                    return "Захаваць у альбом";
                }
                return "";
            }
        }

        public static string Scheme
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Схема";
                }
                if (lang == "en")
                {
                    return "Scheme";
                }
                if (lang == "uk")
                {
                    return "Схема";
                }
                if (lang == "be")
                {
                    return "Схема";
                }
                return "";
            }
        }

        public static string School
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Школа";
                }
                if (lang == "en")
                {
                    return "School";
                }
                if (lang == "uk")
                {
                    return "Школа";
                }
                if (lang == "be")
                {
                    return "Школа";
                }
                return "";
            }
        }

        public static string SchoolFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Друзья по школе";
                }
                if (lang == "en")
                {
                    return "School friends";
                }
                if (lang == "uk")
                {
                    return "Друзі по школі";
                }
                if (lang == "be")
                {
                    return "Сябры па школе";
                }
                return "";
            }
        }

        public static string ScienceAndResearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Наука и исследования";
                }
                if (lang == "en")
                {
                    return "Science and research";
                }
                if (lang == "uk")
                {
                    return "Наука і дослідження";
                }
                if (lang == "be")
                {
                    return "Навука і даследаванні";
                }
                return "";
            }
        }

        public static string Search
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поиск";
                }
                if (lang == "en")
                {
                    return "Search";
                }
                if (lang == "uk")
                {
                    return "Пошук";
                }
                if (lang == "be")
                {
                    return "Пошук";
                }
                return "";
            }
        }

        public static string Search_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Искать";
                }
                if (lang == "en")
                {
                    return "Search";
                }
                if (lang == "uk")
                {
                    return "Шукати";
                }
                if (lang == "be")
                {
                    return "Шукаць";
                }
                return "";
            }
        }

        public static string Select
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Выбрать";
                }
                if (lang == "en")
                {
                    return "Select";
                }
                if (lang == "uk")
                {
                    return "Вибрати";
                }
                if (lang == "be")
                {
                    return "Выбраць";
                }
                return "";
            }
        }

        public static string Send
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отправить";
                }
                if (lang == "en")
                {
                    return "Send";
                }
                if (lang == "uk")
                {
                    return "Надіслати";
                }
                if (lang == "be")
                {
                    return "Даслаць";
                }
                return "";
            }
        }

        public static string SendAsGift
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подарить";
                }
                if (lang == "en")
                {
                    return "Send as a gift";
                }
                if (lang == "uk")
                {
                    return "Подарувати";
                }
                if (lang == "be")
                {
                    return "Падарыць";
                }
                return "";
            }
        }

        public static string SendGift
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отправить подарок";
                }
                if (lang == "en")
                {
                    return "Send gift";
                }
                if (lang == "uk")
                {
                    return "Надіслати подарунок";
                }
                if (lang == "be")
                {
                    return "Даслаць падарунак";
                }
                return "";
            }
        }

        public static string sending
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "отправка";
                }
                if (lang == "en")
                {
                    return "sending";
                }
                if (lang == "uk")
                {
                    return "надсилання";
                }
                if (lang == "be")
                {
                    return "адпраўка";
                }
                return "";
            }
        }

        public static string SendingOfThisMessageFailed
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не удалось отправить это сообщение.";
                }
                if (lang == "en")
                {
                    return "Sending of this message failed.";
                }
                if (lang == "uk")
                {
                    return "Не вдалося надіслати це повідомлення.";
                }
                if (lang == "be")
                {
                    return "Не ўдалося даслаць гэта паведамленне.";
                }
                return "";
            }
        }

        public static string SendingSettings
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Настройки отправки";
                }
                if (lang == "en")
                {
                    return "Sending settings";
                }
                if (lang == "uk")
                {
                    return "Налаштування надсилання";
                }
                if (lang == "be")
                {
                    return "Налады адпраўкі";
                }
                return "";
            }
        }

        public static string SendMessage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отправить сообщение";
                }
                if (lang == "en")
                {
                    return "Send message";
                }
                if (lang == "uk")
                {
                    return "Надіслати повідомлення";
                }
                if (lang == "be")
                {
                    return "Даслаць паведамленне";
                }
                return "";
            }
        }

        public static string SendRequest
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подать заявку";
                }
                if (lang == "en")
                {
                    return "Send request";
                }
                if (lang == "uk")
                {
                    return "Подати заявку";
                }
                if (lang == "be")
                {
                    return "Падаць заяўку";
                }
                return "";
            }
        }

        public static string SendViaPrivateMessage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отправить личным сообщением";
                }
                if (lang == "en")
                {
                    return "Send via private message";
                }
                if (lang == "uk")
                {
                    return "Надіслати особистим повідомленням";
                }
                if (lang == "be")
                {
                    return "Даслаць асабістым паведамленнем";
                }
                return "";
            }
        }

        public static string ServerConnectionError
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ошибка соединения с сервером";
                }
                if (lang == "en")
                {
                    return "Server connection error";
                }
                if (lang == "uk")
                {
                    return "Помилка з'єднання з сервером";
                }
                if (lang == "be")
                {
                    return "Памылка злучэння з серверам";
                }
                return "";
            }
        }

        public static string SetAsCover
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сделать обложкой";
                }
                if (lang == "en")
                {
                    return "Set as cover";
                }
                if (lang == "uk")
                {
                    return "Зробити обкладинкою";
                }
                if (lang == "be")
                {
                    return "Зрабіць вокладкай";
                }
                return "";
            }
        }

        public static string Settings
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Настройки";
                }
                if (lang == "en")
                {
                    return "Settings";
                }
                if (lang == "uk")
                {
                    return "Налаштування";
                }
                if (lang == "be")
                {
                    return "Налады";
                }
                return "";
            }
        }

        public static string Sex
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Пол";
                }
                if (lang == "en")
                {
                    return "Sex";
                }
                if (lang == "uk")
                {
                    return "Стать";
                }
                if (lang == "be")
                {
                    return "Пол";
                }
                return "";
            }
        }

        public static string Share
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поделиться";
                }
                if (lang == "en")
                {
                    return "Share";
                }
                if (lang == "uk")
                {
                    return "Поділитися";
                }
                if (lang == "be")
                {
                    return "Падзяліцца";
                }
                return "";
            }
        }

        public static string Shared
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поделились";
                }
                if (lang == "en")
                {
                    return "Shared";
                }
                if (lang == "uk")
                {
                    return "Поділились";
                }
                if (lang == "be")
                {
                    return "Падзяліліся";
                }
                return "";
            }
        }

        public static string sharedYourPhoto_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "поделилась Вашей фотографией";
                }
                if (lang == "en")
                {
                    return "shared your photo";
                }
                if (lang == "uk")
                {
                    return "поділилася Вашою фотографією";
                }
                if (lang == "be")
                {
                    return "падзялілася Вашым фотаздымкам";
                }
                return "";
            }
        }

        public static string sharedYourPhoto_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "поделился Вашей фотографией";
                }
                if (lang == "en")
                {
                    return "shared your photo";
                }
                if (lang == "uk")
                {
                    return "поділився Вашою фотографією";
                }
                if (lang == "be")
                {
                    return "падзяліўся Вашым фотаздымкам";
                }
                return "";
            }
        }

        public static string sharedYourPhoto_S
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "поделились Вашей фотографией";
                }
                if (lang == "en")
                {
                    return "shared your photo";
                }
                if (lang == "uk")
                {
                    return "поділилися Вашою фотографією";
                }
                if (lang == "be")
                {
                    return "падзяліліся Вашым фотаздымкам";
                }
                return "";
            }
        }

        public static string sharedYourPost_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "поделилась Вашей записью";
                }
                if (lang == "en")
                {
                    return "shared your post";
                }
                if (lang == "uk")
                {
                    return "поділилася Вашим записом";
                }
                if (lang == "be")
                {
                    return "падзялілася Вашым запісам";
                }
                return "";
            }
        }

        public static string sharedYourPost_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "поделился Вашей записью";
                }
                if (lang == "en")
                {
                    return "shared your post";
                }
                if (lang == "uk")
                {
                    return "поділився Вашим записом";
                }
                if (lang == "be")
                {
                    return "падзяліўся Вашым запісам";
                }
                return "";
            }
        }

        public static string sharedYourPost_S
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "поделились Вашей записью";
                }
                if (lang == "en")
                {
                    return "shared your post";
                }
                if (lang == "uk")
                {
                    return "поділилися Вашим записом";
                }
                if (lang == "be")
                {
                    return "падзяліліся Вашым запісам";
                }
                return "";
            }
        }

        public static string sharedYourVideo_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "поделилась Вашей видеозаписью";
                }
                if (lang == "en")
                {
                    return "shared your video";
                }
                if (lang == "uk")
                {
                    return "поділилася Вашим відеозаписом";
                }
                if (lang == "be")
                {
                    return "падзялілася Вашым відэазапісам";
                }
                return "";
            }
        }

        public static string sharedYourVideo_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "поделился Вашей видеозаписью";
                }
                if (lang == "en")
                {
                    return "shared your video";
                }
                if (lang == "uk")
                {
                    return "поділився Вашим відеозаписом";
                }
                if (lang == "be")
                {
                    return "падзяліўся Вашым відэазапісам";
                }
                return "";
            }
        }

        public static string sharedYourVideo_S
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "поделились Вашей видеозаписью";
                }
                if (lang == "en")
                {
                    return "shared your video";
                }
                if (lang == "uk")
                {
                    return "поділилися Вашим відеозаписом";
                }
                if (lang == "be")
                {
                    return "падзяліліся Вашым відэазапісам";
                }
                return "";
            }
        }

        public static string ShareWithYourFriendsAndFollowers
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поделиться с Вашими друзьями и подписчиками";
                }
                if (lang == "en")
                {
                    return "Share with your friends and followers";
                }
                if (lang == "uk")
                {
                    return "Поділитися з Вашими друзями і підписниками";
                }
                if (lang == "be")
                {
                    return "Падзяліцца з Вашымі сябрамі і падпісчыкамі";
                }
                return "";
            }
        }

        public static string Short
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Короткие";
                }
                if (lang == "en")
                {
                    return "Short";
                }
                if (lang == "uk")
                {
                    return "Короткі";
                }
                if (lang == "be")
                {
                    return "Кароткія";
                }
                return "";
            }
        }

        public static string Show
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Показать";
                }
                if (lang == "en")
                {
                    return "Show";
                }
                if (lang == "uk")
                {
                    return "Показати";
                }
                if (lang == "be")
                {
                    return "Паказаць";
                }
                return "";
            }
        }

        public static string ShowAll
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Показать все";
                }
                if (lang == "en")
                {
                    return "Show all";
                }
                if (lang == "uk")
                {
                    return "Показати всі";
                }
                if (lang == "be")
                {
                    return "Паказаць усе";
                }
                return "";
            }
        }

        public static string ShowAllAlbums
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Показать все альбомы";
                }
                if (lang == "en")
                {
                    return "Show all albums";
                }
                if (lang == "uk")
                {
                    return "Показати всі альбоми";
                }
                if (lang == "be")
                {
                    return "Паказаць усе альбомы";
                }
                return "";
            }
        }

        public static string ShowAllLists
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Показать все списки";
                }
                if (lang == "en")
                {
                    return "Show all lists";
                }
                if (lang == "uk")
                {
                    return "Показати всі списки";
                }
                if (lang == "be")
                {
                    return "Паказаць усе спісы";
                }
                return "";
            }
        }

        public static string ShowFull
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Показать полностью";
                }
                if (lang == "en")
                {
                    return "Show full";
                }
                if (lang == "uk")
                {
                    return "Показати повністю";
                }
                if (lang == "be")
                {
                    return "Паказаць поўнасцю";
                }
                return "";
            }
        }

        public static string ShowInformation
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Показать информацию";
                }
                if (lang == "en")
                {
                    return "Show information";
                }
                if (lang == "uk")
                {
                    return "Показати інформацію";
                }
                if (lang == "be")
                {
                    return "Паказаць інфармацыю";
                }
                return "";
            }
        }

        public static string ShowOther
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Показать ещё";
                }
                if (lang == "en")
                {
                    return "Show other";
                }
                if (lang == "uk")
                {
                    return "Показати ще";
                }
                if (lang == "be")
                {
                    return "Паказаць яшчэ";
                }
                return "";
            }
        }

        public static string ShuffleOff
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не перемешивать";
                }
                if (lang == "en")
                {
                    return "Shuffle off";
                }
                if (lang == "uk")
                {
                    return "Не тасувати";
                }
                if (lang == "be")
                {
                    return "Не змешваць";
                }
                return "";
            }
        }

        public static string ShuffleOn
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Перемешивать";
                }
                if (lang == "en")
                {
                    return "Shuffle on";
                }
                if (lang == "uk")
                {
                    return "Тасувати";
                }
                if (lang == "be")
                {
                    return "Змешваць";
                }
                return "";
            }
        }

        public static string Siblings
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Братья, сёстры";
                }
                if (lang == "en")
                {
                    return "Siblings";
                }
                if (lang == "uk")
                {
                    return "Брати, сестри";
                }
                if (lang == "be")
                {
                    return "Браты, сёстры";
                }
                return "";
            }
        }

        public static string Signature
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подпись";
                }
                if (lang == "en")
                {
                    return "Signature";
                }
                if (lang == "uk")
                {
                    return "Підпис";
                }
                if (lang == "be")
                {
                    return "Подпіс";
                }
                return "";
            }
        }

        public static string SignIn
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Регистрация";
                }
                if (lang == "en")
                {
                    return "Register";
                }
                if (lang == "uk")
                {
                    return "Реєстрація";
                }
                if (lang == "be")
                {
                    return "Рэгістрацыя";
                }
                return "";
            }
        }

        public static string Site
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сайт";
                }
                if (lang == "en")
                {
                    return "Site";
                }
                if (lang == "uk")
                {
                    return "Сайт";
                }
                if (lang == "be")
                {
                    return "Сайт";
                }
                return "";
            }
        }

        public static string Socialist
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Социалистические";
                }
                if (lang == "en")
                {
                    return "Socialist";
                }
                if (lang == "uk")
                {
                    return "Соціалістичні";
                }
                if (lang == "be")
                {
                    return "Сацыялістычныя";
                }
                return "";
            }
        }

        public static string Sorting
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сортировка";
                }
                if (lang == "en")
                {
                    return "Sorting";
                }
                if (lang == "uk")
                {
                    return "Сортування";
                }
                if (lang == "be")
                {
                    return "Сартыроўка";
                }
                return "";
            }
        }

        public static string Spam
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Рассылка спама";
                }
                if (lang == "en")
                {
                    return "Spam";
                }
                if (lang == "uk")
                {
                    return "Розсилка спаму";
                }
                if (lang == "be")
                {
                    return "Рассылка спама";
                }
                return "";
            }
        }

        public static string SpamPageShowsUpInSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Рекламная страница, засоряющая поиск";
                }
                if (lang == "en")
                {
                    return "Spam page shows up in search";
                }
                if (lang == "uk")
                {
                    return "Рекламна сторінка, яка засмічує пошук";
                }
                if (lang == "be")
                {
                    return "Рэкламная старонка, якая засмечвае пошук";
                }
                return "";
            }
        }

        public static string startedFollowingYou_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "подписалась на Ваши обновления";
                }
                if (lang == "en")
                {
                    return "started following you";
                }
                if (lang == "uk")
                {
                    return "підписалася на Ваші оновлення";
                }
                if (lang == "be")
                {
                    return "падпісалася на Вашыя абраўленні";
                }
                return "";
            }
        }

        public static string startedFollowingYou_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "подписался на Ваши обновления";
                }
                if (lang == "en")
                {
                    return "started following you";
                }
                if (lang == "uk")
                {
                    return "підписався на Ваші оновлення";
                }
                if (lang == "be")
                {
                    return "падпісаўся на Вашыя абнаўленні";
                }
                return "";
            }
        }

        public static string startedFollowingYou_S
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "подписались на Ваши обновления";
                }
                if (lang == "en")
                {
                    return "started following you";
                }
                if (lang == "uk")
                {
                    return "підписалися на Ваші оновлення";
                }
                if (lang == "be")
                {
                    return "падпісаліся на Вашыя абнаўленні";
                }
                return "";
            }
        }

        public static string StartTime
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Начало";
                }
                if (lang == "en")
                {
                    return "Start time";
                }
                if (lang == "uk")
                {
                    return "Початок";
                }
                if (lang == "be")
                {
                    return "Пачатак";
                }
                return "";
            }
        }

        public static string StartTypingTheName
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Начните вводить имя";
                }
                if (lang == "en")
                {
                    return "Start typing a name";
                }
                if (lang == "uk")
                {
                    return "Почніть вводити ім'я";
                }
                if (lang == "be")
                {
                    return "Пачніце ўводзіць імя";
                }
                return "";
            }
        }

        public static string StartTypingTheTitle
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Начните вводить название";
                }
                if (lang == "en")
                {
                    return "Start typing a title";
                }
                if (lang == "uk")
                {
                    return "Почніть вводити назву";
                }
                if (lang == "be")
                {
                    return "Пачніце ўводзіць назву";
                }
                return "";
            }
        }

        public static string Sticker
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Стикер";
                }
                if (lang == "en")
                {
                    return "Sticker";
                }
                if (lang == "uk")
                {
                    return "Стікер";
                }
                if (lang == "be")
                {
                    return "Стыкер";
                }
                return "";
            }
        }

        public static string Subscriptions
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подписки";
                }
                if (lang == "en")
                {
                    return "Subscriptions";
                }
                if (lang == "uk")
                {
                    return "Підписки";
                }
                if (lang == "be")
                {
                    return "Падпіскі";
                }
                return "";
            }
        }

        public static string Suggestions
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Рекомендации";
                }
                if (lang == "en")
                {
                    return "Suggestions";
                }
                if (lang == "uk")
                {
                    return "Рекомендації";
                }
                if (lang == "be")
                {
                    return "Рэкамендацыі";
                }
                return "";
            }
        }

        public static string SuggestionsFrom
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Рекомендация от";
                }
                if (lang == "en")
                {
                    return "Suggestions from";
                }
                if (lang == "uk")
                {
                    return "Рекомендація від";
                }
                if (lang == "be")
                {
                    return "Рэкамендацыя ад";
                }
                return "";
            }
        }

        public static string Support
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поддержка";
                }
                if (lang == "en")
                {
                    return "Support";
                }
                if (lang == "uk")
                {
                    return "Підтримка";
                }
                if (lang == "be")
                {
                    return "Падтрымка";
                }
                return "";
            }
        }

        public static string SupportAgent
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Агент поддержки";
                }
                if (lang == "en")
                {
                    return "Support agent";
                }
                if (lang == "uk")
                {
                    return "Агент підтримки ";
                }
                if (lang == "be")
                {
                    return "Агент падтрымкі";
                }
                return "";
            }
        }

        public static string tagInPhoto1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "отметка на фотографии";
                }
                if (lang == "en")
                {
                    return "tag in photo";
                }
                if (lang == "uk")
                {
                    return "позначка на фотографії";
                }
                if (lang == "be")
                {
                    return "пазнака на фотаздымку";
                }
                return "";
            }
        }

        public static string tagInPhotos2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "отметки на фотографиях";
                }
                if (lang == "en")
                {
                    return "tags in photos";
                }
                if (lang == "uk")
                {
                    return "позначки на фотографіях";
                }
                if (lang == "be")
                {
                    return "пазнакі на фотаздымках";
                }
                return "";
            }
        }

        public static string tagInPhotos3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "отметок на фотографиях";
                }
                if (lang == "en")
                {
                    return "tags in photos";
                }
                if (lang == "uk")
                {
                    return "позначок на фотографіях";
                }
                if (lang == "be")
                {
                    return "пазнак на фотаздымках";
                }
                return "";
            }
        }

        public static string TermsOfService
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Правила сервиса";
                }
                if (lang == "en")
                {
                    return "Terms of Service";
                }
                if (lang == "uk")
                {
                    return "Правила сервісу";
                }
                if (lang == "be")
                {
                    return "Правілы сэрвіса";
                }
                return "";
            }
        }

        public static string Title
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Название";
                }
                if (lang == "en")
                {
                    return "Title";
                }
                if (lang == "uk")
                {
                    return "Назва";
                }
                if (lang == "be")
                {
                    return "Назва";
                }
                return "";
            }
        }

        public static string to
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "до";
                }
                if (lang == "en")
                {
                    return "to";
                }
                if (lang == "uk")
                {
                    return "до";
                }
                if (lang == "be")
                {
                    return "да";
                }
                return "";
            }
        }

        public static string To
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "До";
                }
                if (lang == "en")
                {
                    return "To";
                }
                if (lang == "uk")
                {
                    return "До";
                }
                if (lang == "be")
                {
                    return "Да";
                }
                return "";
            }
        }

        public static string toCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сообществу";
                }
                if (lang == "en")
                {
                    return "to community";
                }
                if (lang == "uk")
                {
                    return "спільноті";
                }
                if (lang == "be")
                {
                    return "суполцы";
                }
                return "";
            }
        }

        public static string ToCommunity
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сообществу";
                }
                if (lang == "en")
                {
                    return "To community";
                }
                if (lang == "uk")
                {
                    return "Спільноті";
                }
                if (lang == "be")
                {
                    return "Суполцы";
                }
                return "";
            }
        }

        public static string Today
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Сегодня";
                }
                if (lang == "en")
                {
                    return "Today";
                }
                if (lang == "uk")
                {
                    return "Сьогодні";
                }
                if (lang == "be")
                {
                    return "Сёння";
                }
                return "";
            }
        }

        public static string todayAt
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "сегодня в";
                }
                if (lang == "en")
                {
                    return "today at";
                }
                if (lang == "uk")
                {
                    return "сьогодні о";
                }
                if (lang == "be")
                {
                    return "сёння ў";
                }
                return "";
            }
        }

        public static string ToLaunchMenu
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "В меню «Пуск»";
                }
                if (lang == "en")
                {
                    return "To Start Menu";
                }
                if (lang == "uk")
                {
                    return "В меню «Пуск»";
                }
                if (lang == "be")
                {
                    return "У меню «Пуск»";
                }
                return "";
            }
        }

        public static string Tomorrow
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Завтра";
                }
                if (lang == "en")
                {
                    return "Tomorrow";
                }
                if (lang == "uk")
                {
                    return "Завтра";
                }
                if (lang == "be")
                {
                    return "Заўтра";
                }
                return "";
            }
        }

        public static string toYour
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "на Вашу";
                }
                if (lang == "en")
                {
                    return "to your";
                }
                if (lang == "uk")
                {
                    return "на Ваш";
                }
                if (lang == "be")
                {
                    return "на Ваш";
                }
                return "";
            }
        }

        public static string toYourPost
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "на Вашу запись";
                }
                if (lang == "en")
                {
                    return "to your post";
                }
                if (lang == "uk")
                {
                    return "на Ваш запис";
                }
                if (lang == "be")
                {
                    return "на Ваш запіс";
                }
                return "";
            }
        }

        public static string toYourVideo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "на Вашу видеозапись";
                }
                if (lang == "en")
                {
                    return "to your video";
                }
                if (lang == "uk")
                {
                    return "на Ваш відеозапис";
                }
                if (lang == "be")
                {
                    return "на Ваш відэазапіс";
                }
                return "";
            }
        }

        public static string TrafficEncryption
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Шифрование трафика";
                }
                if (lang == "en")
                {
                    return "Traffic encryption";
                }
                if (lang == "uk")
                {
                    return "Шифрування трафіку";
                }
                if (lang == "be")
                {
                    return "Шыфраванне трафіка";
                }
                return "";
            }
        }

        public static string TypeAlbumTitle
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Введите название альбома";
                }
                if (lang == "en")
                {
                    return "Type album title";
                }
                if (lang == "uk")
                {
                    return "Введіть назву альбому";
                }
                if (lang == "be")
                {
                    return "Увядзіце назву альбома";
                }
                return "";
            }
        }

        public static string TypeListTitle
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Введите название списка";
                }
                if (lang == "en")
                {
                    return "Type list title";
                }
                if (lang == "uk")
                {
                    return "Введіть назву списку";
                }
                if (lang == "be")
                {
                    return "Увядзіце назву спіса";
                }
                return "";
            }
        }

        public static string TypeMessage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Введите сообщение";
                }
                if (lang == "en")
                {
                    return "Type message";
                }
                if (lang == "uk")
                {
                    return "Введіть повідомлення";
                }
                if (lang == "be")
                {
                    return "Увядзіце паведамленне";
                }
                return "";
            }
        }

        public static string TypePostText
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Введите текст записи";
                }
                if (lang == "en")
                {
                    return "Type post text";
                }
                if (lang == "uk")
                {
                    return "Введіть текст запису";
                }
                if (lang == "be")
                {
                    return "Увядзіце тэкст запісу";
                }
                return "";
            }
        }

        public static string TypeStatusMessage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Введите статус";
                }
                if (lang == "en")
                {
                    return "Type status message";
                }
                if (lang == "uk")
                {
                    return "Введіть статус";
                }
                if (lang == "be")
                {
                    return "Увядзіце статус";
                }
                return "";
            }
        }

        public static string TypeTheCodeFromThePicture
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Введите код с изображения";
                }
                if (lang == "en")
                {
                    return "Type the code from the picture";
                }
                if (lang == "uk")
                {
                    return "Введіть код із зображення";
                }
                if (lang == "be")
                {
                    return "Увядзіце код з выявы";
                }
                return "";
            }
        }

        public static string Ultraconservative
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ультраконсервативные";
                }
                if (lang == "en")
                {
                    return "Ultraconservative";
                }
                if (lang == "uk")
                {
                    return "Ультраконсервативні";
                }
                if (lang == "be")
                {
                    return "Ультракансерватыўныя";
                }
                return "";
            }
        }

        public static string Unblock
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Разблокировать";
                }
                if (lang == "en")
                {
                    return "Unblock";
                }
                if (lang == "uk")
                {
                    return "Розблокувати";
                }
                if (lang == "be")
                {
                    return "Разблакаваць";
                }
                return "";
            }
        }

        public static string Uncertain
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Возможные";
                }
                if (lang == "en")
                {
                    return "Uncertain";
                }
                if (lang == "uk")
                {
                    return "Можливі";
                }
                if (lang == "be")
                {
                    return "Магчымыя";
                }
                return "";
            }
        }

        public static string Unfollow
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отписаться";
                }
                if (lang == "en")
                {
                    return "Unfollow";
                }
                if (lang == "uk")
                {
                    return "Відписатися";
                }
                if (lang == "be")
                {
                    return "Адпісацца";
                }
                return "";
            }
        }

        public static string University
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "ВУЗ";
                }
                if (lang == "en")
                {
                    return "University";
                }
                if (lang == "uk")
                {
                    return "ВНЗ";
                }
                if (lang == "be")
                {
                    return "ВНУ";
                }
                return "";
            }
        }

        public static string UniversityFriends
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Друзья по вузу";
                }
                if (lang == "en")
                {
                    return "University friends";
                }
                if (lang == "uk")
                {
                    return "Друзі по внзу";
                }
                if (lang == "be")
                {
                    return "Сябры па ВНУ";
                }
                return "";
            }
        }

        public static string Unlike
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Больше не нравится";
                }
                if (lang == "en")
                {
                    return "Unlike";
                }
                if (lang == "uk")
                {
                    return "Більше не подобається";
                }
                if (lang == "be")
                {
                    return "Больш не падабаецца";
                }
                return "";
            }
        }

        public static string Unpin
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Открепить";
                }
                if (lang == "en")
                {
                    return "Unpin";
                }
                if (lang == "uk")
                {
                    return "Відкріпити";
                }
                if (lang == "be")
                {
                    return "Адмацаваць";
                }
                return "";
            }
        }

        public static string Unread
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Не прочитано";
                }
                if (lang == "en")
                {
                    return "Unread";
                }
                if (lang == "uk")
                {
                    return "Не прочитано";
                }
                if (lang == "be")
                {
                    return "Не прачытана";
                }
                return "";
            }
        }

        public static string updatedProfilePhoto_F
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "обновила фотографию страницы";
                }
                if (lang == "en")
                {
                    return "updated her profile photo";
                }
                if (lang == "uk")
                {
                    return "оновила фотографію сторінки";
                }
                if (lang == "be")
                {
                    return "абнавіла фотаздымак старонкі";
                }
                return "";
            }
        }

        public static string updatedProfilePhoto_M
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "обновил фотографию страницы";
                }
                if (lang == "en")
                {
                    return "updated his profile photo";
                }
                if (lang == "uk")
                {
                    return "оновив фотографію сторінки";
                }
                if (lang == "be")
                {
                    return "абнавіў фотаздымак старонкі";
                }
                return "";
            }
        }

        public static string UploadAudio
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Загрузить аудиозапись";
                }
                if (lang == "en")
                {
                    return "Upload audio";
                }
                if (lang == "uk")
                {
                    return "Завантажити аудіозапис";
                }
                if (lang == "be")
                {
                    return "Загрузіць аўдыязапіс";
                }
                return "";
            }
        }

        public static string UploadingMayTakeSeveralMinutes
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Загрузка может длиться несколько минут.";
                }
                if (lang == "en")
                {
                    return "Uploading may take several minutes.";
                }
                if (lang == "uk")
                {
                    return "Завантаження може тривати кілька хвилин.";
                }
                if (lang == "be")
                {
                    return "Загрузка можа цягнуцца некалькі хвілін.";
                }
                return "";
            }
        }

        public static string UploadNewPhoto
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Загрузить новую фотографию";
                }
                if (lang == "en")
                {
                    return "Upload new photo";
                }
                if (lang == "uk")
                {
                    return "Завантажити нову фотографію";
                }
                if (lang == "be")
                {
                    return "Загрузіць новы фотаздымак";
                }
                return "";
            }
        }

        public static string UploadVideo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Загрузить видеозапись";
                }
                if (lang == "en")
                {
                    return "Upload video";
                }
                if (lang == "uk")
                {
                    return "Завантажити відеозапис";
                }
                if (lang == "be")
                {
                    return "Загрузіць відэазапіс";
                }
                return "";
            }
        }

        public static string VerbalAbuse
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Оскорбление";
                }
                if (lang == "en")
                {
                    return "Verbal abuse";
                }
                if (lang == "uk")
                {
                    return "Образа";
                }
                if (lang == "be")
                {
                    return "Абраза";
                }
                return "";
            }
        }

        public static string VerifiedPage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Подтверждённая страница";
                }
                if (lang == "en")
                {
                    return "Verified page";
                }
                if (lang == "uk")
                {
                    return "Підтверджена сторінка";
                }
                if (lang == "be")
                {
                    return "Пацверджаная старонка";
                }
                return "";
            }
        }

        public static string Version
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Версия";
                }
                if (lang == "en")
                {
                    return "Version";
                }
                if (lang == "uk")
                {
                    return "Версія";
                }
                if (lang == "be")
                {
                    return "Версія";
                }
                return "";
            }
        }

        public static string VeryNegative
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Резко негативное";
                }
                if (lang == "en")
                {
                    return "Very negative";
                }
                if (lang == "uk")
                {
                    return "Різко негативне";
                }
                if (lang == "be")
                {
                    return "Рэзка адмоўнае";
                }
                return "";
            }
        }

        public static string viaInstagram
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "через Instagram";
                }
                if (lang == "en")
                {
                    return "via Instagram";
                }
                if (lang == "uk")
                {
                    return "через Instagram";
                }
                if (lang == "be")
                {
                    return "праз Instagram";
                }
                return "";
            }
        }

        public static string Video
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Видеозапись";
                }
                if (lang == "en")
                {
                    return "Video";
                }
                if (lang == "uk")
                {
                    return "Відеозапис";
                }
                if (lang == "be")
                {
                    return "Відэазапіс";
                }
                return "";
            }
        }

        public static string video1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "видеозапись";
                }
                if (lang == "en")
                {
                    return "video";
                }
                if (lang == "uk")
                {
                    return "відеозапис";
                }
                if (lang == "be")
                {
                    return "відэазапіс";
                }
                return "";
            }
        }

        public static string video2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "видеозаписи";
                }
                if (lang == "en")
                {
                    return "videos";
                }
                if (lang == "uk")
                {
                    return "відеозаписи";
                }
                if (lang == "be")
                {
                    return "відэазапісы";
                }
                return "";
            }
        }

        public static string video3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "видеозаписей";
                }
                if (lang == "en")
                {
                    return "videos";
                }
                if (lang == "uk")
                {
                    return "відеозаписів";
                }
                if (lang == "be")
                {
                    return "відэзапісаў";
                }
                return "";
            }
        }

        public static string VideoEditing
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Изменение видеозаписи";
                }
                if (lang == "en")
                {
                    return "Video editing";
                }
                if (lang == "uk")
                {
                    return "Зміна відеозапису";
                }
                if (lang == "be")
                {
                    return "Змена відэзапісу";
                }
                return "";
            }
        }

        public static string Videos
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Видеозаписи";
                }
                if (lang == "en")
                {
                    return "Videos";
                }
                if (lang == "uk")
                {
                    return "Відеозаписи";
                }
                if (lang == "be")
                {
                    return "Відэазапісы";
                }
                return "";
            }
        }

        public static string Videos_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Видео";
                }
                if (lang == "en")
                {
                    return "Videos";
                }
                if (lang == "uk")
                {
                    return "Відео";
                }
                if (lang == "be")
                {
                    return "Відэа";
                }
                return "";
            }
        }

        public static string VideoSending
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отправка видеозаписи";
                }
                if (lang == "en")
                {
                    return "Video sending";
                }
                if (lang == "uk")
                {
                    return "Надсилання відеозапису";
                }
                if (lang == "be")
                {
                    return "Адпраўка відэазапісу";
                }
                return "";
            }
        }

        public static string VideosOf
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Видеозаписи с";
                }
                if (lang == "en")
                {
                    return "Videos of";
                }
                if (lang == "uk")
                {
                    return "Відеозаписи з";
                }
                if (lang == "be")
                {
                    return "Відэазапісы з";
                }
                return "";
            }
        }

        public static string VideosOfMe
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Видеозаписи со мной";
                }
                if (lang == "en")
                {
                    return "Videos of me";
                }
                if (lang == "uk")
                {
                    return "Відеозаписи зі мною";
                }
                if (lang == "be")
                {
                    return "Відэазапісы са мной";
                }
                return "";
            }
        }

        public static string VideosSearch
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Поиск по видеозаписям";
                }
                if (lang == "en")
                {
                    return "Videos search";
                }
                if (lang == "uk")
                {
                    return "Пошук по відеозаписах";
                }
                if (lang == "be")
                {
                    return "Пошук па відэзапісах";
                }
                return "";
            }
        }

        public static string view1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "просмотр";
                }
                if (lang == "en")
                {
                    return "view";
                }
                if (lang == "uk")
                {
                    return "перегляд";
                }
                if (lang == "be")
                {
                    return "прагляд";
                }
                return "";
            }
        }

        public static string view2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "просмотра";
                }
                if (lang == "en")
                {
                    return "views";
                }
                if (lang == "uk")
                {
                    return "перегляди";
                }
                if (lang == "be")
                {
                    return "прагляды";
                }
                return "";
            }
        }

        public static string view3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "просмотров";
                }
                if (lang == "en")
                {
                    return "views";
                }
                if (lang == "uk")
                {
                    return "переглядів";
                }
                if (lang == "be")
                {
                    return "праглядаў";
                }
                return "";
            }
        }

        public static string ViewedFeedbackItems
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Просмотренные ответы";
                }
                if (lang == "en")
                {
                    return "Viewed feedback items";
                }
                if (lang == "uk")
                {
                    return "Переглянуті відповіді";
                }
                if (lang == "be")
                {
                    return "Прагледжаныя адказы";
                }
                return "";
            }
        }

        public static string ViewsOnAlcohol
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отношение к алкоголю";
                }
                if (lang == "en")
                {
                    return "Views on alcohol";
                }
                if (lang == "uk")
                {
                    return "Відношення до алкоголю";
                }
                if (lang == "be")
                {
                    return "Стаўленне да алкаголю";
                }
                return "";
            }
        }

        public static string ViewsOnSmoking
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Отношение к курению";
                }
                if (lang == "en")
                {
                    return "Views on smoking";
                }
                if (lang == "uk")
                {
                    return "Відношення до паління";
                }
                if (lang == "be")
                {
                    return "Стаўленне да курэння";
                }
                return "";
            }
        }

        public static string VKApp
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "ВКонтакте";
                }
                if (lang == "en")
                {
                    return "VK App";
                }
                if (lang == "uk")
                {
                    return "ВКонтакті";
                }
                if (lang == "be")
                {
                    return "УКантакце";
                }
                return "";
            }
        }

        public static string VKAppForWindows
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "ВКонтакте для Windows";
                }
                if (lang == "en")
                {
                    return "VK App for Windows";
                }
                if (lang == "uk")
                {
                    return "ВКонтакті для Windows";
                }
                if (lang == "be")
                {
                    return "УКантакце для Windows";
                }
                return "";
            }
        }

        public static string Volume
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Громкость";
                }
                if (lang == "en")
                {
                    return "Volume";
                }
                if (lang == "uk")
                {
                    return "Гучність";
                }
                if (lang == "be")
                {
                    return "Гучнасць";
                }
                return "";
            }
        }

        public static string vote1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "голос";
                }
                if (lang == "en")
                {
                    return "vote";
                }
                if (lang == "uk")
                {
                    return "голос";
                }
                if (lang == "be")
                {
                    return "голас";
                }
                return "";
            }
        }

        public static string vote2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "голоса";
                }
                if (lang == "en")
                {
                    return "votes";
                }
                if (lang == "uk")
                {
                    return "голоси";
                }
                if (lang == "be")
                {
                    return "галасы";
                }
                return "";
            }
        }

        public static string vote3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "голосов";
                }
                if (lang == "en")
                {
                    return "votes";
                }
                if (lang == "uk")
                {
                    return "голосів";
                }
                if (lang == "be")
                {
                    return "галасоў";
                }
                return "";
            }
        }

        public static string Wall
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Стена";
                }
                if (lang == "en")
                {
                    return "Wall";
                }
                if (lang == "uk")
                {
                    return "Стіна";
                }
                if (lang == "be")
                {
                    return "Сцяна";
                }
                return "";
            }
        }

        public static string WealthAndPower
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Власть и богатство";
                }
                if (lang == "en")
                {
                    return "Wealth and power";
                }
                if (lang == "uk")
                {
                    return "Влада і багатство";
                }
                if (lang == "be")
                {
                    return "Улада і багацце";
                }
                return "";
            }
        }

        public static string WhatIsNew_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Что у Вас нового?";
                }
                if (lang == "en")
                {
                    return "What is new?";
                }
                if (lang == "uk")
                {
                    return "Що у Вас нового?";
                }
                if (lang == "be")
                {
                    return "Што у Вас новага?";
                }
                return "";
            }
        }

        public static string WhoCanCommentOnThisAlbum_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Кто может комментировать этот альбом?";
                }
                if (lang == "en")
                {
                    return "Who can comment on this album?";
                }
                if (lang == "uk")
                {
                    return "Хто може коментувати цей альбом?";
                }
                if (lang == "be")
                {
                    return "Хто можа каментаваць гэты альбом?";
                }
                return "";
            }
        }

        public static string WhoCanCommentOnThisVideo_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Кто может комментировать это видео?";
                }
                if (lang == "en")
                {
                    return "Who can comment on this video?";
                }
                if (lang == "uk")
                {
                    return "Хто може коментувати це відео?";
                }
                if (lang == "be")
                {
                    return "Хто можа каментаваць гэта відэа?";
                }
                return "";
            }
        }

        public static string WhoCanViewThisAlbum_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Кто может просматривать этот альбом?";
                }
                if (lang == "en")
                {
                    return "Who can view this album?";
                }
                if (lang == "uk")
                {
                    return "Хто може переглядати цей альбом?";
                }
                if (lang == "be")
                {
                    return "Хто можа праглядаць гэты альбом?";
                }
                return "";
            }
        }

        public static string WhoCanViewThisVideo_
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Кто может смотреть это видео?";
                }
                if (lang == "en")
                {
                    return "Who can watch this video?";
                }
                if (lang == "uk")
                {
                    return "Хто може переглядати це відео?";
                }
                if (lang == "be")
                {
                    return "Хто можа глядзець гэта відэа?";
                }
                return "";
            }
        }

        public static string WithLyrics
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "С текстом";
                }
                if (lang == "en")
                {
                    return "With lyrics";
                }
                if (lang == "uk")
                {
                    return "З текстом";
                }
                if (lang == "be")
                {
                    return "З тэкстам";
                }
                return "";
            }
        }

        public static string WithPhoto
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "С фотографией";
                }
                if (lang == "en")
                {
                    return "With photo";
                }
                if (lang == "uk")
                {
                    return "З фотографією";
                }
                if (lang == "be")
                {
                    return "З фотаздымкам";
                }
                return "";
            }
        }

        public static string WorldView
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Мировоззрение";
                }
                if (lang == "en")
                {
                    return "World view";
                }
                if (lang == "uk")
                {
                    return "Світогляд";
                }
                if (lang == "be")
                {
                    return "Светапогляд";
                }
                return "";
            }
        }

        public static string WrongLoginOrPassword
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Неверный логин или пароль";
                }
                if (lang == "en")
                {
                    return "Wrong login or password";
                }
                if (lang == "uk")
                {
                    return "Неправильний логін або пароль";
                }
                if (lang == "be")
                {
                    return "Няправільны логін або пароль";
                }
                return "";
            }
        }

        public static string year1
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "год";
                }
                if (lang == "en")
                {
                    return "year";
                }
                if (lang == "uk")
                {
                    return "рік";
                }
                if (lang == "be")
                {
                    return "год";
                }
                return "";
            }
        }

        public static string year2
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "года";
                }
                if (lang == "en")
                {
                    return "years";
                }
                if (lang == "uk")
                {
                    return "роки";
                }
                if (lang == "be")
                {
                    return "гады";
                }
                return "";
            }
        }

        public static string year3
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "лет";
                }
                if (lang == "en")
                {
                    return "years";
                }
                if (lang == "uk")
                {
                    return "років";
                }
                if (lang == "be")
                {
                    return "гадоў";
                }
                return "";
            }
        }

        public static string yesterday
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "вчера";
                }
                if (lang == "en")
                {
                    return "yesterday";
                }
                if (lang == "uk")
                {
                    return "вчора";
                }
                if (lang == "be")
                {
                    return "учора";
                }
                return "";
            }
        }

        public static string Yesterday
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вчера";
                }
                if (lang == "en")
                {
                    return "Yesterday";
                }
                if (lang == "uk")
                {
                    return "Вчора";
                }
                if (lang == "be")
                {
                    return "Учора";
                }
                return "";
            }
        }

        public static string yesterdayAt
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "вчера в";
                }
                if (lang == "en")
                {
                    return "yesterday at";
                }
                if (lang == "uk")
                {
                    return "вчора о";
                }
                if (lang == "be")
                {
                    return "учора ў";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteAllMessagesInThisConversation
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить все сообщения в этом диалоге.";
                }
                if (lang == "en")
                {
                    return "You are about to delete all messages in this conversation.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити всі повідомлення в даному діалозі.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць усе паведамленні ў гэтым дыялогу.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteConversationCover
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить фотографию беседы.";
                }
                if (lang == "en")
                {
                    return "You are about to delete conversation cover.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити фотографію бесіди.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць фотаздымак гутаркі.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteOneMessage
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить одно сообщение.";
                }
                if (lang == "en")
                {
                    return "You are about to delete one message.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити одне повідомлення.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць адно паведамленне.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteSeveralMessages
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить несколько сообщений.";
                }
                if (lang == "en")
                {
                    return "You are about to delete several messages.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити кілька повідомлень.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць некалькі паведамленняў.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteThisAlbum
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить альбом.";
                }
                if (lang == "en")
                {
                    return "You are about to delete this album.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити альбом.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць альбом.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteThisAudio
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить аудиозапись.";
                }
                if (lang == "en")
                {
                    return "You are about to delete this audio.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити аудіозапис.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць аўдыязапіс.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteThisComment
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить комментарий.";
                }
                if (lang == "en")
                {
                    return "You are about to delete this comment.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити коментар.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць каментарый.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteThisDocument
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить документ.";
                }
                if (lang == "en")
                {
                    return "You are about to delete this document.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити документ.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць дакумент.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteThisList
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить список.";
                }
                if (lang == "en")
                {
                    return "You are about to delete this list.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити список.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць спіс.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteThisPhoto
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить фотографию.";
                }
                if (lang == "en")
                {
                    return "You are about to delete this photo.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити фотографію.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць фотаздымак.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteThisPost
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить запись.";
                }
                if (lang == "en")
                {
                    return "You are about to delete this post.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити запис.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць запіс.";
                }
                return "";
            }
        }

        public static string YouAreAboutToDeleteThisVideo
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы собираетесь удалить видеозапись.";
                }
                if (lang == "en")
                {
                    return "You are about to delete this video.";
                }
                if (lang == "uk")
                {
                    return "Ви збираєтеся видалити відеозапис.";
                }
                if (lang == "be")
                {
                    return "Вы збіраецеся выдаліць відэзапіс.";
                }
                return "";
            }
        }

        public static string YouAttend
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы участвуете";
                }
                if (lang == "en")
                {
                    return "You attend";
                }
                if (lang == "uk")
                {
                    return "Ви є учасником";
                }
                if (lang == "be")
                {
                    return "Вы ўдзельнічаеце";
                }
                return "";
            }
        }

        public static string YouFollow
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы подписаны";
                }
                if (lang == "en")
                {
                    return "You follow";
                }
                if (lang == "uk")
                {
                    return "Ви підписані";
                }
                if (lang == "be")
                {
                    return "Вы падпісаны";
                }
                return "";
            }
        }

        public static string YouHave
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "У вас";
                }
                if (lang == "en")
                {
                    return "You have";
                }
                if (lang == "uk")
                {
                    return "У Вас";
                }
                if (lang == "be")
                {
                    return "Вы маеце";
                }
                return "";
            }
        }

        public static string YourBalance
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ваш баланс";
                }
                if (lang == "en")
                {
                    return "Your balance";
                }
                if (lang == "uk")
                {
                    return "Ваш баланс";
                }
                if (lang == "be")
                {
                    return "Ваш баланс";
                }
                return "";
            }
        }

        public static string YourComment
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Ваш комментарий";
                }
                if (lang == "en")
                {
                    return "Your comment";
                }
                if (lang == "uk")
                {
                    return "Ваш коментар";
                }
                if (lang == "be")
                {
                    return "Ваш каментарый";
                }
                return "";
            }
        }

        public static string YourFriend
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "У Вас в друзьях";
                }
                if (lang == "en")
                {
                    return "Your friend";
                }
                if (lang == "uk")
                {
                    return "У Вас в друзях";
                }
                if (lang == "be")
                {
                    return "У Вас у сябрах";
                }
                return "";
            }
        }

        public static string YouSentRequest
        {
            get
            {
                string lang = VKSDK.Lang;
                if (lang == "ru")
                {
                    return "Вы отправили заявку";
                }
                if (lang == "en")
                {
                    return "You sent request";
                }
                if (lang == "uk")
                {
                    return "Ви надіслали заявку";
                }
                if (lang == "be")
                {
                    return "Вы даслалі заяўку";
                }
                return "";
            }
        }

       
    }

}
