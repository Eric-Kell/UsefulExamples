﻿/*
Общий класс для API тестов
*/

using UnitTests.DB;

namespace UnitTests.API
{
  public class APITest
  {
    protected Hac2112DBEntities4 context = new Hac2112DBEntities4();
    protected string serverUrl = "http://hac2112.azurewebsites.net";
  }
}