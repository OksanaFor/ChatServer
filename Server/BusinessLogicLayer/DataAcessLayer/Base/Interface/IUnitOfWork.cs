using DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAcessLayer.Base.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        BaseRepository<User, int> Users { get; }
    
        BaseRepository<Message, int> Messages { get; }
 
        Task SaveAsync();
    }
}
