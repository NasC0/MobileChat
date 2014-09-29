using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.WebApi.Infrastructure;
using MobileChat.Data;
using MobileChat.Services.DataModels;

namespace MobileChat.Services.Controllers
{
    public class FriendsController : BaseController
    {
        public FriendsController(IMobileChatData data, IUserIDProvider userIDProvider)
            : base(data, userIDProvider)
        {
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetFriends()
        {
            var currentUserID = this.userIdProvider.GetUserID();
            var currentUser = this.data.Users.Find(currentUserID);
            var friends = currentUser.Friends
                .AsQueryable()
                .Select(UserModel.FromModel);

            return Ok(friends);
        }
    }
}
