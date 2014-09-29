using System;
using System.Collections.Generic;

using MobileChat.Data.Repositories;
using MobileChat.Models;

namespace MobileChat.Data
{
    public class MobileChatData : IMobileChatData
    {
        private IMobileChatDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public MobileChatData()
            : this(new MobileChatDbContext())
        {
        }

        public MobileChatData(IMobileChatDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Chat> Chats
        {
            get
            {
                return this.GetRepository<Chat>();
            }
        }

        public IRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public IRepository<FriendRequest> FriendRequests
        {
            get
            {
                return this.GetRepository<FriendRequest>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), dbContext);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
