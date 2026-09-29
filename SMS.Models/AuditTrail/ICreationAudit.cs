using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Models.AuditTrail
{
    public interface ICreationAudit
    {
        string CreatedBy { get;  }
        DateTime CreatedAt { get; }
    }
}
