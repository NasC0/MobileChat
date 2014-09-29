using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Exam.WebApi.Infrastructure;
using MobileChat.Data;
using MobileChat.Models;

namespace MobileChat.Services.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IMobileChatData data, IUserIDProvider userIDProvider)
            : base(data, userIDProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult GetUser(string id)
        {
            var user = this.data.Users.Find(id);
            if (user == null)
            {
                return BadRequest("Invalid user id.");
            }

            return Ok(user);
        }

        [HttpGet]
        public IHttpActionResult GetUsersByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Invalid name parameter specified.");
            }

            var users = this.data.Users.All()
                            .Where(u => u.UserName.ToLower().Contains(name.ToLower()));

            return Ok(users);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult SendFriendRequest(string id)
        {
            var currentUserID = this.userIdProvider.GetUserID();
            var friendUser = this.data.Users.Find(id);

            if (friendUser == null)
            {
                return BadRequest("Invalid user id.");
            }

            var friendRequest = new FriendRequest()
            {
                IsAnswered = false,
                IsSeen = false,
                SenderID = currentUserID,
                RecipientID = friendUser.Id
            };

            this.data.FriendRequests.Add(friendRequest);
            this.data.SaveChanges();

            return Ok();
        }
    }
}