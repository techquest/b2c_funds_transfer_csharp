# B2C-Funds-Transfer-Csharp
```
using B2C_Funds_Transfer_Csharp.codec;
using B2C_Funds_Transfer_Csharp.transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * 
 * sample code to showcase all the request in transfer service.
 * 
 * For any difficulty, contact any of the contributors for help.
 *
 */
namespace SampleApp
{
    class AppDriver
    {

        static void Main(string[] args)
        {

           /**
          * Initiating entity code:
          * This is unique to a each merchant.
          * When you are ready to move to production,
          * you will be provided with your initiatingEntityCode
          */
            String initiatingEntityCode = "XXT";

            /**
           * @clientId:
           * @clientSecret:
           * These are for test environment.
           * String clientId = "IKIA2EFBE1EF63D1BBE2AF6E59100B98E1D3043F477A";
           * String clientSecret = "uAk0Amg6NQwQPcnb9BTJzxvMS6Vz22octQglQ1rfrMA=";
           * FundTransfer transfer = new FundTransfer(clientId, clientSecret, Interswitch.ENV_DEV)
           */       

            /**
             * @clientId:
             * @clientSecret:
             * These are for the sandbox environment.
             */
            String clientId = "IKIA6570778A3484D6F33BC7E4165ADCA6CF06B2860A";
            String clientSecret = "DXfUwpuIvMAKN84kv38uspqGOsStgFS0oZMjU7bPwpU=";

            /**
             * Create a funds transfer object.
             * e.g FundsTransfer transfer = new FundsTransfer(clientId, clientSecret, Interswitch.ENV_SANDBOX);
             * 
             * With this object you can
             * 
             * 1. Get all supported banks on our platform.
             * 
             * e.g BankResponse bankResponse = transfer.fetchBanks();
             * 
             * If successful, it returns a list of all banks. Otherwise it
             * throws returns an error object or throws an exception.
             * 
             * 2. Account Validation
             * 
             * e.g AccountValidation validationResponse = transfer.validateAccount(request);// validate account
             * 
             * This is used to validate an account number against a source bank.
             * If successful, you know for sure the bank account number is valid.
             * Otherwise, it is probably okay to still go on with the transaction.
             * 
             * 3. Funds Transfer.
             * 
             * e.g TransferResponse response = transfer.send(request); // send transfer request
             * 
             * This api, is used to initiate a funds transfer from a sender to a receiver.
             * The sample code is clear and concise and states the mandatory and optional fields.
             * 
             * 
             * 
             */

            FundsTransfer transfer = new FundsTransfer(clientId, clientSecret, Interswitch.Interswitch.SANDBOX);

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
                        .amount("100000") // mandatory, minor denomination
                        .channel(FundsTransfer.LOCATION) // mandatory: ATM-1, POS-2, WEB-3, MOBILE-4, KIOSK-5, PCPOS-6, LOCATION-7, DIRECT DEBIT-8
                        .destinationBankCode(cbnCode)/* mandatory:  To be gotten from the get all banks code (transfer.fetchBanks())*/
                        .toAccountNumber("0114951936") // mandatory
                        .requestRef("60360575603527")// mandatory
                        .senderPhoneNumber("07036913492") // optional
                        .senderEmail("grandeur_man@yahoo.com") // optional
                        .senderLastName("Desmond") // optional
                        .senderOtherNames("Samuel") // optional
                        .receiverPhoneNumber("07036913492") // optional
                        .receiverEmail("grandeur_man@yahoo.com") // optional
                        .receiverLastName("Desmond") // optional
                        .receiverOtherNames("Samuel") // optional
                        .fee("10000")// optional (minor denomination)
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

```
