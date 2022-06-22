using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDEFCF.Models
{
    public class BlogPostDBInitializer: DropCreateDatabaseAlways<BlogDBContext]>
    {
        protected override void Seed(BlogDBContext context)
        {
            List<User> users = new List<User>();
            users.Add(new User() { Name = "sultan", Email = "sultan.xmarty@gmail.com" });
            users.Add(new User() { Name = "raven", Email = "raven.xmarty@gmail.com" });
            context.Users.AddRange(users);

            List<Post> posts = new List<Post>();
            posts.Add(new Post() { Title = "First Post", Body = "Hello World", UserId = 1, DatePublished = DateTime.Now });
            context.Posts.AddRange(posts);

            base.Seed(context);
        }
    }
}