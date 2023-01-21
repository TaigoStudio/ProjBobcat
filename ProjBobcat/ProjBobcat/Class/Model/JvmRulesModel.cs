﻿using System;
using Newtonsoft.Json;
using ProjBobcat.Class.Helper.SystemInfo;

namespace ProjBobcat.Class.Model;

public class OperatingSystemRules
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("version")] public string Version { get; set; }

    [JsonProperty("arch")] public string Arch { get; set; }

    public bool IsAllow()
    {
        if (!string.IsNullOrEmpty(Name) &&
            !Name.Equals(Constants.OsSymbol, StringComparison.OrdinalIgnoreCase)) return false;
        if (!string.IsNullOrEmpty(Arch) && Arch != SystemArch.CurrentArch.ToString()) return false;
#if WINDOWS
        if (!string.IsNullOrEmpty(Version) && Version != $"^{WindowsSystemVersion.CurrentVersion}\\.") return false;
#endif

        return true;
    }
}

/// <summary>
///     Jvm规则类
/// </summary>
public class JvmRules
{
    /// <summary>
    ///     需要执行的操作
    /// </summary>
    [JsonProperty("action")]
    public string? Action { get; set; }

    /// <summary>
    ///     使用的操作系统集合
    /// </summary>
    [JsonProperty("os")]
    public OperatingSystemRules? OperatingSystem { get; set; }
}