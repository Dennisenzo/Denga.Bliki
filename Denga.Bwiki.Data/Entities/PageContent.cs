using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Denga.Bwiki.Data.Entities
{
    public class PageContent
    {
        [Key]
        public int Id { get; set; }

        public int PageMetaDataId { get; set; }

        [ForeignKey(nameof(PageMetaDataId))]
        public PageMetaData MetaData { get; set; }


        public DateTime CreatedAt { get; set; }
        public int Version { get; set; }
        public string Title { get; set; }
        public string HtmlContent { get; set; }
    }
}