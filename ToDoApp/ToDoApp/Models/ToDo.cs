using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    /*
     * ToDo Class : Holds the data of each task entry
     * id: auto generated
     * name : task name, or title, has max of 50 char, cant be null
     * body : task description, max of 1000 char , discription
     * Created On : the date when it was Created
     * status: New, Completed <the value is set to default New, 
     * can be updated only throw UPDATE button, using a select list>
     * 
     * 
     * data of Class added to data base, used Migration to Create Data base 
     * 
     */
    public class ToDo
    {
        public Guid id { get; set; }

        [DisplayName("Task Heading")]
        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Required]
        [MaxLength(1000)]
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
