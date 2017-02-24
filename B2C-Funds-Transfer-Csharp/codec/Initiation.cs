using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.codec
{
    public class Initiation
    {

        

        public string amount
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

        public string channel
        {
            set;get;
        }

        public Initiation(String amount, String currencyCode, String paymentMethodCode, String channel)
        {
            this.amount = amount;
            this.currencyCode = currencyCode;
            this.paymentMethodCode = paymentMethodCode;
            this.channel = channel;
        }

        

    }

}
