using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MobileChat.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Chat> chats;
        private ICollection<FriendRequest> friendRequests;

        public ApplicationUser()
        {
            this.chats = new HashSet<Chat>();
            this.friendRequests = new HashSet<FriendRequest>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual ICollection<Chat> Chats
        {
            get
            {
                return this.chats;
            }

            set
            {
                this.chats = value;
            }
        }

        public virtual ICollection<ApplicationUser> Friends { get; set; }

        public virtual ICollection<FriendRequest> FriendRequests
        {
            get
            {
                return this.friendRequests;
            }

            set
            {
                this.friendRequests = value;
            }
        }
    }
}
