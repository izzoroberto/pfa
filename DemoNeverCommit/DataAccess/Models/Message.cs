using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Content { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}