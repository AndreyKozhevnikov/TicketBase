using DataForSolutionNameSpace;
using DXTicketBase.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXTicketBase.Tests {
    [TestFixture]
    public class CLITests {
        [Test]
        public void CLITestBase() {
            //arrange
            var data = new DataForSolution();
            data.Name = "MyTestSolution232";
            data.FolderName = "c:\\!Tickets\\T1246029 How to manage the reset passwor\\";
            data.HasWebAPISeparate = true;
            data.Modules.Add(ModulesEnum.Reports);
            data.Modules.Add(ModulesEnum.Office);
            data.HasSecurity = true;

            //act

            var builder = new CLIBuilder();
            var command = builder.GetCLIString(data);

            //assert

            Assert.AreEqual(@"dotnet new dx.xaf -p Blazor Win -n MyTestSolution232 -o ""c:\!Tickets\T1246029 How to manage the reset passwor\MyTestSolution232\"" -orm XPO --security Password -api Standalone --modules Reports Office", command);


        }
    }
}
