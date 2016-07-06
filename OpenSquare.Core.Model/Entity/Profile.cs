using System;
using System.Collections.Generic;

namespace OpenSquare.Core.Model.Entity
{
    public class Profile : EntityBase
    {
        
        public string Name { get; set; }
        public DateTime Expired { get; set; }
        public bool status { get; set; }
        public Guid ProfileKey { get; set; }

        public ICollection<Profile_User> Users { get; set; }
    }
}
