using System;
using System.Linq;
using static Lab_6.Green_5;

namespace Lab_6
{
    public class Green_5
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

            public Student(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[5];
            }

            public void Exam(int subjectIndex, int mark)
            {
                {
                    for (int i = 0; i < marks.Length; i++)
                    {
                        if (marks[i] == 0) // Если оценка не была установлена
                        {
                            marks[i] = mark;
                            break;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}");
                Console.WriteLine($"Средний балл: {AvgMark:F2}");
            }
        }

        public struct Group
        {
            private string name;
            private Student[] students;

            public string Name => name;
            public Student[] Students => students.ToArray();
            public double AvgMark => students.Average(s => s.AvgMark);

            public Group(string name)
            {
                this.name = name;
                this.students = new Student[0];
            }

            public void Add(Student[] newStudents)
            {
                if (newStudents == null || newStudents.Length == 0)
                {
                    return;
                }

                if (students == null)
                {
                    students = newStudents;
                }
                else
                {
                    int a = students.Length;
                    Array.Resize(ref students, a + newStudents.Length);
                    Array.Copy(newStudents, 0, students, a, newStudents.Length);
                }
            }

            public void Print()
            {
                Console.WriteLine($"Группа: {Name} | Средний балл: {AvgMark:F2}");

                foreach (var student in students)
                {
                    student.Print();
                }
            }

            public static void SortByAvgMark(Group[] groups)
            {
                if (groups == null || groups.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < groups.Length - 1; i++)
                {
                    for (int j = 0; j < groups.Length - 1 - i; j++)
                    {
                        if (groups[j].AvgMark < groups[j + 1].AvgMark)
                        {
                            Group temp = groups[j];
                            groups[j] = groups[j + 1];
                            groups[j + 1] = temp;
                        }
                    }
                }
            }
        }
    }
}
