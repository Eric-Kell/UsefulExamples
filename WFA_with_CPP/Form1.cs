using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WFA_with_CPP
{
  public partial class Form1 : Form
  {

    private double c = 10;

    [DllImport("C:\\Users\\stars_000\\Desktop\\s123\\Project\\UsefulExamples\\MathFuncDll\\Debug\\MathFuncDll", CallingConvention = CallingConvention.Cdecl)]
    public static extern double Add(double a, double b);
    [DllImport("C:\\Users\\stars_000\\Desktop\\s123\\Project\\UsefulExamples\\MathFuncDll\\Debug\\MathFuncDll", CallingConvention = CallingConvention.Cdecl)]
    public static extern double SummArray(double[] ar, int i);
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      double[] ar = {1,2,3};
      c = SummArray(ar, 3);
      label1.Text = c.ToString();
    }
  }
}
