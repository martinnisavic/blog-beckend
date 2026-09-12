using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            builder.Property(x => x.Path).HasMaxLength(300).IsRequired();

            builder.HasOne(x => x.Post)
                   .WithMany(x => x.Images)     
                   .HasForeignKey(x => x.PostId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
