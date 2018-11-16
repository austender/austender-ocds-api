using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class Item
    {
        public string id { get; set; }
        public Classification classification { get; set; }
        public List<AdditionalClassification> additionalClassifications { get; set; }
    }
}