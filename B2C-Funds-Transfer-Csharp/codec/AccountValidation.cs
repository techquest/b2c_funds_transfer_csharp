using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.codec
{
    public class AccountValidation
    {
        public AccountValidation()
        {

        }


        public string accountName
        {
            get;set;
        }

        public ErrorResponse error
        {
            set;get;
        }

       

        public ErrorResponse[] errors
        {
            set;get;
        }

    }
}
