using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using dnAnalytics.LinearAlgebra;
namespace Tema5
{
    class Matrice
    {
        public Matrice()
        {

        }

        public bool ReadFile(string fileName)
        {
            TextReader tr = null;
            try {
                tr = new StreamReader(fileName);
            } catch (Exception e) {
                return false;
            }

            string buffer = tr.ReadLine();
            string[] numbers = buffer.Split(' ');

            N = int.Parse(numbers[0]);
            P = int.Parse(numbers[1]);

            A = new double[P][];
            for (int i = 0; i < P; i++) {
                buffer = tr.ReadLine();
                numbers = buffer.Split(' ');
                A[i] = new double[N];
                for (int j = 0; j < N; j++) {
                    A[i][j] = int.Parse(numbers[j]);
                }
            }
            B = new double[P];
            for (int i = 0; i < P; i++) {
                buffer = tr.ReadLine();
                B[i] = int.Parse(buffer);                
            }

            return true;
        }
        

        public void PrintMatrix(TextBox tb)
        {
            for (int i = 0; i < P; i++) {
                for (int j = 0; j < N; j++) {
                    tb.AppendText(A[i][j] + " ");
                }
                tb.AppendText("\n");
            }
            for (int i = 0; i < P; i++) {
                tb.AppendText(B[i] + "\n");
            }
        }

        public int N { get; set; }
        public int P { get; set; }
        public double[][] A { get; set; }
        public double[] B { get; set; }
    }
}
