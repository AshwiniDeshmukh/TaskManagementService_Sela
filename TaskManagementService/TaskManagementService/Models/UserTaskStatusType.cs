
using System.ComponentModel.DataAnnotations;

namespace TaskManagementService.Models
{
    public class UserTaskStatusType
    {
        [Key]
        public int UserTaskTypeId { get; set; }
        public string UserTaskTypeKey { get; set; }
        public string UserTaskTypeName { get; set; }
        public int Status { get; set; }
    }
}
