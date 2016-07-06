using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSquare.Core.Model.Entity
{
    public class Profile_User
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public int ProfileId { get; set; }
        public Profile profile { get; set; }
    }
}
