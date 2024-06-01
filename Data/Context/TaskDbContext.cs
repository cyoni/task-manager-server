using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Models.Data;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TaskDbContext : DbContext
    {

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring UserTask and Schedule one-to-one relationship
            //modelBuilder.Entity<UserTask>()
            //    .HasOne(ut => ut.Schedule)
            //    .WithOne(s => s.Task)
            //    .HasForeignKey<Schedule>(s => s.TaskId);

            // Configuring UserTask and Comment one-to-many relationship
            //modelBuilder.Entity<UserTask>()
            //    .HasMany(t => t.Tags)
            //    .WithMany(t => t.Tasks);


            //// Configuring Schedule properties
            //modelBuilder.Entity<Schedule>()
            //    .Property(s => s.PlannedStartDate)
            //    .IsRequired();

            //modelBuilder.Entity<Schedule>()
            //    .Property(s => s.PlannedEndDate)
            //    .IsRequired();

            // Configuring Comment properties
            //modelBuilder.Entity<Comment>()
            //    .Property(c => c.Text)
            //    .IsRequired()
            //    .HasMaxLength(500); // Assuming a max length for comment text


            modelBuilder.Entity<TaskTag>()
                .HasKey(pc => new { pc.TaskId, pc.TagId });

            modelBuilder.Entity<TaskTag>()
                .HasOne(t => t.Task)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(t => t.TaskId);


            modelBuilder.Entity<TaskTag>()
                .HasOne(t => t.Tag)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(t => t.TagId);

            //modelBuilder.Entity<UserTask>()
            //    .HasMany(pc => pc.Tags)
            //    .WithMany(p => p.Tasks);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<UserTask> Tasks { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TaskTag> TaskTags { get; set; }

    }
}
