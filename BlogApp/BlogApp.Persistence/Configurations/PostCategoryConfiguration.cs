using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Configurations
{
    public class PostCategoryConfiguration : BaseConfiguration<PostCategory>
    {
        public override void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            //  base.Configure(builder);
            builder.HasKey(x => new { x.CategoryId, x.PostId });

            builder.HasOne(x => x.Post)
                   .WithMany(p => p.PostCategories)
                   .HasForeignKey(x => x.PostId);

            builder.HasOne(x => x.Category)
                   .WithMany(c => c.PostCategories)
                   .HasForeignKey(x => x.CategoryId);
        }
    }
}
