using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPBD
{
    public partial class BuildingInsert : Form
    {
        
        public BuildingInsert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string Imya
        {
            get
            {
                    return textBox1.Text; 
            }
        }
        public string Address
        {
            get { return textBox2.Text; }
        }

        private void BuildingInsert_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
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
