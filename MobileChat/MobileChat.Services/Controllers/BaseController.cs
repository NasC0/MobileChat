using System.Web.Http;
using Exam.WebApi.Infrastructure;
using MobileChat.Data;

namespace MobileChat.Services.Controllers
{
    public class BaseController : ApiController
    {
        protected IMobileChatData data;
        protected IUserIDProvider userIdProvider;

        public BaseController(IMobileChatData data, IUserIDProvider userIdProvider)
        {
            this.data = data;
            this.userIdProvider = userIdProvider;
        }
    }
}
