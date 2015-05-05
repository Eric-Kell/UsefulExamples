using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace HW5
{
    public partial class Form1 : Form
    {
        private static int count;
        public Form1()
        {
            count = 0;
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                // убрать рамки
                Button b = c as Button;
                if (b != null && b.Name != "buttonChangeLanguage")
                {
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                }

            } 
        }

        private void buttonChangeLanguage_Click(object sender, EventArgs e)
        {
            //button1.FlatAppearance.BorderSize = 0;
            string newLanguageString = count++ % 2 == 0 ? "ru-RU" : "en-US";
            var resources = new ComponentResourceManager(typeof(Form1));
            CultureInfo newCultureInfo = new CultureInfo(newLanguageString);
            foreach (Control c in this.Controls)
            {
               // применяем язык
               resources.ApplyResources(c, c.Name, newCultureInfo);
               
            } 

        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonPassword_Click(object sender, EventArgs e)
        {

        }


    }
}
