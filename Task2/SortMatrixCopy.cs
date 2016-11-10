using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class SortMatrixCopy
    {
        public static void Sorting(int[][] matrix, IComparer<int[]> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();

            Sorting(matrix, comparer.Compare);
        }

        public static void Sorting(int[][] matrix, Func<int[], int[], int> comparerDelegate)
        {
            if (matrix == null || comparerDelegate == null)
                throw new ArgumentNullException();

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    if (comparerDelegate(matrix[i], matrix[j]) > 0)
                    {
                        Swap(ref matrix[i], ref matrix[j]);
                    }
                }
            }
        }

        private static void Swap(ref int[] string1, ref int[] string2)
        {
            int[] temp = string1;
            string1 = string2;
            string2 = temp;
        }
    }
}
