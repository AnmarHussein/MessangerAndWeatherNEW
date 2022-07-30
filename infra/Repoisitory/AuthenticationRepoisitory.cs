using Core.Domain;
using Core.DTO;
using Core.Repoisitory;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infra.Repoisitory
{
    public class AuthenticationRepoisitory : IAuthenticationRepoisitory
    {
        private readonly IDBContext _context;
        public AuthenticationRepoisitory(IDBContext context)
        {
            _context = context;
        }
        public async Task<AUTH> GetAuth(AUTH auth)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("username1", auth.USERNAME, dbType: DbType.String, direction: ParameterDirection.Input);
                parameter.Add("password1", auth.PASSWORD, dbType: DbType.String, direction: ParameterDirection.Input);

                IEnumerable<AUTH> result = await _context.dbConnection.QueryAsync<AUTH>("LOGIN_PACKAGE.Auth", parameter, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
