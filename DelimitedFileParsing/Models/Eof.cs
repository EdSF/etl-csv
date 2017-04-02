using System;

namespace DelimitedFileParsing.Models
{
    public class Eof : BaseData, IBuilder
    {
        public int TotalNumberOfOrders { get; set; }
        public int TotalOrderLineItems { get; set; }
        public int TotalNumberOfLinesInFile { get; set; }

        public void MapFields(string[] parsedStrings)
        {
            var fcount = FieldCount();
            if (parsedStrings?.Length != fcount)
                throw new ArgumentException(nameof(parsedStrings), $"Parsed string count {parsedStrings?.Length} match property count: {fcount}");


            FileDesignation = parsedStrings[0];
            int orderCount;
            if (int.TryParse(parsedStrings[1], out orderCount))
                TotalNumberOfOrders = orderCount;
            int lineItems;
            if (int.TryParse(parsedStrings[2], out lineItems))
                TotalOrderLineItems = lineItems;
            int lineTotal;
            if (int.TryParse(parsedStrings[3], out lineTotal))
                TotalNumberOfLinesInFile = lineTotal;
        }


    }
}
