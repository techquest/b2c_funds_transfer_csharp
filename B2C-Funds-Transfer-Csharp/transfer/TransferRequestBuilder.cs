using B2C_Funds_Transfer_Csharp.codec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2C_Funds_Transfer_Csharp.transfer
{
    public class TransferRequestBuilder
    {
        private TransferRequest transferRequest;

        public TransferRequestBuilder begin()
        {
            this.transferRequest = new TransferRequest();
            return this;
        }
        //#region
        private Sender sender;

        private String senderPhoneTmp = "-";
        private String senderEmailTmp = "-";
        private String senderLastNameTmp = "-";
        private String senderOtherNamesTmp = "-";

        private Beneficiary beneficiary;
        private String beneficiaryPhoneNumber;
        private String beneficiaryEmail;
        private String beneficiaryLastName;
        private String beneficiaryOtherNames;

        private String amountTmp;

        private String initiatorAmount;
        private String initiatorCurrencyCode = Constants.CURRENCY_CODE;
        private String initiatorPaymentMethodCode = Constants.INITATION_PAYMENT_METHOD_CODE;
        private String initiatorChannel;

        private String terminationAmountTmp;
        private String terminationEntityCodeTmp;
        private String terminationCurrencyCodeTmp = Constants.CURRENCY_CODE;
        private String terminationPaymentMethodCodeTmp = Constants.TERMINATION_PAYMENT_METHOD_CODE;
        private String terminationCountryCodeTmp = Constants.COUNTRY_CODE;
        private String terminationAccountNumberTmp;
        private String terminationAccountTypeTmp = Constants.ACCOUNT_TYPE;

        private Initiation initiation;
        private Termination termination;

        private String mac;
        private String surcharge;

        private String initiatingEntityCode;

        private String transferCode;
        private String accountNumber;
        private String bankCode;
        //#endregion
        public TransferRequestBuilder(String initiatingEntityCode)
        {

            this.initiatingEntityCode = initiatingEntityCode;

        }

        public String setAccountNumber(String acc)
        {
            return accountNumber;
        }

        public TransferRequestBuilder receiverPhoneNumber(String phone)
        {

            this.beneficiaryPhoneNumber = phone;
            return this;
        }

        public TransferRequestBuilder receiverEmail(String email)
        {

            this.beneficiaryEmail = email;
            return this;
        }

        public TransferRequestBuilder receiverLastName(String lastName)
        {

            this.beneficiaryLastName = lastName;
            return this;
        }

        public TransferRequestBuilder receiverOtherNames(String otherName)
        {

            this.beneficiaryOtherNames = otherName;
            return this;
        }

        public TransferRequestBuilder senderPhoneNumber(String phone)
        {
            this.senderPhoneTmp = phone;
            return this;
        }

        public TransferRequestBuilder senderEmail(String email)
        {

            this.senderEmailTmp = email;
            return this;
        }

        public TransferRequestBuilder senderLastName(String lastName)
        {

            this.senderLastNameTmp = lastName;
            return this;
        }

        public TransferRequestBuilder senderOtherNames(String otherName)
        {

            this.senderOtherNamesTmp = otherName;
            return this;
        }

        public TransferRequestBuilder setAmount(String amount)
        {

            this.amountTmp = amount;
            return this;
        }

        public TransferRequestBuilder amount(String amount)
        {
            this.initiatorAmount = amount;
            this.amountTmp = amount;
            return this;
        }

        public TransferRequestBuilder currencyCode(String currencyCode)
        {
            this.initiatorCurrencyCode = currencyCode;
            return this;
        }

        public TransferRequestBuilder paymentMethodCode(String paymentMethodCode)
        {
            this.initiatorPaymentMethodCode = paymentMethodCode;
            return this;
        }

        public TransferRequestBuilder channel(String channel)
        {
            this.initiatorChannel = channel;
            return this;
        }

        public TransferRequestBuilder terminationCurrencyCode(String currencyCode)
        {
            this.terminationCurrencyCodeTmp = currencyCode;
            return this;
        }

        public TransferRequestBuilder terminationPaymentMethodCode(String paymentMethodCode)
        {
            this.terminationPaymentMethodCodeTmp = paymentMethodCode;
            return this;
        }

        public TransferRequestBuilder terminationCountryCode(String countryCode)
        {
            this.terminationCountryCodeTmp = countryCode;
            return this;
        }

        public TransferRequestBuilder toAccountNumber(String accountNumber)
        {
            this.terminationAccountNumberTmp = accountNumber;
            return this;
        }

        public TransferRequestBuilder destinationBankCode(String entityCode)
        {
            this.terminationEntityCodeTmp = entityCode;

            return this;
        }
        public TransferRequestBuilder terminationAccountType(String accountType)
        {
            this.terminationAccountTypeTmp = accountType;
            return this;
        }

        public TransferRequestBuilder requestRef(String val)
        {

            this.transferCode = val;

            return this;
        }

        public TransferRequestBuilder fee(String surcharge)
        {

            this.surcharge = surcharge;

            return this;
        }

        public TransferRequest build()
        {

            TransferRequestBuilder builder = this;
            //set all the property we want 
            
            this.transferRequest.Sender = new Sender(senderPhoneTmp, senderEmailTmp, senderLastNameTmp, senderOtherNamesTmp);
            this.transferRequest.Beneficiary = new Beneficiary(builder.beneficiaryPhoneNumber, builder.beneficiaryEmail, builder.beneficiaryLastName, builder.beneficiaryOtherNames);
            this.transferRequest.AccountNumber = terminationAccountNumberTmp;
            this.transferRequest.BankCode = terminationEntityCodeTmp;
            this.transferRequest.Surcharge = surcharge;
            this.transferRequest.TransferCode = transferCode;
            this.transferRequest.Termination = new Termination(amountTmp, terminationEntityCodeTmp,terminationCurrencyCodeTmp, terminationPaymentMethodCodeTmp, terminationCountryCodeTmp);
            AccountReceivable tmpAccount = new AccountReceivable(terminationAccountNumberTmp, terminationAccountTypeTmp);
            this.transferRequest.Initiation = new Initiation(amountTmp, initiatingEntityCode, initiatorPaymentMethodCode, initiatorChannel);
   
            return this.transferRequest;
        }

        

    }
}
