using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MikesBank.Models
{
    public partial class Employee
    {
        public Employee()
        {
            InverseEmpManager = new HashSet<Employee>();
        }
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmpJobTitle { get; set; }
        public int? EmpManagerId { get; set; }
        public int? DepId { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }

        [JsonIgnore]
        public virtual Department Dep { get; set; }
        [JsonIgnore]
        public virtual Employee EmpManager { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> InverseEmpManager { get; set; }
    }
}
