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
      Task.Factory.StartNew(() =>
      {
        Task child = Task.Factory.StartNew(() => Console.WriteLine("Nested.."),
        TaskCreationOptions.AttachedToParent);
      }).Wait();

    }



  }
}
