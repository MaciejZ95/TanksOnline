using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using TanksOnline.ProjektPZ.Server.Domain.Enums;

namespace TanksOnline.ProjektPZ.Server.Domain.Entities
{
    public class Friends
    {
        public int RelationId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FriendId { get; set; }
        public User Friend { get; set; }
    }

    public class FriendsMap : EntityTypeConfiguration<Friends>
    {
        public FriendsMap()
        {
            this.HasKey(x => x.RelationId);
            HasRequired(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .WillCascadeOnDelete(true);
            HasRequired(x => x.Friend)
                        .WithMany()
                        .HasForeignKey(x => x.FriendId)
                        .WillCascadeOnDelete(false);
        }
    }
}