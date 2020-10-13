using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTicketBase.Classes {
    class XPOSolutionCreator : SolutionCreator {
        public override string SolutionPattern {
            get {
                return "dxTestSolutionXPO";
            }
        }

        public override string SourceSolutionPath {
            get {
                return dropBoxPath + @"work\templates\MainSolution\ConsoleApp1\";
            }
        }

        internal override List<string> GetFilesWithSolutionNameInName() {
            var filesWithSolutionName = new List<string>();
            filesWithSolutionName.Add(@"dxTestSolutionXPO\dxTestSolutionXPO.csproj");
            filesWithSolutionName.Add(@"dxTestSolutionXPO\\");
            filesWithSolutionName.Add(@"dxTestSolutionXPO.sln");
            return filesWithSolutionName;
        }

        internal override void CopySolutionFiles() {
            DirectoryCopy(SourceSolutionPath, finalSolutionFolderPath, true);
        }

        internal override List<string> GetTokens() {
            var tokens = new List<string>();
            if(selectedModules != null && selectedModules.Contains("inmemory")) {
                tokens.Add("inmemory");
            }
            return tokens;
        }

        public override void AddAdditionalModules(string solutionPath) {
            base.AddAdditionalModules(solutionPath);
            List<string> tokens = GetTokens();
            CreateT4File<TextTemplates.XPOConnectionHelper>(tokens);
        }

    }
}
