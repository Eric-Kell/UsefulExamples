using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
  class Program
  {
    private static void Main()
    {
      Task<int> firstTask = Task.Factory.StartNew<int>(() =>
      {
        Console.WriteLine("First Task");
        return 42;
      });

      Task secondTask = firstTask
        .ContinueWith(ft => Console.WriteLine("Second Task, First task returned {0}", ft.Result));
      secondTask.Wait();
    }



  }
}
