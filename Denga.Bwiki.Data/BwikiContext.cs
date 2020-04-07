using Denga.Bwiki.Data.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace Denga.Bwiki.Data
{
    public class BwikiContext : DbContext
    {
        public DbSet<PageMetaData> PageMetaDatas { get; set; }
        public DbSet<PageContent> PageContents { get; set; }

        public BwikiContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PageMetaData>(entity =>
            {
                entity.HasMany(md => md.Versions)
                    .WithOne(pc => pc.MetaData)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(md => md.LatestVersion);

                entity.HasIndex(e => e.UrlTitle).IsUnique();
            });
            base.OnModelCreating(builder);
        }

        protected BwikiContext()
        {
        }
    }
}