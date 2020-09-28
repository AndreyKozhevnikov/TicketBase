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
    
    #line 1 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class WebApplication : BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 FileName=@"\{0}.Web\WebApplication.cs"; 
            
            #line default
            #line hidden
            this.Write("\r\nusing System;\r\nusing DevExpress.ExpressApp;\r\nusing System.ComponentModel;\r\nusin" +
                    "g DevExpress.ExpressApp.Web;\r\nusing System.Collections.Generic;\r\nusing DevExpres" +
                    "s.ExpressApp.Xpo;\r\n");
            
            #line 14 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("using DevExpress.ExpressApp.Security.ClientServer;\r\n");
            
            #line 16 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"using DevExpress.ExpressApp.Security;

namespace dxTestSolution.Web {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWebWebApplicationMembersTopicAll.aspx
    public partial class dxTestSolutionAspNetApplication : WebApplication {
        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
        private dxTestSolution.Module.dxTestSolutionModule module3;
		//secur#1#
		//report#10
		//office#15#
		
");
            
            #line 29 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write("   private DevExpress.ExpressApp.ReportsV2.ReportsModuleV2 reportsModuleV21;\r\n   " +
                    "     private DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2 reportsAs" +
                    "pNetModuleV21;\r\n");
            
            #line 32 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            
            #line 33 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write("     private DevExpress.ExpressApp.Office.OfficeModule officeModule1;\r\n        pr" +
                    "ivate DevExpress.ExpressApp.Office.Web.OfficeAspNetModule officeAspNetModule1;\r\n" +
                    "");
            
            #line 36 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            
            #line 37 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"		
        private DevExpress.ExpressApp.Security.SecurityStrategyComplex securityStrategyComplex1;
        private DevExpress.ExpressApp.Security.AuthenticationStandard authenticationStandard1;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
");
            
            #line 42 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write("        private dxTestSolution.Module.Web.dxTestSolutionAspNetModule module4;\r\n\r\n" +
                    "        #region Default XAF configuration options (https://www.devexpress.com/kb" +
                    "=T501418)\r\n        static dxTestSolutionAspNetApplication() {\r\n\t\t\tEnableMultiple" +
                    "BrowserTabsSupport = true;\r\n            DevExpress.ExpressApp.Web.Editors.ASPx.A" +
                    "SPxGridListEditor.AllowFilterControlHierarchy = true;\r\n            DevExpress.Ex" +
                    "pressApp.Web.Editors.ASPx.ASPxGridListEditor.MaxFilterControlHierarchyDepth = 3;" +
                    "\r\n            DevExpress.ExpressApp.Web.Editors.ASPx.ASPxCriteriaPropertyEditor." +
                    "AllowFilterControlHierarchyDefault = true;\r\n            DevExpress.ExpressApp.We" +
                    "b.Editors.ASPx.ASPxCriteriaPropertyEditor.MaxHierarchyDepthDefault = 3;\r\n       " +
                    "     DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = true;\r\n   " +
                    "         DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = " +
                    "false;\r\n        }\r\n        private void InitializeDefaults() {\r\n            Link" +
                    "NewObjectToParentImmediately = false;\r\n            OptimizedControllersCreation " +
                    "= true;\r\n        }\r\n        #endregion\r\n        public dxTestSolutionAspNetAppli" +
                    "cation() {\r\n            InitializeComponent();\r\n\t\t\tInitializeDefaults();\r\n      " +
                    "  }\r\n\t\tprotected override IViewUrlManager CreateViewUrlManager() {\r\n            " +
                    "return new ViewUrlManager();\r\n        }\r\n        protected override void CreateD" +
                    "efaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {\r\n    " +
                    "        IObjectSpaceProvider provider;\r\n            if(dxTestSolution.Module.dxT" +
                    "estSolutionModule.UseInMemoryStore) {\r\n                provider = new XPObjectSp" +
                    "aceProvider(InMemoryDataStoreProvider.ConnectionString, null, false);\r\n         " +
                    "   } else {\r\n                provider = new XPObjectSpaceProvider(XPObjectSpaceP" +
                    "rovider.GetDataStoreProvider(args.ConnectionString, args.Connection, true), fals" +
                    "e);\r\n            }\r\n\t\t\t\r\n\t\t\t");
            
            #line 75 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tprovider = new SecuredObjectSpaceProvider((SecurityStrategyComplex)Security, X" +
                    "PObjectSpaceProvider.GetDataStoreProvider(args.ConnectionString, args.Connection" +
                    ", true), false);\r\n");
            
            #line 77 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            args.ObjectSpaceProviders.Add(provider);\r\n            args.ObjectSpac" +
                    "eProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));\r\n        " +
                    "}\r\n        private IXpoDataStoreProvider GetDataStoreProvider(string connectionS" +
                    "tring, System.Data.IDbConnection connection) {\r\n            System.Web.HttpAppli" +
                    "cationState application = (System.Web.HttpContext.Current != null) ? System.Web." +
                    "HttpContext.Current.Application : null;\r\n            IXpoDataStoreProvider dataS" +
                    "toreProvider = null;\r\n            if(application != null && application[\"DataSto" +
                    "reProvider\"] != null) {\r\n                dataStoreProvider = application[\"DataSt" +
                    "oreProvider\"] as IXpoDataStoreProvider;\r\n            }\r\n            else {\r\n    " +
                    "            dataStoreProvider = XPObjectSpaceProvider.GetDataStoreProvider(conne" +
                    "ctionString, connection, true);\r\n                if(application != null) {\r\n    " +
                    "                application[\"DataStoreProvider\"] = dataStoreProvider;\r\n         " +
                    "       }\r\n            }\r\n\t\t\treturn dataStoreProvider;\r\n        }\r\n        privat" +
                    "e void dxTestSolutionAspNetApplication_DatabaseVersionMismatch(object sender, De" +
                    "vExpress.ExpressApp.DatabaseVersionMismatchEventArgs e) {\r\n#if EASYTEST\r\n       " +
                    "     e.Updater.Update();\r\n            e.Handled = true;\r\n#else\r\n            if(S" +
                    "ystem.Diagnostics.Debugger.IsAttached) {\r\n                e.Updater.Update();\r\n " +
                    "               e.Handled = true;\r\n            }\r\n            else {\r\n\t\t\t\tstring " +
                    "message = \"The application cannot connect to the specified database, \" +\r\n\t\t\t\t\t\"" +
                    "because the database doesn\'t exist, its version is older \" +\r\n\t\t\t\t\t\"than that of" +
                    " the application or its schema does not match \" +\r\n\t\t\t\t\t\"the ORM data model stru" +
                    "cture. To avoid this error, use one \" +\r\n\t\t\t\t\t\"of the solutions from the https:/" +
                    "/www.devexpress.com/kb=T367835 KB Article.\";\r\n\r\n                if(e.Compatibili" +
                    "tyError != null && e.CompatibilityError.Exception != null) {\r\n                  " +
                    "  message += \"\\r\\n\\r\\nInner exception: \" + e.CompatibilityError.Exception.Messag" +
                    "e;\r\n                }\r\n                throw new InvalidOperationException(messa" +
                    "ge);\r\n            }\r\n#endif\r\n        }\r\n        private void InitializeComponent" +
                    "() {\r\n            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemMo" +
                    "dule();\r\n            this.module2 = new DevExpress.ExpressApp.Web.SystemModule.S" +
                    "ystemAspNetModule();\r\n            this.module3 = new dxTestSolution.Module.dxTes" +
                    "tSolutionModule();\r\n            this.module4 = new dxTestSolution.Module.Web.dxT" +
                    "estSolutionAspNetModule();\r\n\t\t\t//secur#2\r\n\t\t\t//report#11\r\n\t        //office#12#\r" +
                    "\n\t\t\t");
            
            #line 126 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write("\t\t\t  this.reportsModuleV21 = new DevExpress.ExpressApp.ReportsV2.ReportsModuleV2(" +
                    ");\r\n            this.reportsAspNetModuleV21 = new DevExpress.ExpressApp.ReportsV" +
                    "2.Web.ReportsAspNetModuleV2();\r\n");
            
            #line 129 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            
            #line 130 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write("    this.officeModule1 = new DevExpress.ExpressApp.Office.OfficeModule();\r\n    th" +
                    "is.officeAspNetModule1 = new DevExpress.ExpressApp.Office.Web.OfficeAspNetModule" +
                    "();\r\n");
            
            #line 133 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            
            #line 134 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"            this.securityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.authenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
