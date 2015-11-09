using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
  class Program
  {

    /*
    Суть в том, что Task делается в BackGround и если нету никаких ForeGround, то прога
    завершится не дожидаясь окончания такски из BackGround
    */

    static void Main(string[] args)
    {
      Task.Factory
      .StartNew(WhatTypeOfThreadAmI, TaskCreationOptions.LongRunning)
      .Wait();
    }

    private static void WhatTypeOfThreadAmI()
    {
      Console.WriteLine("I'm a {0} thread",
      Thread.CurrentThread.IsThreadPoolThread ? "Thread Pool" : "Custom");
    }
  }
}
