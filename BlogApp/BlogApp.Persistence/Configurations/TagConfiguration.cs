using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Configurations
{
    public class TagConfiguration : BaseConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);

            builder.HasIndex(c => c.TagName)
                .IsUnique();

            builder.Property(c => c.TagName)
                      .HasConversion(
                          v => v.ToLower(),  // Veritabanına küçük harf olarak kaydedilecek
                          v => v);             // Okuma işlemlerinde dönüşüm yapılacak

        }
    }
}
