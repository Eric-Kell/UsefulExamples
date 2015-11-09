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
      Task t = new Task(Speak);
      t.Start();
    }

    private static void Speak()
    {
      Console.WriteLine("Hello World");
    }
  }
}
