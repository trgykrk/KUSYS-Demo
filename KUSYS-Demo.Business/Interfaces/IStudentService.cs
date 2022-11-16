using KUSYS_Demo.Dtos.StudentDtos;

namespace KUSYS_Demo.Business.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentListDtos>> GetDataAll();
        Task Create(StudentCreateDtos dto);
        Task<StudentListDtos> GetById(object id);
        Task Remove(object id);
        Task Update(StudentUpdateDtos dto);

    }
}
