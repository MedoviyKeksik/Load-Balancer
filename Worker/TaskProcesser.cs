using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Worker
{
    public static class TaskProcesser
    {
        public static int WaitMilliseconds = Int32.MaxValue;

        private static byte[] LoadFile(string filename)
        {
            byte[] buffer;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer);
            }

            return buffer;
        }

        public static void ProcessTask(ref LoadBalancer.Task task)
        {
            string command = task.Command;
            string executeFolder = "Methods\\" + command + "\\";
            string configPath = executeFolder + "\\Config.json";
            string jsonStr = Encoding.UTF8.GetString(LoadFile(configPath));
            Config config = JsonSerializer.Deserialize<Config>(jsonStr);
            using (Process process = new Process())
            {
                process.StartInfo.FileName = executeFolder + "\\" + config.Executable;
                if (config.Arguments != null)
                    process.StartInfo.Arguments += string.Join(" ", config.Arguments) + " ";
                if (task.Arguments != null)
                    process.StartInfo.Arguments += task.Arguments;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WorkingDirectory = executeFolder;
                process.Start();
                process.WaitForExit(WaitMilliseconds);
                StreamReader resultStream;
                if (config.OutputFile == null)
                {
                    resultStream = process.StandardOutput;
                }
                else
                {
                    resultStream = new StreamReader(executeFolder + "\\" + config.OutputFile);
                }

                task.ExitCode = process.ExitCode;
                task.Result = resultStream.ReadToEnd();
                resultStream.Dispose();
                process.Kill();
            }
        }
    }
}