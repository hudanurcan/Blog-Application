using BlogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Persistence.Configurations
{
    public class PostTagConfiguration  : BaseConfiguration<PostTag>
    {
        public override void Configure(EntityTypeBuilder<PostTag> builder)
        {
            //  base.Configure(builder);
            builder.HasKey(x => new { x.TagId, x.PostId });

            builder.HasOne(x => x.Tag)
                   .WithMany(p => p.PostTags)
                   .HasForeignKey(x => x.TagId);

            builder.HasOne(x => x.Post)
                   .WithMany(c => c.PostTags)
                   .HasForeignKey(x => x.PostId);
        }
    }
}
