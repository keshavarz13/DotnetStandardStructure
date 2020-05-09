using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication1.contracts
{
    public static class ApiRouts
    {
        public const string root = "api";
        public const string version = "v1";
        public const string baseUrl = root + "/" + version;
        
        public static class Post
        {
            public const string getAll = baseUrl + "/" + "posts";
            //public static readonly string get = $"{baseUrl}/posts/";
            //public static readonly string post = $"{baseUrl}/posts";
        }
    }
}