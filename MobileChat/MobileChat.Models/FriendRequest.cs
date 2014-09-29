using System.ComponentModel.DataAnnotations;

namespace MobileChat.Models
{
    public class FriendRequest
    {
        public int FriendRequestID { get; set; }

        public string SenderID { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public string RecipientID { get; set; }

        public virtual ApplicationUser Recipient { get; set; }

        public bool IsAnswered { get; set; }

        public bool IsSeen { get; set; }
    }
}
