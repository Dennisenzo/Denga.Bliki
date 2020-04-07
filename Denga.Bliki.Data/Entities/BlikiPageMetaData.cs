using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Denga.Bliki.Data
{
    public class BlikiPageMetaData
    {
        [Key]
        public int Id { get; set; }
        public int? LatestVersionId { get; set; }

        [ForeignKey(nameof(LatestVersionId))]
        public BlikiPageContent LatestVersion { get; set; }

        public List<BlikiPageContent> Versions { get; set; }

        public string UrlTitle { get; set; }

        public DateTime CreatedAt { get; set; }

  
    }
}