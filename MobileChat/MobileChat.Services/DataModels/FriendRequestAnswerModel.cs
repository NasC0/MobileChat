using System.ComponentModel.DataAnnotations;

namespace MobileChat.Services.DataModels
{
    public class FriendRequestAnswerModel
    {
        [Required]
        public int FriendRequestID { get; set; }

        [Required]
        public bool BecomeFriends { get; set; }
    }
}