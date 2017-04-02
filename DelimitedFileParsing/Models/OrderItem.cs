using System;

namespace DelimitedFileParsing.Models
{
    public class OrderItem : BaseData, IBuilder
    {
        public string ProductId { get; set; }
        public string LineSequence { get; set; }
        public string Sku { get; set; }
        public int QtyOrdered { get; set; }
        public int QuantityShipped { get; set; }
        public int ItemLength { get; set; }
        public int ItemWidth { get; set; }
        public int ItemHeight { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// In cents
        /// </summary>
        public int ExtendedPrice { get; set; }

        public string AlternateProductId { get; set; }
        public string WarehousCode { get; set; }

        /// <summary>
        /// in cents
        /// </summary>
        public int DiscountAmount { get; set; }

        /// <summary>
        /// in cents
        /// </summary>
        public int PromotionalAmount { get; set; }


        public void MapFields(string[] parsedStrings)
        {
            var fcount = FieldCount();
            if (parsedStrings?.Length != fcount)
                throw new ArgumentException(nameof(parsedStrings), $"Parsed string count {parsedStrings?.Length} must match property count: {fcount}");


            FileDesignation = parsedStrings[0];
            ProductId = parsedStrings[1];
            LineSequence = parsedStrings[2];
            Sku = parsedStrings[3];

            int qtyOrdered;
            if (int.TryParse(parsedStrings[4], out qtyOrdered))
                QtyOrdered = qtyOrdered;

            int qtyShipped;
            if (int.TryParse(parsedStrings[5], out qtyShipped))
                QuantityShipped = qtyShipped;

            int length;
            if (int.TryParse(parsedStrings[6], out length))
                ItemLength = length;

            int width;
            if (int.TryParse(parsedStrings[7], out width))
                ItemWidth = width;

            int height;
            if (int.TryParse(parsedStrings[8], out height))
                ItemHeight = height;

            int unitPriceAmt;
            if (int.TryParse(parsedStrings[9], out unitPriceAmt))
                UnitPrice = unitPriceAmt;

            int extPriceAmt;
            if (int.TryParse(parsedStrings[10], out extPriceAmt))
                ExtendedPrice = extPriceAmt;

            AlternateProductId = parsedStrings[11];
            WarehousCode = parsedStrings[12];

            int discAmt;
            if (int.TryParse(parsedStrings[13], out discAmt))
                DiscountAmount = discAmt;

            int promoAmt;
            if (int.TryParse(parsedStrings[14], out promoAmt))
                PromotionalAmount = promoAmt;
        }

    }

}
