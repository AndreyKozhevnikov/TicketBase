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
    
    #line 1 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebConfig.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class WebConfig : BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebConfig.tt"
 FileName=@"\{0}.Web\Web.config"; 
            
            #line default
            #line hidden
            this.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<!--\r\n    Note: As an alternative to hand" +
                    " editing this file you can use the\r\n    web admin tool to configure settings for" +
                    " your application. Use\r\n    the Project->ASP.NET Configuration option in Visual " +
                    "Studio.\r\n    A full list of settings and comments can be found in\r\n    machine.c" +
                    "onfig.comments usually located in\r\n    \\Windows\\Microsoft.Net\\Framework\\v2.x\\Con" +
                    "fig\r\n-->\r\n<configuration>\r\n  <configSections>\r\n    <sectionGroup name=\"devExpres" +
                    "s\">\r\n      <section name=\"compression\" requirePermission=\"false\" type=\"DevExpres" +
                    "s.Web.CompressionConfigurationSection, DevExpress.Web.v20.2, Version=20.2.4.0, C" +
                    "ulture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r\n      <section name=\"themes" +
                    "\" requirePermission=\"false\" type=\"DevExpress.Web.ThemesConfigurationSection, Dev" +
                    "Express.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d70" +
                    "0e49a\" />\r\n      <section name=\"settings\" requirePermission=\"false\" type=\"DevExp" +
                    "ress.Web.SettingsConfigurationSection, DevExpress.Web.v20.2, Version=20.2.4.0, C" +
                    "ulture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r\n      <section name=\"resour" +
                    "ces\" requirePermission=\"false\" type=\"DevExpress.Web.ResourcesConfigurationSectio" +
                    "n, DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1" +
                    "754d700e49a\" />\r\n    </sectionGroup>\r\n  </configSections>\r\n  <devExpress>\r\n    <" +
                    "settings rightToLeft=\"false\" doctypeMode=\"Html5\" ieCompatibilityVersion=\"edge\" /" +
                    ">\r\n    <compression enableHtmlCompression=\"true\" enableCallbackCompression=\"true" +
                    "\" enableResourceCompression=\"true\" enableResourceMerging=\"true\" />\r\n    <themes " +
                    "enableThemesAssembly=\"true\" theme=\"Office2010Blue\" />\r\n    <resources>\r\n      <a" +
                    "dd type=\"ThirdParty\" />\r\n      <add type=\"DevExtreme\" />\r\n    </resources>\r\n  </" +
                    "devExpress>\r\n  <appSettings>\r\n    <add key=\"Modules\" value=\"\" />\r\n    <add key=\"" +
                    "ErrorReportEmail\" value=\"\" />\r\n    <add key=\"ErrorReportEmailServer\" value=\"\" />" +
                    "\r\n    <!--\r\n    <add key=\"ErrorReportEmailSubject\" value=\"{0:ExceptionMessage}\"/" +
                    ">\r\n    <add key=\"ErrorReportEmailFrom\" value=\"null@nospam.com\"/>\r\n    <add key=\"" +
                    "ErrorReportEmailFromName\" value=\"{0:ApplicationName} Error handling system\"/>   " +
                    " \r\n    <add key=\"Languages\" value=\"de;es;ja;ru\" />\r\n    -->\r\n    <add key=\"Simpl" +
                    "eErrorReportPage\" value=\"\" />\r\n    <add key=\"RichErrorReportPage\" value=\"Error.a" +
                    "spx\" />\r\n    <add key=\"EnableDiagnosticActions\" value=\"True\" />\r\n    <!-- \r\n    " +
                    "Use the one of predefined values: None, ApplicationFolder. The default value is " +
                    "ApplicationFolder.\r\n    <add key=\"TraceLogLocation\" value=\"ApplicationFolder\"/>\r" +
                    "\n    -->\r\n  </appSettings>\r\n  <connectionStrings>\r\n  \r\n    <add name=\"EasyTestCo" +
                    "nnectionString\" connectionString=\"Integrated Security=SSPI;Pooling=false;Data So" +
                    "urce=(localdb)\\mssqllocaldb;Initial Catalog=dxTestSolutionEasyTest\" />\r\n    <add" +
                    " name=\"ConnectionString\" connectionString=\"Integrated Security=SSPI;Pooling=fals" +
                    "e;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=dxTestSolution\" />\r\n    <!-" +
                    "-\r\n    Use the following connection string to connect to a Jet (Microsoft Access" +
                    ") database:\r\n    <add name=\"ConnectionString\" connectionString=\"Provider=Microso" +
                    "ft.Jet.OLEDB.4.0;Password=;User ID=Admin;Data Source=dxTestSolution.mdb;Mode=Sha" +
                    "re Deny None;\"/>\r\n    -->\r\n  </connectionStrings>\r\n  <system.diagnostics>\r\n    <" +
                    "switches>\r\n      <!-- Use the one of predefined values: 0-Off, 1-Errors, 2-Warni" +
                    "ngs, 3-Info, 4-Verbose. The default value is 3. -->\r\n      <add name=\"eXpressApp" +
                    "Framework\" value=\"3\" />\r\n      <!--\r\n      <add name=\"XPO\" value=\"3\" />\r\n    -->" +
                    "\r\n    </switches>\r\n  </system.diagnostics>\r\n  <system.webServer>\r\n    <handlers>" +
                    "\r\n      <add name=\"ASPxUploadProgressHandler\" verb=\"GET,POST\" path=\"ASPxUploadPr" +
                    "ogressHandlerPage.ashx\" type=\"DevExpress.Web.ASPxUploadProgressHttpHandler, DevE" +
                    "xpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700" +
                    "e49a\" preCondition=\"integratedMode\" />\r\n      <add name=\"XafHttpHandler\" path=\"D" +
                    "XX.axd\" verb=\"*\" type=\"DevExpress.ExpressApp.Web.XafHttpHandler, DevExpress.Expr" +
                    "essApp.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700" +
                    "e49a\" preCondition=\"integratedMode\" />\r\n      <add name=\"ASPxHttpHandlerModuleXA" +
                    "F\" path=\"DXXRD.axd\" verb=\"GET,POST\" type=\"DevExpress.Web.ASPxHttpHandlerModule, " +
                    "DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754" +
                    "d700e49a\" preCondition=\"integratedMode\" />\r\n\t  <!--//report#5-->\r\n\t  ");
            
            #line 76 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebConfig.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write(@"	  <add name=""ASPxWebDocumentViewerHandlerModule"" verb=""GET,POST"" path=""DXXRDV.axd"" type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" preCondition=""integratedMode"" />
	 <add name=""ASPxQueryBuilderDesignerHandlerModule"" verb=""GET,POST"" path=""DXQB.axd"" type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" preCondition=""integratedMode"" />
