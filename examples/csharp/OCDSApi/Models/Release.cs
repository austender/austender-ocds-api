using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class Release
    {
        public string language { get; set; }
        public string date { get; set; }
        public string ocid { get; set; }
        public string id { get; set; }
        public string initiationType { get; set; }
        public List<string> tag { get; set; }
        public List<Party> parties { get; set; }

        public List<Award> awards { get; set; }
        public List<Contract> contracts { get; set; }

    }
}