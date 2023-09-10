using Cms.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Business.Services.Abstract
{
    public interface IUserService
    {
        void SendResetPasswordEmail(string email);

        UserDto GetById(int id);
        List<UserDto> GetAll();
        int GetAllNo();
        bool Update(int id,UserDto user);
        void Add(UserDto user);
        void Delete(int id);
    }
}
