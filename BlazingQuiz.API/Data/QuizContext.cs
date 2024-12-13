using BlazingQuix.Shared;
using BlazingQuiz.API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazingQuiz.API.Data
{
    public class QuizContext : DbContext
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public QuizContext(DbContextOptions<QuizContext> options, IPasswordHasher<User> passwordHasher) : base (options)
        {
            _passwordHasher = passwordHasher;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<StudentQuiz> StudentQuizs { get; set; }
        public DbSet<User> Userss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var adminUser = new User
            {
                Id = 1,
                Name = "admin",
                Email = "admin@email.com",
                Phone = "123456780",
                Role = nameof(UserRole.Admin),
                IsApproved  = true,

            };
            adminUser.PasswordHash = _passwordHasher.HashPassword(adminUser, "123456");

            modelBuilder.Entity<User>()
                .HasData(adminUser);
        }
    }
}
