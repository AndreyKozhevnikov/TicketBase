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
    
    #line 1 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class WinApplicationDesigner : BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 FileName=@"\{0}.Win\WinApplication.Designer.cs"; 
            
            #line default
            #line hidden
            this.Write(@"
namespace dxTestSolution.Win {
    partial class dxTestSolutionWindowsFormsApplication {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name=""disposing"">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule();
            this.module3 = new dxTestSolution.Module.dxTestSolutionModule();
            this.module4 = new dxTestSolution.Module.Win.dxTestSolutionWindowsFormsModule();
			");
            
            #line 37 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"			this.securityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
            this.securityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
            this.authenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
			");
            
            #line 41 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 42 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write("            this.reportsModuleV21 = new DevExpress.ExpressApp.ReportsV2.ReportsMo" +
                    "duleV2();\r\n            this.reportsWindowsFormsModuleV21 = new DevExpress.Expres" +
                    "sApp.ReportsV2.Win.ReportsWindowsFormsModuleV2();\r\n            ");
            
            #line 45 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 46 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write("\t    \tthis.officeModule1 = new DevExpress.ExpressApp.Office.OfficeModule();\r\n\t\t\tt" +
                    "his.officeWindowsFormsModule1 = new DevExpress.ExpressApp.Office.Win.OfficeWindo" +
                    "wsFormsModule();\r\n            ");
            
            #line 49 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\r\n            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();\r\n\t" +
                    "\t\r\n\t\t\t");
            
            #line 53 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
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
            
            #line 68 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 69 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write(@"            // 
            // reportsModuleV21
            // 
            this.reportsModuleV21.EnableInplaceReports = true;
            this.reportsModuleV21.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
			this.reportsModuleV21.ReportStoreMode = DevExpress.ExpressApp.ReportsV2.ReportStoreModes.XML;
			
			
    
            ");
            
            #line 79 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 80 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write("\t\t\t this.officeModule1.RichTextMailMergeDataType = typeof(DevExpress.Persistent.B" +
                    "aseImpl.RichTextMailMergeData);\r\n            ");
            
            #line 82 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"            // 
            // dxTestSolutionWindowsFormsApplication
            // 
            this.ApplicationName = ""dxTestSolution"";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
		    this.Modules.Add(this.module3);
            this.Modules.Add(this.module4);
			");
            
            #line 92 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write("            this.Modules.Add(this.reportsModuleV21);\r\n            this.Modules.Ad" +
                    "d(this.reportsWindowsFormsModuleV21);\r\n\t\t\t");
            
            #line 95 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 96 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write("\t\t\tthis.Modules.Add(this.officeModule1);\r\n\t\t\tthis.Modules.Add(this.officeWindowsF" +
                    "ormsModule1);\r\n\t\t\t");
            
            #line 99 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 100 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("            this.Modules.Add(this.securityModule1);\r\n            this.Security = " +
                    "this.securityStrategyComplex1;\r\n\t\t\t");
            
            #line 103 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"
            this.UseOldTemplates = false;
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.dxTestSolutionWindowsFormsApplication_DatabaseVersionMismatch);
            this.CustomizeLanguagesList += new System.EventHandler<DevExpress.ExpressApp.CustomizeLanguagesListEventArgs>(this.dxTestSolutionWindowsFormsApplication_CustomizeLanguagesList);

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule module2;
        private dxTestSolution.Module.dxTestSolutionModule module3;
        private dxTestSolution.Module.Win.dxTestSolutionWindowsFormsModule module4;

		");
            
            #line 120 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasReports){ 
            
            #line default
            #line hidden
            this.Write("        private DevExpress.ExpressApp.ReportsV2.ReportsModuleV2 reportsModuleV21;" +
                    "\r\n        private DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV" +
                    "2 reportsWindowsFormsModuleV21;\r\n\t\t");
            
            #line 123 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 124 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasOffice){ 
            
            #line default
            #line hidden
            this.Write("        private DevExpress.ExpressApp.Office.Win.OfficeWindowsFormsModule officeW" +
                    "indowsFormsModule1;\r\n        private DevExpress.ExpressApp.Office.OfficeModule o" +
                    "fficeModule1;\r\n\t\t");
            
            #line 127 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 128 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"        private DevExpress.ExpressApp.Security.SecurityStrategyComplex securityStrategyComplex1;
        private DevExpress.ExpressApp.Security.AuthenticationStandard authenticationStandard1;
        private DevExpress.ExpressApp.Security.SecurityModule securityModule1;
		");
            
            #line 132 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\WinApplicationDesigner.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
