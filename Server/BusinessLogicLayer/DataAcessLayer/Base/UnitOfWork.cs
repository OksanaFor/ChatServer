using DataAcessLayer.Base.Interface;
using DataAcessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Base
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ChatServerEntities _dbContext;
        private BaseRepository<User, int> _userRepository;
        private BaseRepository<Message, int> _messageRepository;
        public BaseRepository<User, int> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new BaseRepository<User, int>(_dbContext);
                return _userRepository;
            }
        }
        public BaseRepository<Message, int> Messages
        {
            get
            {
                if (_messageRepository == null)
                    _messageRepository = new BaseRepository<Message, int>(_dbContext);
                return _messageRepository;
            }
        }

    public void Dispose()
        {
            GC.SuppressFinalize(this);
            
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
