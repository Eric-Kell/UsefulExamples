using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

    static BigInteger Factorial(BigInteger x)
    {
      if (x == 1)
        return 1;
      else
      {
        return x * Factorial(x - 1);
      }
    }

    private static void Main(string[] args)
    {
      BigInteger n = 4900;
      BigInteger r = 60;
      Task<BigInteger> part1 = Task.Factory.StartNew<BigInteger>(() => Factorial(n));
      Task<BigInteger> part2 = Task.Factory.StartNew<BigInteger>(() => Factorial(n - r));
      Task<BigInteger> part3 = Task.Factory.StartNew<BigInteger>(() => Factorial(r));
      BigInteger chances = part1.Result / (part2.Result * part3.Result);
      Console.WriteLine(chances);
    }

  }
}
