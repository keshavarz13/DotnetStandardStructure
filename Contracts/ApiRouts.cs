using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication1.Contracts
{
    public static class ApiRouts
    {
        public const string root = "api";
        public const string version = "v1";
        public const string baseUrl = root + "/" + version;
        
        public static class Post
        {
            public const string GetAll = baseUrl + "/" + "posts";
            public const string Create = baseUrl + "/" + "posts";
            public const string Get = baseUrl + "/" + "posts/{postId}";
        }
    }
}