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
    
    #line 1 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class WebModule : BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 FileName=@"\{0}.Module.Web\WebModule.cs"; 
            
            #line default
            #line hidden
            this.Write(@"
using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Persistent.BaseImpl;
using dxTestSolution.Module.BusinessObjects;

namespace dxTestSolution.Module.Web {
    [ToolboxItemFilter(""Xaf.Platform.Web"")]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class dxTestSolutionAspNetModule : ModuleBase {
        public dxTestSolutionAspNetModule() {
            InitializeComponent();
		
");
            
            #line 32 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 if (HasValidation){ 
            
            #line default
            #line hidden
            this.Write("this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.Web.Validati" +
                    "onAspNetModule));\r\n");
            
            #line 34 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 } 
            
            #line default
            #line hidden
            
            #line 35 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write("this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Office.Web.OfficeAspNet" +
                    "Module));\r\n");
            
            #line 37 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 } 
            
            #line default
            #line hidden
            
            #line 38 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write("this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.Web.ReportsAs" +
                    "pNetModuleV2));\r\n");
            
            #line 40 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            return ModuleUpdater.EmptyModuleUpdaters;
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
			
			");
            
            #line 48 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tapplication.CreateCustomModelDifferenceStore += Application_CreateCustomModelD" +
                    "ifferenceStore;\r\n            application.CreateCustomUserModelDifferenceStore +=" +
                    " Application_CreateCustomUserModelDifferenceStore;\r\n");
            
            #line 51 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            // Manage various aspects of the application UI and behavior at the m" +
                    "odule level.\r\n        }\r\n\t\t\r\n\t\t");
            
            #line 55 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"		  private void Application_CreateCustomModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, ""Web"");
            e.Handled = true;
        }
        private void Application_CreateCustomUserModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), false, ""Web"");
            e.Handled = true;
        }
");
            
            #line 64 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WebModule.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
