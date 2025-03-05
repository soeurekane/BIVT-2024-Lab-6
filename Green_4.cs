using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Green_4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _jumps;

            public string Name  => _name;
            public string Surname  => _surname;
            
            public double[] Jumps
            {
                get
                {
                    if (_jumps == null) 
                    {
                        return null;
                    }
                    double[] arr = new double[_jumps.Length];
                    Array.Copy(_jumps, arr, _jumps.Length);
                    return arr;
                }
            }
            public double BestJump
            {
                get
                {
                    if (_jumps == null || _jumps.Length == 0)
                    {
                        return 0;
                    }
                    return _jumps.Max();
                }
            }


            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _jumps = new double[3];
            }

            public void Jump(double result)
            {
                if (_jumps == null)
                {
                    return;
                }

                for (int i = 0; i < _jumps.Length; i++)
                {
                    if (_jumps[i] == 0)
                    {
                        _jumps[i] = result;
                        return;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"Участник: {Name} {Surname}");
                Console.WriteLine($"Попытки: {string.Join(", ", Jumps)}");
                Console.WriteLine($"Лучший результат: {BestJump:F2}");
                Console.WriteLine();
            }
        }

    }
}