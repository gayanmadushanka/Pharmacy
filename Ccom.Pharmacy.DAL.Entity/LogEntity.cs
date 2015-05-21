using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ccom.Pharmacy.DAL.Entity
{
    [Table("Log")]
    public class LogEntity
    {
        public LogEntity()
        {
            CategoryLogs = new HashSet<CategoryLog>();
        }

        [Key]
        public int LogID { get; set; }

        public int? EventID { get; set; }

        public int Priority { get; set; }

        [Required]
        [StringLength(32)]
        public string Severity { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        [StringLength(32)]
        public string MachineName { get; set; }

        [Required]
        [StringLength(512)]
        public string AppDomainName { get; set; }

        [Required]
        [StringLength(256)]
        public string ProcessID { get; set; }

        [Required]
        [StringLength(512)]
        public string ProcessName { get; set; }

        [StringLength(512)]
        public string ThreadName { get; set; }

        [StringLength(128)]
        public string Win32ThreadId { get; set; }

        [StringLength(1500)]
        public string Message { get; set; }

        [Column(TypeName = "ntext")]
        public string FormattedMessage { get; set; }

        public  ICollection<CategoryLog> CategoryLogs { get; set; }
    }
}
