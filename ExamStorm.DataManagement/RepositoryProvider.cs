using ExamStorm.DataManager.Interfaces;
using ExamStorm.DataManager.Models;
using ExamStorm.DataManager.Repositories;
using System;

namespace ExamStorm.DataManager
{
    public class RepositoryProvider : IDisposable
    {
        private readonly ExamContext _dbContext;
        private IBaseRepository<UserModel> _userRepository;

        public RepositoryProvider(ExamContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IBaseRepository<UserModel> GetUserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    _userRepository = new UserModelRepository(_dbContext);
                }
                return this._userRepository;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
