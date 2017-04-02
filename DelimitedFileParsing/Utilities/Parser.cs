using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace DelimitedFileParsing.Utilities
{
    public class Parser
    {
        public static IEnumerable<string[]> ParseFile(Stream dataStream, string delimiter)
        {
            if (dataStream == null)
                throw new ArgumentNullException(nameof(dataStream));

            using (var sr = new StreamReader(dataStream))
            {
                while (!sr.EndOfStream)
                {
                    var str = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(str))
                        continue;
                    var data = str.Replace("\"", "").Split(new[] { delimiter }, StringSplitOptions.None);
                    if (data.Length == 0)
                        continue;

                    yield return data;
                }
            }
        }

        /// <summary>
        /// Using VB TextFieldParser, to more reliably handle quoted fields in CSV, which could contain a comma (which is the csv delimiter) in <see cref="Models.Message.MessageText" />.
        /// <notes>Dependency on VB</notes>
        /// </summary>
        /// <param name="dataStream">Stream to process</param>
        /// <param name="delimeter">Text file delimeter - e.g. comma or tab character</param>
        /// <param name="isQuotedFields">Whether or not the CSV contains quoted fields</param>
        /// <returns></returns>
        public static IEnumerable<string[]> ParseFile(Stream dataStream, string delimeter, bool isQuotedFields)
        {
            if (dataStream == null)
                throw new ArgumentNullException(nameof(dataStream));

            using (var tfp = new TextFieldParser(dataStream) { Delimiters = new[] { delimeter }, HasFieldsEnclosedInQuotes = isQuotedFields})
            {
                while (!tfp.EndOfData)
                {
                    yield return tfp.ReadFields();
                }
            }
        }

    }
}
