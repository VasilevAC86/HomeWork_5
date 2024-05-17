using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Task_1;

namespace Task_2
{
    public class Matrix
    {
        private int[,] value_; // Поле значений матрицы
        // Перегруженный параметрический конструктор
        public Matrix(int size, int start, int end) // Конструктор для создания матрицы, элементы которой = случайному
                                                    // числу в диапазоне от start до end
        {            
            value_ = new int[size, size];
            Random r = new Random();
            for (int i = 0; i < value_.GetLength(0); i++)            
                for (int j = 0; j < value_.GetLength(1); j++)
                    value_[i, j] = r.Next(start, end);                    
        }
        public Matrix(int size) // Конструктор для создания матрицы, элементы которой = 0
        { 
            value_ = new int[size, size]; 
        }
        public void Print() // Метод вывода матрицы в консоль
        {
            for (int i = 0; i < value_.GetLength(0); i++) {
                for (int j = 0; j < value_.GetLength(1); j++)
                    Console.Write(value_[i, j] + "\t");                       
                Console.WriteLine();
             }
        }
        public int this[int rows, int cols] // Перегруженный индексатор матрицы
        {
            get
            {
                if (rows >= 0 && rows < value_.GetLength(0) && cols >= 0 && cols >= value_.GetLength(1)) 
                { 
                    return value_[rows,cols]; 
                }
                throw new IndexOutOfRangeException(); // при выходе за пределы массива
            }
            set { value_[rows, cols] = value; }           
        }
        // Перегруженный оператор сложения матриц +
        public static Matrix operator +(Matrix obj1, Matrix obj2)
        {
            Matrix result = new Matrix(obj1.value_.GetLength(0));
            for (int i = 0; i < obj1.value_.GetLength(0); ++i)
                for (int j = 0; j < obj1.value_.GetLength(1); ++j)
                    result.value_[i,j] = obj1.value_[i,j] + obj2.value_[i,j];
            return result;
        }        
        // Перегруженный оператор вычитания матриц -
        public static Matrix operator -(Matrix obj1, Matrix obj2)
        {
            Matrix result = new Matrix(obj1.value_.GetLength(0));                
            for (int i = 0; i < obj1.value_.GetLength(0); ++i)
                for (int j = 0; j < obj1.value_.GetLength(1); ++j)
                    result.value_[i, j] = obj1.value_[i, j] - obj2.value_[i, j];
            return result;
        }
        // Перегруженный оператор умножения матриц *
        public static Matrix operator *(Matrix obj1, Matrix obj2)
        {
            Matrix result = new Matrix(obj1.value_.GetLength(0));            
            for (int i = 0; i < obj1.value_.GetLength(0); ++i) // Вложенный цикл переменожения матриц 1 и 2       
                for (int j = 0; j < obj2.value_.GetLength(1); ++j)
                    for (int k = 0; k < obj2.value_.GetLength(0); ++k)
                        result.value_[i, j] += obj1.value_[i, k] * obj2.value_[k, j];
            return result;
        }
        // Перегруженный оператор умножения матрицы на число *
        public static Matrix operator *(Matrix obj, int num)
        {
            Matrix result = new Matrix(obj.value_.GetLength(0));
            for (int i = 0; i < obj.value_.GetLength(0); ++i)
                for (int j=0; j < obj.value_.GetLength(1); ++j)
                    result.value_[i, j] = num * obj.value_[i, j];
            return result;
        }
        // Перегруженный оператор проверки матриц на равенство
        public static bool operator ==(Matrix obj1, Matrix obj2)
        {
            for (int i = 0; i < obj1.value_.GetLength(0); ++i)
                for (int j = 0; j < obj1.value_.GetLength(1); ++j)
                    if (obj1.value_[i,j] != obj2.value_[i,j])
                        return false;
            return true;           
        }
        // Перегруженный оператор проверки матриц на неравенство
        public static bool operator !=(Matrix obj1, Matrix obj2)
        {
            for (int i = 0; i < obj1.value_.GetLength(0); ++i)
                for (int j = 0; j < obj1.value_.GetLength(1); ++j)
                    if (obj1.value_[i, j] != obj2.value_[i, j])
                        return true;
            return false;            
        }
        // Перегруженный метод проверки экземпляров объектов на равенство Equals
        public override bool Equals(object? obj)
        {
            if (obj is Matrix other)
                for (int i = 0; i < other.value_.GetLength(0); ++i)
                    for (int j = 0; j < other.value_.GetLength(1); ++j)
                        if (this.value_[i,j] == other.value_[i,j])
                            return true;
            return false;
        }
    }
}
