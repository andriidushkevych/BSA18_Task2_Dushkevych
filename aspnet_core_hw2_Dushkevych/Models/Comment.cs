using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_hw2_Dushkevych.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CreatedAt { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int Likes { get; set; }
    }
}
