using System;
using System.IO;
using System.Runtime.InteropServices;

using UnityEditor;

namespace UnityEditor.XR.MagicLeap
{
    internal static class SDKUtility
    {
        const string kManifestPath = ".metadata/sdk.manifest";

        static class Native
        {
            const string Library = "UnityMagicLeap";

            [DllImport("UnityMagicLeap", EntryPoint = "UnityMagicLeap_PlatformGetAPILevel")]
            public static extern uint GetAPILevel();
        }

        public static bool isCompatibleSDK
        {
            get
            {
                var min = pluginAPILevel;
                var max = sdkAPILevel;
                return min <= max;
            }
        }
        public static int pluginAPILevel
        {
            get
            {
                return (int)Native.GetAPILevel();
            }
        }
        public static int sdkAPILevel
        {
            get
            {
                return PrivilegeParser.ParsePlatformLevelFromHeader(Path.Combine(SDKUtility.sdkPath, PrivilegeParser.kPlatformHeaderPath));
            }
        }
        public static bool sdkAvailable
        {
            get
            {
                if (string.IsNullOrEmpty(sdkPath)) return false;
                return File.Exists(Path.Combine(sdkPath, kManifestPath));
            }
        }
        public static string sdkPath
        {
            get
            {
                return EditorPrefs.GetString("LuminSDKRoot", null);
            }
        }
    }
}