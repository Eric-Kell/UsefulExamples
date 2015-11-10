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
    public interface IImport
    {
      Task ImportXmlFilesAsync(string dataDirectory);
      Task ImportXmlFilesAsync(string dataDirectory, CancellationToken ct);
    }

    public static void DataImport(IImport import)
    {
      var tcs = new CancellationTokenSource();
      CancellationToken ct = tcs.Token;
      Task importTask = import.ImportXmlFilesAsync(@"C:\data", ct);
      while (!importTask.IsCompleted)
      {
        Console.Write(".");
        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
        {
          tcs.Cancel();
        }
        Thread.Sleep(250);
      }
    }



  }
}
