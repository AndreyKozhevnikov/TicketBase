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
    
    #line 1 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinCsproj.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class WinCsproj : BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinCsproj.tt"
 FileName=@"\{0}.Win\{0}.Win.csproj"; 
            
            #line default
            #line hidden
            this.Write("\r\n<Project DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/m" +
                    "sbuild/2003\" ToolsVersion=\"4.0\">\r\n  <PropertyGroup>\r\n    <Configuration Conditio" +
                    "n=\" \'$(Configuration)\' == \'\' \">Debug</Configuration>\r\n    <Platform Condition=\" " +
                    "\'$(Platform)\' == \'\' \">AnyCPU</Platform>\r\n    <ProductVersion>9.0.30729</ProductV" +
                    "ersion>\r\n    <SchemaVersion>2.0</SchemaVersion>\r\n    <ProjectGuid>{D05D93DF-312D" +
                    "-4D4E-B980-726871EC7833}</ProjectGuid>\r\n    <OutputType>WinExe</OutputType>\r\n   " +
                    " <AppDesignerFolder>Properties</AppDesignerFolder>\r\n    <RootNamespace>dxTestSol" +
                    "ution.Win</RootNamespace>\r\n    <AssemblyName>dxTestSolution.Win</AssemblyName>\r\n" +
                    "    <ApplicationIcon>ExpressApp.ico</ApplicationIcon>\r\n    <TargetFrameworkVersi" +
                    "on>v4.5.2</TargetFrameworkVersion>\r\n    <FileUpgradeFlags>\r\n    </FileUpgradeFla" +
                    "gs>\r\n    <UpgradeBackupLocation>\r\n    </UpgradeBackupLocation>\r\n    <OldToolsVer" +
                    "sion>3.5</OldToolsVersion>\r\n    <TargetFrameworkProfile />\r\n    <PublishUrl>publ" +
                    "ish\\</PublishUrl>\r\n    <Install>true</Install>\r\n    <InstallFrom>Disk</InstallFr" +
                    "om>\r\n    <UpdateEnabled>false</UpdateEnabled>\r\n    <UpdateMode>Foreground</Updat" +
                    "eMode>\r\n    <UpdateInterval>7</UpdateInterval>\r\n    <UpdateIntervalUnits>Days</U" +
                    "pdateIntervalUnits>\r\n    <UpdatePeriodically>false</UpdatePeriodically>\r\n    <Up" +
                    "dateRequired>false</UpdateRequired>\r\n    <MapFileExtensions>true</MapFileExtensi" +
                    "ons>\r\n    <ApplicationRevision>0</ApplicationRevision>\r\n    <ApplicationVersion>" +
                    "1.0.0.%2a</ApplicationVersion>\r\n    <IsWebBootstrapper>false</IsWebBootstrapper>" +
                    "\r\n    <UseApplicationTrust>false</UseApplicationTrust>\r\n    <BootstrapperEnabled" +
                    ">true</BootstrapperEnabled>\r\n  </PropertyGroup>\r\n  <PropertyGroup Condition=\" \'$" +
                    "(Configuration)|$(Platform)\' == \'Debug|AnyCPU\' \">\r\n    <DebugSymbols>true</Debug" +
                    "Symbols>\r\n    <DebugType>full</DebugType>\r\n    <Optimize>false</Optimize>\r\n    <" +
                    "OutputPath>bin\\Debug\\</OutputPath>\r\n    <DefineConstants>DEBUG;TRACE</DefineCons" +
                    "tants>\r\n    <ErrorReport>prompt</ErrorReport>\r\n    <WarningLevel>4</WarningLevel" +
                    ">\r\n  </PropertyGroup>\r\n  <PropertyGroup Condition=\" \'$(Configuration)|$(Platform" +
                    ")\' == \'Release|AnyCPU\' \">\r\n    <DebugType>pdbonly</DebugType>\r\n    <Optimize>tru" +
                    "e</Optimize>\r\n    <OutputPath>bin\\Release\\</OutputPath>\r\n    <DefineConstants>TR" +
                    "ACE</DefineConstants>\r\n    <ErrorReport>prompt</ErrorReport>\r\n    <WarningLevel>" +
                    "4</WarningLevel>\r\n  </PropertyGroup>\r\n  <PropertyGroup Condition=\" \'$(Configurat" +
                    "ion)|$(Platform)\' == \'EasyTest|AnyCPU\' \">\r\n    <DebugSymbols>true</DebugSymbols>" +
                    "\r\n    <OutputPath>bin\\EasyTest\\</OutputPath>\r\n    <DefineConstants>TRACE;DEBUG;E" +
                    "ASYTEST</DefineConstants>\r\n    <DebugType>full</DebugType>\r\n    <PlatformTarget>" +
                    "AnyCPU</PlatformTarget>\r\n    <ErrorReport>prompt</ErrorReport>\r\n  </PropertyGrou" +
                    "p>\r\n  <ItemGroup>\r\n  \r\n\r\n\r\n");
            
            #line 72 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinCsproj.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write(@"<Reference Include=""DevExpress.ExpressApp.ReportsV2.v21.1"" >
      <SpecificVersion>False</SpecificVersion>
