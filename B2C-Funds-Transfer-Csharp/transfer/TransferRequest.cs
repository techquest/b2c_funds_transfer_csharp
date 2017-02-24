using B2C_Funds_Transfer_Csharp.codec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.transfer
{
    public class TransferRequest
    {

        public TransferRequest()
        {
        }

        //private Sender sender

        public Sender sender
        {
            set; get;
        }

        public Beneficiary beneficiary
        {
            set; get;
        }

        public Initiation initiation
        {
            set; get;
        }

        public Termination termination
        {
            set; get;
        }

        public string mac
        {
            set; get;
        }

        public string surcharge
        {
            set; get;
        }

        public string initiatingEntityCode
        {
            set; get;
        }

        public string transferCode
        {
            set; get;
        }

        public string accountNumber
        {
            set; get;
        }

        public string bankCode
        {
            set; get;
        }


    }
}
