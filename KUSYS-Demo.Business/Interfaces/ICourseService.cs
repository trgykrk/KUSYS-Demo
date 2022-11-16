using KUSYS_Demo.Dtos.CourseDtos;
using KUSYS_Demo.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Interfaces
{
    public interface ICourseService
    {
        Task<List<CourseListDtos>> GetDataAll();
    }
}
