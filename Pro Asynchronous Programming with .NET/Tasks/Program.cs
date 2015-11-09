using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
      Task t = Task.Factory.StartNew(Speak);
      Console.WriteLine("Waiting for completion");
      // block the main thread, wait for the task to complete, and then exit
      t.Wait(); 
      Console.WriteLine("All Done");
    }

    private static void Speak()
    {
      Console.WriteLine("Hello World");
    }
  }
}
