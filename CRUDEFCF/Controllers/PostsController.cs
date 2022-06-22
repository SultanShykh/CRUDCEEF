using CRUDEFCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDEFCF.Controllers
{
    public class PostsController : Controller
    {
        public ActionResult Index()
        {
            List<Post> cs = new BlogDBContext().Posts.ToList();

            return View(cs);
        }
        public ActionResult Details(int Id)
        {
            Post cs = new BlogDBContext().Posts.Where(x => x.Id == Id).FirstOrDefault();

            return View(cs);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Post posts)
        {
            var context = new BlogDBContext();

            Post post = new Post()
            {
                DatePublished = DateTime.Now,
                Title = posts.Title,
                Body = posts.Body
            };

            context.Posts.Add(post);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            Post cs = new BlogDBContext().Posts.Where(x => x.Id == Id).FirstOrDefault();

            return View(cs);
        }

        [HttpPost]
        public ActionResult Edit(Post model)
        {
            var context = new BlogDBContext();

            Post data = context.Posts.Where(x => x.Id == model.Id).FirstOrDefault();

            if (data != null)
            {
                data.Title = model.Title;
                data.Body = model.Body;
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            var context = new BlogDBContext();

            Post data = context.Posts.Where(x => x.Id == Id).FirstOrDefault();
            context.Posts.Remove(data);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}