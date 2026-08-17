using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Models.AuditTrail
{
    public interface ICreationAudit
    {
        string CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
