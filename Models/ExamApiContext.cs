using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ExamApi.Models
{
    public class ExamApiContext : DbContext
    {
        
        public DbSet<ExamItem> ExamItems { get; set; } = null!;
        public DbSet<QuestionItem> QuestionItems { get; set; } = null!;
        public DbSet<AnwserItem> AnwserItems { get; set; } = null!;
        public ExamApiContext(DbContextOptions<ExamApiContext> options)
            : base(options)
        {
        }
    }
}