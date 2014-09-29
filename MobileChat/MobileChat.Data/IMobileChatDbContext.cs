using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MobileChat.Models;

namespace MobileChat.Data
{
    public interface IMobileChatDbContext
    {
        IDbSet<FriendRequest> FriendRequests { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Chat> Chats { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
