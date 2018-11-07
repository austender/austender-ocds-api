using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class ApiResponse
    {
        public List<Release> Releases { get; set; }
        public List<Error> Errors { get; set; }
        public string PublishedDate { get; set; }
        public Publisher Publisher { get; set; }

    }
}