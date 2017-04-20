using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using TanksOnline.ProjektPZ.Server.Domain.Enums;

namespace TanksOnline.ProjektPZ.Server.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
        public TankInfo TankInfo { get; set; }
        public UserScore UserScore { get; set; }
        public string Password { get; set; }
    }

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).IsRequired();
            this.Property(x => x.Email).IsRequired();
            this.Property(x => x.Status).IsRequired();
            this.HasRequired(x => x.TankInfo);
            this.HasRequired(x => x.UserScore);
            this.Property(x => x.Password).IsRequired();
        }
    }
}