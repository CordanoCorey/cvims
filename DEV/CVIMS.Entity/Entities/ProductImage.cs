using CVIMS.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public byte[] FileBinary { get; set; }
        public string FileExtension { get; set; }
        public string MimeType { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Product Product { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
    }
}
