
using Microsoft.Extensions.DependencyInjection;
using BusinessLogic.Interfases;
using BusinessLogic.Services;

namespace BusinessLogic
{
    public static class BLLDependencyEnjection
    {
        public static void AddBLLDI(this IServiceCollection services)
        {

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMessageService, MessageService>();
          
        }
    }
}
