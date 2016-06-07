using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRWebApp.Models
{
    public class Education
    {
        [DataType(DataType.Text)]
        public string Degree { get; set; }
        [DataType(DataType.Date)]
        public DateTime GraduationYear { get; set; }
        [DataType(DataType.Text)]
        public string Major { get; set; }
        [DataType(DataType.Text)]
        public string School { get; set; }
    }
}
