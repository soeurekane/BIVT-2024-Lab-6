using System;

namespace Lab_6
{
    public class Green_2
    {
        public struct Student
        {
            private string name;
            private string surname;
            private int[] marks;

            public string Name => name;
            public string Surname => surname;
            public int[] Marks => marks.ToArray();
            public double AvgMark => marks.Average();
            public bool IsExcellent => marks.All(mark => mark >= 4);

            public Student(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[4];
            }

            public void Exam(int subjectIndex, int mark)
            {
                if (subjectIndex >= 0 && subjectIndex < marks.Length && marks[subjectIndex] == 0)
                {
                    marks[subjectIndex] = mark;
                }
                else
                {
                    Console.WriteLine("предмет уже сдан или неверный индекс");
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
                Console.WriteLine($"Отличник: {(IsExcellent ? "Да" : "Нет")}");
                Console.WriteLine();
            }
        }
    }
}