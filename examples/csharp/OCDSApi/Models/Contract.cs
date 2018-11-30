using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class Contract
    {
        public string id { get; set; }
        public string type { get; set; }
        public string awardId { get; set; }

        public string dateSigned { get; set; }

        public string description { get; set; }

        public string status { get; set; }
        public string procurementMethod { get; set; }
        public string procurementMethodDetails { get; set; }

        public Period period { get; set; }
        public Value value { get; set; }
        public List<Item> items { get; set; }
        public List<Amendment> amendments { get; set; }

    }
}