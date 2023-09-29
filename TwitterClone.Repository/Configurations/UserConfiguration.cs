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
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.PasswordHash).IsRequired();
            // builder.Property(x => x.ProfileImage).HasDefaultValue("varsayilan_profil_resmi.jpg");
            builder.Property(x => x.FollowerCount).HasDefaultValue(0);
            builder.Property(x => x.FollowingCount).HasDefaultValue(0);
            builder.Property(x => x.Bio).IsRequired().HasMaxLength(500);

        }
    }
}
