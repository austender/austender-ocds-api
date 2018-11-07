using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class ContractGroup
    {
        public TotalContractGroupPeriod totalContractGroupPeriod { get; set; }
        public double totalContractGroupValue { get; set; }
        public List<string> relatedCN { get; set; }
    }
}