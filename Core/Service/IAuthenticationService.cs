using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAuthenticationService
    {
        public Task<string> Auth_jwt(AUTH auth);
    }
}
