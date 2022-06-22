using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUDEFCF.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }

        [InverseProperty("OnlineTeacher")]
        public ICollection<Student> OnlineStudents { get; set; }

        [InverseProperty("ClassRoomTeacher")]
        public ICollection<Student> ClassRoomStudents { get; set; }

    }
}