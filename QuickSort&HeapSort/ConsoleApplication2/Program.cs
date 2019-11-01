using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CopyMedia();
            int[] array = { 3, 52, 5, 2, 1, 6, 3, 7, 3, 78, 32, 12, 54, 25, 11, 23 };
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                BigPileHeap(array, i, array.Length);

            }
            //foreach (int item in array)
            //{
            //    Console.WriteLine("initial Heap {0}", item);


            //}
            for (int k=array.Length-1;k>=2;k--)
            {
                swap(ref array[0], ref array[k]);
                BigPileHeap(array, 0, k);
            }

            foreach (int item in array)
            {
                Console.WriteLine("initial Heap {0}", item);


            }
            int[] array2 = { 3, 52, 5, 2, 1, 6, 3, 7, 3, 78, 32, 12, 54, 25, 11, 23 };

            int[] array3 = { 6,1,2,7,9,3,4,5,10,8};
            quicksort(array2,0,array2.Length-1);
            foreach (int item in array2)
            {
                Console.WriteLine("quick sort {0}", item);


            }
            Console.ReadKey();
        }
        public static void BigPileHeap(int[] array, int i, int length)
        {
            for (int k = 2 * i + 1; k < length-1; k = 2 * k + 1)       //k<length -1
            {
                int temp = array[i];
                if (k + 1 < array.Length && array[k] < array[k + 1])
                {
                    k++;
                }
                if (array[k] > temp)
                {
                    array[i] = array[k];
                    i = k;
                    array[k] = temp;
                }
                else
                    break;
            }
        }
        public static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

        }

        //***************************************
        public void m1(int[] array,int i,int j)
        {
            int key = array[i];
            int low=i;
            int high=j;
            
            

        }
        public static void m1(int[] array)
        {
            
            int i=0;
            int j=array.Length-1;
            int key = array[0];
            do
            {
                for (; j >= i+1; j--)
                {
                    if (array[j] < key)
                    {
                       
                        break;
                    }
                }
                for (; i <= j-1; i++)
                {
                    if (array[i] < key)
                    {
                        
                        break;
                    }
                }
                swap(ref array[i], ref array[j]);
                
            }
            while (i <= j-2);
            if(key<array[i])
            {
                swap(ref array[0], ref array[i-1]);
            }
            if(key>array[i])
            {
                swap(ref array[0], ref array[i]);
            }

        }
        public static void quicksort(int[] array,int left,int right)
        {
            int i, j, Key;
           
            Key = array[left];
            i = left;                              //3, 52, 5, 2, 1, 6, 3, 7, 3, 78, 32, 12, 54, 25, 11, 23
            j = right;                             //1, 52, 5, 2, 3, 6, 3, 7, 3, 78, 32, 12, 54, 25, 11, 23
            while (i!=j)                           //1, 3, 5, 2, 52, 6, 3, 7, 3, 78, 32, 12, 54, 25, 11, 23
            {                                      //1, 2, 5, 3, 52, 6, 3, 7, 3, 78, 32, 12, 54, 25, 11, 23
                while (array[j]>= Key && i<j)      //1, 2, 3, 5, 52, 6, 3, 7, 3, 78, 32, 12, 54, 25, 11, 23
                {
                    j--;
                   
                }
                if (i < j)
                {
                    swap(ref array[i], ref array[j]);
                }
                else
                    break;
                while (array[i]< Key&& i<j)
                {
                    i++;
                   
                }
                if (i < j)
                {
                    swap(ref array[i], ref array[j]);
                }
                else
                    break;
            }
            if(j>=1&&j<=right-2)
            {
                quicksort(array, left, i - 1);
                quicksort(array, i + 1, right);
            }
            else if (j == 0)
            {
                quicksort(array, i + 1, right);
            }
            else if(j==right-1)
            {
                quicksort(array, left, i - 1);
            }
            
            
        }
        public void Floyed()
        {
           
        }

        public void CopyMedia()
        {
            bool flag=File.Exists(@"E:\aspenONE_V11_SLM\setup.exe");
            Process.Start(@"E:\aspenONE_V11_SLM\setup.exe");
            string serverPath = @"\\shrdfile01\aspenONE_Media\aspenONEV11.0\MSC";
            string[] files = Directory.GetFiles(serverPath); //\V11.0_MSCT_Media321
            string targetmedia = null;
            TimeSpan shift = new TimeSpan(1, 0, 0, 0);
            DateTime _creationTime = DateTime.Now.Subtract(shift);
            string creationTime = _creationTime.GetDateTimeFormats()[0];
            foreach (string str in files)
            {
                DateTime temp = Directory.GetCreationTime(str);
                if (temp.GetDateTimeFormats()[0] == creationTime)
                {
                    targetmedia = str;
                    break;
                }
            }

            File.Copy(targetmedia, "C:\\Users\\qapart\\Desktop\\"+ $"{targetmedia}"+".iso", true);

            
            
            //E:\aspenONE_V11_SLM

        }

        //[DllImport("user32")]
        //private static extern int mouse_event(int dwFlags,int dx,int dy,int cButtons)
        //{
        //    const int MOUSEEVENTF_LEFTDOWN = 0x0002;

        //}

    }
   
}
