using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class Book // Класс "Книга"
    {
        public string Title { get; set; } // Название
        public string Author { get; set; } // Автор      
        public int Pages { get; set; } // Кол-во страниц
        public override string ToString() // Перегрузка оператора ToString() для вывода объекта "Книга" в консоль
        {
            return $"Название: \"{Title}\". Автор: {Author}, {Pages} страниц";
        }        
    }
}
