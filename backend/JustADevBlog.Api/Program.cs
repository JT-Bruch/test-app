using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace JustADevBlog.Api
{
  /// <summary>
  /// 
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static IWebHost BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseApplicationInsights()
        .UseStartup<Startup>()
        .Build();
  }
}