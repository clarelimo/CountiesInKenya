using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenyanCounties.Models
{
    public class SubCounty
    {
        public int SubCountyID { get; set; }
        public int CountyCode { get; set; }
        public int SubCountyCode { get; set; }
        public string SubCountyName { get; set; }
        public ICollection<County> County { get; set; }
    }
}
