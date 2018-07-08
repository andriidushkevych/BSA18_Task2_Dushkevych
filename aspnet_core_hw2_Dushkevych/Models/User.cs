using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_hw2_Dushkevych.Models
{
    public class User
    {
        public int Id { get; set; }
        public string CreatedAt { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public List<Post> Posts { get; set; }
        public List<Todo> Todos { get; set; }
        public Address Address { get; set; }
    }
}
