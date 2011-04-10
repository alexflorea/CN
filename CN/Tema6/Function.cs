using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Tema6
{
    class Function
    {
        ArrayList radacini;
        public Function()
        {
            radacini = new ArrayList();
        }

        double Evaluare(double x)
        {
            return x * x * x - 3 * x * x - x + 1;
        }

        double EvaluareDerivata(double x)
        {
            return 3 * x * x - 6 * x - 1;
        }

        public void PrintRadacini(TextBox tb)
        {
            tb.Clear();
            for (int i = 0; i < radacini.Count; i++) {
                tb.AppendText(radacini[i] + "\n");
            }
        }

        void MetodaSecantei()
        {

        }

        public void MetodaNewtonRaphson()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++) {
                double x = rand.NextDouble() * 200000 - 100000;
                int k = 0;
                double deltaX = 0;
                double e = 0.00000001;
                int kMax = 1000;
                do {
                    double derivata = EvaluareDerivata(x);
                    if (Math.Abs(derivata) < e) {
                        deltaX = 0.00001;
                    } else {
                        deltaX = Evaluare(x) / derivata;
                    }
                    x -= deltaX;
                    k++;
                } while (Math.Abs(deltaX) >= e && k < kMax && Math.Abs(deltaX) <= 100000000);
                if (Math.Abs(deltaX) < e) {
                    if(!Contains(x)) {
                        radacini.Add(x);
                    }
                } else {
                    //Divergenta
                }
            }
        }
        bool Contains(double x)
        {
            double e = 0.00000001;
            double abs = Math.Abs(x);
            for (int i = 0; i < radacini.Count; i++) {
                if (Math.Abs(x - (double)radacini[i]) < e)
                    return true;
            }
            return false;
        }
    }
}
