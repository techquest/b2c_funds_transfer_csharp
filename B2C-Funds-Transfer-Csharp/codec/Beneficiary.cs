using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.codec
{
    public class Beneficiary
    {

        

        public string phone
        {
            set;get;
        }

        public string email
        {
            set;get;
        }

        public string lastname
        {
            set;get;
        }

        public string othernames
        {
            set;get;
        }

        public Beneficiary(String phone, String email, String lastname, String othernames)
        {
            this.phone = phone;
            this.email = email;
            this.lastname = lastname;
            this.othernames = othernames;
        }
        

    }

}
