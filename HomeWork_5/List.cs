using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class List // Класс "Список книг"
    {
        private Book[] books_; // Поле для хранения массива книг
        public List(int size) // Параметрический конструктор
        {
            books_ = new Book[size];
        }
        public int Size() { return books_.Length; } // Гэттер размера массива книг
        public void Print() // Метод для вывода списка книг в консоль
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < books_.Length; i++)            
                Console.WriteLine(i + 1 + ". " + books_[i].ToString());
            Console.ForegroundColor= ConsoleColor.White;
        }
        public Book this[int index] // Перегруженный индексатор массива книг
        {
            get
            {
                if (index >= 0 &&  index < books_.Length) { return books_[index]; }
                throw new IndexOutOfRangeException(); // при выходе за пределы массива
            }
            set { books_[index] = value; }
        }
        // Перегруженный оператор увеличения списка книг        
        public static List operator +(List list, Book book)
        {
            Book[] tmp = new Book[list.Size() + 1]; // Временный массив книг
            for (int i = 0; i < list.Size(); ++i) // Цикл заполения временного массива книг до предпоследнего элемента включительно
                tmp[i] = list[i];
            tmp[list.Size()] = book; // Добавляем новую книгу в конец массива
            list.books_ = tmp; // Меняем в объекте класса массив с книгами
            return list;
        }
        // Перегруженный оператор удаления книги из списка книг, index - индекс удаляемой книги
        public static List operator -(List list, int index)
        {
            Book[] tmp = new Book[list.Size() - 1];
            for (int i = 0; i < list.Size(); ++i)
            {
                if (i < index)
                    tmp[i] = list[i];
                if (i == index)
                    continue;
                if (i > index)
                    tmp[i - 1] = list[i];
            }
            list.books_ = tmp;
            return list;
        }
        public int Search(string str)
        {
            for (int i = 0; i < books_.Length; ++i)
                if (books_[i].Title == str)
                    return i + 1;
            return -1;
        }
    }
}
