using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class MESSAGE
    {
        public int ID { get; set; }
        public DateTime CREATEAT { get; set; }
        public string CONTENT1 { get; set; }
        public int GROUPID { get; set; }
        public int USERID { get; set; }
    }
}
