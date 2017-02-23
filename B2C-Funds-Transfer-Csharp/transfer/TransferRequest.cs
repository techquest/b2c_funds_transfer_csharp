using B2C_Funds_Transfer_Csharp.codec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.transfer
{
    public class TransferRequest : Transfer
    {

        public TransferRequest()
        {
        }

        private Sender sender;
        private Beneficiary beneficiary;

        private Initiation initiation;
        private Termination termination;

        private String mac;
        private String surcharge;

        private String initiatingEntityCode;

        private String transferCode;

        private String accountNumber;
        private String bankCode;

        public Sender Sender
        {
            get
            {
                return sender;
            }

            set
            {
                sender = value;
            }
        }

        public Beneficiary Beneficiary
        {
            get
            {
                return beneficiary;
            }

            set
            {
                beneficiary = value;
            }
        }

        public Initiation Initiation
        {
            get
            {
                return initiation;
            }

            set
            {
                initiation = value;
            }
        }

        public Termination Termination
        {
            get
            {
                return termination;
            }

            set
            {
                termination = value;
            }
        }

        public string Mac
        {
            get
            {
                return mac;
            }

            set
            {
                mac = value;
            }
        }

        public string Surcharge
        {
            get
            {
                return surcharge;
            }

            set
            {
                surcharge = value;
            }
        }

        public string InitiatingEntityCode
        {
            get
            {
                return initiatingEntityCode;
            }

            set
            {
                initiatingEntityCode = value;
            }
        }

        public string TransferCode
        {
            get
            {
                return transferCode;
            }

            set
            {
                transferCode = value;
            }
        }

        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }

            set
            {
                accountNumber = value;
            }
        }

        public string BankCode
        {
            get
            {
                return bankCode;
            }

            set
            {
                bankCode = value;
            }
        }

        public String getAccountNumber()
        {
            return AccountNumber;
        }

        public void setAccountNumber(String accountNumber)
        {
            this.AccountNumber = accountNumber;
        }

        public String getBankCode()
        {
            return BankCode;
        }

        public void setBankCode(String bankCode)
        {
            this.BankCode = bankCode;
        }



        private TransferRequest(TransferRequestBuilder builder)
        {
            

        }

        public void setMac(String mac)
        {
            this.Mac = mac;
        }

        public Sender getSender()
        {
            return Sender;
        }

        public Beneficiary getBeneficiary()
        {
            return Beneficiary;
        }

        public Initiation getInitiation()
        {
            return Initiation;
        }

        public Termination getTermination()
        {
            return Termination;
        }

        public String getMac()
        {
            return Mac;
        }

        public String getSurcharge()
        {
            return Surcharge;
        }

        public String getInitiatingEntityCode()
        {
            return InitiatingEntityCode;
        }

        public String getTransferCode()
        {
            return TransferCode;
        }


    }
}
