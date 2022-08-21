using ExamStorm.DataManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamStorm.DataManager
{
    public class ExamContext : DbContext
    {
        public ExamContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
    }
}
