using Core.DTO;
using Core.Repoisitory;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace infra.Service
{
    public class OthersService : IOthersService
    {
        private readonly IOthersRepoisitory _othersRepoisitory;
        public OthersService(IOthersRepoisitory othersRepoisitory)
        {
            _othersRepoisitory = othersRepoisitory;
        }
        public async Task<List<SEALESYEAR>> GetSealesYear()
        {
            return await _othersRepoisitory.GetSealesYear();
        }
        public async Task<List<LIKEINPOST>> GETLIKEALL()
        {
            return await _othersRepoisitory.GETLIKEALL();
        }

        public async Task<List<USER1INPOST>> GETUSERPOSTS()
        {
            return await _othersRepoisitory.GETUSERPOSTS();
        }
        public async Task<List<CityNumberOfUser>> GetCityNumberOfUser1()
        {
            return await _othersRepoisitory.GetCityNumberOfUser1();
        }
        public async Task<List<TotalVisaEachUser1>> TotalVisaUser1()
        {
            return await _othersRepoisitory.TotalVisaUser1();
        }

        public async Task<string> ApprovedFrindReguest(int firndID)
        {
            if (!await _othersRepoisitory.ApprovedFrindReguest(firndID))
                return "1 Row Aproved ^_^! ";

            return "0 Row Aproved ^_^! ";
        }

        public async Task<string> BlockFrind(int firndID)
        {
            if (!await _othersRepoisitory.BlockFrind(firndID))
                return "1 Row Blocked -_-! ";

            return "0 Row Blocked -_-! ";
        }
        public async Task<List<FriendRequest>> GetAllFrindByUser(int userId)
        {
            return await _othersRepoisitory.GetAllFrindByUser(userId);
        }

        public async Task<List<FriendRequest>> GetAllRequesFrindByUser(int userId)
        {
            return await _othersRepoisitory.GetAllRequesFrindByUser(userId);
        }
        public async Task<FRINEDEMAIL> GetEmailBlockFrind(int firndID)
        {
            return await _othersRepoisitory.GetEmailBlockFrind(firndID);
        }

        public async Task<List<GetAllMessagebyUser>> getAllMessagebyUsers(string userName)
        {
            return await _othersRepoisitory.getAllMessagebyUsers(userName);
        }

        public async Task<List<GetAllMessageByGroubUser1>> GetAllMessageByGroubUser1()
        {
            return await _othersRepoisitory.GetAllMessageByGroubUser1();
        }

        public async Task<List<GetAllMessageCountbyAllUser>> GetAllMessageCountbyAllUser()
        {
            return await _othersRepoisitory.GetAllMessageCountbyAllUser();
        }

        public async Task<List<GetAllMessageCountbyAllGroup>> GetAllMessageCountbyAllGroup()
        {
            return await _othersRepoisitory.GetAllMessageCountbyAllGroup();
        }
    }
}
