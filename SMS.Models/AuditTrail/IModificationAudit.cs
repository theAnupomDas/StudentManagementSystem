using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Models.AuditTrail
{
    public interface IModificationAudit
    {
        string? ModifiedBy { get; set; }
        DateTime? ModifiedAt { get; set; } 
    }
}
