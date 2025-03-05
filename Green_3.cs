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
            private string _name;
            private string _surname;
            private int[] _marks;
            private bool _isExpelled;
            private int _count;

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
            public bool IsExpelled
            {
                get
                {
                    if (_count == 0)
                    {
                        return false;
                    }
                    for (int i = 0; i < _count; i++)
                    {
                        if (_marks[i] <= 2)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) 
                    {
                        return 0;
                    }

                    double sum = 0;
                    int count = 0;

                    foreach (int mark in _marks)
                    {
                        if (mark != 0)
                        {
                            sum += mark;
                            count++;
                        }
                    }
                    if (count == 0) 
                    {
                        return 0;
                    }
                    return sum / count;
                }
            }

            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[3];
                _isExpelled = false;
                _count = 0;
            }


            public void Exam(int mark)
            {
                if (_marks == null) 
                {
                    return;
                }
                if (_count >= 3)
                {
                    return;
                }
                if (_isExpelled) 
                {
                    return;
                }
                if (mark >= 2 && mark <= 5)
                    {
                        _marks[_count] = mark;
                        _count++;
                    }
                else
                    {
                        _marks[_count] = mark;
                        _count++;
                        _isExpelled = true;
                    }
                if (mark <= 2)
                {
                    _isExpelled = true;
                }
            }

            public static void SortByAvgMark(Student [] array)
            {
                if (array == null) 
                {
                    return;
                }
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].AvgMark < array[j+1].AvgMark)
                        {
                            int temp = array[j];
                            array[j] = array[j+1];
                            array[j+1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{Name} {Surname} {AvgMark:F2} {IsExpelled}");
            }
        }
    }
}