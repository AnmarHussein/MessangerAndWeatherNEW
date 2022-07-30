using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IOthersService
    {
        public Task<List<SEALESYEAR>> GetSealesYear();
        public Task<List<LIKEINPOST>> GETLIKEALL();
        public Task<List<USER1INPOST>> GETUSERPOSTS();
        public Task<List<CityNumberOfUser>> GetCityNumberOfUser1();
        public Task<List<TotalVisaEachUser1>> TotalVisaUser1();

        //
        public Task<List<FriendRequest>> GetAllRequesFrindByUser(int userId);
        public Task<List<FriendRequest>> GetAllFrindByUser(int userId);
        public Task<FRINEDEMAIL> GetEmailBlockFrind(int firndID);
        public Task<string> ApprovedFrindReguest(int firndID);
        public Task<string> BlockFrind(int firndID);

        //
        public Task<List<GetAllMessagebyUser>> getAllMessagebyUsers(string userName);
        public Task<List<GetAllMessageByGroubUser1>> GetAllMessageByGroubUser1();
        public Task<List<GetAllMessageCountbyAllUser>> GetAllMessageCountbyAllUser();
        public Task<List<GetAllMessageCountbyAllGroup>> GetAllMessageCountbyAllGroup();
    }
}
