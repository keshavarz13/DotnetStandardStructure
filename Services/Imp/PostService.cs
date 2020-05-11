using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services.Imp
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> getAllAsync()
        {
            return await _dataContext.Posts.ToListAsync();
        }

        public async Task<Post> getAsync(string id)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> UpdateAsync(Post postToUpdate)
        {
            _dataContext.Posts.Update(postToUpdate);
            var result = await _dataContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var post = await _dataContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
            {
                return false;
            }

            _dataContext.Posts.Remove(post);
            var result = await _dataContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> CreateAsync(Post post)
        {
            var result = await _dataContext.Posts.FirstOrDefaultAsync(x => x.Id == post.Id);
            if (result == null)
            {
                if (string.IsNullOrEmpty(post.Id))
                {
                    post.Id = Guid.NewGuid().ToString();
                }

                await _dataContext.Posts.AddAsync(post);
                await _dataContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}