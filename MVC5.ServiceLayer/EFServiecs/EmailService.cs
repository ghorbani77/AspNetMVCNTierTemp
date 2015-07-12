using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace MVC5.ServiceLayer.EFServiecs
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0); 
        }
    }
}
