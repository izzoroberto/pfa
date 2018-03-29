using System;

namespace DataAccess.Models
{
    public class Profile
    {
        public int ProfileID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual Account Account { get; set; }
    }
}