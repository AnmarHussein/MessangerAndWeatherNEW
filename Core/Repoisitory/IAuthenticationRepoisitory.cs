using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repoisitory
{
    public interface IAuthenticationRepoisitory
    {
        public Task<AUTH> GetAuth(AUTH auth);
    }
}
