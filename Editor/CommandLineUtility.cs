#if UNITY_EDITOR
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;

namespace ShackLab.OpenUPM.Editor
{
    public static class CommandLineUtility
    {
        public static async Task RunCommand(string command)
        {
            await Task.Run(() =>
            {
                string projectRootPath = Path.GetDirectoryName(Application.dataPath)!;

                using var process = new Process();
                process.StartInfo = new ProcessStartInfo
                {
#if UNITY_EDITOR_WIN
                    FileName = "cmd.exe",
                    Arguments = $"/c {command}",
#elif UNITY_EDITOR_OSX || UNITY_EDITOR_LINUX
                        FileName = "/bin/bash",
                        Arguments = $"-c \"{command}\"",
#else
                        FileName = "/bin/bash",
                        Arguments = $"-c \"{command}\"",
#endif
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = projectRootPath,
                };

                process.Start();
                process.WaitForExit();
            });

            Client.Resolve();
        }
    }
}
#endif