using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class Amendment
    {
        public string id { get; set; }
        public string cnid { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public string rationale { get; set; }
        public string startdate { get; set; }
        public double contractamendmentvalue { get; set; }
        public double amendedvalue { get; set; }
    }
}