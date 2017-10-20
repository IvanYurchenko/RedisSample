using System.Collections.Generic;

namespace RedisSample.Models
{
    public class Foo
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual ICollection<Bar> Bars { get; set; }
    }
}