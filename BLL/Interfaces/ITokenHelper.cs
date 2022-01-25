using MMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MMS.BLL.Interfaces
{
    public interface ITokenHelper
    {

        Task<string> CreateAccessToken(User user);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string _token);

        string CreateRefreshToken();
    }
}
