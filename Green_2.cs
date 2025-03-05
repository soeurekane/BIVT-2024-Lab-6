using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_2
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[] arr = new int[_marks.Length];
                    Array.Copy(_marks, arr, _marks.Length);
                    return arr;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_marks == null) return 0;

                    double sum = 0;
                    int k = 0;
                    foreach (int mark in _marks)
                    {
                        if (mark != 0)
                        {
                            sum += mark;
                            k++;
                        }
                    }
                    if (k == 0) return 0;
                    return sum / k;
                }
            }
            public bool IsExcellent
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return false;
                    foreach (int mark in _marks)
                    {
                        if (mark < 4)
                            return false;
                    }
                    return true;
                }
            }


            public Student(string name, string surname)
            {
                 _name = name;
                _surname = surname;
                _marks = new int[4];
            }

            public void Exam(int mark)
            {
                if (_mark < 2 || _mark > 5)
                {
                    return;
                }
                for (int i = 0; i < _marks.Length; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = mark;
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