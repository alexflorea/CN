using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tema5
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Matrice m = new Matrice();
            m.ReadFile("input.txt");
            m.PrintMatrix(this.textBox1);           
        }
    }
}
