using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class EmailAttachment_xref
    {
        public int AttachmentId { get; set; }
        public int EmailId { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual Email Email { get; set; }
    }
}
