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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox2.KeyPress += (s, e) =>
            {
                char number = e.KeyChar;
                if (!Char.IsDigit(number) && number != 8 && number != 44)
                {
                    e.Handled = true;
                }
                else if (number == 44 && (textBox2.Text.IndexOf(',') > -1 || textBox2.Text.Length == 0))
                {
                    e.Handled = true;
                }
            };
        }

        public int SelectedBuilding
        {
            get { return (int)comboBox1.SelectedValue; }
        }
        public string RoomName
        {
            get { return textBox1.Text; }
        }
        public double RoomSuare
        {
            get { return double.Parse(textBox2.Text); }
        }

        public void SetFields(DataTable buildingTable)
        {
            comboBox1.DataSource = buildingTable;
            comboBox1.DisplayMember = "Имя";
            comboBox1.ValueMember = "Код Здания";
            comboBox2.DataSource = buildingTable;
            comboBox2.DisplayMember = "Адрес";
            comboBox2.ValueMember = "Код Здания";

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            EventHandler handler2 = (s, e) =>
            {
                if (s is ComboBox sender && sender.SelectedIndex != -1)
                {
                    comboBox1.SelectedIndex = sender.SelectedIndex;
                    comboBox2.SelectedIndex = sender.SelectedIndex;
                }
            };

            comboBox1.SelectedIndexChanged += handler2;
            comboBox2.SelectedIndexChanged += handler2;
        }

        private void button1_Click(object sender, EventArgs e)
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

            if (comboBox1.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox1, "Ничего не выбрано");
                isValid = false;
            }

            if (comboBox2.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox2, "Ничего не выбрано");
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
