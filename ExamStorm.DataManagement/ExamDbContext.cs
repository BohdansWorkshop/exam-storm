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
        public DbSet<AnswerModel> Answers { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<ExamResultModel> ExamResults { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserModel>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }
}
