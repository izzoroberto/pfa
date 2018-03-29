using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Account
    {
        public Account()
        {
            this.Messages = new HashSet<Message>();
            this.Groups = new HashSet<Group>();
        }
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Profile Profile { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Group> Groups { get; set; }

    }
}