using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class VISACARD
    {
        public int ID { get; set; }
        public string CARDNAME { get; set; }
        public string CARDNUMBER { get; set; }
        public string EXPIREDATE { get; set; }
        public int SECURITYCODE { get; set; }
        public int USER_ID { get; set; }
    }
}
