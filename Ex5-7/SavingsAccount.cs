using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5_7
{
    public class SavingsAccount:BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal SavingsAmount { get; set; }

        public SavingsAccount(string name, string account, string accountNumber, decimal savingsAmount)
               :base( name,  account)
        {
            AccountNumber = accountNumber;
            SavingsAmount = savingsAmount;
        }

       

    }

}
