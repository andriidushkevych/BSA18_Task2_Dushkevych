using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet_core_hw2_Dushkevych.Models;
using aspnet_core_hw2_Dushkevych.Services;

namespace aspnet_core_hw2_Dushkevych.Controllers
{
    public class TodoController : Controller
    {
        private DataService dataService;
        private List<Todo> todos;
        public TodoController()
        {
            dataService = new DataService();
        }

        public IActionResult Index()
        {
            todos = dataService.GetTodos();
            foreach(var todo in todos)
            {
                todo.Username = dataService.GetUserNameById(todo.UserId);
            }
            return View(todos);
        }

        public IActionResult TodoDetails(int id)
        {
            var todo = dataService.GetTodoById(id);
            todo.Username = dataService.GetUserNameById(todo.UserId);
            return View(todo);
        }
    }
}