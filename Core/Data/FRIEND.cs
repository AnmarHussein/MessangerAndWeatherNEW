using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class FRIEND
    {
        public int ID { get; set; }
        public DateTime CREATEAT { get; set; }
        public int APPROVED { get; set; }
        public int BLOCKUSER { get; set; }
        public int TOUSER { get; set; }
        public int FROMUSER { get; set; }
    }
}
