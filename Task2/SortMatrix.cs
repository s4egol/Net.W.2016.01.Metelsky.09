using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SortMatrix
    {
        /// <summary>
        /// Sort a matrix of integers
        /// </summary>
        /// <param name="matrix">Sortable matrix</param>
        /// <param name="comparer"></param>
        public static void Sorting(int[][] matrix, IComparer<int[]> comparer)
        {
            if (matrix == null || comparer == null)
                throw new ArgumentNullException();

            for (int i = 0; i < matrix.Length - 1; i++)
            {
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    if (comparer.Compare(matrix[i], matrix[j]) > 0)
                    {
                        Swap(ref matrix[i], ref matrix[j]);
                    }
                }
            }
        }

        public static void Sorting(int[][] matrix, Func<int[], int[], int> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();

            Sorting(matrix, new DelegateWithSupportInterface<int[]>(comparer));
        }


        private class DelegateWithSupportInterface<T> : IComparer<T>
        {
            private readonly Func<T, T, int> comparerDelegate;

            public DelegateWithSupportInterface(Func<T, T, int> comparer)
            {
                comparerDelegate = comparer;
            }

            public int Compare(T x, T y)
            {
                return comparerDelegate(x, y);
            }

        }


        /// <summary>
        /// Swaps the elements of the array
        /// </summary>
        /// <param name="string1">First string of array</param>
        /// <param name="string2">Second string of array</param>
		private static void Swap(ref int[] string1, ref int[] string2)
        {
            int[] temp = string1;
            string1 = string2;
            string2 = temp;
        }
    }
}
