using B2C_Funds_Transfer_Csharp.codec;
using B2C_Funds_Transfer_Csharp.transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            String initiatingEntityCode = "PBL";
            String clientId = "IKIA2EFBE1EF63D1BBE2AF6E59100B98E1D3043F477A";
            String clientSecret = "uAk0Amg6NQwQPcnb9BTJzxvMS6Vz22octQglQ1rfrMA=";
            FundTransfer transfer = new FundTransfer(clientId, clientSecret, Interswitch.Interswitch.DEV);

            try
            {
                BankResponse bankResponse = transfer.fetchBanks();

                Bank[] bank = bankResponse.banks; // a bank array of all banks

                if (bank != null)
                {
                    // successful
                    Bank testBank = bank[0]; // bank at index 0

                    String cbnCode = testBank.cbnCode; // Central bank code
                    String bankName = testBank.bankName; // bank name:
                    String bankCode = testBank.bankCode; // bankcode in alphabetical form: UBA, GTB, FBN

                    TransferRequest request = new TransferRequestBuilder(initiatingEntityCode).begin()
                        .senderPhoneNumber("07036913492") // optional
                        .senderEmail("grandeur_man@yahoo.com") // optional
                        .senderLastName("Desmond") // optional
                        .senderOtherNames("Samuel") // optional
                        .receiverPhoneNumber("07036913492") // optional
                        .receiverEmail("grandeur_man@yahoo.com") // optional
                        .receiverLastName("Desmond") // optional
                        .receiverOtherNames("Samuel") // optional
                        .amount("100000") // mandatory, minor denomination
                        .channel(FundTransfer.LOCATION) // mandatory: ATM-1, POS-2, WEB-3, MOBILE-4, KIOSK-5, PCPOS-6, LOCATION-7, DIRECT DEBIT-8
                        .destinationBankCode(cbnCode)/* mandatory:  To be gotten from the get all banks code*/
                        .toAccountNumber("4114951936") // mandatory
                        .fee("10000")// optional
                        .requestRef("30360575603526")// mandatory and unique for each transaction
                        .build();

                    AccountValidation validationResponse = transfer.validateAccount(request);// validate account

                    if (validationResponse is AccountValidation)
                    {

                        String accountName = validationResponse.accountName;
                    }

                    TransferResponse response = transfer.send(request); // send transfer request

                    if (response.error is ErrorResponse)
                    {
                        // NOT SUCCESSFUL
                        String code = response.error.code;
                        String message = response.error.message;

                    }
                    else if (response.responseCode.Equals("90000"))
                    {

                        // SUCCESS
                        String mac = response.mac;
                        String transactionDate = response.transactionDate;
                        String responseCode = response.responseCode;

                    }
                    else
                    {
                        // transfer was not successful
                    }
                }
                else
                {
                    // transfer was not successful
                }

            }
            catch (Exception ex)
            {

            }


        }
    }
}
