using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace malevaNewsV2.Dtos.Post
{
    public class PostDto
    {
        public string title { get; set; } = "";
        public string body { get; set; } = "";
        public string author { get; set; } = "" ;
        public DateTime date { get; set; }
        public string image { get; set; } = "";
    }
}