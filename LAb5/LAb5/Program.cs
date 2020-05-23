using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
 
class Program
{
    static public int n;
    static int ribs(int[,] m, int a)
    {
        a = 0;
        for (var j = 0; j < m.GetLength(0); j++)
        {
            for (var i = 0; i <= j; i++)
            {
                if (m[i, j] == 1) a++;
            }
        }
        return a;
    }
    static List<List<int>> convert(int[,] a)
    {
        int l = a.GetLength(0);
        List<List<int>> adjListArray = new List<List<int>>(l);
        int i, j;

        for (i = 0; i < l; i++)
        {
            adjListArray.Add(new List<int>());
        }


        for (i = 0; i < a.GetLength(0); i++)
        {
            for (j = 0; j < a.GetLength(1); j++)
            {
                if (a[i, j] == 1)
                {
                    for (int ii = i + 1; ii < a.GetLength(0); ii++)
                    {
                        if (a[ii, j] == 1) { adjListArray[i].Add(ii); }
                    }
                    for (int ii = i - 1; ii >= 0; ii--)
                    {
                        if (a[ii, j] == 1) { adjListArray[i].Add(ii); }
                    }
                }
            }
        }

        return adjListArray;
    }
    static void printList(List<List<int>> adjListArray)
    {

        for (int v = 0; v < adjListArray.Count; v++)
        {
            Console.Write(v);
            foreach (int u in adjListArray[v])
            {
                Console.Write(" -> " + u);
            }
            Console.WriteLine();
        }
    }
    public static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"E:\111o.txt");
        int[,]  num= new int[lines.Length, lines[0].Split(' ').Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] temp = lines[i].Split(' ');
            for (int j = 0; j < temp.Length; j++)
                num[i, j] = Convert.ToInt32(temp[j]);
        }
        // проверяем выводом на консоль
      
        int[,] ms =num;
        int v = ms.GetLength(0);
        int[,] mi = new int[ribs(ms, 0), v];
        for (var j = 0; j < v; j++)
        {
            for (var i = 0; i < j; i++)
            {
                if (ms[i, j] == 1)
                {
                    mi[n, i] = 1;
                    mi[n, j] = 1;
                    n++;
                }
            }
        }
        // ВЫВОД МАТРИЦ
        for (var j = 0; j < ms.GetLength(1); j++)
        {
            for (var i = 0; i < ms.GetLength(0); i++)
            {
                Console.Write(ms[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        int[,] matrix = new int[mi.GetLength(1), mi.GetLength(0)];
        for (var j = 0; j < mi.GetLength(1); j++)
        {
            for (var i = 0; i < mi.GetLength(0); i++)
            {
                Console.Write(mi[i, j]);
                Console.Write(" ");
                matrix[j, i] = mi[i, j];
            }
            Console.WriteLine();
        }
        List<List<int>> adjListArray = convert(matrix);
        Console.WriteLine("Adjacency List: ");
        printList(adjListArray);
    }
}
