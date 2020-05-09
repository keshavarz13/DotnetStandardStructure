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
                _posts.Add(new Post(){Id = Guid.NewGuid().ToString()});
            }  
        }
        
        public List<Post> getAll()
        {
            return (_posts);
        }

        public Post get(string id)
        {
            return (_posts.SingleOrDefault(x => x.Id == id));
        }
    }
}