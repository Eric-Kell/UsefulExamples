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
    public void Import(object o)
    {
      string directory = (string)o;
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
      Task.Factory.StartNew(importer.Import, @"C:\data");
    }

  }
}
