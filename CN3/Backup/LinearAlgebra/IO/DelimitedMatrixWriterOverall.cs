using System.IO;
using dnAnalytics.LinearAlgebra;
using dnAnalytics.LinearAlgebra.IO;

namespace dnAnalytics.Examples.LinearAlgebra.IO
{
    public sealed class DelimtedMatrixWriterOverall
    {
        public static void Main()
        {
            //create a DelimtedMatrixWriter that writes space delimited files.
            SingleMatrixWriter space = new DelimitedMatrixWriter(' ');

            //create a DelimtedMatrixWriter that writes comma delimited files.
            SingleMatrixWriter comma = new DelimitedMatrixWriter(',');

            //create a DelimtedMatrixWriter that writes tab delimited files
            SingleMatrixWriter tab = new DelimitedMatrixWriter('\t');

            //create a DelimtedMatrixWriter that writes '<::>' delimited files
            SingleMatrixWriter custom = new DelimitedMatrixWriter("<::>");

            //the matrix to write out
            Matrix matrix = new DenseMatrix(100, 100);

            //add data to the matrix
            //matrix[,] = ...

            //write the matrix to space delimited file using a file name
            space.WriteMatrix(matrix, "somefile.prn");

            //write the matrix to comma separated text file by passing the
            //reader the file stream. 
            using (Stream stream = File.Open("somefile.csv", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                comma.WriteMatrix(matrix, stream);
            }

            //write the matrix to a tab delimited text file using a TextWriter
            using (TextWriter text = new StreamWriter("somefile.tab"))
            {
                tab.WriteMatrix(matrix, text);
            }
        }
    }
}