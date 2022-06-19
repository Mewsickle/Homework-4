using System;
using System.IO;
using System.Linq;
using MassLib;


/*
  1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.

2. Реализуйте задачу 1 в виде статического класса StaticClass;
а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
в)*Добавьте обработку ситуации отсутствия файла на диске.

3.
а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного размера и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений), метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов.
б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
в) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)

4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.
5.
а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами.
*
*Студент Ким Алексей
 */
namespace Homework_4
{

    class MyArray
    {
        #region Private Fields

        private int[] array;

        #endregion

        #region StaticClass

        static class StaticClass // 2 задание
        {
            public static int div;
            public static int[] array;



            public static void StaticArray(int count, int min, int max) //рандомизатор
            {
                array = new int[count];
                Random random = new Random();
                for (int i = 0; i < count; i++)
                {

                    array[i] = random.Next(min, max);
                }

            }




            public static int DivX() //счетчик пар
            {
                int count = 0;
                


                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] % div == 0 | array[i + 1] % div == 0)
                    {
                        count++;
                        Console.WriteLine($"Пара чисел {array[i]} и {array[i + 1]}");
                    }

                }
                Console.WriteLine($"Кол-во пар {count}");
                return count;

            }

            public static void PrintArr() //вывод рандомного массива
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i]}\t");
                }
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
            }

            public static void ReadTxt()
            {
                StreamReader sr = new StreamReader("..\\..\\TestFile.txt");
                int n = int.Parse(sr.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    int a = int.Parse(sr.ReadLine());
                    Console.WriteLine(a);
                }
                sr.Close();
            }



        }

        #endregion

        #region Constructors
        public MyArray(int[] array)
        {
            this.array = array;
        }

        public MyArray(int count, int min, int max) // массив с рандомизатором
        {
            array = new int[count];
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {

                array[i] = random.Next(min, max);
            }
        }
        public MyArray(string fileName) //из файла
        {
            array = LoadArrayFromFile(fileName);
        }

       


        public int Div3()
        {
            int count = 0;
            StaticClass.div = 3;


            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] % StaticClass.div == 0 | array[i + 1]% StaticClass.div == 0)   
                {
                    count++;
                    Console.WriteLine($"Пара чисел {array[i]} и {array[i + 1]}");
                }
                    
            }
            Console.WriteLine($"Кол-во пар {count}");
            return count;
            
        }



        #endregion

        #region Private Methods

        private int[] LoadArrayFromFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            int[] buf = new int[1000];
            StreamReader streamReader = new StreamReader(fileName);
            //streamReader.EndOfStream
            int count = 0   ;
            while(!streamReader.EndOfStream)
            {
                buf[count] = int.Parse(streamReader.ReadLine());
                count++;
            }
            int[] arr = new int[count];
            Array.Copy(buf, arr, count);
            streamReader.Close();
            return arr;
        }

    

        #endregion

        #region Public methods

        public void PrintArr()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
        }
        public override string ToString()
        {
            string buf = "";
            for (int i = 0; i < array.Length; i++)
            {
                buf += $"{array[i]}\t";
            }
            return buf;
        }

        #endregion
        internal class sample01
        {
            static void Main(string[] args)
            {


            Console.Title = "Домашнее задание 4";
                Console.WriteLine("Здравствуйте, Юзер! Добро пожаловать в меню выбора программ!");
                Console.WriteLine("//////////////////////////////////////////////////////////////////////////");
                Menu();
                static void Menu()
                {

                    Console.WriteLine("Пожалуйста введите номер программы!");
                    Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                    Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                    Console.WriteLine("1:Реализация численного массива с рандомизатором");
                    Console.WriteLine("2:Решение через статический класс");
                    Console.WriteLine("3:Демонстрация работы библиотеки MyArray1");
                   // Console.WriteLine("4:)");
                   





                    Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                    Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////////////////");

                    string menuSwitch = (Console.ReadLine());
                    bool result = int.TryParse(menuSwitch, out var number);
                    if (result == true)
                    {
                        switch (number)
                        {
                            case 1:
                                RandomMassive();
                                break;
                            case 2:
                                StaticMassive();
                                break;
                            case 3:
                                DemoArrayLib();
                                break;
                            //case 4:
                            //   ();
                            //    break;

                        }
                    }

                    else
                        Console.WriteLine($"Ошибка! Пожалуйста введите числовое значение!");

                }


                //1 задача

                

                Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                
                static void RandomMassive()
                {
                    MyArray myArray = new MyArray(10, -10001, 10001);
                    myArray.PrintArr();
                    myArray.Div3();
                }

                static void StaticMassive()
                {
                    StaticClass.StaticArray(10, -10001, 10001);
                    StaticClass.PrintArr();
                    StaticClass.div = 3;
                    StaticClass.DivX();
                    MyArray myArray = new MyArray(10, -10001, 10001);
                    // вывод из файла
                    myArray = new MyArray(AppDomain.CurrentDomain.BaseDirectory + "TestFile.txt");
                    Console.WriteLine($"Массив из файла TestFile.txt)");
                    myArray.PrintArr();

                }

                static void DemoArrayLib()
                {

                    double count = 10;

                    MyArray1 myArray = new MyArray1(count, 10, 3);

                    myArray.PrintArr();
                    myArray.Sum();
                    Console.WriteLine($"{myArray.Sum()};");

                    myArray.Multi();
                    Console.WriteLine($"{myArray.Multi()};");

                    myArray.Inverse();
                    
                    Console.WriteLine($"{myArray.Inverse()};");

                    myArray.MaxCounter();
                    Console.WriteLine($"{myArray.MaxCounter()};");
                    



                }






                Console.ReadKey();
            }
        }
       
    }
}
