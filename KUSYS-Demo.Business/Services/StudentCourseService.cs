using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.DataAccess.UnitOfWork;
using KUSYS_Demo.Dtos.CourseDtos;
using KUSYS_Demo.Dtos.StudentCourseDtos;
using KUSYS_Demo.Entities.Concrete;
using AutoMapper;
using KUSYS_Demo.Dtos.StudentDtos;


namespace KUSYS_Demo.Business.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentCourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<StudentCourseDtos> GetById(object id)
        {
            var studentCourse = await _unitOfWork.GetRepository<StudentCourse>().GetById(id);
            return new()
            {
                CourseName = studentCourse.Course.CourseName,
                StudentName = studentCourse.Students.FirstName,
            };
        }

        public async Task<StudentCourseDtos> GetByStudentCourse(object id)
        {
            var studentCourse = await _unitOfWork.GetRepository<StudentCourse>().GetById(id);
            return _mapper.Map<StudentCourseDtos>(studentCourse);
        }

        public async Task<List<StudentCourseDtos>> GetDataAll()
        {
            var list = await _unitOfWork.GetRepository<StudentCourse>().GetDataAll();
            var courseList = new List<StudentCourseDtos>();
            if (list != null && list.Count > 0)
            {
                foreach (var course in list)
                {
                    courseList.Add(new()
                    {
                        CourseName = course.Course.CourseName,
                        StudentName = course.Students.FirstName,
                    });
                }
            }
            return courseList;
        }
    }
}
