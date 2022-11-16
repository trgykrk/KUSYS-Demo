using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.DataAccess.UnitOfWork;
using KUSYS_Demo.Dtos.StudentDtos;
using KUSYS_Demo.Entities.Concrete;

namespace KUSYS_Demo.Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Create(StudentCreateDtos dto)
        {
            await _unitOfWork.GetRepository<Student>().Create(new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
            });
            await _unitOfWork.SaveChanges();
        }

        public async Task<StudentListDtos> GetById(object id)
        {
            var student = await _unitOfWork.GetRepository<Student>().GetById(id);
            return new()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
            };
        }

        public async Task<List<StudentListDtos>> GetDataAll()
        {
            var list = await _unitOfWork.GetRepository<Student>().GetDataAll();
            var studentList = new List<StudentListDtos>();
            if (list != null && list.Count > 0)
            {
                foreach (var student in list)
                {
                    studentList.Add(new()
                    {
                        StudentId = student.StudentId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        BirthDate = student.BirthDate,
                    });
                }
            }
            return studentList;
        }

        public async Task Remove(object id)
        {
            var deletedStudent = await _unitOfWork.GetRepository<Student>().GetById(id);
            if (deletedStudent != null)
            {
                _unitOfWork.GetRepository<Student>().Delete(deletedStudent);
                await _unitOfWork.SaveChanges();
            }
        }

        public async Task Update(StudentUpdateDtos dto)
        {
            _unitOfWork.GetRepository<Student>().Update(new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
            });
            await _unitOfWork.SaveChanges();
        }
    }
}
