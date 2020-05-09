using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.contracts;
using WebApplication1.Models;

namespace WebApplication1.Controllers.v1
{
    public class PostsController : Controller
    {
        private List<Post> _posts;

        public PostsController()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5 ; i++)
            {
                _posts.Add(new Post(){Id = i.ToString()});
            }   
        }

        [HttpGet(ApiRouts.Post.getAll)]
        public IActionResult getAll()
        {
            return Ok(_posts);
        }
    }
}