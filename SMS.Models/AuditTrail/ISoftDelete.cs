using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Models.AuditTrail
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        string? DeletedBy { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
