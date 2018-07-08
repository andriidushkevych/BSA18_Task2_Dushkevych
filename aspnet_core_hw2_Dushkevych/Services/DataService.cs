using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using aspnet_core_hw2_Dushkevych.Models;

namespace aspnet_core_hw2_Dushkevych.Services
{
    enum DataType { User, Post, Comment, Todo, Address };

    public class DataService
    {
        private static List<User> users;
        private static List<Post> posts;
        private static List<Todo> todos;
        private static List<Comment> comments;
        private static List<Address> addresses;
        private string[] dataSources = new string[] {   "https://5b128555d50a5c0014ef1204.mockapi.io/users",
                                                        "https://5b128555d50a5c0014ef1204.mockapi.io/posts",
                                                        "https://5b128555d50a5c0014ef1204.mockapi.io/comments",
                                                        "https://5b128555d50a5c0014ef1204.mockapi.io/todos",
                                                        "https://5b128555d50a5c0014ef1204.mockapi.io/address"};
        public DataService()
        {
            users = users ?? GetUsersFromServer();
            posts = posts ?? GetPostsFromServer();
            todos = todos ?? GetTodosFromServer();
            comments = comments ?? GetCommentsFromServer();
            addresses = addresses ?? GetAddressesFromServer();
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public List<Post> GetPosts()
        {
            return posts;
        }

        public List<Todo> GetTodos()
        {
            return todos;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }

        public User GetUserById(int id)
        {
            return users.Where(u => u.Id == id).FirstOrDefault();
        }

        public Post GetPostById(int id)
        {
            return posts.Where(p => p.Id == id).FirstOrDefault();
        }

        public Todo GetTodoById(int id)
        {
            return todos.Where(t => t.Id == id).FirstOrDefault();
        }

        public List<Post> GetUserPosts(int userId)
        {
            return posts.Where(p => p.UserId == userId).ToList();
        }

        public List<Todo> GetUserTodos(int userId)
        {
            return todos.Where(t => t.UserId == userId).ToList();
        }

        public Address GetUserAddress(int userId)
        {
            return addresses.Where(a => a.UserId == userId).FirstOrDefault();
        }

        public string GetUserNameById(int userId)
        {
            return users.Where(u => u.Id == userId).FirstOrDefault().Name;
        }

        public List<Comment> GetPostComments(int postId)
        {
            return comments.Where(c => c.PostId == postId).ToList();
        }

        public Comment GetCommentById(int id)
        {
            return comments.Where(c => c.Id == id).FirstOrDefault();
        }

        private List<User> GetUsersFromServer()
        {
            List<User> userList;
            string url = dataSources[(int)DataType.User];
            HttpResponseMessage response = GetHttpResponseMessage(url);
            userList = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
            return userList;
        }

        private List<Post> GetPostsFromServer()
        {
            List<Post> postList;
            string url = dataSources[(int)DataType.Post];
            HttpResponseMessage response = GetHttpResponseMessage(url);
            postList = JsonConvert.DeserializeObject<List<Post>>(response.Content.ReadAsStringAsync().Result);
            return postList;
        }

        private List<Comment> GetCommentsFromServer()
        {
            List<Comment> commentList;
            string url = dataSources[(int)DataType.Comment];
            HttpResponseMessage response = GetHttpResponseMessage(url);
            commentList = JsonConvert.DeserializeObject<List<Comment>>(response.Content.ReadAsStringAsync().Result);
            return commentList;
        }

        private List<Todo> GetTodosFromServer()
        {
            List<Todo> todoList;
            string url = dataSources[(int)DataType.Todo];
            HttpResponseMessage response = GetHttpResponseMessage(url);
            todoList = JsonConvert.DeserializeObject<List<Todo>>(response.Content.ReadAsStringAsync().Result);
            return todoList;
        }

        private List<Address> GetAddressesFromServer()
        {
            List<Address> addressList;
            string url = dataSources[(int)DataType.Address];
            HttpResponseMessage response = GetHttpResponseMessage(url);
            addressList = JsonConvert.DeserializeObject<List<Address>>(response.Content.ReadAsStringAsync().Result);
            return addressList;
        }

        private HttpResponseMessage GetHttpResponseMessage(string url)
        {
            HttpResponseMessage response;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync(url).Result;
            }
            return response;
        }
    }
}
