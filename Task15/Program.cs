using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task15
{
    class Program
    {
        static void Main(string[] args)
        {
            ///
            /// Моделирование объектов реального мира при помощи классов
            /// 
            /// 1. Последовательный вывод членов арифметической и геометрической прогрессий с заранее определенными разностью и знаменателем соответственно
            /// 2. Вывод прогрессий с введенным количеством членов
            ///
            #region Инициализация исходных данных
            string key;
            bool cycle = true;
            Console.Write("Арифметическая и геометрическая прогрессии\nРазность арифметической прогрессии n = 2\nЗнаменатель геометрической прогрессии q = 2\nВведите стартовое число: ");
            InputIntNumber(out int x);
            ArithProgression arithProgression = new ArithProgression();
            arithProgression.setStart(x);
            GeomProgression geomProgression = new GeomProgression();
            geomProgression.setStart(x);
            #endregion
            
            #region 1. Последовательный вывод членов арифметической и геометрической прогрессий, с выбором дальнейших действий
            Console.WriteLine("Начальные члены: арифметической прогрессии - {0}, геометрической прогрессии - {0}", x);
            do
            {
                Console.WriteLine("\nСледующие члены: арифметической прогрессии - {0}, геометрической прогрессии - {1}", arithProgression.getNext(), geomProgression.getNext());
                Console.Write("Дальнейшее действие? [слеДующий/сБрос/Выход]: (слеДующий) ");
                if ((key = Console.ReadLine()) == "В" || key == "в")
                    cycle = false;
                else
                {
                    if (key == "Б" || key == "б")
                    {
                        arithProgression.reset();
                        geomProgression.reset();
                        Console.WriteLine("\nНачальные члены: арифметической прогрессии - {0}, геометрической прогрессии - {0}", x);
                    }
                }
            } while (cycle);
            #endregion

            /// 
            #region 2. Вывод прогрессий с введенным количеством членов
            arithProgression.reset();
            Console.Write("\nВведите количество членов прогрессий: ");
            InputIntNumber(out int n);
            Console.Write("Арифметическая прогрессия: {0}, ", x);
            for (int i = 0; i < n-1; i++)
            {
                Console.Write(arithProgression.getNext() + ", ");
            }
            Console.WriteLine("...");
            Console.Write("Геометрическая прогрессия: {0}, ", x);
            geomProgression.reset();
            for (int i = 0; i < n-1; i++)
            {
                Console.Write(geomProgression.getNext() + ", ");
            }
            Console.WriteLine("...");
            #endregion

            Console.Write("\nНажмите любую клавишу... ");
            Console.ReadKey();
        }

        //Проверка корректности введенных данных
        static void InputIntNumber(out int number)
        {
            number = 0;
            bool x;
            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    x = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}\nПопробуйте еще раз\n", ex.Message);
                    Console.Write("Введите целое число: ");
                    x = true;
                }
            } while (x);
        }

    }
    //Создание интерфейса ISeries генерации ряда чисел
    interface ISeries
    {
        void setStart(int x);
        int getNext();
        void reset();
    }
    //Создание класса ArithProgression производного от интерфейса ISeries
    class ArithProgression : ISeries
    {
        int start_x;
        int d = 2;
        int n = 1;
        public int getNext()
        {
            n += 1;
            return start_x + d * (n - 1);
        }

        public void reset()
        {
            n = 1;
            return;
        }

        public void setStart(int x)
        {
            start_x = x;
        }
    }
    //Создание класса GeomProgression производного от интерфейса ISeries
    class GeomProgression : ISeries
    {
        int start_x;
        int q = 2;
        int n = 1;
        public int getNext()
        {
            n += 1;
            return (int)(start_x * Math.Pow(q, n - 1));
        }

        public void reset()
        {
            n = 1;
            return;
        }

        public void setStart(int x)
        {
            start_x = x;
        }
    }
}
