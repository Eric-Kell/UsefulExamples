using System;
using System.Threading;

namespace SimpleConsoleApps
{
  class Program
  {

    // Как пример, пусть она циклится и не циклится.
    static void sum()
    {

      int x = 1;
      x += 1;

      //
      while (true)
      {
        x *= 1;
      }
    }

    static void Main(string[] args)
    {
      // Пихаем функцию в поток
      Thread my = new Thread(sum);
      // Запускаем поток
      my.Start();
      // Join сработает после 3х секунд и вернет true, если поток завершился и false иначе
      if (my.Join(TimeSpan.FromSeconds(3)))
      {
        Console.WriteLine("ok");
      }
      // Тут можно сделать Abrubt() те убить поток или же Interupt, но у него нету реализации Interupt
      else
      {
        Console.WriteLine("not ok");
      }
    }
  }
}
