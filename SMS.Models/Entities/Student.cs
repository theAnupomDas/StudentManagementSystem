using SMS.Models.AuditTrail;
using SMS.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SMS.Models.Entities
{
    public class Student : EntityBase, ICreationAudit, IModificationAudit, ISoftDelete
    {
        public Student()
        {
            CreatedAt = DateTime.Now;
            CreatedBy = string.Empty;
            IsDeleted = false;
        }
        [Required]
        public string Name { get; set; }
        [Required]

        public string StudentId { get; set; }
     
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string ContactNumber { get; set; }

        //creation audit properties
        public string CreatedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }

        //modification audit properties
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        //soft delete properties
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


    }
}
