using B2C_Funds_Transfer_Csharp.codec;
using B2C_Funds_Transfer_Csharp.transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.utility
{
    public class Utility
    {

        //static char[] hexArray = "0123456789ABCDEF".toCharArray();

        public static String generateMAC(TransferRequest t) {


        Initiation inn = t.getInitiation();
        Termination tm = t.getTermination();
        String init = (inn.getAmount()
        +inn.getCurrencyCode()
        +inn.getPaymentMethodCode()+tm.getTerminationAmount()
        +tm.getTerminationCurrencyCode()
        +tm.getTerminationPaymentMethodCode()
        +tm.getTerminationCountryCode());

            //MessageDigest md = MessageDigest.getInstance("SHA-512");
            //byte[] b = init.getBytes("UTF-8");
            //byte[] bytes = md.digest(b);

            //do sha512

            //
            byte[] data = new byte[8];

            byte[] result;

            var shaM = new SHA512Managed();

            result = shaM.ComputeHash(Encoding.UTF8.GetBytes(init));

            var hex = BitConverter.ToString(result);
          

            return hex;
    }
  
}

}
