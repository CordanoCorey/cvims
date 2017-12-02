using CVIMS.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class Attachment
    {
        public Attachment()
        {
            Email = new HashSet<EmailAttachment_xref>();
        }
        public int Id { get; set; }
        public Guid? FileId { get; set; }
        public string AttachmentName { get; set; }
        public string FileExtension { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPrivate { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser LastModifiedBy { get; set; }
        public virtual ICollection<EmailAttachment_xref> Email { get; set; }
    }
}
