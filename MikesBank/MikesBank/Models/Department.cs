using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MikesBank.Models
{
    public class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }
        [Key]
        public int DepId { get; set; }
        public string DepName { get; set; }
        public string DepOffice { get; set; }
        public int? LocId { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual Location Loc { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
