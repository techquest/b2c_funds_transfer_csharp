using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.codec
{
    public class BankResponse
    {
        private Bank[] banks;
        private ErrorResponse error;
        private ErrorResponse[] errors;

        public Bank[] Banks
        {
            get
            {
                return banks;
            }

            set
            {
                banks = value;
            }
        }

        public ErrorResponse Error
        {
            get
            {
                return error;
            }

            set
            {
                error = value;
            }
        }

        public ErrorResponse[] Errors
        {
            get
            {
                return errors;
            }

            set
            {
                errors = value;
            }
        }

        public ErrorResponse getError()
        {
            return Error;
        }

        public void setError(ErrorResponse error)
        {
            this.Error = error;
        }

        public ErrorResponse[] getErrors()
        {
            return Errors;
        }

        public void setErrors(ErrorResponse[] errors)
        {
            this.Errors = errors;
        }

        public Bank[] getBanks()
        {
            return banks;
        }

        public void setBanks(Bank[] banks)
        {
            this.banks = banks;
        }
    }
}
