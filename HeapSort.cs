using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = {5, 8, 7, 2, 5, 9, 3, 7, 1, 6 };
            sort(ref array);
            foreach(int item in array)
            {
                Console.WriteLine(item);
            }
          
            Console.ReadKey();
        }
        public  static void sort(ref int[] array)
        {   //从下往上构造大顶堆
            for(int i=array.Length/2-1;i>=0;i--)
            {   //
                adjustHeap(array, i, array.Length);
            }
            //
            for(int j=array.Length-1;j>0;j--)
            {   
                swap(array, 0, j);//交换大顶堆堆顶元素和最后一个元素
                adjustHeap(array, 0, j);//交换元素后，堆的结构可能发生混乱，重新调整为大顶堆
            }
        }
        public static void adjustHeap(int [] array, int i,int length)
        {   //
            int temp = array[i];
            for(int k=i*2+1;k<length;k=k*2+1)
            {
                if(k+1<length&&array[k]<array[k+1])
                {
                    k++; //k表示左右子节点中的最大值。
                }
                if (array[k] > temp)
                {
                    //k表示要与结点i进行交换的子节点。不进行交换的子节点及其孙子结点一定是满足大顶堆要求，不需要调整
                    array[i] = array[k];
                    i = k;
                    array[i] = temp;
                }
                else
                    break; 
                //Break：若结点i满足堆的性质（大于子节点值i），就不需要对结点i的子节点2i+1,孙子结点2*（2i+1)+1进行调整

            
            }
           
        }
        public static void swap(int[] array,int a,int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
