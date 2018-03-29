using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Group
    {
        public Group()
        {
            this.Messages = new HashSet<Message>();
            this.Accounts = new HashSet<Account>();
        }
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}