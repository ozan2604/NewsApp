using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class NewsAppDbContext : DbContext
    {
        public NewsAppDbContext(DbContextOptions<NewsAppDbContext> options)
            : base(options) { }

        
        public DbSet<AppUser> AppUsers => Set<AppUser>();
        public DbSet<AppRole> AppRoles => Set<AppRole>();
        public DbSet<News> News => Set<News>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<AiLog> AiLogs => Set<AiLog>();

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API konfigürasyonları
            // ef core da  enttiy sınıflarının veri tabanı ile nasıl eşleşeceğini söyleriz

            // AppRole - AppUser
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.AppRole)
                .WithMany(r => r.AppUsers)
                .HasForeignKey(u => u.AppRoleId);

            // News - AppUser (Author)
            modelBuilder.Entity<News>()
                .HasOne(n => n.Author)
                .WithMany()
                .HasForeignKey(n => n.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);

            // News - AiLog (Çift yönlü)
            modelBuilder.Entity<AiLog>()
                .HasOne(l => l.News)
                .WithMany(n => n.AiLogs)
                .HasForeignKey(l => l.NewsId)
                .OnDelete(DeleteBehavior.SetNull);

            // Category - SubCategory (Self reference)
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-Many: News <-> Category
            modelBuilder.Entity<News>()
                .HasMany(n => n.Categorires)
                .WithMany(c => c.NewsList);

            // Many-to-Many: News <-> Tag
            modelBuilder.Entity<News>()
                .HasMany(n => n.Tags)
                .WithMany(t => t.News);
        }
    }
}