</Reference>
<Reference Include=""DevExpress.ExpressApp.ReportsV2.Win.v21.1"" >
   <SpecificVersion>False</SpecificVersion>
</Reference>
<Reference Include=""DevExpress.Utils.v21.1.UI"" >
    <SpecificVersion>False</SpecificVersion>
</Reference>
<Reference Include=""DevExpress.XtraReports.v21.1"" >
   <SpecificVersion>False</SpecificVersion>
</Reference>
<Reference Include=""DevExpress.XtraReports.v21.1.Extensions"" >
   <SpecificVersion>False</SpecificVersion>
</Reference>
");
            
            #line 88 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinCsproj.tt"
 } 
            
            #line default
            #line hidden
            
            #line 89 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinCsproj.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write(@"<Reference Include=""DevExpress.Office.v21.1.Core"">
	<SpecificVersion>False</SpecificVersion>
</Reference>
<Reference Include=""DevExpress.RichEdit.v21.1.Core"">
	<SpecificVersion>False</SpecificVersion>
</Reference>
<Reference Include=""DevExpress.ExpressApp.Office.v21.1"" >
	<SpecificVersion>False</SpecificVersion>
</Reference>
<Reference Include=""DevExpress.ExpressApp.Office.Win.v21.1"" >
	<SpecificVersion>False</SpecificVersion>
</Reference>
");
            
            #line 102 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinCsproj.tt"
 } 
            
            #line default
            #line hidden
            
            #line 103 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinCsproj.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"    <Reference Include=""DevExpress.ExpressApp.Security.v21.1"" >
      <SpecificVersion>False</SpecificVersion>
    </Reference>
    <Reference Include=""DevExpress.ExpressApp.Security.Xpo.v21.1"">
      <SpecificVersion>False</SpecificVersion>
    </Reference>
