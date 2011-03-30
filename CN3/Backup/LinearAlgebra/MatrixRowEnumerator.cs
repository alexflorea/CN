using System;
using System.Collections.Generic;
using dnAnalytics.LinearAlgebra;

namespace dnAnalytics.Examples.LinearAlgebra
{
    public sealed class MatrixRowEnumerator
    {
        public static void Main()
        {
            Matrix matrix = new DenseMatrix(5, 6);
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    matrix[i, j] = i;
                }
            }

            //the enumerator returns a KeyValuePair, where the key is the row number
            //and the value is the row as a Vector.
            foreach (KeyValuePair<int, Vector> row in matrix.GetRowEnumerator())
            {
                Console.WriteLine("Row: {0}", row.Key);

                foreach (double element in row.Value)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}