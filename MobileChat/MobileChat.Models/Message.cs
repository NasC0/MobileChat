using System;
using System.ComponentModel.DataAnnotations;

namespace MobileChat.Models
{
    public class Message
    {
        public Message()
        {
            this.MessageID = Guid.NewGuid();
        }

        public Guid MessageID { get; set; }

        public MessageState MessageState { get; set; }

        [MinLength(1)]
        public string Content { get; set; }

        public string SenderID { get; set; }

        public ApplicationUser Sender { get; set; }

        public Guid ChatID { get; set; }

        public virtual Chat Chat { get; set; }
    }
}
