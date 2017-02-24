using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.codec
{
    public class AccountReceivable
    {
       

        public string accountNumber
        {
            set;get;
        }

        public string accountType
        {
            set;get;
        }

        public AccountReceivable(String accountNumber, String accountType)
        {
            this.accountType = accountType;
            this.accountNumber = accountNumber;
        }

    }
}
