using KUSYS_Demo.Dtos.StudentDtos;
using KUSYS_Demo.Dtos.UserDtos;
using KUSYS_Demo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS_Demo.Business.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByUsernameAndPassword(string username, string password);
    }
}
