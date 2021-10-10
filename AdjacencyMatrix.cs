using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace adjacency_matrix
{
    class AdjacencyMatrix
    {
        public int n;
        public int[,] a;
    
        public bool readAdjacencyMatrix(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File khong ton tai");
                return false;
            }
            string[] lines = File.ReadAllLines(filename);
            n = Int32.Parse(lines[0]);
            a = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                string[] tokens = lines[i + 1].Split(new char[]
               { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; ++j)
                    a[i, j] = Int32.Parse(tokens[j]);
            }
            return true;
        }

        public void showAdjacencyMatrix()
        {
            Console.WriteLine(n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.Write(a[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public bool isUndirectedGraph(AdjacencyMatrix g)
        {
            // Ý tưởng: kiểm tra ma trận kề của đồ thị có đối xứng?
            int i, j;
            bool isSymmetric = true;
            for (i = 0; i < g.n && isSymmetric; ++i)
            {
                for (j = i + 1; (j < g.n) && (g.a[i, j] == g.a[j, i]); ++j) ;
                if (j < g.n)
                    isSymmetric = false;
            }
            return isSymmetric;
        }

        public int[] countDegrees(AdjacencyMatrix g)
        {
            int[] degrees = new int[g.n]; // Mảng chứa bậc của các đỉnh
            for (int i = 0; i < g.n; i++)
            {
                int count = 0;
                for (int j = 0; j < g.n; j++)
                    if (g.a[i, j] != 0)
                    {
                        count += g.a[i, j];
                        if (i == j) // xet truong hop canh khuyen
                            count += g.a[i, i];
                    }
                degrees[i] = count;
            }
            return degrees;
        }

        public int[] DG_countDegreesIN(AdjacencyMatrix g)
        {
            int[] degrees = new int[g.n]; // Mảng chứa bậc của các đỉnh
            for (int i = 0; i < g.n; i++)
            {
                int count = 0;
                for (int j = 0; j < g.n; j++)
                    if (g.a[i, j] != 0)
                    {
                        count += g.a[j, i];
                        if (i == j) // xet truong hop canh khuyen
                        {
                            count = count + g.a[j, i];
                        }
                    }
                degrees[i] = count;
            }
            return degrees;
        }

        public int DG_alltopDegreesIN(int[] dInCount)
        {
            int sum = 0;
            for (int i = 0; i < dInCount.Length; i++)
            {
                sum = sum + dInCount[i];
            }
            return sum;
        }

        public int[] DG_countDegreesOUT(AdjacencyMatrix g)
        {
            int[] degrees = new int[g.n]; // Mảng chứa bậc của các đỉnh
            for (int i = 0; i < g.n; i++)
            {
                int count = 0;
                for (int j = 0; j < g.n; j++)
                    if (g.a[i, j] != 0)
                    {
                        count += g.a[i, j];
                        if (i == j) // xet truong hop canh khuyen
                            count += g.a[i, i];
                    }
                degrees[i] = count;
            }
            return degrees;
        }

        public int DG_alltopDegreesOUT(int[] dOutCount)
        {
            int sum = 0;
            for (int i = 0; i < dOutCount.Length; i++)
            {
                sum = sum + dOutCount[i];
            }
            return sum;
        }


        public int UDG_allTopDegree(AdjacencyMatrix g, int[] degrees)
        {
            int sum = 0;
            for (int i = 0; i < degrees.Length; i++)
                sum = sum + degrees[i];
            return sum;
        }

        public int countVertex(AdjacencyMatrix g)
        {
            int sum = 0;
            for (int i = 0; i < g.n; ++i)
            {
                sum += 1;
            }
            return sum;
        }

        public int UDG_countEdge(int n)
        {
            int result = 0;
            result = n / 2;
            return result;
        }

        public int DG_countEdge(int n)
        {
            int result = 0;
            result = n / 2;
            return result;
        }



        public int countIsolatedVertices(AdjacencyMatrix g, int[] degrees)
        {
            // đếm số giá trị degrees[0], degrees[1], … bằng 0
            int count = 0;
            for (int i = 0; i < degrees.Length; i++)
                if (degrees[i] == 0)
                    count = count + 1;
            if (count == 0)
            {
                return 0;
            }
            else
            {
                return count;
            }
        }
        public int countHangedVertices(AdjacencyMatrix g, int[] degrees)
        {
            // đếm số giá trị degrees[0], degrees[1], … bằng 0
            int count = 0;
            for (int i = 0; i < degrees.Length; i++)
                if (degrees[i] == 1)
                    count = count + 1;
            if (count == 0)
            {
                return 0;
            }
            else
            {
                return count;
            }
        }

        public int countLoopVertices(AdjacencyMatrix g)
        {
            int count = 0;
            for (int i = 0; i <= g.n; i++)
            {
                for (int j = 0; j < g.n; j++)
                {
                    if (i == j)
                    {
                        if (g.a[i, j] == 1)
                        {
                            count = count + 1;
                        }
                    }
                }
            }
            if (count == 0)
            {
                return 0;
            }
            else
            {
                return count;
            }
        }
        public int countMultipleEdge(AdjacencyMatrix g)
        {
            int count = 0;
            for (int i = 0; i < g.n; i++)
            {
                for (int j = 0; j < g.n; j++)
                {
                    if (g.a[i, j] > 1)
                    {
                        count = count + 1;
                        a[j, i] = 1;
                    }
                }
            }
            if (count == 0)
            {
                return 0;
            }
            else
            {
                return count;
            }
        }

        public void UDG_summary(int mCount, int lCount)
        {
            if (mCount == 0 && lCount == 0)
            {
                Console.WriteLine("Don do thi");
            }

            if (mCount == 1 && lCount == 0)
            {
                Console.WriteLine("Da do thi");
            }

            if (mCount == 1 && lCount == 1)
            {
                Console.WriteLine("Gia do thi");
            }
        }
        public void DG_summary(int mCount)
        {
            if (mCount == 0)
            {
                Console.WriteLine("Do thi co huong");
            }
            else
            {
                Console.WriteLine("Da do thi co huong");
            }
        }
    }
}
