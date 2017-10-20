using System;
using System.Collections.Generic;
using System.Data.Entity;
using RedisSample.Models;

namespace RedisSample
{
    public class MyDbContext : DbContext
    {
        // Your context has been configured to use a 'MyDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RedisSample.MyDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyDbContext' 
        // connection string in the application configuration file.
        public MyDbContext()
            : base("name=MyDbContext")
        {
            Database.SetInitializer<MyDbContext>(new MyDbContextInitializer());
        }

        public DbSet<Foo> Foos { get; set; }
        public DbSet<Bar> Bars { get; set; }
    }

    public class MyDbContextInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            base.Seed(context);

            var r = new Random();

            for (int i = 1; i < 100; i++)
            {
                var foo = new Foo
                {
                    Description = "Detailed description of Foo " + i + ", hello world!",
                    Title = "FOO #" + i,
                    Bars = new List<Bar>()
                };

                var bar1 = new Bar
                {
                    Foo = foo,
                    Amount = r.Next(100),
                    Code = "BARCODE" + r.Next(10000)
                };

                var bar2 = new Bar
                {
                    Foo = foo,
                    Amount = r.Next(100),
                    Code = "BARCODE" + r.Next(10000)
                };

                foo.Bars.Add(bar1);
                foo.Bars.Add(bar2);

                context.Bars.Add(bar1);
                context.Bars.Add(bar2);
                context.Foos.Add(foo);
            }

            context.SaveChanges();
        }
    }
}