");
            
            #line 138 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();\r\n\t\t\t/" +
                    "/office#14#\r\n\t\t\t//secur#3\r\n\t\t\t//report#12\r\n\t\t\t");
            
            #line 143 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write(@"			      // 
            // reportsModuleV21
            // 
            this.reportsModuleV21.EnableInplaceReports = true;
            this.reportsModuleV21.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
			this.reportsModuleV21.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
            // 

			// reportsAspNetModuleV21
            // 
            this.reportsAspNetModuleV21.ReportViewerType = DevExpress.ExpressApp.ReportsV2.Web.ReportViewerTypes.HTML5;
            // 

			
");
            
            #line 158 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            
            #line 159 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write("     this.officeModule1.RichTextMailMergeDataType = typeof(DevExpress.Persistent." +
                    "BaseImpl.RichTextMailMergeData);\r\n");
            
            #line 161 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            
            #line 162 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"        		
             // 
            // securityStrategyComplex1
            // 
            this.securityStrategyComplex1.Authentication = this.authenticationStandard1;
            this.securityStrategyComplex1.RoleType = typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyRole);
            this.securityStrategyComplex1.UsePermissionRequestProcessor = false;
            this.securityStrategyComplex1.SupportNavigationPermissionsForTypes = false;
            this.securityStrategyComplex1.UserType = typeof(DevExpress.Persistent.BaseImpl.PermissionPolicy.PermissionPolicyUser);
            // 
            // authenticationStandard1
            //
            this.authenticationStandard1.LogonParametersType = typeof(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters);
            // 
");
            
            #line 177 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"			
            // 
            // dxTestSolutionAspNetApplication
            // 
            this.ApplicationName = ""dxTestSolution"";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
			//report#14
            this.Modules.Add(this.module3);
			//office#13#
            this.Modules.Add(this.module4);
			//secur#4
			");
            
            #line 191 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write("\t\t\t               this.Modules.Add(this.reportsModuleV21);\r\n            this.Modu" +
                    "les.Add(this.reportsAspNetModuleV21);\r\n");
            
            #line 194 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            
            #line 195 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write(" this.Modules.Add(this.officeModule1);\r\n         this.Modules.Add(this.officeAspN" +
                    "etModule1);\r\n");
            
            #line 198 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            
            #line 199 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("        this.Modules.Add(this.securityModule1);\r\n            this.Security = this" +
                    ".securityStrategyComplex1;\r\n");
            
            #line 202 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.dxTestSolutionAspNetApplication_DatabaseVersionMismatch);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
    }
}
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
