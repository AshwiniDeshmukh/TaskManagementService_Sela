using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementService.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int CreatedBy { get; set; }
        public string EmailId { get; set; }

    }
}
