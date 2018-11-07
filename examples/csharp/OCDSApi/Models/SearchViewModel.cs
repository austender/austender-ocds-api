

using System.ComponentModel.DataAnnotations;

namespace OCDSApi.Models
{
    public class SearchViewModel
    {
        [Display(Name = "CN ID")]
        public string CnId { get; set; }

        public string DataStart { get; set; }

        public bool DateEnd { get; set; }
    }
}
