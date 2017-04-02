namespace DelimitedFileParsing.Models
{
    public interface IBuilder
    {
        /// <summary>
        /// Map csv data
        /// </summary>
        /// <param name="parsedStrings">Parsed string array</param>
        void MapFields(string[] parsedStrings);
        
        int FieldCount();
    }
}
