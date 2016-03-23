using System.Collections.Generic;
using Newtonsoft.Json;

namespace VKCore.API.VKModels.Poll
{
    public class PollClass
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("owner_id")]
        public int owner_id { get; set; }
        [JsonProperty("created")]
        public int created { get; set; }
        [JsonProperty("question")]
        public string question { get; set; }
        [JsonProperty("votes")]
        public int votes { get; set; }
        [JsonProperty("answer_id")]
        public int answer_id { get; set; }
        [JsonProperty("answers")]
        public List<Answer> answers { get; set; }
        [JsonProperty("anonymous")]
        public int anonymous { get; set; }
    }


    public class Answer
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("votes")]
        public int votes { get; set; }
        [JsonProperty("rate")]
        public double rate { get; set; }
    }
}
