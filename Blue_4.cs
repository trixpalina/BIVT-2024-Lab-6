using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Blue_4
    {
        public struct Team
        {
            private string _name;
            private int[] _scores;

            public string Name => _name;
            public int[] Scores
            {
                get
                {
                    if (_scores == null) return null;
                    int[] newarr = new int[_scores.Length];
                    for (int i = 0; i < _scores.Length; i++)
                        newarr[i] = _scores[i];
                    return newarr;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_scores == null || _scores.Length == 0)
                        return 0;
                    int total = 0;
                    for (int i = 0; i < _scores.Length; i++)
                            total += _scores[i];
                    
                    return total;
                }
            }

            public Team(string name)
            {
                _name = name;
                _scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                int[] newarr = new int[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                    newarr[i] = _scores[i];
                newarr[_scores.Length] = result;
                _scores = newarr;
            }

            public void Print()
            {
                Console.Write($"{_name}: {TotalScore}");
                Console.WriteLine("");
            }
        }


        public struct Group
        {
            private string _name;
            private Team[] _teams;
            private int _count;

            public string Name => _name;
            public Team[] Teams
            {
                get
                {
                    return _teams;
                }
            }

            public Group(string name)
            {
                _name = name;
                _teams = new Team[12];
                _count = 0;
            }

            public void Add(Team team)
            {
                if (_teams == null || _count == 12) return;
                else _teams[_count++] = team;
            }
            public void Add(Team[] teams)
            {
                for (int i = 0; i < teams.Length && _count < 12; i++)
                    _teams[_count++] = teams[i];
            }
            public void Sort()
        {
            if (_teams == null) return;
            for (int i = 0; i < _count - 1; i++)
            {
                for (int j = 0; j < _count - i - 1; j++)
                {
                    if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                    {
                        Team temp = _teams[j];
                        _teams[j] = _teams[j + 1];
                        _teams[j + 1] = temp;
                    }
                }
            }
        }
            public static Group Merge(Group group1, Group group2, int size)
            {
                Group result = new Group("Финалисты");
                int i = 0, j = 0;
                while (i < size / 2 && j < size / 2)
                {
                    if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore) result.Add(group1.Teams[i++]);
                    else result.Add(group2.Teams[j++]);
                }
                while (i < size / 2)
                {
                    result.Add(group1.Teams[i++]);
                }
                while (j < size / 2)
                {
                    result.Add(group2.Teams[j++]);
                }
                return result;
            }

            public void Print()
            {
                Console.Write($"{_name}: ");
                foreach (var team in _teams)
                {
                    team.Print();
                }
                Console.WriteLine("");
            }
        }
    }
}
