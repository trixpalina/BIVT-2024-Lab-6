using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Blue_5
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private int _place;

            public string Name => _name;
            public string Surname => _surname;
            public int Place => _place;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _place = 0;
            }

            public void SetPlace(int place)
            {
                if (_place == 0 && place >= 1)
                {
                    _place = place;
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} - {_place}");
            }
        }

        public struct Team
        {
            private string _name;
            private int _count;
            private Sportsman[] _sportsmen;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsmen;

            public int SummaryScore
            {
                get
                {
                    if (_sportsmen == null) return 0;

                    int sum = 0;
                    for (int i = 0; i < _count; i++)
                    {
                        if (_sportsmen[i].Place <= 5 && _sportsmen[i].Place != 0)
                        {
                            sum += 6 - _sportsmen[i].Place;
                        }
                    }
                    return sum;
                }
            }

            public int TopPlace
            {
                get
                {
                    if (_sportsmen == null) return 0;

                    int topPlace = 18;
                    for (int i = 0; i < _count; i++)
                    {
                        if (_sportsmen[i].Place < topPlace && _sportsmen[i].Place != 0)
                        {
                            topPlace = _sportsmen[i].Place;
                        }
                    }
                    return topPlace;
                }
            }

            public Team(string name)
            {
                _name = name;
                _sportsmen = new Sportsman[6];
                _count = 0;
            }

            public void Add(Sportsman sportsman)
            {
                if (_sportsmen == null || _count >= _sportsmen.Length) return;

                _sportsmen[_count++] = sportsman;
            }

            public void Add(Sportsman[] sportsmen)
            {
                if (_sportsmen == null || sportsmen == null) return;

                foreach (Sportsman sportsman in sportsmen)
                {
                    Add(sportsman);
                }
            }

            public static void Sort(Team[] teams)
            {
                if (teams == null || teams.Length == 0)
                    return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                        else if (teams[j].SummaryScore == teams[j + 1].SummaryScore)
                        {
                            if (teams[j].TopPlace > teams[j + 1].TopPlace)
                            {
                                Team temp = teams[j];
                                teams[j] = teams[j + 1];
                                teams[j + 1] = temp;
                            }
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine($"{_name}: ");
                foreach (Sportsman sportsman in _sportsmen)
                {
                    sportsman.Print();
                }
                Console.WriteLine("");
            }
        }
    }
}
