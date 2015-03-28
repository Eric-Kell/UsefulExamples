using System.Collections.Generic;
using SportsStore.Domain.Entities;

/*
 * Применяем Repository Pattern
 * 
 * В двух словах, паттерн Repository инкапсулирует объекты, представленыые в хранилище данных и операции,
 * производимые над ними, предоставляя более объектно-ориентированное представление реальных данных. 
 * Repository также преследует цель достижения полного разделения и односторонней зависимости между уровнями
 * области определения и распределения данных. Класс изпользующий IProductRepository может получать Product без знаний, как он реализован
 * и где хранится.
 */

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}