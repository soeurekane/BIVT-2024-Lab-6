using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_3
    {
        public struct Student
        {
            private string name;
            private string surname;
            private int[] marks;
            private bool isExpelled;


            public double AvgMark
            {
                get
                {
                    if (marks.All(m => m == 0))
                    {
                        return 0;
                    }
                    return marks.Average();
                }
            }

            public bool IsExpelled => isExpelled;
            public string Name => name;
            public string Surname => surname;
            public int[] Marks => marks;


            public Student(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[3] { 0, 0, 0 };
                this.isExpelled = false;
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
                            Student temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }

            public void Exam(int mark)
            {
                if (isExpelled)
                {
                    return;
                }

                if (mark < 2 || mark > 5)
                {
                    Console.WriteLine("Оценка должна быть от 2 до 5.");
                    return;
                }

                if (mark == 2)
                {
                    isExpelled = true;
                    return;
                }


                int index = 0;
                index = Array.IndexOf(marks, 0);
                if (index != -1)
                {
                    marks[index] = mark;
                }
                else
                {
                    Console.WriteLine("все оценки получены");
                }
            }



            public void Print()
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Студент: {Name} {Surname}");

                Console.WriteLine($"Оценки: {string.Join(", ", Marks)}");

                Console.WriteLine($"СР Балл: {AvgMark:F2}");

                Console.WriteLine($"Отчислен: {(IsExpelled ? "Да" : "Нет")}");
                Console.WriteLine("----------------------------------------");
         
            }
        }
    }
}
