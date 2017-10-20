namespace RedisSample.Models
{
    public class Bar
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public string Code { get; set; }

        public virtual Foo Foo { get; set; }
    }
}