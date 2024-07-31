using DataForSolutionNameSpace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTicketBase.Classes {
    public class CLIBuilder {
        public string GetCLIString(DataForSolution dataForSolution) {
            List<string> parts = new List<string>();
            parts.Add("dotnet new dx.xaf");
            parts.Add("-p Blazor Win");
            parts.Add($"-n {dataForSolution.Name}");
            //parts.Add("test" + "\\" + "test");
            //parts.Add(Path.Combine("test" , "test"));
            parts.Add($"-o");
            parts.Add($"\"{Path.Combine(dataForSolution.FolderName, dataForSolution.Name)}\\\"");

            switch(dataForSolution.ORMType) {
                case ORMEnum.XPO:
                parts.Add($"-orm XPO");
                break;
                case ORMEnum.EF:
                parts.Add($"-orm EFCore");
                break;
            }
            if(dataForSolution.HasSecurity) {
                parts.Add($"--security Password");
            }
            if(dataForSolution.HasMultitenant) {
                parts.Add($"--multitenancy true");
            }
            if(dataForSolution.HasWebAPISeparate) {
                parts.Add($"-api Standalone");
            } else if(dataForSolution.HasWebAPIIntegrate) {
                parts.Add($"-api Integrated");
            }
            if(dataForSolution.Modules.Count > 0) {
                parts.Add($"--modules");
                foreach(var md in dataForSolution.Modules) {
                    parts.Add($"{md}");
                }
            }
            var command = string.Join(" ", parts);
            return command;
        }
    }
}
