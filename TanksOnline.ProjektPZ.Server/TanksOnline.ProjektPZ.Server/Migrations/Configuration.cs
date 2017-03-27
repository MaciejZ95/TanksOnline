namespace TanksOnline.ProjektPZ.Server.Migrations
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TanksOnline.ProjektPZ.Server.Domain.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TanksOnline.ProjektPZ.Server.Domain.Db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Users.Any())
            {
                var users = new List<User>();
                for (int i = 0; i < 5; i++)
                {
                    users.Add(new User
                    {
                        Name = $"test{i}",
                        Email = $"test@test{i}.pl",
                        Password = "test",
                        TankInfo = new TankInfo { Name = "test", ColorR = 100, ColorG = 100, ColorB = 100 },
                        UserScore = new UserScore(),
                    });
                }

                context.Users.AddRange(new List<User>(users)
                {
                    new User
                    {
                        Name = "test",
                        Email = "test",
                        Password = "test",
                        TankInfo = new TankInfo { Name = "test", ColorR = 100, ColorG = 100, ColorB = 100 },
                        UserScore = new UserScore(),
                    }
                });
            }
        }
    }
}
