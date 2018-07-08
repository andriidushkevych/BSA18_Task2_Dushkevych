using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet_core_hw2_Dushkevych.Models;
using aspnet_core_hw2_Dushkevych.Services;

namespace aspnet_core_hw2_Dushkevych.Controllers
{
    public class UsersController : Controller
    {
        private DataService dataService;
        private List<User> users;
        public UsersController()
        {
            dataService = new DataService();
        }

        public IActionResult Index()
        {
            users = dataService.GetUsers();
            foreach(User user in users)
            {
                user.Posts = dataService.GetUserPosts(user.Id);
                user.Todos = dataService.GetUserTodos(user.Id);
            }
            return View(users);
        }
    }
}