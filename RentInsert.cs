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
    public partial class RentInsert : Form
    {
        public RentInsert()
        {
            InitializeComponent();
        }

        public int SelectedBuilding
        {
            get { return (int)comboBox1.SelectedValue; }
        }

        public int SelectedRoom
        {
            get { return (int)comboBox5.SelectedValue; }
        }

        public int SelectedRenter
        {
            get { return (int)comboBox7.SelectedValue; }
        }

        public string RentNumber
        {
            get { return textBox1.Text; }
        }

        public DateTime RentDate
        {
            get { return dateTimePicker1.Value; }
        }

        public DateTime RentStart
        {
            get { return dateTimePicker2.Value; }
        }

        public DateTime RentEnd
        {
            get { return dateTimePicker3.Value; }
        }

        public void SetFields(DataTable buildingTable, DataTable roomTable, DataTable rentorTable)
        {
            comboBox1.DataSource = buildingTable;
            comboBox1.DisplayMember = "Имя";
            comboBox1.ValueMember = "Код Здания";
            comboBox2.DataSource = buildingTable;
            comboBox2.DisplayMember = "Адрес";
            comboBox2.ValueMember = "Код Здания";

            comboBox6.DisplayMember = "Имя";
            comboBox6.ValueMember = "Код Помещения";
            comboBox5.DisplayMember = "Площадь";
            comboBox5.ValueMember = "Код Помещения";

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;


            comboBox1.SelectedIndexChanged += (s, e) =>
            {
                // Получаем выбранное здание
                var selectedBuildingCode = (int)comboBox1.SelectedValue;

                // Используем LINQ для фильтрации помещений, которые принадлежат выбранному зданию
                var rooms = roomTable.AsEnumerable()
                    .Where(row => row.Field<int>("Код Здания") == selectedBuildingCode);

                // Проверяем, есть ли помещения
                if (rooms.Any())
                {
                    // Если есть помещения, привязываем их к comboBox6 и comboBox5
                    var roomsTable = rooms.CopyToDataTable();
                    comboBox6.DataSource = roomsTable;
                    comboBox5.DataSource = roomsTable;

                    // Устанавливаем DisplayMember и ValueMember после установки DataSource
                    comboBox6.DisplayMember = "Имя";
                    comboBox6.ValueMember = "Код Помещения";
                    comboBox5.DisplayMember = "Площадь";
                    comboBox5.ValueMember = "Код Помещения";
                }
                else
                {
                    // Если помещений нет, очищаем comboBox6 и comboBox5
                    comboBox6.DataSource = null;
                    comboBox5.DataSource = null;
                }
            };

            EventHandler handler1 = (s, e) =>
            {
                if (s is ComboBox sender && sender.SelectedIndex != -1)
                {
                    comboBox3.SelectedIndex = sender.SelectedIndex;
                    comboBox4.SelectedIndex = sender.SelectedIndex;
                    comboBox7.SelectedIndex = sender.SelectedIndex;
                    comboBox8.SelectedIndex = sender.SelectedIndex;
                }
            };

            comboBox3.SelectedIndexChanged += handler1;
            comboBox4.SelectedIndexChanged += handler1;
            comboBox7.SelectedIndexChanged += handler1;
            comboBox8.SelectedIndexChanged += handler1;

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

            comboBox4.DataSource = rentorTable;
            comboBox4.DisplayMember = "Название Фирмы";
            comboBox4.ValueMember = "Код арендатора";
            comboBox3.DataSource = rentorTable;
            comboBox3.DisplayMember = "Юридический Адрес";
            comboBox3.ValueMember = "Код арендатора";
            comboBox8.DataSource = rentorTable;
            comboBox8.DisplayMember = "ФИО";
            comboBox8.ValueMember = "Код арендатора";
            comboBox7.DataSource = rentorTable;
            comboBox7.DisplayMember = "Контактный телефон";
            comboBox7.ValueMember = "Код арендатора";

            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
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

            if (comboBox3.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox3, "Ничего не выбрано");
                isValid = false;
            }

            if (comboBox4.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox4, "Ничего не выбрано");
                isValid = false;
            }

            if (comboBox5.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox5, "Ничего не выбрано");
                isValid = false;
            }

            if (comboBox6.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox6, "Ничего не выбрано");
                isValid = false;
            }

            if (comboBox7.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox7, "Ничего не выбрано");
                isValid = false;
            }

            if (comboBox8.SelectedValue == null)
            {
                errorProvider1.SetError(comboBox8, "Ничего не выбрано");
                isValid = false;
            }

            if (dateTimePicker1.Value == null)
            {
                errorProvider1.SetError(dateTimePicker1, "Поле не заполнено");
                isValid = false;
            }

            if (dateTimePicker2.Value == null)
            {
                errorProvider1.SetError(dateTimePicker2, "Поле не заполнено");
                isValid = false;
            }

            if (dateTimePicker3.Value == null)
            {
                errorProvider1.SetError(dateTimePicker3, "Поле не заполнено");
                isValid = false;
            }

            if (dateTimePicker2.Value > dateTimePicker3.Value)
            {
                errorProvider1.SetError(dateTimePicker3, "Конец аренды не может быть раньше начала аренды");
                isValid = false;
            }

            if (isValid)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