");
            
            #line 79 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebConfig.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"    </handlers>
    <validation validateIntegratedModeConfiguration=""false"" />
    <modules>
      <add name=""ASPxHttpHandlerModule"" type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
      <add name=""XafHttpModule"" type=""DevExpress.ExpressApp.Web.XafHttpModule, DevExpress.ExpressApp.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
    </modules>
  </system.webServer>
  <system.web>
    <httpRuntime requestValidationMode=""2.0"" />
    <pages controlRenderingCompatibilityVersion=""3.5"" clientIDMode=""AutoID"" />
    <httpHandlers>
      <add path=""DXX.axd"" verb=""*"" type=""DevExpress.ExpressApp.Web.XafHttpHandler, DevExpress.ExpressApp.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
      <add verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" validate=""false"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
      <add path=""DXXRD.axd"" verb=""GET,POST"" type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" validate=""false"" />
	  <!--//report#6-->
	  ");
            
            #line 95 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebConfig.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write(@"	  		<add verb=""GET,POST"" path=""DXXRDV.axd"" type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
				<add verb=""GET,POST"" path=""DXQB.axd"" type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
");
            
            #line 98 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebConfig.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    </httpHandlers>\r\n    <httpModules>\r\n      <add name=\"ASPxHttpHandlerModule\" t" +
                    "ype=\"DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v20.2, Version=20.2.4." +
                    "0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r\n      <add name=\"XafHtt" +
                    "pModule\" type=\"DevExpress.ExpressApp.Web.XafHttpModule, DevExpress.ExpressApp.We" +
                    "b.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r" +
                    "\n    </httpModules>\r\n    <!--\r\n    Set compilation debug=\"true\" to insert debugg" +
                    "ing\r\n    symbols into the compiled page. Because this\r\n    affects performance, " +
                    "set this value to true only\r\n    during development.\r\n    -->\r\n    <compilation " +
                    "debug=\"true\" targetFramework=\"4.5.2\">\r\n      <assemblies>\r\n        <add assembly" +
                    "=\"DevExpress.ExpressApp.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken" +
                    "=b88d1754d700e49a\" />\r\n        <add assembly=\"DevExpress.ExpressApp.Web.v20.2, V" +
                    "ersion=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r\n        <" +
                    "add assembly=\"DevExpress.Persistent.Base.v20.2, Version=20.2.4.0, Culture=neutra" +
                    "l, PublicKeyToken=b88d1754d700e49a\" />\r\n        <add assembly=\"DevExpress.Expres" +
                    "sApp.Images.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d70" +
                    "0e49a\" />\r\n        <add assembly=\"DevExpress.Printing.v20.2.Core, Version=20.2.4" +
                    ".0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r\n        <add assembly=" +
                    "\"DevExpress.Data.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d17" +
                    "54d700e49a\" />\r\n        <add assembly=\"DevExpress.Utils.v20.2, Version=20.2.4.0," +
                    " Culture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r\n        <add assembly=\"De" +
                    "vExpress.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d7" +
                    "00e49a\" />\r\n        <add assembly=\"DevExpress.Web.ASPxTreeList.v20.2, Version=20" +
                    ".1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r\n        <add assem" +
                    "bly=\"DevExpress.Web.ASPxThemes.v20.2, Version=20.2.4.0, Culture=neutral, PublicK" +
                    "eyToken=b88d1754d700e49a\" />\r\n        <add assembly=\"DevExpress.Xpo.v20.2, Versi" +
                    "on=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r\n        <add " +
                    "assembly=\"DevExpress.ExpressApp.Xpo.v20.2, Version=20.2.4.0, Culture=neutral, Pu" +
                    "blicKeyToken=b88d1754d700e49a\" />\r\n      <add assembly=\"DevExpress.RichEdit.v20." +
                    "1.Core, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\" />\r\n" +
                    "\t  <!--//report#7-->\r\n\t  ");
            
            #line 126 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebConfig.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write(@"	  	<add assembly=""DevExpress.ExpressApp.ReportsV2.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
				<add assembly=""DevExpress.XtraReports.v20.2.Web, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
				<add assembly=""DevExpress.XtraReports.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
				<add assembly=""DevExpress.XtraReports.v20.2.Extensions, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
				<add assembly=""DevExpress.ExpressApp.ReportsV2.Web.v20.2, Version=20.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"" />
