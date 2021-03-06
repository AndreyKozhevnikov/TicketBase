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
    
    #line 1 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class WinModule : BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 FileName=@"\{0}.Module.Win\WinModule.cs"; 
            
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

namespace dxTestSolution.Module.Win {
    [ToolboxItemFilter(""Xaf.Platform.Win"")]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class dxTestSolutionWindowsFormsModule : ModuleBase {
        public dxTestSolutionWindowsFormsModule() {
            InitializeComponent();
	
			");
            
            #line 32 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 if (HasValidation){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tthis.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.Win.Valid" +
                    "ationWindowsFormsModule));\r\n\t\t\t");
            
            #line 34 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 35 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tthis.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Office.Win.OfficeWin" +
                    "dowsFormsModule));\r\n\t\t\t");
            
            #line 37 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 38 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tthis.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.Win.Report" +
                    "sWindowsFormsModuleV2));\r\n\t\t\t");
            
            #line 40 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
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
            
            #line 47 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tapplication.CreateCustomModelDifferenceStore += Application_CreateCustomModelD" +
                    "ifferenceStore;\r\n            application.CreateCustomUserModelDifferenceStore +=" +
                    " Application_CreateCustomUserModelDifferenceStore;\r\n\t\t\t");
            
            #line 50 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 } 
            
            #line default
            #line hidden
            this.Write("            // Manage various aspects of the application UI and behavior at the m" +
                    "odule level.\r\n        }\r\n\t\t");
            
            #line 53 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"		 private void Application_CreateCustomUserModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), false, ""Win"");
            e.Handled = true;
        }
         private void Application_CreateCustomModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, ""Win"");
            e.Handled = true;
        }
		");
            
            #line 62 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinModule.tt"
 } 
            
            #line default
            #line hidden
            this.Write("    }\r\n}\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
