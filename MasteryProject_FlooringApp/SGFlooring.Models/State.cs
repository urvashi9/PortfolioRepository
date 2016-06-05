using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGFlooring.Models
{
    public class State
    {
        public State(string stateAbbr, string stateName, decimal taxRate)
        {
            this.TaxRate = taxRate;
            this.StateAbbr = stateAbbr;
            this.StateName = stateName;
        }

        public State()
        {
        }

        public string StateAbbr { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }

        public override string ToString()
        {
            return string.Format($"{StateAbbr},{StateName},{TaxRate}");
        }
    }

   
}
