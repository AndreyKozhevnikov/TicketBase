﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
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
    
    #line 1 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class WinApplication : BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
 FileName=@"\{0}.Win\WinApplication.cs"; 
            
            #line default
            #line hidden
            this.Write(@"
using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using System.Collections.Generic;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Security;
");
            
            #line 16 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("using DevExpress.ExpressApp.Security.ClientServer;\r\n ");
            
            #line 18 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"
namespace dxTestSolution.Win {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWinWinApplicationMembersTopicAll.aspx
    public partial class dxTestSolutionWindowsFormsApplication : WinApplication {
        #region Default XAF configuration options (https://www.devexpress.com/kb=T501418)
        static dxTestSolutionWindowsFormsApplication() {
            DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = true;
            DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = false;
			DevExpress.ExpressApp.Utils.ImageLoader.Instance.UseSvgImages = true;
        }
        private void InitializeDefaults() {
            LinkNewObjectToParentImmediately = false;
            OptimizedControllersCreation = true;
			UseLightStyle = true;
        }
        #endregion
        public dxTestSolutionWindowsFormsApplication() {
            InitializeComponent();
			InitializeDefaults();
			");
            
            #line 38 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tthis.LastLogonParametersRead += MyApplication_LastLogonParametersRead;\r\n\t\t\t");
            
            #line 40 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t\r\n        }\r\n\t\t");
            
            #line 43 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"		private void MyApplication_LastLogonParametersRead(object sender, LastLogonParametersReadEventArgs e) {
              AuthenticationStandardLogonParameters logonParameters = e.LogonObject as AuthenticationStandardLogonParameters;
              if(logonParameters != null) {
                if(String.IsNullOrEmpty(logonParameters.UserName)) {
                    logonParameters.UserName = ""Admin"";
                }
              }
        }
		");
            
            #line 52 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"		
        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args) {
            IObjectSpaceProvider provider;
            if(dxTestSolution.Module.dxTestSolutionModule.UseInMemoryStore) {
                provider = new XPObjectSpaceProvider(InMemoryDataStoreProvider.ConnectionString, null, false);
            } else {
                provider = new XPObjectSpaceProvider(XPObjectSpaceProvider.GetDataStoreProvider(args.ConnectionString, args.Connection, true), false);
            }
			");
            
            #line 61 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tprovider = new SecuredObjectSpaceProvider((SecurityStrategyComplex)Security, X" +
                    "PObjectSpaceProvider.GetDataStoreProvider(args.ConnectionString, args.Connection" +
                    ", true), false);\r\n\t\t\t");
            
            #line 63 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplication.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n            args.ObjectSpaceProviders.Add(provider);\r\n            args.ObjectSp" +
                    "aceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));\r\n      " +
                    "  }\r\n        private void dxTestSolutionWindowsFormsApplication_CustomizeLanguag" +
                    "esList(object sender, CustomizeLanguagesListEventArgs e) {\r\n            string u" +
                    "serLanguageName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;\r\n" +
                    "            if(userLanguageName != \"en-US\" && e.Languages.IndexOf(userLanguageNa" +
                    "me) == -1) {\r\n                e.Languages.Add(userLanguageName);\r\n            }\r" +
                    "\n        }\r\n        private void dxTestSolutionWindowsFormsApplication_DatabaseV" +
                    "ersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEvent" +
                    "Args e) {\r\n#if EASYTEST\r\n            e.Updater.Update();\r\n            e.Handled " +
                    "= true;\r\n#else\r\n            if(System.Diagnostics.Debugger.IsAttached) {\r\n      " +
                    "          e.Updater.Update();\r\n                e.Handled = true;\r\n            }\r" +
                    "\n            else {\r\n\t\t\t\tstring message = \"The application cannot connect to the" +
                    " specified database, \" +\r\n\t\t\t\t\t\"because the database doesn\'t exist, its version " +
                    "is older \" +\r\n\t\t\t\t\t\"than that of the application or its schema does not match \" " +
                    "+\r\n\t\t\t\t\t\"the ORM data model structure. To avoid this error, use one \" +\r\n\t\t\t\t\t\"o" +
                    "f the solutions from the https://www.devexpress.com/kb=T367835 KB Article.\";\r\n\r\n" +
                    "\t\t\t\tif(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {" +
                    "\r\n\t\t\t\t\tmessage += \"\\r\\n\\r\\nInner exception: \" + e.CompatibilityError.Exception.M" +
                    "essage;\r\n\t\t\t\t}\r\n\t\t\t\tthrow new InvalidOperationException(message);\r\n            }" +
                    "\r\n#endif\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
