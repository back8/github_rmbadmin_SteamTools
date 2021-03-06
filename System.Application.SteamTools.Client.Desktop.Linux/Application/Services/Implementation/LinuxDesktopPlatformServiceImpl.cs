﻿using System.Application.Models;
using System.Diagnostics;
using System.IO;

namespace System.Application.Services.Implementation
{
    internal sealed class LinuxDesktopPlatformServiceImpl : IDesktopPlatformService
    {
        public void SetResizeMode(IntPtr hWnd, int value)
        {
        }

        public string GetCommandLineArgs(Process process)
        {
            return string.Empty;
        }

        public const string kate = "kate";
        public const string vi = "vi";

        public string? GetFileName(TextReaderProvider provider)
        {
            return vi;
        }

        public void SetBootAutoStart(bool isAutoStart, string name)
        {

        }

        public string? GetSteamDirPath()
        {
            return null;
        }

        public string? GetSteamProgramPath()
        {
            return null;
        }

        public string GetLastSteamLoginUserName() => string.Empty;

        public void SetCurrentUser(string userName) { }

        static string GetMachineSecretKey()
        {
            var filePath = "/etc/machine-id";
            return File.ReadAllText(filePath);
        }

        static readonly Lazy<(byte[] key, byte[] iv)> mMachineSecretKey = IDesktopPlatformService.GetMachineSecretKey(GetMachineSecretKey);

        public (byte[] key, byte[] iv) MachineSecretKey => mMachineSecretKey.Value;
    }
}