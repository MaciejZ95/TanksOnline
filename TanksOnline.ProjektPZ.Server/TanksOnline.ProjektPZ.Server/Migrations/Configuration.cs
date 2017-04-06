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

            var users = new List<User>();
            for (int i = 1; i < 10; i++)
            {
                users.Add(new User
                {
                    Id = i,
                    Name = $"test{i}",
                    Email = $"test{i}@test.pl",
                    Password = "test",
                    TankInfo = new TankInfo { Name = $"Tester0{i}", ColorR = 100, ColorG = 100, ColorB = 100 },
                    UserScore = new UserScore(),
                    Status = Domain.Enums.UserStatus.Offline,
                });
            }
            context.Users.AddOrUpdate(users.ToArray());
            context.SaveChanges();

            context.Players.AddOrUpdate(new Player[2]
            {
                new Player
                {
                    Id = 1,
                    IdInMatch = 0,
                    TankHP = Consts.DEFAULT_TANK_HP,
                    TurretAngle = Consts.DEFAULT_TURRET_ANGLE,
                    User = context.Users.Find(1),
                },
                new Player {
                    Id = 2,
                    IdInMatch = 1,
                    TankHP = Consts.DEFAULT_TANK_HP,
                    TurretAngle = Consts.DEFAULT_TURRET_ANGLE,
                    User = context.Users.Find(2),
                },
            });
            context.SaveChanges();

            var players = context.Players.Take(2).ToList();
            context.GameRooms.AddOrUpdate(new GameRoom
            {
                Id = 1,
                Match = new Match
                {
                    ActualPlayer = 0,
                    Players = players
                },
                Owner = context.Users.Find(1),
                PlayersLimit = 2,
                RoomStatus = Domain.Enums.RoomStatus.Ready,
                Players = players,
            });
            context.SaveChanges();
        }
    }
}
