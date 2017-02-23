using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.codec
{
    public class Bank
    {
        private String id;
        private String cbnCode;
        private String bankName;
        private String bankCode;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string CbnCode
        {
            get
            {
                return cbnCode;
            }

            set
            {
                cbnCode = value;
            }
        }

        public string BankName
        {
            get
            {
                return bankName;
            }

            set
            {
                bankName = value;
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

        public String getId()
        {
            return Id;
        }
        public void setId(String id)
        {
            this.Id = id;
        }
        public String getCbnCode()
        {
            return CbnCode;
        }
        public void setCbnCode(String cbnCode)
        {
            this.CbnCode = cbnCode;
        }
        public String getBankName()
        {
            return BankName;
        }
        public void setBankName(String bankName)
        {
            this.BankName = bankName;
        }
        public String getBankCode()
        {
            return BankCode;
        }
        public void setBankCode(String bankCode)
        {
            this.BankCode = bankCode;
        }

    }
}
