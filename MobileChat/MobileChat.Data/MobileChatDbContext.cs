using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobileChat.Data.Migrations;
using MobileChat.Models;

namespace MobileChat.Data
{
    public class MobileChatDbContext : IdentityDbContext<ApplicationUser>, IMobileChatDbContext
    {
        public MobileChatDbContext()
            : base("MobileChatConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MobileChatDbContext, Configuration>());
        }

        public static MobileChatDbContext Create()
        {
            return new MobileChatDbContext();
        }

        public virtual IDbSet<FriendRequest> FriendRequests { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Chat> Chats { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ApplicationUser>()
        //                .HasMany(u => u.Friends)
        //                .WithOptional();
        //}
    }
}
