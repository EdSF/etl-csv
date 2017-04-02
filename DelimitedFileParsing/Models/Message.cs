using System;

namespace DelimitedFileParsing.Models
{
    public class Message : BaseData, IBuilder
    {
        public string MessageStatus { get; set; }
        public string MessageText { get; set; }

        

        public void MapFields(string[] parsedStrings)
        {
            var fcount = FieldCount();
            if (parsedStrings?.Length != fcount)
                throw new ArgumentException(nameof(parsedStrings), $"Parsed string count {parsedStrings?.Length} must match property count: {fcount}");


            FileDesignation = parsedStrings[0];
            MessageStatus = parsedStrings[1];
            MessageText = parsedStrings[2];
        }

        
    }


}
