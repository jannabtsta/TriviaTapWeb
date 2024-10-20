using Microsoft.EntityFrameworkCore;
using TriviaTapWeb.Models;

namespace TriviaTapWeb
{
    public class TriviaDBContext : DbContext
    {
        public TriviaDBContext(DbContextOptions<TriviaDBContext> options)
            : base(options) 
        {
        }

        // Define your database sets (tables) here
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<User> Users { get; set; }
        

    }
}
