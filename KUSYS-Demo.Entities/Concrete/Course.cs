using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Entities.Concrete
{
    public class Course
    {
        public string? CourseId { get; set; }
        public string? CourseName { get; set; }

        [NotMapped]
        public IList<StudentCourse>? StudentCourses { get; set; }
    }
}
