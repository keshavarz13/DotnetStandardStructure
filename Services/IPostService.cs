using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPostService
    {
        List<Post> getAll();
        Post get(string id); 
    }
}