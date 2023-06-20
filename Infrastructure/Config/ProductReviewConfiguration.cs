﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class ProductReviewConfiguration  : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.HasOne(p => p.ReviewProps).WithMany()
                .HasForeignKey(p => p.ReviewPropsId);
            builder.HasOne(p => p.Product).WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}
