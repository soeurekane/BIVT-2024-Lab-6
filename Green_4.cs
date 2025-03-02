using System;

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
            public double[] Jumps => jumps.ToArray();
            public double BestJump => jumps.Max();

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.jumps = new double[3];
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