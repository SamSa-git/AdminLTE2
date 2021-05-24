using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AdminLTE.Modelss
{
    public partial class Course
    {
        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
