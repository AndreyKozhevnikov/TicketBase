using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataForSolutionNameSpace {
    public class DataForSolution {
        public string Name { get; set; }
        public string Type { get; set; }

        public bool HasSecurity { get; set; }
        public List<string> Modules { get; set; }
    }
}
