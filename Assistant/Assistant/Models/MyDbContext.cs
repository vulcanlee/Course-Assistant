using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assistant.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=MyNote.db");
        public DbSet<CourseUser> CourseUsers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseCourseUser>()
                        .HasKey(t => new { t.CourseUserId, t.CourseId });

            modelBuilder.Entity<CourseCourseUser>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseCourseUsers)
                .HasForeignKey(pt => pt.CourseId);

            modelBuilder.Entity<CourseCourseUser>()
                .HasOne(pt => pt.CourseUser)
                .WithMany(t => t.CourseCourseUsers)
                .HasForeignKey(pt => pt.CourseUserId);
        }
    }
}
