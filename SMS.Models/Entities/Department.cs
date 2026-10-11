using SMS.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Models.Entities
{
    public class Department: EntityBase
    {
        public string Name { get; set; }
        public string? Details { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
 