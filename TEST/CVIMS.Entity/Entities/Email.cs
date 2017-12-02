using CVIMS.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVIMS.Entity.Entities
{
    public partial class Email
    {
        public Email()
        {
            Attachments = new HashSet<EmailAttachment_xref>();
        }

        public int Id { get; set; }
        public string Bcc { get; set; }
        public string Body { get; set; }
        public string Cc { get; set; }
        public string Failed { get; set; }
        public string From { get; set; }
        public bool Sent { get; set; }
        public DateTime? SentDate { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ICollection<EmailAttachment_xref> Attachments { get; set; }
    }
}
