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

                Bank[] bank = bankResponse.getBanks(); // a bank array of all banks

                if (bank != null)
                {
                    // successful
                    Bank testBank = bank[0]; // bank at index 0

                    String cbnCode = testBank.getCbnCode(); // Central bank code
                    String bankName = testBank.getBankName(); // bank name:
                    String bankCode = testBank.getBankCode(); // bankcode in alphabetical form: UBA, GTB, FBN

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
                        .toAccountNumber("0114951936") // mandatory
                        .fee("10000")// optional
                        .requestRef("60360575603527")// mandatory
                        .build();

                    AccountValidation validationResponse = transfer.validateAccount(request);// validate account

                    if (validationResponse is AccountValidation)
                    {

                        String accountName = validationResponse.getAccountName();
                    }

                    TransferResponse response = transfer.send(request); // send transfer request

                    if (response.getError() is ErrorResponse)
                    {
                        // NOT SUCCESSFUL
                        String code = response.getError().getCode();
                        String message = response.getError().getMessage();

                    }
                    else if (response.getResponseCode().Equals("90000"))
                    {

                        // SUCCESS
                        String mac = response.getMac();
                        String transactionDate = response.getTransactionDate();
                        String responseCode = response.getResponseCode();

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
