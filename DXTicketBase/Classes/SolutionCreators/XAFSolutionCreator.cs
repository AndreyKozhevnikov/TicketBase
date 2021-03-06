﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTicketBase.Classes {
    abstract class XAFSolutionCreator : SolutionCreator {
        public override string SolutionPattern {
            get {
                return "dxTestSolution";
            }
        }
        public override string SourceSolutionPath {
            get {
                return dropBoxPath + @"work\templates\MainSolution\dxTestSolution(Secur)\";
            }
        }
        internal abstract void CopyDotVSFolder();

        internal override void CopySolutionFiles() {

            DirectoryCopy(SourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Module", true);
            File.Copy(SourceSolutionPath + "dxTestSolution.sln", finalSolutionFolderPath + "dxTestSolution.sln", true);
            DirectoryCopy(SourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Module.Win", true);
            DirectoryCopy(SourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Win", true);
            DirectoryCopy(SourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Module.Web", true);
            DirectoryCopy(SourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Web", true);
            if(selectedModules != null && selectedModules.Contains("report")) {
                File.Copy(SourceSolutionPath + @"Controllers\ClearReportCacheController.cs", finalSolutionFolderPath + @"dxTestSolution.Module\Controllers\ClearReportCacheController.cs");
            }
            if(selectedModules != null && selectedModules.Contains("office")) {
                File.Copy(SourceSolutionPath + @"Controllers\ClearMailMergeCacheController.cs", finalSolutionFolderPath + @"dxTestSolution.Module.Win\Controllers\ClearMailMergeCacheController.cs");
            }
            CopyDotVSFolder();
        }
        internal override List<string> GetFilesWithSolutionNameInName() {
            var filesWithSolutionName = new List<string>();
            filesWithSolutionName.Add(@"dxTestSolution.Module\dxTestSolution.Module.csproj");
            filesWithSolutionName.Add("dxTestSolution.Module\\");
            filesWithSolutionName.Add(@"dxTestSolution.Module.Win\dxTestSolution.Module.Win.csproj");
            filesWithSolutionName.Add("dxTestSolution.Module.Win\\");
            filesWithSolutionName.Add(@"dxTestSolution.Win\dxTestSolution.Win.csproj");
            filesWithSolutionName.Add("dxTestSolution.Win\\");
            filesWithSolutionName.Add(@"dxTestSolution.Module.Web\dxTestSolution.Module.Web.csproj");
            filesWithSolutionName.Add("dxTestSolution.Module.Web\\");
            filesWithSolutionName.Add(@"dxTestSolution.Web\dxTestSolution.Web.csproj");
            filesWithSolutionName.Add("dxTestSolution.Web\\");
            filesWithSolutionName.Add(@".vs\dxTestSolution\");
            filesWithSolutionName.Add("dxTestSolution.sln");
            return filesWithSolutionName;
        }
        internal override List<string> GetTokens() {
            var tokens = new List<string>();
            if(selectedModules != null) {
                tokens = selectedModules.Cast<string>().ToList();
            }
            return tokens;
        }

        public override void AddAdditionalModules(string solutionPath) {
            base.AddAdditionalModules(solutionPath);
            List<string> tokens = GetTokens();
            CreateT4File<TextTemplates.Updater>(tokens);
            CreateT4File<TextTemplates.Module>(tokens);
            CreateT4File<TextTemplates.ModuleDesigner>(tokens);
            CreateT4File<TextTemplates.Contact>(tokens);
            CreateT4File<TextTemplates.ModuleCsproj>(tokens);
            CreateT4File<TextTemplates.WinModule>(tokens);
            CreateT4File<TextTemplates.WebModule>(tokens);
            CreateT4File<TextTemplates.ModuleWinCsproj>(tokens);
            CreateT4File<TextTemplates.ModuleWebCsproj>(tokens);
            CreateT4File<TextTemplates.WinApplicationDesigner>(tokens);
            CreateT4File<TextTemplates.WinApplication>(tokens);
            CreateT4File<TextTemplates.WinCsproj>(tokens);
            CreateT4File<TextTemplates.WebCsproj>(tokens);
            CreateT4File<TextTemplates.GlobalAsax>(tokens);
            CreateT4File<TextTemplates.WebApplication>(tokens);
            CreateT4File<TextTemplates.WebConfig>(tokens);
            CreateT4File<TextTemplates.Program>(tokens);

        }
    }

}
