using System;
using Microsoft.EntityFrameworkCore;
using CS321_W4D2_ExerciseLogAPI.Core.Models;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityType> ActivitesTypes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= ../CS321_W4D2_ExerciseLog.Infrastructure/ExerciseLog.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActivityType>().HasData(
                  new ActivityType { Id = 1, Name = "Running", RecordType = RecordType.DurationAndDistance },
                  new ActivityType { Id = 2, Name = "Weights", RecordType = RecordType.DurationOnly },
                  new ActivityType { Id = 3, Name = "Walking", RecordType = RecordType.DurationAndDistance }
              );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Test User" }
            );

            
            modelBuilder.Entity<Activity>().HasData(
                new Activity { Id = 1, UserId = 1, ActivityTypeId = 1, Date = new DateTime(2019, 6, 19), Distance = 3, Duration = 30, Notes = "Hot!!!!" }
            );
        }
    }
}
