using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
  public class DataImporter
  {
    public void Import(string directory)
    {
    }
  }

  class Program
  {

    /*
    Суть в том, что Task делается в BackGround и если нету никаких ForeGround, то прога
    завершится не дожидаясь окончания такски из BackGround
    */

    private static void Main(string[] args)
    {
      var importer = new DataImporter();
      string importDirectory = @"C:\data";
      Task.Factory.StartNew(() => importer.Import(importDirectory));
    }

  }
}