");
            
            #line 110 "C:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinCsproj.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t    <Reference Include=\"DevExpress.DataAccess.v21.1\" >\r\n      <SpecificVersion" +
                    ">False</SpecificVersion>\r\n    </Reference>\r\n\r\n\r\n    <Reference Include=\"DevExpre" +
                    "ss.ExpressApp.Xpo.v21.1\">\r\n      <SpecificVersion>False</SpecificVersion>\r\n    <" +
                    "/Reference>\r\n\r\n    <Reference Include=\"DevExpress.Data.Desktop.v21.1\">\r\n      <S" +
                    "pecificVersion>False</SpecificVersion>\r\n    </Reference>\r\n \r\n    <Reference Incl" +
                    "ude=\"DevExpress.BonusSkins.v21.1\">\r\n      <SpecificVersion>False</SpecificVersio" +
                    "n>\r\n    </Reference>\r\n\r\n    <Reference Include=\"DevExpress.Printing.v21.1.Core\">" +
                    "\r\n      <SpecificVersion>False</SpecificVersion>\r\n    </Reference>\r\n    <Referen" +
                    "ce Include=\"DevExpress.Data.v21.1\">\r\n      <SpecificVersion>False</SpecificVersi" +
                    "on>\r\n    </Reference>\r\n\t<Reference Include=\"DevExpress.Images.v21.1\" >\r\n\t  <Spec" +
                    "ificVersion>False</SpecificVersion>\r\n    </Reference>\r\n    <Reference Include=\"D" +
                    "evExpress.ExpressApp.v21.1\">\r\n      <SpecificVersion>False</SpecificVersion>\r\n  " +
                    "  </Reference>\r\n        <Reference Include=\"DevExpress.Office.v21.1.Core\">\r\n    " +
                    "  <SpecificVersion>False</SpecificVersion>\r\n      <Private>False</Private>\r\n    " +
                    "</Reference>\r\n    <Reference Include=\"DevExpress.RichEdit.v21.1.Core\">\r\n      <S" +
                    "pecificVersion>False</SpecificVersion>\r\n      <Private>False</Private>\r\n    </Re" +
                    "ference>\r\n    <Reference Include=\"DevExpress.ExpressApp.Win.v21.1\">\r\n      <Spec" +
                    "ificVersion>False</SpecificVersion>\r\n    </Reference>\r\n    <Reference Include=\"D" +
                    "evExpress.Persistent.Base.v21.1\">\r\n      <SpecificVersion>False</SpecificVersion" +
                    ">\r\n    </Reference>\r\n    <Reference Include=\"DevExpress.Persistent.BaseImpl.v21." +
                    "1\">\r\n      <SpecificVersion>False</SpecificVersion>\r\n    </Reference>\r\n    <Refe" +
                    "rence Include=\"DevExpress.Xpo.v21.1\">\r\n      <SpecificVersion>False</SpecificVer" +
                    "sion>\r\n    </Reference>\r\n    <Reference Include=\"DevExpress.XtraGrid.v21.1\">\r\n  " +
                    "    <SpecificVersion>False</SpecificVersion>\r\n    </Reference>\r\n    <Reference I" +
                    "nclude=\"DevExpress.XtraBars.v21.1\">\r\n      <SpecificVersion>False</SpecificVersi" +
                    "on>\r\n    </Reference>\r\n    <Reference Include=\"DevExpress.XtraEditors.v21.1\">\r\n " +
                    "     <SpecificVersion>False</SpecificVersion>\r\n    </Reference>\r\n    <Reference " +
                    "Include=\"DevExpress.XtraLayout.v21.1\">\r\n      <SpecificVersion>False</SpecificVe" +
                    "rsion>\r\n    </Reference>\r\n    <Reference Include=\"DevExpress.XtraNavBar.v21.1\">\r" +
                    "\n      <SpecificVersion>False</SpecificVersion>\r\n    </Reference>\r\n    <Referenc" +
                    "e Include=\"DevExpress.XtraPrinting.v21.1\">\r\n      <SpecificVersion>False</Specif" +
                    "icVersion>\r\n      <Private>False</Private>\r\n    </Reference>\r\n    <Reference Inc" +
                    "lude=\"DevExpress.XtraRichEdit.v21.1\">\r\n      <SpecificVersion>False</SpecificVer" +
                    "sion>\r\n      <Private>False</Private>\r\n    </Reference>\r\n    <Reference Include=" +
                    "\"DevExpress.XtraTreeList.v21.1\">\r\n      <SpecificVersion>False</SpecificVersion>" +
                    "\r\n      <Private>False</Private>\r\n    </Reference>\r\n    <Reference Include=\"DevE" +
                    "xpress.XtraVerticalGrid.v21.1\">\r\n      <SpecificVersion>False</SpecificVersion>\r" +
                    "\n      <Private>False</Private>\r\n    </Reference>\r\n    <Reference Include=\"Syste" +
                    "m\">\r\n      <Name>System</Name>\r\n      <Private>False</Private>\r\n    </Reference>" +
                    "\r\n    <Reference Include=\"System.configuration\">\r\n      <Private>False</Private>" +
                    "\r\n    </Reference>\r\n    <Reference Include=\"System.Data\">\r\n      <Name>System.Da" +
                    "ta</Name>\r\n      <Private>False</Private>\r\n    </Reference>\r\n    <Reference Incl" +
                    "ude=\"System.Drawing\">\r\n      <Name>System.Drawing</Name>\r\n      <Private>False</" +
                    "Private>\r\n    </Reference>\r\n    <Reference Include=\"System.Windows.Forms\">\r\n    " +
                    "  <Name>System.Windows.Forms</Name>\r\n      <Private>False</Private>\r\n    </Refer" +
                    "ence>\r\n    <Reference Include=\"System.Xml\">\r\n      <Name>System.XML</Name>\r\n    " +
                    "  <Private>False</Private>\r\n    </Reference>\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n   " +
                    " <Compile Include=\"Program.cs\" />\r\n    <Compile Include=\"Properties\\AssemblyInfo" +
                    ".cs\" />\r\n    <Compile Include=\"WinApplication.cs\">\r\n      <SubType>Component</Su" +
                    "bType>\r\n    </Compile>\r\n    <Compile Include=\"WinApplication.Designer.cs\">\r\n    " +
                    "  <DependentUpon>WinApplication.cs</DependentUpon>\r\n    </Compile>\r\n    <Embedde" +
                    "dResource Include=\"Properties\\Resources.resx\">\r\n      <Generator>ResXFileCodeGen" +
                    "erator</Generator>\r\n      <LastGenOutput>Resources.Designer.cs</LastGenOutput>\r\n" +
                    "      <SubType>Designer</SubType>\r\n    </EmbeddedResource>\r\n    <Compile Include" +
                    "=\"Properties\\Resources.Designer.cs\">\r\n      <AutoGen>True</AutoGen>\r\n      <Depe" +
                    "ndentUpon>Resources.resx</DependentUpon>\r\n      <DesignTime>True</DesignTime>\r\n " +
                    "   </Compile>\r\n    <EmbeddedResource Include=\"WinApplication.resx\">\r\n      <Depe" +
                    "ndentUpon>WinApplication.cs</DependentUpon>\r\n      <SubType>Designer</SubType>\r\n" +
                    "    </EmbeddedResource>\r\n    <None Include=\"App.config\" />\r\n    <Content Include" +
                    "=\"Model.xafml\">\r\n      <CopyToOutputDirectory>Always</CopyToOutputDirectory>\r\n  " +
                    "  </Content>\r\n    <None Include=\"Properties\\Settings.settings\">\r\n      <Generato" +
                    "r>SettingsSingleFileGenerator</Generator>\r\n      <LastGenOutput>Settings.Designe" +
                    "r.cs</LastGenOutput>\r\n    </None>\r\n    <Compile Include=\"Properties\\Settings.Des" +
                    "igner.cs\">\r\n      <AutoGen>True</AutoGen>\r\n      <DependentUpon>Settings.setting" +
                    "s</DependentUpon>\r\n      <DesignTimeSharedInput>True</DesignTimeSharedInput>\r\n  " +
                    "  </Compile>\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <Content Include=\"ExpressApp.ic" +
                    "o\" />\r\n    <None Include=\"Images\\ReadMe.txt\" />\r\n    <None Include=\"ReadMe.txt\" " +
                    "/>\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <ProjectReference Include=\"..\\dxTestSolut" +
                    "ion.Module.Win\\dxTestSolution.Module.Win.csproj\">\r\n      <Project>{7964F87D-BC5D" +
                    "-4C4E-8B2F-71E89739AA97}</Project>\r\n      <Name>dxTestSolution.Module.Win</Name>" +
                    "\r\n    </ProjectReference>\r\n    <ProjectReference Include=\"..\\dxTestSolution.Modu" +
                    "le\\dxTestSolution.Module.csproj\">\r\n      <Project>{5F15837D-D1E5-44DC-92F0-4F2EB" +
                    "E9C3F8D}</Project>\r\n      <Name>dxTestSolution.Module</Name>\r\n    </ProjectRefer" +
                    "ence>\r\n  </ItemGroup>\r\n  <ItemGroup>\r\n    <BootstrapperPackage Include=\"Microsof" +
                    "t.Net.Client.3.5\">\r\n      <Visible>False</Visible>\r\n      <ProductName>.NET Fram" +
                    "ework 3.5 SP1 Client Profile</ProductName>\r\n      <Install>false</Install>\r\n    " +
                    "</BootstrapperPackage>\r\n    <BootstrapperPackage Include=\"Microsoft.Net.Framewor" +
                    "k.3.5.SP1\">\r\n      <Visible>False</Visible>\r\n      <ProductName>.NET Framework 3" +
                    ".5 SP1</ProductName>\r\n      <Install>true</Install>\r\n    </BootstrapperPackage>\r" +
                    "\n    <BootstrapperPackage Include=\"Microsoft.Windows.Installer.3.1\">\r\n      <Vis" +
                    "ible>False</Visible>\r\n      <ProductName>Windows Installer 3.1</ProductName>\r\n  " +
                    "    <Install>true</Install>\r\n    </BootstrapperPackage>\r\n  </ItemGroup>\r\n  <Impo" +
                    "rt Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />\r\n  <!-- To modify you" +
                    "r build process, add your task inside one of the targets below and uncomment it." +
                    " \r\n       Other similar extension points exist, see Microsoft.Common.targets.\r\n " +
                    " <Target Name=\"BeforeBuild\">\r\n  </Target>\r\n  <Target Name=\"AfterBuild\">\r\n  </Tar" +
                    "get>\r\n  -->\r\n</Project>\r\n\r\n\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
