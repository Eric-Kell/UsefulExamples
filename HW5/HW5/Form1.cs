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
        private String[] rusMonths = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
                                             "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь",
                                             "Декабрь"};
        private String[] enMonths = {
                                              "January", "February", "March", "April", "May",
                                              "June", "July", "August", "September", "October",
                                              "November", "December"
                                          };
        private void  addMonths(String[] m)
        {
            foreach (String s in m)
            {
                this.comboBoxMonth.Items.Add(s);
            }
        }
        private void removeMonths(String[] m)
        {
            foreach (String s in m)
            {
                this.comboBoxMonth.Items.Remove(s);
            }
        }
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
            this.labelMoneyRub.Visible = false;
            addMonths(enMonths);
            for (int i = 1; i <= 9; i++)
                this.comboBoxSalary.Items.Add(i.ToString());
            for (int i = 1; i <= 31; i++ )
                this.comboBoxDay.Items.Add(i.ToString());
            for (int i = 1900; i <= 2015; i++)
                this.comboBoxYear.Items.Add(i.ToString());
        }

        private void buttonChangeLanguage_Click(object sender, EventArgs e)
        {
            //button1.FlatAppearance.BorderSize = 0;
            string newLanguageString = count++ % 2 == 0 ? "ru-RU" : "en-US";

            if (newLanguageString == "ru-RU")
            {
                removeMonths(enMonths);
                addMonths(rusMonths);
                this.labelMoneyRub.Visible = true;
                this.labelMoneyUSD.Visible = false;
            }
            else
            {
                removeMonths(rusMonths);
                addMonths(enMonths);
                this.labelMoneyRub.Visible = false;
                this.labelMoneyUSD.Visible = true;
            }

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

        private void comboBoxDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
