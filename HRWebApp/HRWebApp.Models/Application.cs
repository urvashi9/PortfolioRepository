using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRWebApp.Models
{
    public class Application : IValidatableObject
    {
        [Display(Name = "Applicant Name*")]
        //[Required(ErrorMessage = "Please enter the Applicant Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public Address Address { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email ID*")]
        public string EmailId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime Dob { get; set; }

        public List<Education> Education { get; set; }

        [Display(Name = "Skill Set")]
        //[Required(ErrorMessage = "Please list your skill set")]
        public string SkillSet { get; set; }

        public List<WorkHistory> WorkHistory { get; set; }

        //[Required(ErrorMessage = "Please give us a brief description about you")]
        [Display(Name = "Brief Description*")]
        public string BriefDescription { get; set; }

        public int ApplicationId { get; set; }

        [Display(Name = "Job Applying For")]
        public Job JobApplyingFor { get; set; }


        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(new ValidationResult("Please enter your name",
                    new[] { "Name" }));
            }
            if (string.IsNullOrWhiteSpace(Address.City) || string.IsNullOrWhiteSpace(Address.State))
            {
                errors.Add(new ValidationResult("Please enter your city and state",new [] {"Address"}));
            }
            if (string.IsNullOrWhiteSpace(PhoneNumber) && string.IsNullOrWhiteSpace(EmailId))
            {
                errors.Add(new ValidationResult("Please enter either your phone number or your email address"));
            }
            if (string.IsNullOrWhiteSpace(SkillSet))
            {
                errors.Add(new ValidationResult("Please list your skill set",new []{"SkillSet"}));
            }
            if (string.IsNullOrWhiteSpace(BriefDescription))
            {
                errors.Add(new ValidationResult("Please give us a brief description about you", new []{"BriefDescription"}));
            }
            return errors;
        }
    }
}
