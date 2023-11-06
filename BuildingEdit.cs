using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPBD
{
    public partial class BuildingEdit : Form
    {
        
        
        public BuildingEdit()
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetFields(string s1, string s2)
        {
            textBox1.Text = s1;
            textBox2.Text = s2;
        }
        public void SetFocus(string column)
        {
            switch(column)
            {
                case "Адрес":
                    {
                        textBox2.Select();
                    }
                    break;
            }

        }


        private void button2_Click(object sender, EventArgs e)
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

            if (isValid)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
