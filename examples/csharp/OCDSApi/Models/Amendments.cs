using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class Amendments
    {
        public string date { get; set; }
        public List<Document> documents { get; set; }
        public string rationale { get; set; }
    }
}