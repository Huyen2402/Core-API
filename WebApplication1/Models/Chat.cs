using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Chat
    {
        public int Id { get; set; }
        public int? FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public string? Text { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? Sent { get; set; }

        public virtual ThanhVien? FromUser { get; set; }
        public virtual ThanhVien? ToUser { get; set; }
    }
}
