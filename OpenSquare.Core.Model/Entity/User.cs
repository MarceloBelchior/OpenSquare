using System;
using System.Collections.Generic;


namespace OpenSquare.Core.Model.Entity
{
    public class User : EntityBase
    {
        public string login { get; set; }
        public string senha { get; set; }
        public DateTime date_last_access { get; set; }
        public System.Guid token { get; set; }
        public string salt { get; set; }
        public Enum.Status Status { get; set; }
        public ICollection<Profile_User> Profile { get; set; }
        public Enum.SocialMedia SocialMedia { get; set; }
        public Int64 SocialMediaId { get; set; }
        public System.Guid ProfileKey { get; set; }
    }
}
