using System.Collections.Generic;
using SportsStore.Domain.Entities;

/*
 * Класс для того чтобы передать репозиторий Products и информацию о странице одним файлом
 */

namespace SportsStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}