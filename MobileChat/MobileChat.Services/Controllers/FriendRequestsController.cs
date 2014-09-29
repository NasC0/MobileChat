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
    [Authorize]
    public class FriendRequestsController : BaseController
    {
        public FriendRequestsController(IMobileChatData data, IUserIDProvider userIDProvider)
            : base(data, userIDProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult GetFriendRequests(bool unseen)
        {
            var currentUserId = this.userIdProvider.GetUserID();
            var userFriendRequests = this.data.FriendRequests.All()
                                         .Where(fr => fr.RecipientID == currentUserId);

            if (unseen == true)
            {
                userFriendRequests = userFriendRequests
                                                       .Where(fr => fr.IsSeen = false);
            }

            return Ok(userFriendRequests);
        }

        [HttpPut]
        public IHttpActionResult AnswerFriendRequest(FriendRequestAnswerModel answer)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var friendRequest = this.data.FriendRequests.Find(answer.FriendRequestID);
            if (friendRequest == null)
            {
                return BadRequest("Invalid friend request id.");
            }

            if (friendRequest.RecipientID != this.userIdProvider.GetUserID())
            {
                return BadRequest("You do not have permission to answer this request.");
            }

            if (friendRequest.SenderID == this.userIdProvider.GetUserID())
            {
                return BadRequest("You cannot answer your own friend request!");
            }

            if (answer.BecomeFriends = true)
            {
                var currentUser = friendRequest.Recipient;
                var requester = friendRequest.Sender;

                currentUser.Friends.Add(requester);
                requester.Friends.Add(currentUser);

                this.data.Users.Update(currentUser);
                this.data.Users.Update(requester);

                this.data.SaveChanges();
            }

            friendRequest.IsAnswered = true;
            this.data.FriendRequests.Update(friendRequest);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
