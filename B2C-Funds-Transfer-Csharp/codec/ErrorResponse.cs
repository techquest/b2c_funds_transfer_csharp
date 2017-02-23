using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.codec
{
    public class ErrorResponse
    {
        private String code;
        private String message;

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public String getCode()
        {
            return Code;
        }
        public void setCode(String code)
        {
            this.Code = code;
        }
        public String getMessage()
        {
            return Message;
        }
        public void setMessage(String message)
        {
            this.Message = message;
        }
    }
}
