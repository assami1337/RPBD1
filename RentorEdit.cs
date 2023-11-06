using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPBD
{
    public partial class RentorEdit : Form
    {
        public RentorEdit()
        {
            InitializeComponent();
        }

        public string TextBox1Value
        {
            get { return textBox1.Text; }
        }
        public string TextBox2Value
        {
            get { return textBox2.Text; }
        }
        public string TextBox3Value
        {
            get { return textBox3.Text; }
        }
        public string TextBox4Value
        {
            get { return maskedTextBox1.Text; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetFields(string s1, string s2, string s3, string s4)
        {
            textBox1.Text = s1;
            textBox2.Text = s2;
            textBox3.Text = s3;
            maskedTextBox1.Text = s4;
        }
        public void SetFocus(string column)
        {
            switch (column)
            {
                case "ФИО":
                    {
                        textBox3.Select();
                    }
                    break;
                case "Контактный телефон":
                    {
                        maskedTextBox1.Select();
                    }
                    break;
                case "Название Фирмы":
                    {
                        textBox1.Select();
                    }
                    break;
                case "Юридический Адрес":
                    {
                        textBox2.Select();
                    }
                    break;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            bool isValid = true;

            if (textBox1.Text == String.Empty)
            {
                errorProvider1.SetError(textBox1, "Поле не заполнено");
                isValid = false;
            }

            if (textBox2.Text == String.Empty)
            {
                errorProvider1.SetError(textBox2, "Поле не заполнено");
                isValid = false;
            }
            if (textBox3.Text == String.Empty)
            {
                errorProvider1.SetError(textBox3, "Поле не заполнено");
                isValid = false;
            }
            if (maskedTextBox1.Text == String.Empty || maskedTextBox1.Text.Length != maskedTextBox1.Mask.Length)
            {
                errorProvider1.SetError(maskedTextBox1, "Поле не заполнено");
                isValid = false;
            }


            if (isValid)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

      

    }
}
