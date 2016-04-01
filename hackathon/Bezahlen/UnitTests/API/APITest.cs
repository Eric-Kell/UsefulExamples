/*
Общий класс для API тестов
*/

using UnitTests.DB;

namespace UnitTests.API
{
  public class APITest
  {
    protected Hac2112DBEntities1 context = new Hac2112DBEntities1();
    protected string serverUrl = "http://hac2112.azurewebsites.net";
  }
}