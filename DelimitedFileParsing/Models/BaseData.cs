using Newtonsoft.Json;

namespace DelimitedFileParsing.Models
{
    public class BaseData
    {
        /// <summary>
        /// Optional. <c>JsonProperty Order</c> controls serialization order
        /// </summary>
        [JsonProperty(Order = -2)]
        public string FileDesignation { get; set; }
        public virtual int FieldCount()
        {
            return GetType().GetProperties().Length;
        }
    }
}
