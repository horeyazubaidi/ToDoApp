using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class ToDo
    {
        public Guid id { get; set; }
        [DisplayName("Task Heading")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }
        [Required]
        [MaxLength(50)]
        public string body { get; set; }
        public DateTime createdOn { get; private set; }
        [DisplayName("Task Status")]
        public string status { get; set; }

        public ToDo()
        {
            id = new Guid();
            createdOn = DateTime.Now;
            status = "New";
        }
    }
}
