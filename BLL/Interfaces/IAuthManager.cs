using MMS.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.BLL.Interfaces
{
    public interface IAuthManager
    {

        Task<bool> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task<string> Refresh(RefreshModel refreshModel);
    }
}
