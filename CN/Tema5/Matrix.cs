using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using dnAnalytics.LinearAlgebra;
namespace Tema5
{
    class Matrix
    {
        
        Matrix()
        {

        }

        bool ReadFile(string fileName)
        {
            TextReader tr = null;
            try {
                tr = new StreamReader(fileName);
            } catch {

            }
            return true;
        }
        

        void PrintMatrix()
        {

        }
    }
}
