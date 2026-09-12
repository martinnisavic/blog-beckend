using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class BlogDbContext:DbContext
    {
        private readonly string _connString;

        public BlogDbContext(string connString)
        {
            _connString = connString;
        }

        public BlogDbContext()
        {
            _connString = "Data Source=localhost;Initial Catalog=BlogDb;TrustServerCertificate=true;Integrated Security=true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString)
                          .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                                .Property(nameof(BaseEntity.CreatedAt))
                                .HasDefaultValueSql("GETUTCDATE()");
                }
            }

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<HashtagEntity> Hashtags { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<UseCaseEntity> UseCases { get; set; }
        public DbSet<RoleUseCaseEntity> RoleUseCases { get; set; }
    } 
}
