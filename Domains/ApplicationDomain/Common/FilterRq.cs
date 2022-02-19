using Newtonsoft.Json;

namespace ApplicationDomain.Common
{
    public class FilterRq
    {
        [JsonProperty("take")]
        public int Take { set; get; }
        [JsonProperty("skip")]
        public int Skip { set; get; }
    }
}
