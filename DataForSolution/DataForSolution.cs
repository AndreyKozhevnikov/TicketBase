using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataForSolutionNameSpace {
    public class DataForSolution {
        public string Name { get; set; }
        public string FolderName { get; set; }
        public ProjectTypeEnum Type { get; set; }
        public ORMEnum ORMType { get; set; }

        public bool HasSecurity { get; set; }
        public bool HasWebAPISeparate { get; set; }
        public bool HasWebAPIIntegrate { get; set; }
        public bool HasMultitenant { get; set; }
        public List<ModulesEnum> Modules { get; set; }=new List<ModulesEnum>();
    }
}
