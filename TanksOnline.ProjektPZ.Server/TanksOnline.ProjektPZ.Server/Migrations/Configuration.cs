namespace TanksOnline.ProjektPZ.Server.Migrations
{
    using Domain;
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
            var users = new List<User>();
            for (int i = 1; i < 10; i++)
            {
                users.Add(new User
                {
                    Id = i,
                    Name = $"Tester0{i}",
                    Email = $"t{i}",
                    Password = "t",
                    TankInfo = new TankInfo { Name = $"Tester0{i}", ColorR = 100, ColorG = 100, ColorB = 100 },
                    UserScore = new UserScore(),
                    Status = Domain.Enums.UserStatus.Offline,
                });
            }
            context.Users.AddOrUpdate(users.ToArray());
            context.SaveChanges();
        }
    }
}
