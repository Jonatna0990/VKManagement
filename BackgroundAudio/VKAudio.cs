namespace BackgroundAudio
{
    public sealed class VKAudio
    {
        public long id { get; set; }

        public int owner_id { get; set; }


        public string artist { get; set; }



        public string title { get; set; }



        public int duration { get; set; }

       
        public string url { get; set; }


        public int? lyrics_id { get; set; }


        public int? album_id { get; set; }



        public bool IsPlaying { get; set; }
    }
}
