using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUDEFCF.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public ICollection<Post> Posts { get; set; }

        [NotMapped]
        public string extra { get; set; }
    }
}