using Newtonsoft.Json;

namespace RedisSample.Models
{
    public class Bar
    {
        public virtual int Id { get; set; }

        public virtual int Amount { get; set; }

        public virtual string Code { get; set; }

        [JsonIgnore]
        public virtual Foo Foo { get; set; }
    }
}