using KUSYS_Demo.Business.Interfaces;
using KUSYS_Demo.DataAccess.UnitOfWork;
using KUSYS_Demo.Dtos.StudentDtos;
using KUSYS_Demo.Dtos.UserDtos;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Services
{
    public class UserService  : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> GetByUsernameAndPassword(string username, string password)
        {
          return await _unitOfWork.GetRepository<User>().GetByFilter(x => x.UserName == username && x.Password == password);
        }
    }
}
