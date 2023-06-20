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
    public class HighlightConfiguration : IEntityTypeConfiguration<Highlight>
    {
        public void Configure(EntityTypeBuilder<Highlight> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Treatment).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.HasOne(p => p.Product).WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}
