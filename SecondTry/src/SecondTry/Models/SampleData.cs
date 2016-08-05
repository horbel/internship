using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SecondTry.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<BloggingContext>();
            if (!context.Blogs.Any())
            {
                context.AddRange(
                    new Blog
                    {
                        Url = "FirstUrl"
                    },
                    new Blog
                    {
                        Url = "SecondUrl"
                    },
                    new Blog
                    {
                        Url = "ThirdUrl"
                    },
                    new Blog
                    {
                        Url = "FourthUrl"
                    }
                );
            }

            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post
                    {                        
                        BlogId = 1,
                        Content = "some context 1",
                        Title = "the first post"
                    },
                    new Post
                    {
                        BlogId = 1,
                        Content = "some content 2",
                        Title = "the second post of 1 blog"
                    },
                    new Post
                    {
                        BlogId = 2,
                         Content = "some contetnty 3",
                         Title = "the first post of blog 2"
                    },
                    new Post
                    {
                        BlogId  = 3,
                        Content = "spome contetn 4",
                        Title = "the first post of blog 3"
                    },
                    new Post
                    {
                        BlogId = 3,
                        Content = "spome contetn 5",
                        Title = "the second post of blog 3"
                    },
                    new Post
                    {
                        BlogId = 3,
                        Content = "spome contetn 6",
                        Title = "the third post of blog 3"
                    }
                    );
            }
            context.SaveChanges();
        }
    }
}
