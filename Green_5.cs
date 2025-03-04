using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_6
    {
        public class Green_5
        {
            public struct Student
            {
                private string name;
                private string surname;
                private int[] marks;
                private int exam_count;

                public string Name => name;
                public string Surname => surname;
                public int[] Marks => marks.ToArray();
                public double AvgMark => marks.Average();

                public Student(string name, string surname)
                {
                    this.name = name;
                    this.surname = surname;
                    this.marks = new int[5];
                    this.exam_count = 0;
                }

                public void Exam(int mark)
                {
                    if (exam_count < 0 || exam_count >= marks.Length)
                    {
                        return;
                    }

                    if (mark < 2 || mark > 5)
                    {
                        Console.WriteLine("оценка должна быть от 2 до 5");
                        return;
                    }
                    marks[exam_count] = mark;
                    exam_count++;
                }

                public void Print()
                {
                    Console.WriteLine($"{Name} {Surname}. Средний балл: {AvgMark:F2}");
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
                public void Add(Student student)
                {
                    var New = new Student[students.Length + 1];
                    Array.Copy(students, New, students.Length);
                    New[students.Length] = student;
                    students = New;
                }

                public void Add(Student[] new_s)
                {
                    if (new_s == null || new_s.Length == 0)
                    {
                        return;
                    }

                    if (students == null)
                    {
                        students = new_s;
                    }
                    else
                    {
                        int oldSize = students.Length;
                        Array.Resize(ref students, oldSize + new_s.Length);
                        Array.Copy(new_s, 0, students, oldSize, new_s.Length);
                    }
                }
                public static void SortByAvgMark(Group[] array)
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
                                Group temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                            }
                        }
                    }
                }
                public void Print()
                {
                    Console.WriteLine($"Группа: {Name}. Средний балл: {AvgMark:F2}");
                    foreach (var n1 in students)
                    {
                        n1.Print();
                    }
                }
            }
        }
    }

