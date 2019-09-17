using System;
using System.Collections.Generic;

namespace MikesBank.Models
{
    public partial class Location
    {
        public Location()
        {
            Department = new HashSet<Department>();
        }

        public int LocId { get; set; }
        public string LocName { get; set; }
        public string LocCountry { get; set; }
        public string LocAddress1 { get; set; }
        public string LocAddress2 { get; set; }
        public string LocCity { get; set; }
        public string LocZip { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }

        public virtual ICollection<Department> Department { get; set; }
    }
}
