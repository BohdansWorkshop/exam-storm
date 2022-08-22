using ExamStorm.DataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamStorm.DataManager
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
    }
}
