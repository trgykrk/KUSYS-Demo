using AutoMapper;
using KUSYS_Demo.Dtos.StudentCourseDtos;
using KUSYS_Demo.Entities.Concrete;

namespace KUSYS_Demo.Business.Mapping
{
    public class StudentCourseProfile : Profile
    {
        public StudentCourseProfile()
        {
            CreateMap<StudentCourse,StudentCourseDtos>().ReverseMap();
        }
    }
}
