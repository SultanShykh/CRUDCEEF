using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUDEFCF.Models
{
    [Table("StudentInfo")]
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        public virtual ICollection<Course> Courses { get; set; }

        [Key]
        public int Id { get; set; }

        [Column("Name", TypeName = "nvarchar")]
        [MaxLength(20)]
        public string StudentName { get; set; }

        [NotMapped]
        public int? Age { get; set; }

        [ForeignKey("OnlineTeacher")]
        public int? OnlineTeacherId { get; set; }
        public Teacher OnlineTeacher { get; set; }

        [ForeignKey("ClassRoomTeacher")]
        public int? ClassRoomTeacherId { get; set; }
        public Teacher ClassRoomTeacher { get; set; }

    }
}