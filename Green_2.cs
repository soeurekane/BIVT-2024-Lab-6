using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_2
    {
        public struct Student
        {
            private string name1;
            private string surname1;
            private int[] marks1;


            public string Name => name1;
            public string Surname => surname1;
            public int[] Marks => marks1;

            public Student(string name, string surname)
            {
                name1 = name;
                surname1 = surname;
                marks1 = new int[4] { 0, 0, 0, 0 };
            }
            public bool IsExcellent
            {
                get
                {
                    for (int i = 0; i < marks1.Length; i++)
                    {
                        if (marks1[i] < 4)
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
            public double AvgMark
            {
                get
                {
                    double sum = 0;
                    foreach (var mark in marks1)
                    {
                        sum += mark;
                    }
                    if (marks1.Length == 0)
                    {
                        return 0;
                    }
                    return sum / marks1.Length;
                }
            }



            public void Exam(int mark)
            {
                if (mark < 2 || mark > 5)
                {
                    Console.WriteLine("неправильные   оценки");
                    return;
                }
                if (marks1.Length == 0 || marks1 == null)
                {
                    return;
                }
                for (int i = 0; i < marks1.Length; i++)
                {
                    if (marks1[i] == 0)
                    {
                        marks1[i] = mark;
                        return;
                    }
                }
            }

            public static void SortByAvgMark(Student[] array)
            {
                if (array == null || array.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i].AvgMark < array[j].AvgMark)
                        {
                            Student t = array[i];
                            array[i] = array[j];
                            array[j] = t;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"КТо?: {Name} {Surname}");
                Console.WriteLine(string.Join(", ", Marks));
                Console.WriteLine($"СР Балл: {AvgMark:F2}");
                Console.WriteLine(IsExcellent ? "Отличник" : "Не отличник");
                Console.WriteLine();
            }
        }
    }
}
