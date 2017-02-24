using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.codec
{
    public class BankResponse
    {
        

        public Bank[] banks
        {
            set;get;
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
