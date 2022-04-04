using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMinternship
{
    public class BankAccount
    {
        Random rand = new Random();
        public string OwnerName { get; set; }
        public string Id { get; set; }
        public int Balance { get; set; }
        public Boolean IsLocked { get; set; }
        
        public Boolean IsAdmin { get; set; }

        public List<String> TranHistory { get; set; }

        public List<Bills> myBills;

        public BankAccount(string OwnerName, string Id, int Balance, Boolean IsLocked, Boolean IsAdmin)
        {
            this.OwnerName = OwnerName;
            this.Id = Id;
            this.Balance = Balance;
            this.IsLocked = IsLocked;
            this.IsAdmin = IsAdmin;

            TranHistory = new List<String>();

            myBills = new List<Bills> {
                new Bills("Electricity", $"Consumption: {rand.Next(1000)} kWh", rand.Next(1000), false),
                new Bills("Water", $"Consumption: {rand.Next(15)} mc", rand.Next(100), false),
                new Bills("Phone", $"Minutes: {rand.Next(1000)}/{rand.Next(1000)} , Messages: {rand.Next(200)}/{rand.Next(200)}", rand.Next(300), false)
            };
        }

    }
}
