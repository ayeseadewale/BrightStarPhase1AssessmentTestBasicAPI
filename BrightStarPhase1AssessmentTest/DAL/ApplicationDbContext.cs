using BrightStarPhase1AssessmentTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BrightStarPhase1AssessmentTest.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().HasKey(s => s.ServiceId);
            modelBuilder.Entity<Subscriber>().HasKey(s => s.SubscriberId);
            modelBuilder.Entity<Token>().HasKey(t => t.TokenId);

            modelBuilder.Entity<Subscriber>()
                .HasOne(s => s.Service)
                .WithMany()
                .HasForeignKey(s => s.ServiceId);

            modelBuilder.Entity<Token>()
                .HasOne(t => t.Service)
                .WithMany()
                .HasForeignKey(t => t.ServiceId);
        }
    }
}
