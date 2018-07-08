using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet_core_hw2_Dushkevych.Models;
using aspnet_core_hw2_Dushkevych.Services;

namespace aspnet_core_hw2_Dushkevych.Controllers
{
    public class PostController : Controller
    {
        private DataService dataService;
        private List<Post> posts;
        public PostController()
        {
            dataService = new DataService();
        }

        public IActionResult Index()
        {
            posts = dataService.GetPosts();
            foreach (var post in posts)
            {
                post.Username = dataService.GetUserNameById(post.UserId);
                post.Comments = dataService.GetPostComments(post.Id);
            }
            return View(posts);
        }

        public IActionResult PostDetails(int id)
        {
            var post = dataService.GetPostById(id);
            post.Username = dataService.GetUserNameById(post.UserId);
            return View(post);
        }
    }
}