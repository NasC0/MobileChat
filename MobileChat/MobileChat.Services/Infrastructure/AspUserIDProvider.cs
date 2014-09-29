using System.Threading;

using Microsoft.AspNet.Identity;

namespace Exam.WebApi.Infrastructure
{
    public class AspUserIDProvider : IUserIDProvider
    {
        public string GetUserID()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}