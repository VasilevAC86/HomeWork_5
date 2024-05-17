using Task_1;
using Task_2;

namespace HomeWork_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------- Задача 1 - Список книг ----------------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Задача 1 - \'Список книг\'\n");
            Console.ForegroundColor = ConsoleColor.White;
            // Формируем список из 2-ух книг "по умолчанию"
            List list = new List(2);
            list[0] = new Book
            {
                Title = "Оформление программного кода",
                Author = "Столяров",
                Pages = 127
            };
            list[1] = new Book
            {
                Title = "Программирование для начинающих на C#",
                Author = "Васильев",
                Pages = 212
            };
            Console.WriteLine("Исходный список книг: ");
            list.Print();
            char choice = '1'; // Переменная для хранения выбора пользователя
            while (choice == '1' || choice == '2' || choice == '3') 
            {
                Console.Write("\nВыберите номер действия из списка или нажмите любую другую клавишу для выхода:\n" +
                    "1. Добавить книгу в список;\n2. Удалить книгу из списка;\n3. Проверить, есть ли книга в списке;\n" +
                    "Ваш выбор -> ");
                choice = Convert.ToChar(Console.ReadLine());
                if (choice != '1' && choice != '2' && choice != '3')
                    break;
                if (choice == '1')
                {
                    Book book = new Book { };
                    Console.Write("\nВведите название книги -> ");
                    book.Title = Console.ReadLine();                    
                    Console.Write("Введите автора -> ");
                    book.Author = Console.ReadLine();
                    Console.Write("Введите кол-во страниц -> ");
                    book.Pages = Exception(Console.ReadLine());                    
                    list = list + book; // Добавляем книгу в список, используя перегруженный оператор +
                }
                if (choice == '2')
                {
                    Console.Write("Введите номер книги, которую надо удалить из списка -> ");
                    int index = Exception(Console.ReadLine());                    
                    while (index < 1 || index > list.Size())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Нет книги в списке с таким номером! Введите номер книги ещё раз -> ");
                        Console.ForegroundColor = ConsoleColor.White;
                        index = Exception(Console.ReadLine());                        
                    }
                    list = list - (index - 1); // Удаляем книгу из списка, используя перегруженный оператор -
                }
                if (choice == '3')
                {
                    Console.Write("Введите название книги, которую надо найти -> ");
                    string str = Console.ReadLine();
                    if (list.Search(str) == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nКнига в списке не найдена");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        Console.WriteLine("\nКнига в списке найдена! под номером " + list.Search(str) + "\n" + list[list.Search(str) - 1]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Console.Write("\nДля продолжения нажмите любую клавишу ");
                Console.ReadKey(true);
                Console.WriteLine("\nИтоговый список книг:");
                list.Print();
            }

            // ------------- Задача 2 - Операции с матрицами ----------------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЗадача 2 - \'Операции с матрицами\'\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введите размер матриц -> ");
            int size = Exception(Console.ReadLine());
            Matrix m1 = new Matrix(size, -5, 5);
            Matrix m2 = new Matrix(size, -5, 5);
            Console.WriteLine("\nМатрица 1:");
            m1.Print();
            Console.WriteLine("\nМатрица 2:");
            m2.Print();
            Console.WriteLine("\nМатрица 1 + матрица 2:");
            (m1 + m2).Print();
            Console.WriteLine("\nМатрица 1 - матрица 2:");
            (m1 - m2).Print();
            Console.WriteLine("\nМатрица 1 * матрица 2:");
            (m1 * m2).Print();
            Console.Write("\nВведите целое положительное число -> ");
            int num = Exception(Console.ReadLine());
            Console.WriteLine("\nМатрица 1 * число " + num + ":");
            (m1 * num).Print();
            Console.WriteLine("\nМатрица 2 * число" + num + ":");
            (m2 * num).Print();
            if (m1 == m2) Console.WriteLine("\nМатрицы равны!\n");
            if (m1 != m2) Console.WriteLine("\nМатирицы не равны!\n");
            if (m1.Equals(m2)) Console.WriteLine("Матрицы имеют одинаковые элементы в равных индексах");
            else Console.WriteLine("Матрицы не имеют ни одного одинакового элемента в равных индексах");
        }
        static int Exception(string message) // Метод обработки введённого пользователем значения
                                             // (исп-ся везде, где пользователь вводит int)
        {
            int number = 0;
            // Если введённое значение можно преобразовать в int, то записываем его в number
            if (int.TryParse(message, out number)) { }
            if (number < 1) // если введено не положительное целочисленное число, то 
            {
                while (!int.TryParse(message, out int value) || number < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Введённое некорректное значение! Введите целое число, больше нуля ещё один раз -> ");
                    Console.ForegroundColor = ConsoleColor.White;
                    message = Console.ReadLine();
                    if (int.TryParse(message, out number)) { }
                }
            }
            return number;
        }      
    }
}