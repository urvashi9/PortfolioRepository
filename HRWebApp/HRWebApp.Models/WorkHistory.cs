﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRWebApp.Models
{
    public class WorkHistory
    {       
        
        public decimal Years { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
    }
}
