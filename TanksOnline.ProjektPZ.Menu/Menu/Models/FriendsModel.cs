using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Models
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
