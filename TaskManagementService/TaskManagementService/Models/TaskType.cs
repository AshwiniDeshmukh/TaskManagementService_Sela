using System.ComponentModel.DataAnnotations;

namespace TaskManagementService.Models
{
    public class TaskType
    {
        [Key]
        public int TaskTypeId { get; set; }
        public string TaskTypeKey { get; set; }
        public string TaskTypeName { get; set; }
        public int Status { get; set; }
    }
}
