using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts;
using WebApplication1.Contracts.Requests;
using WebApplication1.Contracts.Responses;
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
                _posts.Add(new Post(){Id = Guid.NewGuid().ToString()});
            }   
        }

        [HttpGet(ApiRouts.Post.GetAll)]
        public IActionResult getAll()
        {
            return Ok(_posts);
        }
        
        [HttpPost(ApiRouts.Post.Create)]
        public IActionResult create([FromBody] CreatePostRequest post)
        {
            Post realPost = new Post() {Id = post.Id};
            
            if (string.IsNullOrEmpty(post.Id))
            {
                post.Id = Guid.NewGuid().ToString();
            }
            _posts.Add(realPost);
            
            CreatePostResponse postResponse = new CreatePostResponse(){Id = post.Id};
            
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUrl + "/" + ApiRouts.Post.Get.Replace("{postId}", post.Id);
            return Created(location , postResponse);
        }
    }
}