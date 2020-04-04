using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Denga.Bliki.Data
{
    public class BlikiPageContent
    {
        [Key]
        public int Id { get; set; }

        public int BlikiPageMetaDataId { get; set; }

        [ForeignKey(nameof(BlikiPageMetaDataId))]
        public BlikiPageMetaData MetaData { get; set; }

        public int Version { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }
    }
}