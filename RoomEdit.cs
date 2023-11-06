using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RPBD
{
    public partial class RoomEdit : Form
    {
        public int? SelectedBuilding
        {
            get { return (int)comboBox1.SelectedValue; }
        }

        public string RoomName
        {
            get { return textBox1.Text; }
        }

        public double RoomSquare
        {
            get
            {
                return Convert.ToDouble(textBox2.Text);
            }
        }

        public RoomEdit()
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

        public void SetFields(DataTable buildingTable, string roomName, double roomSquare, DataGridViewRow currentRow)
        {
            comboBox1.DataSource = buildingTable;
            comboBox1.DisplayMember = "Имя";
            comboBox1.ValueMember = "Код Здания";
            comboBox2.DataSource = buildingTable;
            comboBox2.DisplayMember = "Адрес";
            comboBox2.ValueMember = "Код Здания";

            comboBox1.SelectedValue = currentRow.Cells["Код Здания"].Value.ToString();
            comboBox2.SelectedValue = currentRow.Cells["Код Здания"].Value.ToString();
            textBox1.Text = roomName;
            textBox2.Text = roomSquare.ToString();
        }

        public void SetFocus(string column)
        {
            switch (column)
            {
                case "Название здания":
                    {
                        comboBox1.Select();
                    }
                    break;
                case "Площадь помещения":
                    {
                        textBox2.Select();
                    }
                    break;
                case "Имя помещения":
                    {
                        textBox1.Select();
                    }
                    break;
                case "Адрес здания":
                    {
                        comboBox2.Select();
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoomEdit_Load(object sender, EventArgs e)
        {

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
