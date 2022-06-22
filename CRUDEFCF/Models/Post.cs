using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDEFCF.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}