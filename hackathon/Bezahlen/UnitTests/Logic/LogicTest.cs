/*
Общие штуки для тестов бизнес логики выносим сюда
*/

namespace UnitTests.Logic
{
  public class LogicTest
  {
    // Эмулируем главную БД
    protected readonly FakeData data = new FakeData();
  }
}
