using System;
using System.Linq;

namespace Lab_6
{
    public class Green_4
    {
        public struct Participant
        {
            private string name;
            private string surname;
            private double[] jumps;

            public string Name => name;
            public string Surname => surname;
            public double[] Jumps => jumps;

            public double BestJump
            {
                get
                {
                    if (jumps == null || jumps.Length == 0)
                    {
                        return 0;
                    }
                    return jumps.Max();
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.jumps = new double[3] { 0, 0, 0 };
            }

            public void Jump(double result)
            {
                if (jumps == null || jumps.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < jumps.Length; i++)
                {
                    if (jumps[i] == 0)
                    {
                        jumps[i] = result;
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

                int n = array.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
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
                Console.WriteLine($"Спортсмен: {Name} {Surname}");
                Console.WriteLine($"Прыжки: {string.Join(", ", Jumps)}");
                Console.WriteLine($"Лучший результат: {BestJump:F2}");
                Console.WriteLine();
            }
        }
    }
}