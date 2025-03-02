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

            public void Exam(int index, int mark)
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

                if (index >= 0 && index < marks.Length)
                {
                    marks[index] = mark;
                }
                else
                {
                    Console.WriteLine("Индекс должен быть от 0 до 2.");
                }
            }



            public void Print()
            {
                Console.WriteLine($"Студент: {Name} {Surname}");
                Console.WriteLine($"Оценки: {string.Join(", ", Marks)}");
                Console.WriteLine($"СР Балл: {AvgMark:F2}");
                Console.WriteLine($"Отчислен: {(IsExpelled ? "Да" : "Нет")}");
                Console.WriteLine();
            }
        }
    }
}