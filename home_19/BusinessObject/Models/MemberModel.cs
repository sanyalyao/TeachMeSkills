using Newtonsoft.Json;

namespace home_19.BusinessObject.Models
{
    public class MemberModel
    {
        [JsonProperty("member_id")]
        public int MemberId { get; set; }
    }
}
