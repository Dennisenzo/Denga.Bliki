using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Denga.Bliki.Data
{
    public class BlikiContext : DbContext
    {
        public DbSet<BlikiPageMetaData> BlikiPageMetaDatas { get; set; }
        public DbSet<BlikiPageContent> BlikiPageContents { get; set; }

        public BlikiContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BlikiPageMetaData>(entity =>
            {
                entity.HasMany(md => md.Versions)
                    .WithOne(pc => pc.MetaData)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => e.UrlTitle).IsUnique();
            });
            builder.Entity<BlikiPageMetaData>(entity =>
            {
                entity.HasOne(md => md.LatestVersion);
  
            });
            base.OnModelCreating(builder);
        }

        protected BlikiContext()
        {
        }
    }
}