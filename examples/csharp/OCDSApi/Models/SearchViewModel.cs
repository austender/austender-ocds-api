

using System.ComponentModel.DataAnnotations;

namespace OCDSApi.Models
{
    public class SearchViewModel
    {
        [Display(Name = "CN ID")]
        public string CnId { get; set; }

        [Display(Name = "Date Range")]
        public string DataStart { get; set; }

        public bool DateEnd { get; set; }
    }
}
