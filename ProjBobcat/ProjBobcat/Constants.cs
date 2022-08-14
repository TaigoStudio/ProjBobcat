﻿namespace ProjBobcat;

public static class Constants
{
#if WINDOWS
    public const string JavaExecutable = "javaw.exe";
    public const string OsSymbol = "windows";
#elif OSX
    public const string JavaExecutable = "javaw";
    public const string OsSymbol = "osx";
#elif LINUX
    public const string JavaExecutable = "javaw";
    public const string OsSymbol = "linux";
#endif
}