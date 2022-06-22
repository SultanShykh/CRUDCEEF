using CRUDEFCF.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDEFCF.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var cs = new BlogDBContext().Courses.ToList();

            return View(cs);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Course model)
        {
            var context = new BlogDBContext();

            Course course = new Course() 
            {
                CourseName = model.CourseName
            };

            SqlParameter CName = new SqlParameter("@CourseName", model.CourseName);
            int ss = context.Database.ExecuteSqlCommand("Course_Insert @CourseName", CName);

            return RedirectToAction("Index");
        }
    }
}