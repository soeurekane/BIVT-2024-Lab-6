using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            public string Name => name;
            public string Surname => surname;
            public int[] Marks => marks.ToArray();
            public double AvgMark => marks.Average();
            public bool IsExpelled => isExpelled;

            public Student(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[3];
                this.isExpelled = false;
            }

            public void Exam(int mark)
            {
                if (isExpelled)
                {
                    return;
                }

                if (mark < 2 || mark > 5)
                {
                    Console.WriteLine("оценка должна быть от 2 до 5");
                    return;
                }
                for (int i = 0; i < marks.Length; i++)
                {
                    if (marks[i] == 0)
                    {
                        marks[i] = mark;

                        if (mark == 2)
                        {
                            isExpelled = true;
                            Console.WriteLine($"{Name} {Surname} отчислен за 2");
                        }
                        return;
                    }
                }
                Console.WriteLine("все оценки уже выставлены");
            }

            public static void SortByAvgMark(Student[] array)
            {
                if (array == null || array.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AvgMark < array[j + 1].AvgMark)
                        {
                            Student temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Студент: {Name} {Surname}");
                Console.WriteLine($"Оценки: {string.Join(", ", Marks)}");
                Console.WriteLine($"Средний балл: {AvgMark:F2}");
                Console.WriteLine($"Отчислен: {(IsExpelled ? "Да" : "Нет")}");
                Console.WriteLine();
            }
        }
    }
}
