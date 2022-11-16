using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.DataAccess.UnitOfWork;
using KUSYS_Demo.Dtos.CourseDtos;
using KUSYS_Demo.Dtos.StudentDtos;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CourseListDtos>> GetDataAll()
        {
            var list = await _unitOfWork.GetRepository<Course>().GetDataAll();
            var courseList = new List<CourseListDtos>();
            if (list != null && list.Count > 0)
            {
                foreach (var course in list)
                {
                    courseList.Add(new()
                    {
                        CourseName = course.CourseName,
                    });
                }
            }
            return courseList;
        }
    }
}
