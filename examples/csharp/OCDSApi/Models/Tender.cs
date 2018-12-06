using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class Tender
    {
        public string id { get; set; }
        public string RFTUUID { get; set; }
        public List<string> relatedRFT { get; set; }
        public List<string> relatedCN { get; set; }
        public List<string> relatedSON { get; set; }
        public string title { get; set; }
        public string multiAgencyAccess { get; set; }
        public string multiAgencyAccessType { get; set; }
        public string description { get; set; }
        public string tenderType { get; set; }
        public string inheritanceType { get; set; }
        public string status { get; set; }
        public string eTenderStatus { get; set; }
        public string RFTAccess { get; set; }
        public DeliveryLocation deliveryLocation { get; set; }
        public List<Item> items { get; set; }
        public string PlannedProcurementUUID { get; set; }
        public MinValue minValue { get; set; }
        public Value value { get; set; }
        public HardCopyCost hardCopyCost { get; set; }
        public string hardCopyLink { get; set; }
        public SoftCopyCost softCopyCost { get; set; }
        public string softCopyLink { get; set; }
        public string procurementMethod { get; set; }
        public string eTenderProcurementMethod { get; set; }
        public List<string> submissionMethod { get; set; }
        public string submissionMethodDetails { get; set; }
        public string addressForLodgement { get; set; }
        public string lodgeResponse { get; set; }
        public string conditionsForParticipation { get; set; }
        public string timeframeDelivery { get; set; }
        public TenderPeriod tenderPeriod { get; set; }
        public List<Prequalification> prequalifications { get; set; }
        public List<string> capabilities { get; set; }
        public List<Questionnaire> questionnaires { get; set; }
        public int numberOfTenderers { get; set; }
        public List<Tenderer> tenderers { get; set; }
        public List<Document> documents { get; set; }
        public Amendments amendments { get; set; }
        public string estimatedDateToMarket { get; set; }
        public string procurementMethodDetails { get; set; }
    }
}