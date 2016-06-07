using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRWebApp.Models
{
    public class Job
    {
        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "Please provide a job title")]
        public string JobTitle { get; set; }
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        [Display(Name = "Job Requirements")]
        [Required(ErrorMessage = "Please provide the job requirements")]
        public string JobRequirement { get; set; }
        public int JobId { get; set; }
    }
}
