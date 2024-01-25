using System;

namespace TaskManagementService.Models
{
    public class UserTask
    {
        public int UserTaskId { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string UserTaskKey { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int TaskStatusTypeId { get; set; }
        public DateTime VersionOn { get; set; }
        public int VersionBy { get; set; }
    }
}
