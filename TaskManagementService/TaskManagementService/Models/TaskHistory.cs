using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementService.Models
{
    public class TaskHistory
    {
        [Key]
        public int TaskHistoryId { get; set; }
        public int TaskId { get; set; }
        public string TaskHistoryKey { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime VersionOn { get; set; }
        public int VersionBy { get; set; }

    }
}
