using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet_core_hw2_Dushkevych.Models;
using aspnet_core_hw2_Dushkevych.Services;

namespace aspnet_core_hw2_Dushkevych.Controllers
{
    public class UserController : Controller
    {
        private DataService dataService;
        public UserController()
        {
            dataService = new DataService();
        }

        public IActionResult Index(int id)
        {
            User user = dataService.GetUserById(id);
            user.Address = dataService.GetUserAddress(user.Id);
            return View(user);
        }
    }
}