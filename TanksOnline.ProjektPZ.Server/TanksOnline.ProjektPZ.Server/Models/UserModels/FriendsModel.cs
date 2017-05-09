using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TanksOnline.ProjektPZ.Server.Models.UserModels
{
    public class FriendsModel
    {
        public int RelationId { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public int FriendId { get; set; }
        public UserModel Friend { get; set; }
    }
}