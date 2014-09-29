using MobileChat.Data.Repositories;
using MobileChat.Models;

namespace MobileChat.Data
{
    public interface IMobileChatData
    {
        IRepository<Chat> Chats { get; }

        IRepository<Message> Messages { get; }

        IRepository<FriendRequest> FriendRequests { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
