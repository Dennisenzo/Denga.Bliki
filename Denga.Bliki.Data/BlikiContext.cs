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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlikiPageMetaData>()
                .HasMany(md => md.Versions)
                .WithOne(pc => pc.MetaData);

            modelBuilder.Entity<BlikiPageMetaData>()
                .HasOne(md => md.LatestVersion);

            base.OnModelCreating(modelBuilder);
        }

        protected BlikiContext()
        {
        }
    }
}