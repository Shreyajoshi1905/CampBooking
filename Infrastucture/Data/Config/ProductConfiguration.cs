using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastucture.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.Property(p=> p.Id).IsRequired();
            builder.Property(p=> p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(180);
            builder.Property(p=> p.Price).HasColumnType("decimal(18 , 2)");
            builder.Property(p =>p.PictureUrl).IsRequired();
            builder.HasOne(b=> b.CampCity).WithMany()
                    .HasForeignKey(b=> b.CampCityId);
        }
    }
}