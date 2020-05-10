using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services.Imp
{
    public class PostService : IPostService
    {
        private List<Post> _posts;

        public PostService()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5 ; i++)
            {
                _posts.Add(new Post()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"Post {i}"
                });
            }  
        }
        
        public List<Post> getAll()
        {
            return (_posts);
        }

        public Post get(string id)
        {
            return ( _posts.SingleOrDefault(x => x.Id == id));
        }

        public bool Update(Post postToUpdate)
        {
            var post = _posts.FirstOrDefault(x => x.Id == postToUpdate.Id);
            if (post == null)
            {
                return false;
            }
            _posts[_posts.FindIndex(x => x.Id == postToUpdate.Id)] = postToUpdate;
            return true;
        }

        public bool Delete(string id)
        {
            var post = _posts.FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return false;
            }
            
            _posts.Remove(post);
            return true;
        }

        public bool Create(Post post)
        {
            var result = _posts.FirstOrDefault(x => x.Id == post.Id);
            if (result == null)
            {
             
                if (string.IsNullOrEmpty(post.Id))
                {
                    post.Id = Guid.NewGuid().ToString();
                }
                _posts.Add(post);
                return true;   
            }

            return false;
        }
    }
}