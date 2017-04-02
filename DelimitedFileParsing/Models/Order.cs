using System;
using System.Collections.Generic;

namespace DelimitedFileParsing.Models
{
    public class Order : BaseData, IBuilder
    {
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderShipDate { get; set; }
        public string ShipBatch { get; set; }
        public string SalesPerson { get; set; }
        public string SalesGroupId { get; set; }
        public string OrderNotes { get; set; }
        public Billinginfo BillingInfo { get; set; }
        public Shippinginfo ShippingInfo { get; set; }
        public Message OrderMessage { get; set; }
        public List<OrderItem> OrderLineItems { get; set; }
        public TransactionData TransactionData { get; set; }

        public void MapFields(string[] parsedStrings)
        {
            var fcount = FieldCount();
            if (parsedStrings?.Length != fcount)
                throw new ArgumentException(nameof(parsedStrings), $"Parsed string count {parsedStrings?.Length} must match property count: {fcount}");


            FileDesignation = parsedStrings[0];
            OrderStatus = parsedStrings[1];
            DateTime ordDate;
            if (DateTime.TryParse(parsedStrings[2], out ordDate))
                OrderDate = ordDate;
            OrderNumber = parsedStrings[3];
            DateTime shipDate;
            if (DateTime.TryParse(parsedStrings[4], out shipDate))
                OrderShipDate = shipDate;
            ShipBatch = parsedStrings[5];
            SalesPerson = parsedStrings[6];
            SalesGroupId = parsedStrings[7];
            OrderNotes = parsedStrings[8];
        }

        public override int FieldCount()
        {
            return 9;
        }
    }

}
