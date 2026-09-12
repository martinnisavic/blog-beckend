using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configurations
{
    public class HashtagConfiguration : IEntityTypeConfiguration<HashtagEntity>
    {
        public void Configure(EntityTypeBuilder<HashtagEntity> builder)
        {
            builder.Property(x => x.Value).HasMaxLength(50).IsRequired();
        }
    }
}
