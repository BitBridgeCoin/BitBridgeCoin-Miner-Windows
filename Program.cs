using System;
using System.Diagnostics;

namespace bitbridgecoinminer
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("bitbridgecoind.exe");
            p.StartInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory().ToString();
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            string output = string.Empty;
            while (true) {
                Process q = new Process();
                q.StartInfo = new ProcessStartInfo("bitbridgecoin-cli.exe");
                q.StartInfo.Arguments = "generate 1";
                q.StartInfo.WorkingDirectory = System.IO.Directory.GetCurrentDirectory().ToString();
                q.StartInfo.UseShellExecute = false;
                q.StartInfo.RedirectStandardOutput = true;
                q.Start();
                output = await q.StandardOutput.ReadToEndAsync();
                if(output.Length > 20)
                    Console.WriteLine(output);
                q.WaitForExit();
            }

        }
    }
}
