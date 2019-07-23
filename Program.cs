using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace aspnetapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls("http://0.0.0.0:9000")
                .Configure(app => app.Run(async context =>
                {

                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine($"Environment.Version={Environment.Version}");
                    builder.AppendLine($"RuntimeInformation.FrameworkDescription={System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}");
                    builder.AppendLine($"RuntimeInformation.OSDescription={System.Runtime.InteropServices.RuntimeInformation.OSDescription}");
                    builder.AppendLine($"RuntimeInformation.OSArchitecture={System.Runtime.InteropServices.RuntimeInformation.OSArchitecture}");
                    builder.AppendLine($"RuntimeInformation.ProcessArchitecture={System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture}");
                    builder.AppendLine($"GC.GetGCMemoryInfo.HeapSizeBytes={GC.GetGCMemoryInfo().HeapSizeBytes}");
                    builder.AppendLine($"GC.GetGCMemoryInfo.MemoryLoadBytes={GC.GetGCMemoryInfo().MemoryLoadBytes}");
                    builder.AppendLine($"GC.GetGCMemoryInfo.TotalAvailableMemoryBytes={GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");
                    builder.AppendLine($"GC.GetTotalAllocatedBytes={GC.GetTotalAllocatedBytes(true)}");

                    await context.Response.WriteAsync($"Hello docker remote from ASP.NET Core!\r\n{builder.ToString()}");
                }))
                .Build();

            host.Run();
        }
    }
}