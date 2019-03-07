using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5_7
{
   public class BankAccount
    {

        public string Name { get; set; }
        public string Account { get; set; }
        public BankAccount(string name, string account)
        {
            Name = name;
            Account = account;

        }
        public BankAccount()
        { }

        public override  string ToString()
        {
            return string.Format("{0} - {1}", Account, Name);
        }
        public virtual string FileFormat()
        {
            return string.Format("{0},{1},", Name, Account);

        }
    }


}

   
