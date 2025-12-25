using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Configurations
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.HasIndex(c => c.CategoryName)
                .IsUnique();

            builder.Property(c => c.CategoryName)
                      .HasConversion(
                          v => v.ToLower(),  // Veritabanına küçük harf olarak kaydedilecek
                          v => v);             // Okuma işlemlerinde dönüşüm yapılacak
                    
        }
    }
}
