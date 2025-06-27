using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class DataContextEF: DbContext
    {

        private readonly IConfiguration _confing;

        public DataContextEF(IConfiguration confing)
        {
            _confing = confing;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserJobInfo> JobInfos { get; set; }
        public virtual DbSet<UserSalary> UserSalaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_confing.GetConnectionString("DefaultConnetion"), optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TutorialAppSchema");

            modelBuilder.Entity<User>()
                .ToTable("Users", "TutorialAppSchema")
                .HasKey(u => u.UserID);

            modelBuilder.Entity<UserJobInfo>()
                .ToTable("UserJobInfo", "TutorialAppSchema")
                .HasKey(u => u.UserID);

            modelBuilder.Entity<UserSalary>()
                .ToTable("UserSalary", "TutorialAppSchema")
                .HasKey(u => u.UserID);
        }


    }
}
