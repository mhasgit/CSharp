using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Models;

namespace TaskManagement.ViewModels.TaskViewModel
{
    public class TaskItemCreateViewModel
    {
        [Required]
        [Display(Name = "Task Title")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Task Description")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name = "Task Status")]
        public TaskItemStatus Status { get; set; }
    }
}
