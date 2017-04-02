using System;
using Newtonsoft.Json;

namespace DelimitedFileParsing.Models
{
    public class AddressBase : BaseData
    {
       
        public string FullName { get; set; }
       
        public string AddressLine1 { get; set; }
       
        public string AddressLine2 { get; set; }
       
        public string City { get; set; }
       
        public string StateOrProvince { get; set; }
       
        public string PostalCode { get; set; }
       
        public string AddressLine3 { get; set; }
       
        public string Country { get; set; }
       
        public string TelephoneNumber { get; set; }
       
        /// <summary>
        /// Optional. <c>JsonProperty Order</c> controls serialization order
        /// </summary>
        [JsonProperty(Order = 2)]
        public string AddressNotes { get; set; }

    }

    /// <summary>
    /// Optional. <c>JsonProperty Order</c> controls serialization order
    /// </summary>
    public class Billinginfo : AddressBase, IBuilder
    {
        [JsonProperty(Order = 1)]
        public string TelephoneExtension { get; set; }
        [JsonProperty(Order = 1)]
        public string EmailAddress { get; set; }
        [JsonProperty(Order = 1)]
        public string EmailVerified { get; set; }
        [JsonProperty(Order = 1)]
        public string CustomerPaymentMethodId { get; set; }
        [JsonProperty(Order = 1)]
        public string AddressVerified { get; set; }
        [JsonProperty(Order = 1)]
        public string CustomerGroup { get; set; }

        public void MapFields(string[] parsedStrings)
        {
            var fcount = FieldCount();
            if (parsedStrings?.Length != fcount)
                throw new ArgumentException(nameof(parsedStrings), $"Parsed string count {parsedStrings?.Length} match property count: {fcount}");

            FileDesignation = parsedStrings[0];
            FullName = parsedStrings[1];
            AddressLine1 = parsedStrings[2];
            AddressLine2 = parsedStrings[3];
            City = parsedStrings[4];
            StateOrProvince = parsedStrings[5];
            PostalCode = parsedStrings[6];
            AddressLine3 = parsedStrings[7];
            Country = parsedStrings[8];
            TelephoneNumber = parsedStrings[9];
            TelephoneExtension = parsedStrings[10];
            EmailAddress = parsedStrings[11];
            EmailVerified = parsedStrings[12];
            CustomerPaymentMethodId = parsedStrings[13];
            AddressVerified = parsedStrings[14];
            CustomerGroup = parsedStrings[15];
            AddressNotes = parsedStrings[16];
        }



    }

    public class Shippinginfo : AddressBase, IBuilder
    {
        public void MapFields(string[] parsedStrings)
        {
            var fcount = FieldCount();
            if (parsedStrings?.Length != fcount)
                throw new ArgumentException(nameof(parsedStrings), $"Parsed string count {parsedStrings?.Length} match property count: {fcount}");


            FileDesignation = parsedStrings[0];
            FullName = parsedStrings[1];
            AddressLine1 = parsedStrings[2];
            AddressLine2 = parsedStrings[3];
            City = parsedStrings[4];
            StateOrProvince = parsedStrings[5];
            PostalCode = parsedStrings[6];
            AddressLine3 = parsedStrings[7];
            Country = parsedStrings[8];
            TelephoneNumber = parsedStrings[9];
            AddressNotes = parsedStrings[10];
        }


    }

}
