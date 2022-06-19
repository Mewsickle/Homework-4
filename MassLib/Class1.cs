using System;
using System.IO;
using System.Linq;

namespace MassLib
{
    public class MyArray1
    {
       
        public int[] array;
        public MyArray1(int[] array)
        {
            this.array = array;
        }

        public MyArray1(int count, int min, int max) // массив с рандомизатором
        {
            array = new int[count];
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {

                array[i] = random.Next(min, max);
            }
        }


        public MyArray1(double count, int min, int step) // массив с шагом. double потому что компилятор отказывается перегружать.
        {
            array = new int[(int)count];

            for (int i = 0; i < count; i++)
            {
                array[i] = min + (step*i);
            }
        }

        public void PrintArr()
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");
            }
            Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------");
        }

        public int Sum()
        {

            int s = 0;
            for (int i = 0; i < array.Length; i++)
            {
                s += array[i];
            }
            return s;
        }

        public int[] Inverse()
        {
            int[] newArr = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArr[i] = -array[i];
            }

            return newArr;
        }

        public int[] Multi()
        {
            int multy = 2;
            int[] newArr = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArr[i] = multy * array[i];
            }

            return newArr;
        }

        public int MaxCounter()
        {
            int max = array.Max();
            int s = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == max)
                    s += 1;
            }
            return s;
        }
       

       
    }
}
