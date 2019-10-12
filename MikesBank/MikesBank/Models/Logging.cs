using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MikesBank.Models
{
    public partial class Logging
    {
        [Key]
        public int LogId { get; set; }
        public string LogSeverity { get; set; }
        public string LogSource { get; set; }
        public string LogMessage { get; set; }
        public string LogStackTrace { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
