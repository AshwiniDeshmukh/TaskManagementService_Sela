using System;

namespace TaskManagementService.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string UserKey { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string UserName { get; set; }
       
    }
}
