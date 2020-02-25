using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTicketBase.Classes {
    class XAFWinSolutionCreator : XAFSolutionCreator {
        internal override void CopyDotVSFolder() {
            DirectoryCopy(SourceSolutionPath + ".vsWin", finalSolutionFolderPath + ".vs", true);
        }

    }
}
