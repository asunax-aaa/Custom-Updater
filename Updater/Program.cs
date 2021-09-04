using System;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 4)
                return;

            string processPath = args[0];
            string processName = args[1];
            string processUrl = args[2];
            string[] entries = args[3].Split('|');

            if (entries.Length % 2 == 1)
                return;

            Download(processPath, processName, processUrl, entries)
                .GetAwaiter().GetResult();

            Environment.Exit(0);
        }

        private static async Task Download(string procPath, string procName, string procUrl, string[] entries)
        {
            string _procPath = Path.Combine(procPath, procName);
            if (File.Exists(_procPath))
                File.Delete(_procPath);

            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync(procUrl, _procPath);

                for (int i = 0; i <= entries.Length / 2; i += 2)
                {
                    string url = entries[i];
                    string path = entries[i + 1];

                    if (File.Exists(path))
                        File.Delete(path);

                    await client.DownloadFileTaskAsync(url, path);
                }
            }

            var proc = new Process();
            proc.StartInfo.FileName = procName;
            //proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WorkingDirectory = procPath;
            proc.Start();
        }
    }
}
