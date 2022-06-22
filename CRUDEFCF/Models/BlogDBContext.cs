using CRUDEFCF.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDEFCF.Models
{
    public class BlogDBContext : DbContext
    {
        //public BlogDBContext() : base("BlogPost") passed DB name
        //{

        //}

        public BlogDBContext() : base("name=BlogDBContext") //passed connection string
        {
            //Database.SetInitializer<BlogDBContext>(new DropCreateDatabaseIfModelChanges<BlogDBContext>());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDBContext, Configuration>());
            //Database.SetInitializer<BlogDBContext>(new BlogPostDBInitializer());

            //Disable initializer
            //Database.SetInitializer<BlogDBContext>(null);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Teacher>().Property(p => p.Name)
            //    .HasMaxLength(50)
            //    .IsOptional();

            modelBuilder.Configurations.Add(new TeacherEntityConfiguration());

            modelBuilder.Entity<Post>().Property(p => p.UserId)
                .IsOptional();

            modelBuilder.Entity<Course>().MapToStoredProcedures();

            //modelBuilder.Entity<Course>().MapToStoredProcedures(p => p.Insert(sp => sp.HasName("Course_Insert").Parameter(pm => pm.CourseName, "CourseName").Result(rs => rs.CourseId, "CourseId")));
        }
    }
}