using System;
using System.Collections.Generic;
using dnAnalytics.LinearAlgebra;

namespace dnAnalytics.Examples.LinearAlgebra
{
    public sealed class MatrixColumnEnumerator
    {
        public static void Main()
        {
            Matrix matrix = new DenseMatrix(5, 6);
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    matrix[i, j] = j;
                }
            }

            //the enumerator returns a KeyValuePair, where the key is the column number
            //and the value is the column as a Vector.
            foreach (KeyValuePair<int, Vector> column in matrix.GetColumnEnumerator())
            {
                Console.WriteLine("Column: {0}", column.Key);

                //the Vector enumerator also returns a KeyValuePair with the key
                //being the element's position in the Vector (the row in this case)
                //and the value being the element's value.
                foreach (double element in column.Value)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}