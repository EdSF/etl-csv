using System;

namespace DelimitedFileParsing.Models
{
    /// <summary>
    /// <note>Integers representing monetary values are in cents</note>
    /// </summary>
    public class TransactionData : BaseData, IBuilder
    {
        public int TotalQuantityOrdered { get; set; }
        public int TotalQuantityShipped { get; set; }
        public int TotalbackorderQuantity { get; set; }
        public int TotalnumberOfPackages { get; set; }
        public int TotalQuantityReturned { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int TotalDiscountAmount { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int TotalPromotionalAmount { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int StoreCreditAmount { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int TotalAdjustmentsAmount { get; set; }


        public string AuthorizationCode { get; set; }
        public string TransactionId { get; set; }
        public string ShippingCarrierCode { get; set; }
        public string ShippingCarrierTrackingNumber { get; set; }
        public int ShippingClass { get; set; }
        public DateTime ShipDate { get; set; }
        public string DeliveryInstructions { get; set; }
        public string TransactionNotes { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int TransactionSubTotal { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int TransactionSalesTax { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int TransactionCustomsDuties { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int TransactionShippingCost { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int TransactionGrandTotal { get; set; }

        public void MapFields(string[] parsedStrings)
        {
            var fcount = FieldCount();
            if (parsedStrings?.Length != fcount)
                throw new ArgumentException(nameof(parsedStrings), $"Parsed string count {parsedStrings?.Length} must match property count: {fcount}");


            FileDesignation = parsedStrings[0];

            int qtyCount;
            if (int.TryParse(parsedStrings[1], out qtyCount))
                TotalQuantityOrdered = qtyCount;

            int qtyShipped;
            if (int.TryParse(parsedStrings[2], out qtyShipped))
                TotalQuantityShipped = qtyShipped;

            int qtyBackorder;
            if (int.TryParse(parsedStrings[3], out qtyBackorder))
                TotalbackorderQuantity = qtyBackorder;

            int qtyPackages;
            if (int.TryParse(parsedStrings[4], out qtyPackages))
                TotalnumberOfPackages = qtyPackages;

            int qtyRefunded;
            if (int.TryParse(parsedStrings[5], out qtyRefunded))
                TotalQuantityReturned = qtyRefunded;

            int discAmt;
            if (int.TryParse(parsedStrings[6], out discAmt))
                TotalDiscountAmount = discAmt;

            int refundAmt;
            if (int.TryParse(parsedStrings[7], out refundAmt))
                TotalPromotionalAmount = refundAmt;

            int creditAmt;
            if (int.TryParse(parsedStrings[8], out creditAmt))
                StoreCreditAmount = creditAmt;

            int adjAmt;
            if (int.TryParse(parsedStrings[9], out adjAmt))
                TotalAdjustmentsAmount = adjAmt;

            AuthorizationCode = parsedStrings[10];
            TransactionId = parsedStrings[11];
            ShippingCarrierCode = parsedStrings[12];
            ShippingCarrierTrackingNumber = parsedStrings[13];

            int shipClass;
            if (int.TryParse(parsedStrings[14], out shipClass))
                ShippingClass = shipClass;

            DateTime shipDate;
            if (DateTime.TryParse(parsedStrings[15], out shipDate))
                ShipDate = shipDate;

            DeliveryInstructions = parsedStrings[16];
            TransactionNotes = parsedStrings[17];

            int subTotalAmt;
            if (int.TryParse(parsedStrings[18], out subTotalAmt))
                TransactionSubTotal = subTotalAmt;

            int salesTaxAmt;
            if (int.TryParse(parsedStrings[19], out salesTaxAmt))
                TransactionSalesTax = salesTaxAmt;

            int customsTaxAmt;
            if (int.TryParse(parsedStrings[20], out customsTaxAmt))
                TransactionCustomsDuties = customsTaxAmt;

            int shipCostAmt;
            if (int.TryParse(parsedStrings[21], out shipCostAmt))
                TransactionShippingCost = shipCostAmt;

            int grandTotalAmt;
            if (int.TryParse(parsedStrings[22], out grandTotalAmt))
                TransactionGrandTotal = grandTotalAmt;

        }
    }

}
