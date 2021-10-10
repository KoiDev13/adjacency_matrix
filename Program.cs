using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace adjacency_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Đọc ma trận
            AdjacencyMatrix a = new AdjacencyMatrix();
            a.readAdjacencyMatrix("C:/Users/edrag/source/repos/adjacency_matrix/Sample/inputD.txt");
            a.showAdjacencyMatrix();

            // Kiểm tra vô hướng hay có hướng
            // Vô hướng = Undirected Graph = UDG
            // Có hướng = Directed Graph = DG

            bool o = a.isUndirectedGraph(a);

            if (o == true) //True là đồ thị vô hướng
            {
                Console.WriteLine("Do thi vo huong");
                //Tính số đỉnh của đồ thị
                int vCount = a.countVertex(a);
                Console.WriteLine($"So dinh cua do thi: {vCount}");

                //Tính bậc của đỉnh
                int[] dCount = a.countDegrees(a);
                // Tính tổng bậc của đồ thị
                int alltopD = a.UDG_allTopDegree(a, dCount);

                //Tính cạnh của đồ thị 
                int eCount = a.UDG_countEdge(alltopD);
                Console.WriteLine($"So canh cua do thi: {eCount}");

                // Tính cặp đỉnh xuất hiện cạnh bộ 
                int mCount = a.countMultipleEdge(a);
                Console.WriteLine($"So cap dinh xuat hien canh boi: {mCount}");

                // Tính số cạnh khuyên
                int lCount = a.countLoopVertices(a);
                Console.WriteLine($"So canh khuyen: {lCount}");

                // Tính số đỉnh treo
                int hangVCount = a.countHangedVertices(a, dCount);
                Console.WriteLine($"So dinh treo: {hangVCount}");

                // Tính số đỉnh cô lập
                int isoVCount = a.countIsolatedVertices(a, dCount);
                Console.WriteLine($"So dinh co lap: {isoVCount}");

                // In kết quả bậc của đỉnh
                Console.WriteLine("Bac cua tung dinh:");
                for (int i = 0; i <= dCount.Length - 1; i++)
                {
                    Console.Write($"{i}({dCount[i]}) \t");
                }
                Console.Write("\n");

                //Kết luận
                a.UDG_summary(mCount, lCount);
            }
            else
            {
                Console.WriteLine("Do thi co huong");
                //Tính số đỉnh của đồ thị
                int vCount = a.countVertex(a);
                Console.WriteLine($"So dinh cua do thi: {vCount}");
                //Tính bậc IN của đỉnh
                int[] dInCount = a.DG_countDegreesIN(a);
                int[] dOutCount = a.DG_countDegreesOUT(a);
                // Tổng bậc IN
                int allTopDegIN = a.DG_alltopDegreesIN(dInCount);
                // Tổng bậc OUT
                int allTopDegOUT = a.DG_alltopDegreesOUT(dOutCount);
                Console.WriteLine($"Tong bac IN la: {allTopDegOUT}");
                int allTopDeg = allTopDegIN + allTopDegIN;

                //Tính số cạnh của đồ thị
                int eCountD = a.DG_countEdge(allTopDeg);
                Console.WriteLine($"So canh cua do thi: {eCountD}");

                // Tính cặp đỉnh xuất hiện cạnh bộ 
                int mCount = a.countMultipleEdge(a);
                Console.WriteLine($"So cap dinh xuat hien canh boi: {mCount}");

                // Tính số cạnh khuyên
                int lCount = a.countLoopVertices(a);
                Console.WriteLine($"So canh khuyen: {lCount}");

                // Tính số đỉnh treo
                int hangVCount = a.countHangedVertices(a, dOutCount);
                Console.WriteLine($"So dinh treo: {hangVCount}");

                // Tính số đỉnh cô lập
                int isoVCount = a.countIsolatedVertices(a, dOutCount);
                Console.WriteLine($"So dinh co lap: {isoVCount}");

                // In kết quả của đỉnh
                Console.WriteLine("(Bac vao - Bac ra) cua tung dinh:");
                for (int i = 0; i <= dInCount.Length - 1; i++)
                {
                    Console.Write($"{i}({dInCount[i]}-{dOutCount[i]}) \t");
                }
                Console.Write("\n");

                //Kết luận
                a.DG_summary(mCount);

            }
        }
    }
}
