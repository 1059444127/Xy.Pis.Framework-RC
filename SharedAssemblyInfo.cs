﻿using System.Reflection;

[assembly: AssemblyCompany("广州市行心信息科技有限公司")]
[assembly: AssemblyProduct("PIS")]
[assembly: AssemblyCopyright("© Copyright 2016 PIS Team. All rights reserved.")]

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
[assembly: AssemblyVersion(ProductVersion.VersionString)]
[assembly: AssemblyInformationalVersion(ProductVersion.InformationalVersion)]

internal static class ProductVersion
{
    public const string VersionString = "3.0.0.28";

    public const string InformationalVersion = VersionString;
}