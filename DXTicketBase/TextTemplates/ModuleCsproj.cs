﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace DXTicketBase.TextTemplates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ModuleCsproj : BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
 FileName=@"\{0}.Module\{0}.Module.csproj"; 
            
            #line default
            #line hidden
            this.Write("\r\n<Project DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/m" +
                    "sbuild/2003\" ToolsVersion=\"4.0\">\r\n\t<PropertyGroup>\r\n\t\t<Configuration Condition=\"" +
                    " \'$(Configuration)\' == \'\' \">Debug</Configuration>\r\n\t\t<Platform Condition=\" \'$(Pl" +
                    "atform)\' == \'\' \">AnyCPU</Platform>\r\n\t\t<ProductVersion>9.0.30729</ProductVersion>" +
                    "\r\n\t\t<SchemaVersion>2.0</SchemaVersion>\r\n\t\t<ProjectGuid>{5F15837D-D1E5-44DC-92F0-" +
                    "4F2EBE9C3F8D}</ProjectGuid>\r\n\t\t<OutputType>Library</OutputType>\r\n\t\t<AppDesignerF" +
                    "older>Properties</AppDesignerFolder>\r\n\t\t<RootNamespace>dxTestSolution.Module</Ro" +
                    "otNamespace>\r\n\t\t<AssemblyName>dxTestSolution.Module</AssemblyName>\r\n\t\t<TargetFra" +
                    "meworkVersion>v4.5.2</TargetFrameworkVersion>\r\n\t\t<FileUpgradeFlags>\r\n\t\t</FileUpg" +
                    "radeFlags>\r\n\t\t<UpgradeBackupLocation>\r\n\t\t</UpgradeBackupLocation>\r\n\t\t<OldToolsVe" +
                    "rsion>3.5</OldToolsVersion>\r\n\t\t<TargetFrameworkProfile />\r\n\t</PropertyGroup>\r\n\t<" +
                    "PropertyGroup Condition=\" \'$(Configuration)|$(Platform)\' == \'Debug|AnyCPU\' \">\r\n\t" +
                    "\t<DebugSymbols>true</DebugSymbols>\r\n\t\t<DebugType>full</DebugType>\r\n\t\t<Optimize>f" +
                    "alse</Optimize>\r\n\t\t<OutputPath>bin\\Debug\\</OutputPath>\r\n\t\t<DefineConstants>DEBUG" +
                    ";TRACE</DefineConstants>\r\n\t\t<ErrorReport>prompt</ErrorReport>\r\n\t\t<WarningLevel>4" +
                    "</WarningLevel>\r\n\t</PropertyGroup>\r\n\t<PropertyGroup Condition=\" \'$(Configuration" +
                    ")|$(Platform)\' == \'Release|AnyCPU\' \">\r\n\t\t<DebugType>pdbonly</DebugType>\r\n\t\t<Opti" +
                    "mize>true</Optimize>\r\n\t\t<OutputPath>bin\\Release\\</OutputPath>\r\n\t\t<DefineConstant" +
                    "s>TRACE</DefineConstants>\r\n\t\t<ErrorReport>prompt</ErrorReport>\r\n\t\t<WarningLevel>" +
                    "4</WarningLevel>\r\n\t</PropertyGroup>\r\n\t<PropertyGroup Condition=\" \'$(Configuratio" +
                    "n)|$(Platform)\' == \'EasyTest|AnyCPU\' \">\r\n\t\t<DebugSymbols>true</DebugSymbols>\r\n\t\t" +
                    "<OutputPath>bin\\EasyTest\\</OutputPath>\r\n\t\t<DefineConstants>TRACE;DEBUG;EASYTEST<" +
                    "/DefineConstants>\r\n\t\t<DebugType>full</DebugType>\r\n\t\t<PlatformTarget>AnyCPU</Plat" +
                    "formTarget>\r\n\t\t<ErrorReport>prompt</ErrorReport>\r\n\t</PropertyGroup>\r\n\t<ItemGroup" +
                    ">\r\n\t\t<Reference Include=\"DevExpress.Data.v20.2\">\r\n\t\t\t<SpecificVersion>False</Spe" +
                    "cificVersion>\r\n\t\t</Reference>\r\n\t\t<Reference Include=\"DevExpress.ExpressApp.v20.2" +
                    "\">\r\n\t\t\t<SpecificVersion>False</SpecificVersion>\r\n\t\t</Reference>\r\n\t\t<Reference In" +
                    "clude=\"DevExpress.ExpressApp.Xpo.v20.2\">\r\n\t\t\t<SpecificVersion>False</SpecificVer" +
                    "sion>\r\n\t\t\t<Private>False</Private>\r\n\t\t</Reference>\r\n\t\t<Reference Include=\"DevExp" +
                    "ress.Persistent.Base.v20.2\">\r\n\t\t\t<SpecificVersion>False</SpecificVersion>\r\n\t\t</R" +
                    "eference>\r\n\t\t<Reference Include=\"DevExpress.Persistent.BaseImpl.v20.2\">\r\n\t\t\t<Spe" +
                    "cificVersion>False</SpecificVersion>\r\n\t\t</Reference>\r\n\t\t<Reference Include=\"DevE" +
                    "xpress.Printing.v20.2.Core\">\r\n\t\t\t<SpecificVersion>False</SpecificVersion>\r\n\t\t</R" +
                    "eference>\r\n\t\t<Reference Include=\"DevExpress.Xpo.v20.2\">\r\n\t\t\t<SpecificVersion>Fal" +
                    "se</SpecificVersion>\r\n\t\t</Reference>\r\n\t\t");
            
            #line 75 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
 if (HasValidation){ 
            
            #line default
            #line hidden
            this.Write("\t\t<Reference Include=\"DevExpress.ExpressApp.Validation.v20.2\">\r\n            <Spec" +
                    "ificVersion>False</SpecificVersion>\r\n        </Reference>\r\n\t\t");
            
            #line 79 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 80 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write(@"			<Reference Include=""DevExpress.ExpressApp.ReportsV2.v20.2"">
					<SpecificVersion>False</SpecificVersion>
				</Reference>
				<Reference Include=""DevExpress.Utils.v20.2"" >
					<SpecificVersion>False</SpecificVersion>
				</Reference>
				<Reference Include=""DevExpress.XtraReports.v20.2"" >
					<SpecificVersion>False</SpecificVersion>
				</Reference>
				<Reference Include=""DevExpress.XtraReports.v20.2.Extensions"" >
					<SpecificVersion>False</SpecificVersion>
				</Reference>
		");
            
            #line 93 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 94 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write(@"		<Reference Include=""DevExpress.ExpressApp.Office.v20.2"" >
			<SpecificVersion>False</SpecificVersion>
		</Reference>
		<Reference Include=""DevExpress.Office.v20.2.Core"">
			<SpecificVersion>False</SpecificVersion>
		</Reference>
		<Reference Include=""DevExpress.RichEdit.v20.2.Core"">
			<SpecificVersion>False</SpecificVersion>
		</Reference>
		<Reference Include=""DevExpress.Spreadsheet.v20.2.Core"" >
			<SpecificVersion>False</SpecificVersion>
		</Reference>
		<Reference Include=""DevExpress.RichEdit.v20.2.Export"">
			<SpecificVersion>False</SpecificVersion>
		</Reference>

		");
            
            #line 111 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\r\n\t\t");
            
            #line 113 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"			<Reference Include=""DevExpress.ExpressApp.Security.v20.2"">
			<SpecificVersion>False</SpecificVersion>
		</Reference>
		<Reference Include=""DevExpress.ExpressApp.Security.Xpo.v20.2"">
			<SpecificVersion>False</SpecificVersion>
			
		</Reference>
");
            
            #line 121 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\ModuleCsproj.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\r\n\r\n\t\r\n\r\n\r\n\r\n\t\t<Reference Include=\"System\">\r\n\t\t\t<Name>System</Name>\r\n\t\t\t<Privat" +
                    "e>False</Private>\r\n\t\t</Reference>\r\n\t\t<Reference Include=\"System.Data\">\r\n\t\t\t<Name" +
                    ">System.Data</Name>\r\n\t\t\t<Private>False</Private>\r\n\t\t</Reference>\r\n\t\t<Reference I" +
                    "nclude=\"System.Drawing\">\r\n\t\t\t<Private>False</Private>\r\n\t\t</Reference>\r\n\t\t<Refere" +
                    "nce Include=\"System.Xml\">\r\n\t\t\t<Name>System.XML</Name>\r\n\t\t\t<Private>False</Privat" +
                    "e>\r\n\t\t</Reference>\r\n\t</ItemGroup>\r\n\t<ItemGroup>\r\n\t\t<Compile Include=\"BusinessObj" +
                    "ects\\Contact.cs\" />\r\n\t\t<Compile Include=\"BusinessObjects\\MyTask.cs\" />\r\n\t\t<Compi" +
                    "le Include=\"BusinessObjects\\CustomClass.cs\" />\r\n\t\t<!--//report#15-->\r\n\t\t<Compile" +
                    " Include=\"Controllers\\CustomControllers.cs\">\r\n\t\t\t<SubType>Component</SubType>\r\n\t" +
                    "\t</Compile>\r\n\t\t<Compile Include=\"DatabaseUpdate\\Updater.cs\" />\r\n\t\t<Compile Inclu" +
                    "de=\"Module.cs\">\r\n\t\t\t<SubType>Component</SubType>\r\n\t\t</Compile>\r\n\t\t<Compile Inclu" +
                    "de=\"Module.Designer.cs\">\r\n\t\t\t<DependentUpon>Module.cs</DependentUpon>\r\n\t\t</Compi" +
                    "le>\r\n\t\t<Compile Include=\"Properties\\AssemblyInfo.cs\" />\r\n\t</ItemGroup>\r\n\t<ItemGr" +
                    "oup>\r\n\t\t<EmbeddedResource Include=\"Model.DesignedDiffs.xafml\" />\r\n\t\t<EmbeddedRes" +
                    "ource Include=\"Module.resx\">\r\n\t\t\t<SubType>Designer</SubType>\r\n\t\t\t<DependentUpon>" +
                    "Module.cs</DependentUpon>\r\n\t\t</EmbeddedResource>\r\n\t\t<EmbeddedResource Include=\"P" +
                    "roperties\\licenses.licx\" />\r\n\t</ItemGroup>\r\n\t<ItemGroup>\r\n\t\t<None Include=\"Datab" +
                    "aseUpdate\\ReadMe.txt\" />\r\n\t</ItemGroup>\r\n\t<ItemGroup>\r\n\t\t<None Include=\"Business" +
                    "Objects\\ReadMe.txt\" />\r\n\t</ItemGroup>\r\n\t<ItemGroup>\r\n\t\t<None Include=\"Controller" +
                    "s\\ReadMe.txt\" />\r\n\t</ItemGroup>\r\n\t<ItemGroup>\r\n\t\t<None Include=\"FunctionalTests\\" +
                    "ReadMe.txt\" />\r\n\t</ItemGroup>\r\n\t<ItemGroup>\r\n\t\t<None Include=\"FunctionalTests\\sa" +
                    "mple.ets\" />\r\n\t\t<None Include=\"FunctionalTests\\WebSample.ets\" />\r\n\t\t<None Includ" +
                    "e=\"Images\\ReadMe.txt\" />\r\n\t\t<None Include=\"ReadMe.txt\" />\r\n\t</ItemGroup>\r\n\t<Item" +
                    "Group>\r\n\t\t<None Include=\"FunctionalTests\\config.xml\">\r\n\t\t\t<SubType>Designer</Sub" +
                    "Type>\r\n\t\t</None>\r\n\t</ItemGroup>\r\n\t<ItemGroup>\r\n\t\t<Content Include=\"Welcome.html\"" +
                    " />\r\n\t</ItemGroup>\r\n\t<Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets" +
                    "\" />\r\n\t<!-- To modify your build process, add your task inside one of the target" +
                    "s below and uncomment it. \r\n       Other similar extension points exist, see Mic" +
                    "rosoft.Common.targets.\r\n  <Target Name=\"BeforeBuild\">\r\n  </Target>\r\n  <Target Na" +
                    "me=\"AfterBuild\">\r\n  </Target>\r\n  -->\r\n</Project>");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
