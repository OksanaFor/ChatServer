using DataAcessLayer.Base;
using DataAcessLayer.Base.Interface;
using DataAcessLayer.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DataAcessLayer
{
    public static class DALDependencyInjection
    {
        public static void AddDALDI(this IServiceCollection services)
        {
            services.AddScoped<IChatServerEntities , ChatServerEntities>();
            services.AddTransient<BaseRepository<User, int>>();
            services.AddTransient<BaseRepository<Message, string>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


    }
}
