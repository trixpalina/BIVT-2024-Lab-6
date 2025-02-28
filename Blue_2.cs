using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{


    public class Blue_2
    {
        public struct Participant
        {
            //поля
            private string _name;
            private string _surname;
            private int[,] _marks;

            //публичные свойства
            private string Name => _name;
            private string Surname => _surname;
            private int[,] Marks => _marks;

            //публичное поле
            public int TotalScore
            {
                get
                {
                    int sum = 0; 
                    foreach (var mark in _marks)   
                        sum += mark;               
                    return sum;                    
                }
            }

            //конструктор
            public Participant (string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];

            }

            public void Jump(int[] result)
            {
                if (_marks == null) return;

                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    if (_marks[i, 0] != 0)
                    {
                        continue;
                    }


                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        _marks[i, j] = result[j];
                    }
                    break;
                }
            }


            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }

                    }
                }

            }


            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(_name);

                Console.Write("Surname: ");
                Console.WriteLine(_surname);

                Console.Write("Marks: ");
                for (int i = 0; i < _marks.GetLength(0); i++)
                {
                    for (int j = 0; j < _marks.GetLength(1); j++)
                    {
                        Console.Write(_marks[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

    
        }
    }
}