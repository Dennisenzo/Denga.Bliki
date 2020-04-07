using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Denga.Bwiki.Data.Entities
{
    public class PageMetaData
    {
        [Key]
        public int Id { get; set; }
        public int? LatestVersionId { get; set; }

        [ForeignKey(nameof(LatestVersionId))]
        public PageContent LatestVersion { get; set; }

        public List<PageContent> Versions { get; set; }

        public string UrlTitle { get; set; }

        public DateTime CreatedAt { get; set; }

  
    }
}