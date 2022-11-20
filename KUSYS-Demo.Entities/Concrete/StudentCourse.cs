using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Entities.Concrete
{
    [Keyless]
    public class StudentCourse
    {
        [Key]
        public int StudentId { get; set; }
        public Student? Students { get; set; }

        public string? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
