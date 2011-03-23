using System;
using System.Collections.Generic;
using dnAnalytics.LinearAlgebra;

namespace dnAnalytics.Examples.LinearAlgebra
{
    public sealed class SparseVectorEnumerator
    {
        public static void Main()
        {
            Vector vector = new SparseVector(10);
            for (int i = 0; i < vector.Count; i++)
            {
                vector[i] = i % 2 * i;
            }

            //The Vector enumerator also returns a KeyValuePair with the key being the 
            //element's position in the Vector and the value being the element's value.
            //For sparse matrices, the enumerator only returns non-zero values. 
            //The code below will return:
            //Position: 1, Value: 1
            //Position: 3, Value: 3
            //Position: 5, Value: 5
            //Position: 7, Value: 7
            //Position: 9, Value: 9
            foreach (KeyValuePair<int, double> element in vector.GetIndexedEnumerator())
            {
                Console.WriteLine("Position: {0}, Value: {1}", element.Key, element.Value);
            }
        }
    }
}
