using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dnAnalytics;
using System.IO;
using dnAnalytics.LinearAlgebra;
using dnAnalytics.LinearAlgebra.Decomposition;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filePath = "C:\\input.txt";
        string line; 
        Matrix A;
        Matrix Giv_R, Giv_Q;
        Vector Giv_b;
        Vector b,s;
        int n;
        double eps;

        void print_matrix(Matrix m)
        {
            string s;
            for (int i = 0; i < m.Rows; i++)
            {
                s = "";
                for (int j = 0; j < m.Columns; j++)
                {
                    s = s + String.Format("  {0:F26}", m[i,j]) + "\t";
                   // s = s + m[i, j].ToString() + "\t";
                }
                s = s + "\r\n";
                textBox1.AppendText(s);
            }


        }
        void print_vector(Vector m)
        {
            string s;
            
            
                s = "";
                for (int j = 0; j < m.Count; j++)
                {
                    s = s + m[j].ToString() + "\t";
                }
                s = s + "\r\n";
                textBox1.AppendText(s);
            


        }
        Vector mul_matrix(Matrix a, Vector b) {

            return a.Multiply(b);
        }
        Matrix generate_rotate(double p,int q,double c,double s)
        {
            Matrix R;
            R = new DenseMatrix(n, n);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++) {
                    if ((i == j) && (i != p) && (i != q)) R[i, j] = 1;
                    else
                        if ((i == j) && ((i == p) || i == q)) R[i, j] = c;
                        else
                            if ((i == p) && (j == q)) R[i, j] = s;
                            else
                                if ((i == q) && (j == p)) R[i, j] = -s;
                                else
                                    R[i, j] = 0;
                }

                    return R;
        }
        void ReadFromFile() {
            StreamReader file = null;
            try
            {
                file = new StreamReader(filePath);
                line = file.ReadLine();
                eps = System.Convert.ToDouble(line); // epsilon
                line = file.ReadLine();
                n = System.Convert.ToInt32(line);  // n - dimensiunea matricii
                A = new DenseMatrix(n, n);
                for (int i = 0; i < A.Rows; i++)
                {
                    line = file.ReadLine();
                    for (int j = 0; j < A.Columns; j++)
                    {
                        A[i, j] = System.Convert.ToInt32(line.Split(' ').ElementAt(j));
                    }
                }
                s = new DenseVector(n);
                line = file.ReadLine();
                for (int j = 0; j < A.Columns; j++)
                {
                    s[j] = System.Convert.ToInt32(line.Split(' ').ElementAt(j));
                }
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        
        }
        void Givens_Decomposition(Matrix A, Vector b)
        {
            Matrix q,R;
            q = new DenseMatrix(n, n);
            R = new DenseMatrix(n, n);
            q = new DenseMatrix(A);
            double r0, c1, s1;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i == j) q[i, j] = 1;
                    else
                        q[i, j] = 0;
            for (int r = 0; r < n; r++)
            {
                for (int i = r + 1; i < n; i++)
                {
                    r0 = Math.Sqrt((A[r, r] * A[r, r] + A[i, r] * A[i, r]));
                    if (r0 < eps) { c1 = 1; s1 = 0; }
                    else { c1 = A[r, r] / r0; s1 = A[i, r] / r0; }

                    R = generate_rotate(r, i, c1, s1);
                    print_matrix(R);
                    A = R.Multiply(A); // R[r,i]
                    b = R.Multiply(b); // R[r,i]
                    q = R.Multiply(q); // R[r,i]
                }

            }
            Giv_R = A;
            Giv_b = b;
            Giv_Q = q.Transpose();


        }
            
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

                ReadFromFile();
                b = new DenseVector(n, n); 
                b = A.Multiply(s);    // Punctul 1
                
            
               
                Giv_R = new DenseMatrix(n, n);
                Giv_Q = new DenseMatrix(n, n);

                //Givens
                Givens_Decomposition(A,b); // Punctul 2


                dnAnalytics.LinearAlgebra.Decomposition.IQR t;
                t = new Householder(A);
                textBox1.AppendText("\r\nR\r\n\r\n");
                print_matrix(t.R());
                textBox1.AppendText("\r\nR\r\n\r\n");
                print_matrix(Giv_R);
                textBox1.AppendText("Q\r\n\r\n");
                print_matrix(t.Q());
                textBox1.AppendText("Q\r\n\r\n");
                print_matrix(Giv_Q);
                
        }


    }
}