");
            
            #line 132 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebConfig.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t  </assemblies>\r\n    </compilation>\r\n    <!--\r\n    The <authentication> section " +
                    "enables configuration\r\n    of the security authentication mode used by\r\n    ASP." +
                    "NET to identify an incoming user.\r\n    -->\r\n    <identity impersonate=\"true\" />\r" +
                    "\n    <authentication mode=\"Forms\">\r\n      <forms name=\"Login\" loginUrl=\"Login.as" +
                    "px\" path=\"/\" timeout=\"10\" />\r\n    </authentication>\r\n    <authorization>\r\n      " +
                    "<deny users=\"?\" />\r\n      <allow users=\"*\" />\r\n    </authorization>\r\n    <!--\r\n " +
                    "   The <customErrors> section enables configuration\r\n    of what to do if/when a" +
                    "n unhandled error occurs\r\n    during the execution of a request. Specifically,\r\n" +
                    "    it enables developers to configure html error pages\r\n    to be displayed in " +
                    "place of a error stack trace.\r\n\r\n    <customErrors mode=\"RemoteOnly\" defaultRedi" +
                    "rect=\"GenericErrorPage.htm\">\r\n      <error statusCode=\"403\" redirect=\"NoAccess.h" +
                    "tm\" />\r\n      <error statusCode=\"404\" redirect=\"FileNotFound.htm\" />\r\n    </cust" +
                    "omErrors>\r\n    -->\r\n  </system.web>\r\n  <!-- For applications with a security sys" +
                    "tem -->\r\n  <location path=\"DXX.axd\">\r\n    <system.web>\r\n      <authorization>\r\n " +
                    "       <allow users=\"?\" />\r\n      </authorization>\r\n    </system.web>\r\n  </locat" +
                    "ion>\r\n  <location path=\"Error.aspx\">\r\n    <system.web>\r\n      <authorization>\r\n " +
                    "       <allow users=\"?\" />\r\n      </authorization>\r\n    </system.web>\r\n  </locat" +
                    "ion>\r\n  <location path=\"Images\">\r\n    <system.web>\r\n      <authorization>\r\n     " +
                    "   <allow users=\"?\" />\r\n      </authorization>\r\n    </system.web>\r\n  </location>" +
                    "\r\n</configuration>");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
