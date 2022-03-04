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
    
    #line 1 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\Updater.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class Updater : BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 6 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\Updater.tt"
 FileName=@"\{0}.Module\DatabaseUpdate\Updater.cs"; 
            
            #line default
            #line hidden
            this.Write(@"using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

using dxTestSolution.Module.BusinessObjects;

namespace dxTestSolution.Module.DatabaseUpdate {
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            var cnt = ObjectSpace.GetObjects<Contact>().Count;
            if(cnt > 0) {
                return;
            }
            for (int i = 0; i < 2; i++) {
                string contactName = ""FirstName"" + i;
                var contact = CreateObject<Contact>(""FirstName"", contactName);
                contact.LastName = ""LastName"" + i;
				contact.Age = i * 10;
                for(int j = 0; j < 2; j++) {
                    string taskName = ""Subject"" + i + "" - "" + j;
                    var task = CreateObject<MyTask>(""Subject"", taskName);
                    task.AssignedTo = contact;
                }
            }
			 ");
            
            #line 43 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\Updater.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write(@"            PermissionPolicyRole adminRole = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryOperator(""Name"", SecurityStrategy.AdministratorRoleName));
            if(adminRole == null) {
                adminRole = CreateAdministratorRole();
			}

            PermissionPolicyRole userRole = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryOperator(""Name"", ""Users""));
            if(userRole == null) {
                userRole = CreateUsersRole();
            }

            PermissionPolicyUser adminUser = ObjectSpace.FindObject<PermissionPolicyUser>(new BinaryOperator(""UserName"", ""Admin""));
            if(adminUser == null) {
                adminUser = ObjectSpace.CreateObject<PermissionPolicyUser>();
                adminUser.UserName = ""Admin"";
                adminUser.SetPassword("""");
            }

            PermissionPolicyUser commonUser = ObjectSpace.FindObject<PermissionPolicyUser>(new BinaryOperator(""UserName"", ""User""));
            if(commonUser == null) {
                commonUser = ObjectSpace.CreateObject<PermissionPolicyUser>();
                commonUser.UserName = ""User"";
                commonUser.SetPassword("""");
            }

            adminUser.Roles.Add(adminRole);
            commonUser.Roles.Add(userRole);
			 ");
            
            #line 70 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\Updater.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n\t\t\tObjectSpace.CommitChanges(); \r\n        }\r\n\t\t ");
            
            #line 74 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\Updater.tt"
 if (HasSecurity){ 
            
            #line default
            #line hidden
            this.Write("        public PermissionPolicyRole CreateAdministratorRole() {\r\n            Perm" +
                    "issionPolicyRole role = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryO" +
                    "perator(\"Name\", \"Administrator\"));\r\n            if(role == null) {\r\n            " +
                    "    role = ObjectSpace.CreateObject<PermissionPolicyRole>();\r\n                ro" +
                    "le.Name = \"Administrator\";\r\n                role.PermissionPolicy = SecurityPerm" +
                    "issionPolicy.DenyAllByDefault;\r\n                role.IsAdministrative = true;\r\n " +
                    "           }\r\n            return role;\r\n        }\r\n        public PermissionPoli" +
                    "cyRole CreateUsersRole() {\r\n            PermissionPolicyRole role = ObjectSpace." +
                    "FindObject<PermissionPolicyRole>(new BinaryOperator(\"Name\", \"Users\"));\r\n        " +
                    "    if(role == null) {\r\n                role = ObjectSpace.CreateObject<Permissi" +
                    "onPolicyRole>();\r\n                role.Name = \"Users\";\r\n                role.Per" +
                    "missionPolicy = SecurityPermissionPolicy.DenyAllByDefault;\r\n                role" +
                    ".AddTypePermission<Contact>(SecurityOperations.FullAccess, SecurityPermissionSta" +
                    "te.Allow);\r\n                role.AddTypePermission<PermissionPolicyUser>(Securit" +
                    "yOperations.FullAccess, SecurityPermissionState.Deny);\r\n                role.Add" +
                    "ObjectPermission<PermissionPolicyUser>(SecurityOperations.ReadOnlyAccess, \"[Oid]" +
                    " = CurrentUserId()\", SecurityPermissionState.Allow);\r\n                role.AddMe" +
                    "mberPermission<PermissionPolicyUser>(SecurityOperations.Write, \"StoredPassword\"," +
                    " null, SecurityPermissionState.Allow);\r\n                role.AddMemberPermission" +
                    "<PermissionPolicyUser>(SecurityOperations.Write, \"ChangePasswordOnFirstLogon\", n" +
                    "ull, SecurityPermissionState.Allow);\r\n                role.AddTypePermission<Per" +
                    "missionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Allow);\r\n   " +
                    "             role.AddTypePermission<PermissionPolicyRole>(\"Write;Create;Delete;N" +
                    "avigate\", SecurityPermissionState.Deny);\r\n                role.AddTypePermission" +
                    "<PermissionPolicyTypePermissionObject>(SecurityOperations.Read, SecurityPermissi" +
                    "onState.Allow);\r\n                role.AddNavigationPermission(@\"Application/Navi" +
                    "gationItems/Items/Default/Items/Contact_ListView\", SecurityPermissionState.Allow" +
                    ");\r\n            }\r\n            return role;\r\n        }\r\n\t\t ");
            
            #line 103 "c:\Dropbox\C#\DXTicketsBase\DXTicketBase\DXTicketBase\TextTemplates\Updater.tt"
 } 
            
            #line default
            #line hidden
            this.Write(@"        T CreateObject<T>(string propertyName,string value) {
       
            T theObject = ObjectSpace.FindObject<T>(new OperandProperty(propertyName) == value);
            if (theObject == null){
                theObject = ObjectSpace.CreateObject<T>();
                ((BaseObject)(Object)theObject).SetMemberValue(propertyName, value);
            }
          
            return theObject;

        }

        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version(""1.1.0.0"") && CurrentDBVersion > new Version(""0.0.0.0"")) {
            //    RenameColumn(""DomainObject1Table"", ""OldColumnName"", ""NewColumnName"");
            //}
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
