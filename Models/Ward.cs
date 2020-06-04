using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenyanCounties.Models
{
    public class Ward
    {
        public int WardID { get; set; }
        public int SubCountyCode { get; set; }
        public int WardCode { get; set; }
        public string WardName { get; set; }
        public ICollection<SubCounty> SubCounty { get; set; }
    }
}
