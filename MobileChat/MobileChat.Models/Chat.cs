using System;
using System.Collections.Generic;

namespace MobileChat.Models
{
    public class Chat
    {
        private ICollection<Message> messages;

        public Chat()
        {
            this.ChatID = Guid.NewGuid();
            this.messages = new HashSet<Message>();
        }

        public Guid ChatID { get; set; }

        public string FirstUserID { get; set; }

        public virtual ApplicationUser FirstUser { get; set; }

        public string SecondUserID { get; set; }

        public virtual ApplicationUser SecondUser { get; set; }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }
    }
}
