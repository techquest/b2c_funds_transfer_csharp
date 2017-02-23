using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.transfer
{
    public class Constants
    {
        public static  String CURRENCY_CODE = "566";
        public static  String INITATION_PAYMENT_METHOD_CODE = "CA";
        public static  String TERMINATION_PAYMENT_METHOD_CODE="AC";
        public static  String ACCOUNT_TYPE = "00";
        public static  String TERMINAL_ID = "TerminalId";
        public static  String GET = "GET";
        public static  String POST = "POST";
        public static  String TRANSFER_RESOURCE_URL = "/api/v2/quickteller/payments/transfers";
        public static  int MAX_TRANSFER_LENGTH = 12;
        public static  String COUNTRY_CODE = "NG";
        public static  String GET_ALL_BANKS_RESOURCE_URL = "/api/v2/quickteller/configuration/fundstransferbanks";
        public static  String ACCOUNT_VALIDATION_URL_PREFIX = "/api/v1/nameenquiry/banks/";
        public static  String ACCOUNT_VALIDATION_URL_SUFFIX = "accounts/";
    }
}
