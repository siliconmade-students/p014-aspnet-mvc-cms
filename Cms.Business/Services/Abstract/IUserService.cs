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
    }
}
