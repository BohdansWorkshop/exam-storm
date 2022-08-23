using ExamStorm.DataManager.Interfaces;
using ExamStorm.DataManager.Models;
using ExamStorm.DataManager.Models.Exam;
using ExamStorm.DataManager.Repositories;
using System;

namespace ExamStorm.DataManager
{
    public class RepositoryProvider : IDisposable
    {
        private readonly ExamDbContext _dbContext;
        private IBaseRepository<UserModel> _userRepository;
        private IBaseRepository<ExamModel> _examRepository;

        public RepositoryProvider(ExamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBaseRepository<UserModel> GetUserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserModelRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public IBaseRepository<ExamModel> GetExamRepository
        {
            get
            {
                if(_examRepository == null)
                {
                    _examRepository = new ExamModelRepository(_dbContext);
                }
                return _examRepository;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
