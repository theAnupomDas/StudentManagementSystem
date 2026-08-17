using SMS.Models.AuditTrail;
using SMS.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMS.Models.Entities
{
    public class StudentEntity : EntityBase, ICreationAudit, IModicationAudit, ISoftDelete
    {
        public StudentEntity()
        {
            CreatedAt = DateTime.Now;
            CreatedBy = string.Empty;
            IsDeleted = false;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public string StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string ContactNumber { get; set; }

        //creation audit properties
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        //modification audit properties
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        //soft delete properties
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

    

    }
}
