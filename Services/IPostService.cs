using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPostService
    {
        Task<List<Post>> getAllAsync();
        Task<Post> getAsync(string id);
        Task<bool> UpdateAsync(Post postToUpdate);
        Task<bool> DeleteAsync(string id);
        Task<bool> CreateAsync(Post post);
    }
}