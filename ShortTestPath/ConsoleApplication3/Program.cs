using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        public const int Inf = 1000;
        public const int N = 6;        //point number
        static void Main(string[] args)
        {
     
            int[,] arc = new int[6,6]
            {
                { 0,   Inf, 10,  Inf,  30,   Inf },
                { Inf, 0,   5,   Inf,  Inf,  Inf },
                { Inf, Inf, 0,   50,   Inf,  Inf },
                { Inf, Inf, Inf, 0,    Inf,  10  },
                { Inf, Inf, Inf, 20,   0,    60  },
                { Inf, Inf, Inf, Inf,  Inf,  0   },
            };


            Flyod(arc);

            int n = 0; //start point
            //Dijsktra(arc, n);

            for(int i=0;i<N;i++)
            {
                Console.WriteLine(arc[n, i]);
            }
            Console.ReadKey();
        }
        public static void Dijsktra(int[,] arc,int n)
        {
            int[] dis = new int[N];
            int[] prePoint = new int[6] { -1, -1, -1, -1, -1, -1 };
            prePoint[n] = n;
            bool[] T = new bool[N];
            T[n] = true;

            for (int i=0;i<N;i++)
            {
                dis[i] = arc[n,i];
            }
            for (int k = 0; k < N; k++)
            {
                int min = 0;
                int temp = Inf;
                
                for (int i = 0; i < N; i++)
                {
                    if (T[i] == false && dis[i] < temp)     //T is used as a flag here, indicating whether the minimum path is found
                    {
                        temp = dis[i];
                        min = i;
                        if (temp == arc[n, i])
                            prePoint[i] = n;
                    }
                }
                if (temp != Inf)
                {
                    arc[n, min] = temp;
                    T[min] = true;

                    for (int i = 0; i < N; i++)//zhao chu du
                    {
                        if (arc[min, i] < Inf)
                        {
                            if (dis[i] > dis[min] + arc[min, i])
                            {
                                dis[i] = dis[min] + arc[min, i]; //update dis[] relax
                               
                                prePoint[i] = min;
                            }
                        }
                    }
                }

            }

            for (int i = 0; i < N; i++)
            {
                List<string> _path = new List<string>();
                var b = shortestPath(prePoint, _path, i,n);
                b.Reverse();
                Console.WriteLine("shortest path from point {0} to point {1} is {2}", n, i, b.Aggregate<string>((p1, p2) => p1 + "->" + p2));
            }
        }
   
        public static List<string> shortestPath(int[] PrePoint,List<string> path,int i,int n)
        {
            if (PrePoint[i]== -1)
            {
                path.Add("Inf");
            }
            else
            {
                path.Add("V" + i);
                if (PrePoint[i] == n)
                {
                    path.Add("V"+n);
                }
                else
                {
                    shortestPath(PrePoint, path, PrePoint[i],n);

                }
            }
            
            return path;
        }

        public static void Flyod(int[,] arc)
        {
            int[,] map = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (arc[i, j] != Inf)
                    {
                        map[i, j] = i;
                    }
                    else
                        map[i, j] = -1;

                }
            }

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (arc[i, k] != Inf && arc[k, j] != Inf)
                        {
                            if (arc[i, j] > arc[i, k] + arc[k, j])
                            {
                                arc[i, j] = arc[i, k] + arc[k, j];
                                map[i, j] = map[k,j];                  // keng!!!  map[i,j]=k is Wrong
                            }
                        }

                    }
                }
            }

            string[,] path = new string[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (map[i, j] == -1)
                    {
                        path[i, j] = "Inf";
                    }
                    else
                    {
                        path[i, j] += "V" + j+" ";
                        //if (map[i, j] == 0||i==j)
                        //    continue;
                        if (map[i, j] != 0)
                        {
                            M2(map, ref path[i, j], i, map[i, j]);
                        }
                        else
                            path[i, j] += "V" + i+" ";

                    }
                    string[] b = path[i, j].Split(new char[] { ' ' },1);
                    b.Reverse();
                    Console.WriteLine("shortest path from point {0} to point {1} is {2}", i, j, b.Aggregate<string>((p1, p2) => p1 + "<-" + p2));
                  
                }
            }

            Console.WriteLine("Aha");

        }
            

        public static void M2(int[,] map, ref string route,int i,int j)
        {
            if (j == -1)
            {
                route += "Inf";
                return;
            }
            else 
            {
                route += "V" + j+" ";
                if (j == i)
                {
                    
                    return;
                }
                else
                   
                    M2(map, ref route, i, map[i, j]);


            }
        }
   
   

        //public static void shortest(int[] T, int[,] arc, int n)
        //{
        //    int temp = Inf;
        //    int min = 0;

        //    for (int i = 0; i < N; i++)
        //    {
        //        if (T[i] == Inf && arc[n, i] < temp)
        //        {
        //            temp = arc[n, i];
        //            min = i;

        //        }
        //    }
        //    arc[n, min] = temp;
        //    T[min] = min;
        //    for (int i = 0; i < N; i++)//zhao chu du
        //    {
        //        if (arc[min, i] < Inf)
        //        {
        //            if (arc[n, i] > arc[n, min] + arc[min, i])
        //            {
        //                arc[n, i] = arc[n, min] + arc[min, i]; //update dis[] relax

        //            }
        //        }
        //    }

        //    if (T.Aggregate<int>((p1, p2) => p1 + p2) >= Inf)

        //    {
        //        shortest(T, arc, n);
        //    }





    }
}
