using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMinternship
{
    public class Bills
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public Boolean IsPaid { get; set; }

        public Bills(string Name, string Description, int Amount, Boolean IsPaid)
        {
            this.Name = Name;
            this.Description = Description;
            this.Amount = Amount;
            this.IsPaid = IsPaid;
        }
    }
}
