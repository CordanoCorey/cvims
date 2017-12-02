using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVIMS.Api.Infrastructure.Models;

namespace CVIMS.Api.Features.Products
{
    public class ProductImageModel : BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public byte[] FileBinary { get; set; }
        public string FileExtension { get; set; }
        public string MimeType { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}
