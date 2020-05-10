using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPostService
    {
        List<Post> getAll();
        Post get(string id);
        bool Update(Post postToUpdate); 
        bool Delete (string id);
        bool Create(Post post);
    }
}