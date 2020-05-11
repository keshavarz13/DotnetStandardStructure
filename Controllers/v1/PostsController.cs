using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts;
using WebApplication1.Contracts.Requests;
using WebApplication1.Contracts.Responses;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers.v1
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRouts.Post.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return  Ok(await _postService.getAllAsync());
        }

        [HttpGet(ApiRouts.Post.Get)]
        public async Task<IActionResult> Get([FromRoute] string postId)
        {
            var post = await _postService.getAsync(postId);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPut(ApiRouts.Post.Update)]
        public async Task<IActionResult> Update([FromRoute] string postId, [FromBody] UpdatePostRequest postRequest)
        {
            Post realPost = new Post() {Id = postRequest.Id , Name = postRequest.Name};
            var result = await _postService.UpdateAsync(realPost);
            if (result)
            {
                return Ok(postRequest);
            }

            return NotFound();
        }

        [HttpPost(ApiRouts.Post.Create)]
        public async Task<IActionResult> create([FromBody] CreatePostRequest post)
        {
            Post realPost = new Post() {Id = post.Id, Name = post.Name};

            var result = await _postService.CreateAsync(realPost);
            if (!result)
            {
                return BadRequest();
            }

            CreatePostResponse postResponse = new CreatePostResponse() {Id = post.Id};
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUrl + "/" + ApiRouts.Post.Get.Replace("{postId}", post.Id);
            return Created(location, postResponse);
        }

        [HttpDelete(ApiRouts.Post.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string postId)
        {
            var result = await _postService.DeleteAsync(postId);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}