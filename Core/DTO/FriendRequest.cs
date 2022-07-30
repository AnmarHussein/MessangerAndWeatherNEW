using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class FriendRequest
    {
        public int ID { get; set; }
        public DateTime CREATEAT { get; set; }
        public int APPROVED { get; set; }
        public string FROMNAME { get; set; }
        public string TONAME { get; set; }
    }
}
