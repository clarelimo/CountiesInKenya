using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenyanCounties.Models
{
    public class County
    {
        public int CountyID { get; set; }
        public int CountyCode { get; set; }
        public string CountyName { get; set; }
        //public SubCounty SubCounty { get; set; }
        //public Ward Ward { get; set; }
    }
}
