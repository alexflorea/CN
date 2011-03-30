using System;
using System.Collections.Generic;
using dnAnalytics.LinearAlgebra;

namespace dnAnalytics.Examples.LinearAlgebra
{
    public sealed class VectorEnumerator
    {
        public static void Main()
        {
            Vector vector = new DenseVector(10);
            for (int i = 0; i < vector.Count; i++)
            {
                vector[i] = i;
            }

            //The Vector enumerator also returns a KeyValuePair with the key being the 
            //element's position in the Vector and the value being the element's value.
            foreach (KeyValuePair<int, double> element in vector.GetIndexedEnumerator())
            {
                Console.WriteLine("Position: {0}, Value: {1}", element.Key, element.Value);
            }

            //The Vector enumerator each element of the vector
            foreach (double element in vector)
            {
                Console.WriteLine("Value: {0}", element);
            }
        }
    }
}
