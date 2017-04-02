using System;
using System.Collections.Generic;

namespace DelimitedFileParsing.Models
{
    public class BatchFile : BaseData, IBuilder
    {
        public DateTime BatchDate { get; set; }
        public string SortOrder { get; set; }
        public List<Order> Orders { get; set; }
        public Eof Eof { get; set; }


        public void MapFields(string[] parsedStrings)
        {
            var fcount = FieldCount();
            if (parsedStrings?.Length != fcount)
                throw new ArgumentException(nameof(parsedStrings), $"Parsed string count {parsedStrings?.Length} match property count: {fcount}");


            FileDesignation = parsedStrings[0];
            DateTime batch;
            if (DateTime.TryParse(parsedStrings[1], out batch))
                BatchDate = batch;
            SortOrder = parsedStrings[2];
        }

        public override int FieldCount()
        {
            return 3;
        }
    }

}
