using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using VKCore.Helpers;

namespace VKCore.API.VKModels.Market
{
    public enum MarketPlaceType
    {
        ZooFood,
        BabyCloth,
        Cosmetic,
        AutoPart,
        House,
        Smatphone,
        Appliances,
        Tablet,
        Camera,
        TV,
        PC,
        PcParts,
        Office,
        Health,
        Sport,
        Food
    }
    public class MarketPlaceCategoryClass : ViewModelBase
    {
        public ObservableCollection<MarketPlaceCategoryClass> GetAllCategories()
        {
            ObservableCollection<MarketPlaceCategoryClass> temp = new ObservableCollection<MarketPlaceCategoryClass>();
            var values = ListExtensions.GetValues<MarketPlaceType>();
            foreach (var t in values)
            {
                temp.Add(new MarketPlaceCategoryClass() {CategoryType = t});
            }
            return temp;


        }
        private MarketPlaceType _categoryType;
        public string name { get; set; }
        public string image { get; set; }

        public MarketPlaceType CategoryType
        {
            get { return _categoryType; }
            set
            {
                _categoryType = value;
                switch (value)
                {
                        case MarketPlaceType.BabyCloth:
                        {
                            this.name = "Детские товары";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/baby_cloth.png";
                        }; break;
                    case MarketPlaceType.Appliances:
                        {
                            this.name = "Бытовая техника";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/appilance.png";
                        }; break;
                    case MarketPlaceType.AutoPart:
                        {
                            this.name = "Автозапчасти и автотовары";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/machine_repair.png";
                        }; break;
                    case MarketPlaceType.Camera:
                        {
                            this.name = "Фото и видеокамеры";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/camera.png";
                        }; break;
                    case MarketPlaceType.Cosmetic:
                        {
                            this.name = "Парфюмерия и косметика";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/cosmetic.png";
                        }; break;
                    case MarketPlaceType.Health:
                        {
                            this.name = "Здоровье и красота";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/medical.png";
                        }; break;
                    case MarketPlaceType.House:
                        {
                            this.name = "Для дома и дачи";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/house_repair.png";
                        }; break;
                    case MarketPlaceType.Office:
                        {
                            this.name = "Офис и канцелярия";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/office.png";
                        }; break;
                    case MarketPlaceType.PC:
                        {
                            this.name = "Компьютеры и ноутбуки";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/computer.png";
                        }; break;
                    case MarketPlaceType.PcParts:
                        {
                            this.name = "Комплектующие";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/pcparts.png";
                        }; break;
                    case MarketPlaceType.Smatphone:
                        {
                            this.name = "Телефоны";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/smartphone.png";
                        }; break;
                    case MarketPlaceType.Sport:
                        {
                            this.name = "Спотр и туризм";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/sport.png";
                        }; break;
                    case MarketPlaceType.TV:
                        {
                            this.name = "ТВ, аудио и видео";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/tv.png";
                        }; break;
                    case MarketPlaceType.ZooFood:
                        {
                            this.name = "Зоотовары";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/dog_food.png";
                        }; break;
                    case MarketPlaceType.Food:
                        {
                            this.name = "Зоотовары";
                            this.image = "ms-appx:///Icons/Dark/MarketPlace/eating.png.png";
                        }; break;
                    default:
                        break;

                }
            }
        }
    }
}
