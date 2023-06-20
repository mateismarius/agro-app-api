using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class FarmerProfileConfiguration : IEntityTypeConfiguration<FarmerProfile>
    {
        public void Configure(EntityTypeBuilder<FarmerProfile> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(p => p.AppUser).WithMany()
                .HasForeignKey(p => p.UserId);
        }
    }
}
