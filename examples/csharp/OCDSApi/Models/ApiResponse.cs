using System.Collections.Generic;

namespace OCDSApi.Models
{
    public class ApiResponse
    {
        public List<Release> releases { get; set; }
        public List<Error> errors { get; set; }
    }
}