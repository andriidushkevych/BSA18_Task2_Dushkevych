using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_hw2_Dushkevych.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string CreatedAt { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
