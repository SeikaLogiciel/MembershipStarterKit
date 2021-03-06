﻿using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

[assembly: AllowPartiallyTrustedCallers]
[assembly: CLSCompliant(true)]

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.

[assembly: AssemblyTitle("ASP.Net MVC Membership Starter Kit")]
[assembly: AssemblyDescription("<![CDATA[The starter kit provides the Asp.Net MVC controllers, models, and views needed to administer users & roles. This package contains classes needed by the MvcMembership.Mvc package to provide a testable interface to ASP.Net's MembershipProvider and RoleProvider features.]]>")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Troy Goode")]
[assembly: AssemblyProduct("ASP.Net MVC Membership Starter Kit")]
[assembly: AssemblyCopyright("Copyright © Troy Goode 2008-2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Fix for error with MVC 5:
// Compiling transformation: The type or namespace name 'MvcTextTemplateHost'
// could not be found (are you missing a using directive or an assembly reference
[assembly: SecurityRules(SecurityRuleSet.Level1)]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: Guid("c798dae9-9f47-480b-af1b-984f856cb38d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("4.0.0")]
[assembly: AssemblyFileVersion("4.0.0")]
