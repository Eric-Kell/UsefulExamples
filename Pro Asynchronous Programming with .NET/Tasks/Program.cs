using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{

  class Program
  {
    static void Main(string[] args)
    {
      Task<string> downloadTask = DownloadWebPageAsync("http://xvideos.com");
      while (!downloadTask.IsCompleted)
      {
        Console.Write(".");
        Thread.Sleep(250);
      }
      Console.WriteLine(downloadTask.Result);
    }

    private static Task<string> DownloadWebPageAsync(string url)
    {
      return Task.Factory.StartNew(() => DownloadWebPage(url));
    }

    private static string DownloadWebPage(string url)
    {
      WebRequest request = WebRequest.Create(url);
      WebResponse response = request.GetResponse();
      var reader = new StreamReader(response.GetResponseStream());
      {
        // this will return the content of the web page
        return reader.ReadToEnd();
      }
    }

  }
}
