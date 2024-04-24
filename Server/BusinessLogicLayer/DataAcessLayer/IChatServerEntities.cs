

using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcessLayer
{
    public interface IChatServerEntities
    {
        DbSet<User> Users { get; }
        DbSet<Message> Messages { get; }    
    }
}
