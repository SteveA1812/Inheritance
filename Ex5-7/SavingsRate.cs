using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5_7
{
    class SavingsRate:SavingsAccount
    {

        public decimal Interest { get; set; }


        public SavingsRate(string name, string account, string accountNumber, decimal savingsAmount, decimal interest)
            :base( name, account,  accountNumber,  savingsAmount)
        { Interest = interest; }
        public override string ToString()
        {
            return string.Format("{0} \n{1} \n{2} \n{3:C} \nRate: {4}%",Name,Account, AccountNumber, SavingsAmount, Interest);
        }

    }
}
