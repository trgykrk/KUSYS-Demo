using KUSYS_Demo.Dtos.CourseDtos;
using KUSYS_Demo.Dtos.StudentCourseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Interfaces
{
    public interface IStudentCourseService
    {
        Task<List<StudentCourseDtos>> GetDataAll();
        Task<StudentCourseDtos> GetByStudentCourse(object id);
    }
}
