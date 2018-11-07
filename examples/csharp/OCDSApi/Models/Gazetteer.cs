using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class Gazetteer
    {
        public string scheme { get; set; }
        public List<string> Identifiers { get; set; }
    }
}