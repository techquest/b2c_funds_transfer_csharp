using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.codec
{
    public class Termination
    {

        

        public AccountReceivable accountReceivable
        {
            set;get;
        }

        public string amount
        {
            set;get;
        }

        public string entityCode
        {
            set;get;
        }

        public string currencyCode
        {
            set;get;
        }

        public string paymentMethodCode
        {
            set;get;
        }

        public string countryCode
        {
            set;get;
        }

        public Termination(String amount, String entityCode, String currencyCode, String paymentMethodCode, String countryCode)
        {
            this.amount = amount;
            this.entityCode = entityCode;
            this.currencyCode = currencyCode;
            this.paymentMethodCode = paymentMethodCode;
            this.countryCode = countryCode;
        }
        
    }

}
