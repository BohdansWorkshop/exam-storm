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
        private IBaseRepository<QuestionModel> _questionRepository;
        private IBaseRepository<AnswerModel> _answerRepository;
        private IBaseRepository<ExamResultModel> _examResultModelRepository;

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

        public IBaseRepository<QuestionModel> GetQuestionsRepository
        {
            get
            {
                if (_questionRepository == null)
                {
                    _questionRepository = new QuestionModelRepository(_dbContext);
                }
                return _questionRepository;
            }
        }

        public IBaseRepository<AnswerModel> GetAnswerRepository
        {
            get
            {
                if (_answerRepository == null)
                {
                    _answerRepository = new AnswerModelRepository(_dbContext);
                }
                return _answerRepository;
            }
        }

        public IBaseRepository<ExamResultModel> GetExamResultRepository
        {
            get
            {
                if (_examResultModelRepository == null)
                {
                    _examResultModelRepository = new ExamResultModelRepository(_dbContext);
                }
                return _examResultModelRepository;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
