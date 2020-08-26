using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BertoniWeb2.Models
{
    public class Image
    {
        public int AlbumId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}