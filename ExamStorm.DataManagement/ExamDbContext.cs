using ExamStorm.DataManager.Models;
using ExamStorm.DataManager.Models.Exam;
using Microsoft.EntityFrameworkCore;

namespace ExamStorm.DataManager
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ExamModel> Exams { get; set; }
        public DbSet<OptionModel> Options { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }

    }
}
