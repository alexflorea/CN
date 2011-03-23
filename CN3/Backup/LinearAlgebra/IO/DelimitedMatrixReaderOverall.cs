using System.IO;
using dnAnalytics.LinearAlgebra;
using dnAnalytics.LinearAlgebra.IO;

namespace dnAnalytics.Examples.LinearAlgebra.IO
{
    public sealed class DelimtedMatrixReaderOverall
    {
        public static void Main()
        {
            //create a DelimtedMatrixReader that reads whitespace delimited files.
            SingleMatrixReader white = new DelimitedMatrixReader();

            //create a DelimtedMatrixReader that reads whitespace delimited files.
            SingleMatrixReader comma = new DelimitedMatrixReader(',');

            //create a DelimtedMatrixReader that reads tab delimited files.
            SingleMatrixReader tab = new DelimitedMatrixReader('\t');

            //create a DelimtedMatrixReader that reads '<::>' delimited files
            SingleMatrixReader custom = new DelimitedMatrixReader("<::>");

            //create a matrix from a space delimited text file by passing the
            //reader the name/path of the file
            Matrix matrix = white.ReadMatrix("somefile.prn", StorageType.Dense);

            //create a matrix from a comma separated text file by passing the
            //reader the file stream.  the stream could have been any type
            //of stream that contains the matrix data.
            using (Stream stream = File.Open("somefile.csv", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                matrix = comma.ReadMatrix(stream, StorageType.Dense);
            }
        }
    }
}