using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Denga.Bliki.Data
{
    public class BlikiPageMetaData
    {
        [Key]
        public int Id { get; set; }

        public string UrlTitle { get; set; }

        public int? LatestVersionId { get; set; }

        [ForeignKey(nameof(LatestVersionId))]
        public BlikiPageContent LatestVersion { get; set; }
    }
}