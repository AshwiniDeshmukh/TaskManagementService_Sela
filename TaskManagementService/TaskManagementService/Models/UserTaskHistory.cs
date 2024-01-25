using System;

namespace TaskManagementService.Models
{
    public class UserTaskHistory
    {
        public int UserTaskHistoryId { get; set; }
        public int UserTaskId { get; set; }
        public string UserTaskHistoryKey { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime VersionOn { get; set; }
        public int VersionBy { get; set; }
    }
}
