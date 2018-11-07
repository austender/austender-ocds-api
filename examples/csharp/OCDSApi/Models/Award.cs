using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class Award
    {
        public object multiAgencyAccess { get; set; }
        public string id { get; set; }
        public string publishedDate { get; set; }
        public string CNUUID { get; set; }
        public string SONUUID { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string date { get; set; }
        public string evaluationCriteria { get; set; }
        public IndustrialRelationsDetails industrialRelationsDetails { get; set; }
        public Value value { get; set; }
        public string valueDescription { get; set; }
        public List<Supplier> suppliers { get; set; }
        public List<Item> items { get; set; }
        public ContractPeriod contractPeriod { get; set; }
        public string procurementMethod { get; set; }
        public string eTenderProcurementMethod { get; set; }
        public List<string> relatedRFT { get; set; }
        public List<string> relatedSON { get; set; }
        public string costBenefitAnalysis { get; set; }
        public string descriptionContractor { get; set; }
        public string descriptionRenegotiated { get; set; }
        public string descriptionServices { get; set; }
        public int exemptionsProvisions { get; set; }
        public string futureTransfersToContractor { get; set; }
        public string futureTransfersToState { get; set; }
        public string otherInformation { get; set; }
        public string otherKeyElements { get; set; }
        public string otherPrivateSector { get; set; }
        public string provisionsNotProvided { get; set; }
        public string publicSectorComparator { get; set; }
        public string publishIntention { get; set; }
        public string reasons { get; set; }
        public string summaryOfInfo { get; set; }
        public string risk { get; set; }
        public string significantGuarantee { get; set; }
        public ContractGroup contractGroup { get; set; }
    }
}