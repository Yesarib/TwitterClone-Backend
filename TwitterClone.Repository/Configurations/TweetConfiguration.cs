using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Core.Models;

namespace TwitterClone.Repository.Configurations
{
    public class TweetConfiguration : IEntityTypeConfiguration<Tweet>
    {
        public void Configure(EntityTypeBuilder<Tweet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Text).HasMaxLength(500);
            builder.Property(t => t.LikeCount).HasDefaultValue(0);
            builder.Property(t => t.RetweetCount).HasDefaultValue(0);
            builder.Property(t => t.Media).HasColumnType("bytea[]"); // PostgreSQL için örnek bir tip
            builder.Property(t => t.Hashtags).HasColumnType("text[]"); // PostgreSQL için örnek bir tip
        }
    }
}
