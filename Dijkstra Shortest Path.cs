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

            int n = 0; //start point
            
            int[] T = new int[N];
            for (int i = 0; i < N; i++)
            {
                T[i] = Inf;
            }
            T[n]=0;
            int[] prePoint = new int[6] { 0, -1, -1, -1, -1, -1 }; 
            shortest(T, arc, ref prePoint, n);
            for(int i=0;i<N;i++)
            {
                Console.WriteLine(arc[n, i]);
            }

            for (int i = 0; i < N; i++)
            {
                List<string> _path = new List<string>();
               
                var b = shortestPath(prePoint, _path,i);
                b.Reverse();
                Console.WriteLine("shortest path from point {0} to point {1} is {2}", n, i, b.Aggregate<string>((p1, p2) => p1 + "->" + p2));
            }
            Console.ReadKey();
        }
        public static void shortest(int[] T, int[,] arc, ref int[] prePoint,int n)
        {
            int[] dis = new int[N];
            for(int i=0;i<N;i++)
            {
                dis[i] = arc[n,i];
            }
            for (int k = 0; k < N; k++)
            {
                int min = 0;
                int temp = Inf;
                
                for (int i = 0; i < N; i++)
                {
                    if (T[i] == Inf && dis[i] < temp)     //T is used as a flag here, indicating whether the minimum path is found
                    {
                        temp = dis[i];
                        min = i;
                        if (temp == arc[n, i])
                            prePoint[i] = 0;
                       
                    }
                }
                if (temp != Inf)
                {
                    arc[n, min] = temp;
                    T[min] = min;

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
        }
   
        public static List<string> shortestPath(int[] PrePoint,List<string> path,int i)
        {
            if (PrePoint[i]== -1)
            {
                path.Add("Inf");
            }
            else
            {
                path.Add("V" + i);
                if (PrePoint[i] == 0)
                {
                    path.Add("V0");
                }
                else
                {
                    shortestPath(PrePoint, path, PrePoint[i]);

                }
            }
            
            return path;

        }
        public static void asd(int[] PrePoint, List<string> path, int i)
        {
            if (PrePoint[i] == -1)
            {
                path.Add("Inf");
            }
            else
            {
                path.Add("V" + i);
                if (PrePoint[i] == 0)
                {
                    path.Add("V0");
                }
                else
                {
                    asd(PrePoint, path, PrePoint[i]);

                }
            }

            path.Reverse();
           
        }
      
        //public static void shortest(int[] T,int[,] arc,int n)
        //{
        //    int temp = Inf;
        //    int min=0;

        //    for(int i=0;i< N; i++)
        //    {
        //        if(T[i]==Inf&&arc[n,i]<temp)
        //        {
        //            temp = arc[n,i];
        //            min = i;

        //        }
        //    }
        //    arc[n, min] = temp;
        //    T[min] = min;
        //    for(int i=0;i< N; i++)//zhao chu du
        //    {
        //        if(arc[min,i]<Inf)
        //        {
        //            if(arc[n,i]>arc[n,min]+arc[min,i])
        //            {
        //                arc[n, i] = arc[n, min] + arc[min, i]; //update dis[] relax

        //            }
        //        }
        //    }

        //    if (T.Aggregate<int>((p1, p2) => p1 + p2)>=Inf)

        //    {
        //        shortest(T, arc, n);
        //    }

        //    //int a=listDis.Aggregate<int>((p1, p2) => { int temp = p1; if (p1 < p2) temp = p1; return temp; });
        //}



    }
}
