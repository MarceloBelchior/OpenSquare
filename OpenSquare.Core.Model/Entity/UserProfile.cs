using System;


namespace OpenSquare.Core.Model.Entity
{
    public class UserProfile : User
    {
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime date_birth { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
    }
}
