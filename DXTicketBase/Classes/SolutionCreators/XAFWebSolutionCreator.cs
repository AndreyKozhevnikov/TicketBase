using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTicketBase.Classes {
    class XAFWebSolutionCreator : XAFSolutionCreator {
        internal override void CopyDotVSFolder() {
            DirectoryCopy(SourceSolutionPath + ".vsWeb", finalSolutionFolderPath + ".vs", true);
        }
     
    }
}
