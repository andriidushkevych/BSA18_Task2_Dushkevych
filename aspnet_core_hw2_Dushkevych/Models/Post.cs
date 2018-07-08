using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_hw2_Dushkevych.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string CreatedAt { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int Likes { get; set; }
        public List<Comment> Comments { get; set; }
        public string Username { get; set; }
    }
}
