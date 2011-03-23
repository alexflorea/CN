using System.IO;
using dnAnalytics.LinearAlgebra;
using dnAnalytics.LinearAlgebra.IO;

namespace dnAnalytics.Examples.LinearAlgebra.IO
{
    public sealed class MatrixMarketReaderOverall
    {
        public static void Main()
        {
            //create the MatrixMarketReader
            SingleMatrixReader reader = new MatrixMarketReader();

            //create a matrix from a Matrix Market text file by passing the
            //reader the name/path of the file
            Matrix matrix = reader.ReadMatrix("somefile.mtx", StorageType.Dense);

            //create a matrix from a Matrix Market text file by passing the
            //reader the file stream.  the stream could have been any type
            //of stream that contains the matrix data.
            using (Stream stream = File.Open("somefile.mtx", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                matrix = reader.ReadMatrix(stream, StorageType.Dense);
            }
        }
    }
}