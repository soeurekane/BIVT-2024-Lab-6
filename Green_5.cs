using System;
using System.Linq;
using static Lab_6.Green_5;

namespace Lab_6
{
    public class Green_5
    {
        public struct Student
        {
            private string name1;
            private string surname1;
            private int[] marks1;

            public string Name => name1;
            public string Surname => surname1;
            public int[] Marks => marks1.ToArray();
            public double AvgMark => marks1.Average();

            public Student(string name, string surname)
            {
                name1 = name;
                surname1 = surname;
                marks1 = new int[5];
            }

            public void Exam(int mark)
            {
                if (mark < 2 || mark > 5)
                {
                    Console.WriteLine("не те оценки");
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

                Console.WriteLine("написали всё");
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname}, ср арифм балл: {AvgMark:F2}");
            }
        }

        public struct Group
        {
            private string name1;
            private Student[] students;

            public string Name => name1;
            public Student[] Students => students.ToArray();
            public double AvgMark => students.Average(s => s.AvgMark);

            public Group(string name)
            {
                name1 = name;
                students = new Student[0];
            }

            public void Add(Student student)
            {
                Array.Resize(ref students, students.Length + 1);
                students[students.Length - 1] = student;
            }

            public void Add(Student[] newStudents)
            {
                if (newStudents == null || newStudents.Length == 0)
                {
                    return;
                }
                var studentList = students.ToList();
                studentList.AddRange(newStudents); // добавляем массив студентов
                students = studentList.ToArray();
            }

            public void Print()
            {
                Console.WriteLine($"группа: {Name} , балл : {AvgMark:F2}");

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
