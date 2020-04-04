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

        protected BlikiContext()
        {
        }
    }
}