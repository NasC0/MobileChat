using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MobileChat.Models;

namespace MobileChat.Services.DataModels
{
    public class UserModel
    {
        public static Expression<Func<ApplicationUser, UserModel>> FromModel
        {
            get
            {
                return user => new UserModel()
                {
                    UserID = user.Id,
                    Username = user.UserName,
                    Email = user.Email
                };
            }
        }

        public string UserID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}