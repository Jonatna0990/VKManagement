using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using VKCore.API.VKModels.Wall;

namespace VKCore.API.VKModels.Photo
{

    public class PhotoClass : ViewModelBase
   {

       private bool _isLoaded = true;
        private BitmapImage _image;
        [JsonProperty("id")]
         public int id { get; set; }

           [JsonProperty("album_id")]
         public int album_id { get; set; }

           [JsonProperty("owner_id")]
         public int owner_id { get; set; }

           [JsonProperty("user_id")]  
         public int user_id { get; set; }

           [JsonProperty("photo_75")]
         public string photo_75 { get; set; }

           [JsonProperty("photo_130")]
         public string photo_130 { get; set; }

           [JsonProperty("photo_604")] 
         public string photo_604 { get; set; }

           [JsonProperty("photo_807")]
         public string photo_807 { get; set; }

           [JsonProperty("photo_1280")]
         public string photo_1280 { get; set; }

           [JsonProperty("photo_2560")]
         public string photo_2560 { get; set; }

           [JsonProperty("width")]
         public int width { get; set; }

           [JsonProperty("height")]
         public int height { get; set; }

           [JsonProperty("text")]
         public string text { get; set; }

           [JsonProperty("date")]
         public int date { get; set; }

           [JsonProperty("access_key")]
         public string access_key { get; set; }
        [JsonProperty("likes")]
        public Likes likes { get; set; }
        [JsonProperty("comments")]
        public Comments comments { get; set; }
        [JsonProperty("reposts")]
        public Reposts reposts { get; set; }
        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value; RaisePropertyChanged("Image");
            }
        }
        public bool is_loaded
       {
           get { return _isLoaded; }
           set { _isLoaded = value;RaisePropertyChanged("is_loaded"); }
       }

       public PhotoSize photo_size 
           {
               get 
               {
                   if (!string.IsNullOrEmpty(photo_2560)) return PhotoSize.XXXL;
                   else if (!string.IsNullOrEmpty(photo_1280)) return PhotoSize.XXL;
                   else if (!string.IsNullOrEmpty(photo_807)) return PhotoSize.XL;
                   else if (!string.IsNullOrEmpty(photo_604)) return PhotoSize.L;
                   else if (!string.IsNullOrEmpty(photo_130)) return PhotoSize.M;
                   else return PhotoSize.S;
               
               }
           
           }
         public string photoMax
           {
                get 
               {
                   if (!string.IsNullOrEmpty(photo_2560)) return photo_2560;
                   else if (!string.IsNullOrEmpty(photo_1280)) return photo_1280;
                   else if (!string.IsNullOrEmpty(photo_807)) return photo_807;
                   else if (!string.IsNullOrEmpty(photo_604)) return photo_604;
                   else if (!string.IsNullOrEmpty(photo_130)) return photo_130;
                   else return photo_75;
               
               }
           }
        public Image photo()
           {

               Image main = new Image { Stretch = Stretch.UniformToFill};
               main.Source = new BitmapImage { UriSource = new Uri(photoMax) };
             //  main.Margin = new Thickness(2);
               //PhotoListViewer viewer = new PhotoListViewer(this);
                  
               
              
               return main;
               
           }
   }
   public enum PhotoSize
   { 
        S,
        M,
        L,
        XL,
        XXL,
        XXXL
   }
    //S - 75*75
    //M - 130*130
    //L - 604*604
    //XL - 807*807
    //XXL - 1280*1024
    //XXXL - 2560*2048
}
