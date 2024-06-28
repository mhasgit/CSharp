using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    
    public enum TaskItemStatus
    {
        [Display(Name = "To Do")]
        Todo,
        [Display(Name = "In Progress")]
        InProgress,
        Done
    }
}
