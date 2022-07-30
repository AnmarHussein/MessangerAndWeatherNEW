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
    public class OthersRepoisitory : IOthersRepoisitory
    {
        private readonly IDBContext _context;
        public OthersRepoisitory(IDBContext context)
        {
            _context = context;
        }

        public async Task<List<SEALESYEAR>> GetSealesYear()
        {
            try
            {
                IEnumerable<SEALESYEAR> resualt = await _context.dbConnection.QueryAsync<SEALESYEAR>("OTHERS_PACKAGE.ServiceItem_GetSealesYear", commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<LIKEINPOST>> GETLIKEALL()
        {
            try
            {
                IEnumerable<LIKEINPOST> resualt = await _context.dbConnection.QueryAsync<LIKEINPOST>("OTHERS_PACKAGE.POST_GETLIKEALL", commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<USER1INPOST>> GETUSERPOSTS()
        {
            try
            {
                IEnumerable<USER1INPOST> resualt = await _context.dbConnection.QueryAsync<USER1INPOST>("OTHERS_PACKAGE.POST_GETUSERPOSTS", commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<CityNumberOfUser>> GetCityNumberOfUser1()
        {
            try
            {
                IEnumerable<CityNumberOfUser> resualt = await _context.dbConnection.QueryAsync<CityNumberOfUser>("OTHERS_PACKAGE.User1_GetALLCityNumberUSer1", commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TotalVisaEachUser1>> TotalVisaUser1()
        {
            try
            {
                IEnumerable<TotalVisaEachUser1> resualt = await _context.dbConnection.QueryAsync<TotalVisaEachUser1>("OTHERS_PACKAGE.User1_GetTotalVisaEachUser1", commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ApprovedFrindReguest(int firndID)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("P_ID", firndID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var resualt = await _context.dbConnection.ExecuteAsync("OTHERS_PACKAGE.ApprovedFrindReguest", parameters, commandType: CommandType.StoredProcedure);
                return (resualt > 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> BlockFrind(int firndID)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("P_ID", firndID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var resualt = await _context.dbConnection.ExecuteAsync("OTHERS_PACKAGE.BlockFrind", parameters, commandType: CommandType.StoredProcedure);
                return (resualt > 0);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<FriendRequest>> GetAllFrindByUser(int userId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("P_USER_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                IEnumerable<FriendRequest> resualt = await _context.dbConnection.QueryAsync<FriendRequest>("OTHERS_PACKAGE.GetAllFrindByUser", parameters, commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<FriendRequest>> GetAllRequesFrindByUser(int userId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("P_USER_ID", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                IEnumerable<FriendRequest> resualt = await _context.dbConnection.QueryAsync<FriendRequest>("OTHERS_PACKAGE.GetAllRequesFrindByUser", parameters, commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<FRINEDEMAIL> GetEmailBlockFrind(int firndID)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("P_ID", firndID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                IEnumerable<FRINEDEMAIL> resualt = await _context.dbConnection.QueryAsync<FRINEDEMAIL>("OTHERS_PACKAGE.GetEmailBlockFrind", parameters, commandType: CommandType.StoredProcedure);
                return resualt.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetAllMessagebyUser>> getAllMessagebyUsers(string userName)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("P_USERNAME", userName, dbType: DbType.String, direction: ParameterDirection.Input);
                IEnumerable<GetAllMessagebyUser> resualt = await _context.dbConnection.QueryAsync<GetAllMessagebyUser>("OTHERS_PACKAGE.GetAllMessagebyUser", parameters, commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<GetAllMessageByGroubUser1>> GetAllMessageByGroubUser1()
        {
            try
            {
                IEnumerable<GetAllMessageByGroubUser1> resualt = await _context.dbConnection.QueryAsync<GetAllMessageByGroubUser1>("OTHERS_PACKAGE.GetAllMessageByGroubUser1", commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<GetAllMessageCountbyAllUser>> GetAllMessageCountbyAllUser()
        {
            try
            {
                IEnumerable<GetAllMessageCountbyAllUser> resualt = await _context.dbConnection.QueryAsync<GetAllMessageCountbyAllUser>("OTHERS_PACKAGE.GetAllMessageCountbyAllUser", commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GetAllMessageCountbyAllGroup>> GetAllMessageCountbyAllGroup()
        {
            try
            {
                IEnumerable<GetAllMessageCountbyAllGroup> resualt = await _context.dbConnection.QueryAsync<GetAllMessageCountbyAllGroup>("OTHERS_PACKAGE.GetAllMessageCountbyAllGroup", commandType: CommandType.StoredProcedure);
                return resualt.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
