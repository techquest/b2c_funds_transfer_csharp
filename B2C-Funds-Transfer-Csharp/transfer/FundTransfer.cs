using B2C_Funds_Transfer_Csharp.codec;
using B2C_Funds_Transfer_Csharp.utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.transfer
{
    public class FundsTransfer : Transfer
    {
        private string clientId;
        private string clientSecret;
        private string environment;
        public static Interswitch.Interswitch interswitch;
        public static String ATM = "1";
        public static String WEB = "3";
        public static String MOBILE = "4";
        public static String KIOSK = "5";
        public static String PCPOS = "6";
        public static String POS = "2";
        public static String LOCATION = "7";
        public static String DIRECT_DEBIT = "8";
        public static string HTTP_CODE = "CODE";
        public static string HTTP_RESPONSE = "RESPONSE";

        public FundsTransfer(string clientId, string clientSecret, string env=null) {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.environment = env;
            if (env == null) env = "SANDBOX";
            interswitch = new Interswitch.Interswitch(clientId, clientSecret, env);
        }

        

        public BankResponse fetchBanks() {
            Dictionary<string, string> extra = new Dictionary<string, string>();
            Dictionary<string, string> response = interswitch.Send(Constants.GET_ALL_BANKS_RESOURCE_URL, Constants.GET);
            String responseCode;
            response.TryGetValue(Interswitch.Interswitch.HTTP_CODE, out responseCode);
            String msg;
            response.TryGetValue(Interswitch.Interswitch.HTTP_RESPONSE, out msg);

            return JsonConvert.DeserializeObject<BankResponse>(msg);

        }

        public AccountValidation validateAccount(TransferRequest request) {

            String bankCode = request.bankCode;
            Dictionary<string, string> extra = new Dictionary<string, string>();
            String accountNumber = request.accountNumber;
            String url = Constants.ACCOUNT_VALIDATION_URL_PREFIX + bankCode + "/" + Constants.ACCOUNT_VALIDATION_URL_SUFFIX + accountNumber + "/names";
            Dictionary<string, string> response = interswitch.Send(url, Constants.GET);
            String responseCode;
            response.TryGetValue(Interswitch.Interswitch.HTTP_CODE, out responseCode);
            String msg;
            response.TryGetValue(Interswitch.Interswitch.HTTP_RESPONSE, out msg);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<AccountValidation>(msg);
        }

        public TransferResponse send(TransferRequest tr) {

            String mac = Utility.generateMAC(tr);

            if (mac != null) {
                mac = mac.Replace("-", string.Empty);
            }

            tr.mac = mac;

            var settings = new JsonSerializerSettings();

            settings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            String json = JsonConvert.SerializeObject(tr, settings);

            tr = Newtonsoft.Json.JsonConvert.DeserializeObject<TransferRequest>(json, settings);

            //Console.WriteLine(json);

            Dictionary <string, string> response = interswitch.Send(Constants.TRANSFER_RESOURCE_URL, Constants.POST, tr);
            String responseCode;
            response.TryGetValue(Interswitch.Interswitch.HTTP_CODE, out responseCode);
            String msg;
            response.TryGetValue(Interswitch.Interswitch.HTTP_RESPONSE, out msg);

            return JsonConvert.DeserializeObject<TransferResponse>(msg);

        }
    }
}
