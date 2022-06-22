using CRUDEFCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDEFCF.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            var cs = new BlogDBContext().Users.ToList();

            return View(cs);
        }
        public ActionResult Details(int Id)
        {
            var cs = new BlogDBContext().Users.Where(x => x.Id == Id).FirstOrDefault();

            return View(cs);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User User)
        {
            var context = new BlogDBContext();

            var Users = new User()
            {
                CreatedDateTime = DateTime.Now,
                Name = User.Name,
                Email = User.Email
            };

            context.Users.Add(Users);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            var cs = new BlogDBContext().Users.Where(x => x.Id == Id).FirstOrDefault();

            return View(cs);
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            var context = new BlogDBContext();

            var data = context.Users.Where(x => x.Id == model.Id).FirstOrDefault();

            if (data != null)
            {
                data.Name = model.Name;
                data.Email = model.Email;
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            var context = new BlogDBContext();

            var data = context.Users.Where(x => x.Id == Id).FirstOrDefault();
            context.Users.Remove(data);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}