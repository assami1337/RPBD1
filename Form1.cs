using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;


namespace RPBD
{
    public partial class Form1 : Form
    {
        DataTable buildingTable = new DataTable("Здание");
        DataTable roomTable = new DataTable("Помещение");
        DataTable tenantTable = new DataTable("Арендатор");
        DataTable leaseTable = new DataTable("Аренда");


        public Form1()
        {
            InitializeComponent();
            buildingTable.Columns.Add("Код Здания", typeof(int));
            buildingTable.Columns["Код Здания"].AutoIncrement = true;
            buildingTable.PrimaryKey = new DataColumn[] { buildingTable.Columns["Код Здания"] };
            buildingTable.Columns.Add("Имя", typeof(string));
            buildingTable.Columns.Add("Адрес", typeof(string));

            DataRow row = buildingTable.NewRow(); 
            row["Имя"] = "Здание 5";
            row["Адрес"] = "Московский тракт 135";
            buildingTable.Rows.Add(row);
            DataRow row1 = buildingTable.NewRow();
            row1["Имя"] = "Здание 1";
            row1["Адрес"] = "Ленина 18";
            buildingTable.Rows.Add(row1);
            DataRow row2 = buildingTable.NewRow();
            row2["Имя"] = "Здание 12";
            row2["Адрес"] = "Мельникате 30к1";
            buildingTable.Rows.Add(row2);

            roomTable.Columns.Add("Код Помещения", typeof(int));
            roomTable.Columns["Код Помещения"].AutoIncrement = true;
            roomTable.PrimaryKey = new DataColumn[] { roomTable.Columns["Код Помещения"] };
            roomTable.Columns.Add("Имя", typeof(string));
            roomTable.Columns.Add("Площадь", typeof(double));
            roomTable.Columns.Add("Код Здания", typeof(int));

            DataRow row3 = roomTable.NewRow();
            row3["Имя"] = "Комната 1";
            row3["Площадь"] = 21.5;
            row3["Код Здания"] = buildingTable.Rows[0]["Код Здания"];
            roomTable.Rows.Add(row3);
            DataRow row4 = roomTable.NewRow();
            row4["Имя"] = "Комната 5";
            row4["Площадь"] = 51;
            row4["Код Здания"] = buildingTable.Rows[1]["Код Здания"];
            roomTable.Rows.Add(row4);
            DataRow row5 = roomTable.NewRow();
            row5["Имя"] = "Комната 31";
            row5["Площадь"] = 65;
            row5["Код Здания"] = buildingTable.Rows[2]["Код Здания"];
            roomTable.Rows.Add(row5);

            tenantTable.Columns.Add("Код арендатора", typeof(int));
            tenantTable.Columns["Код арендатора"].AutoIncrement = true;
            tenantTable.PrimaryKey = new DataColumn[] { tenantTable.Columns["Код арендатора"] };
            tenantTable.Columns.Add("Название Фирмы", typeof(string));
            tenantTable.Columns.Add("Юридический Адрес", typeof(string));
            tenantTable.Columns.Add("ФИО", typeof(string));
            tenantTable.Columns.Add("Контактный телефон", typeof(string));

            DataRow row6 = tenantTable.NewRow();
            row6["Название Фирмы"] = "Додо Пицца";
            row6["Юридический Адрес"] = "г.Москва, ул. Ленина, д. 37, кв. 5";
            row6["ФИО"] = "Иванов Иван Иванович";
            row6["Контактный телефон"] = "+7(905)123-45-67";
            tenantTable.Rows.Add(row6);

            DataRow row7 = tenantTable.NewRow();
            row7["Название Фирмы"] = "Рога и Копыта";
            row7["Юридический Адрес"] = "г.Санкт-Петербург, пр. Невский, д. 123";
            row7["ФИО"] = "Петров Петр Петрович";
            row7["Контактный телефон"] = "+7(911)987-65-43";
            tenantTable.Rows.Add(row7);

            DataRow row8 = tenantTable.NewRow();
            row8["Название Фирмы"] = "Загадочная Фирма";
            row8["Юридический Адрес"] = "г. Тюмень, ул. Сибирская, д. 15";
            row8["ФИО"] = "Сидорова Анна Васильевна";
            row8["Контактный телефон"] = "+7(922)333-44-55";
            tenantTable.Rows.Add(row8);

            leaseTable.Columns.Add("Код Аренды", typeof(int));
            leaseTable.Columns["Код Аренды"].AutoIncrement = true;
            leaseTable.PrimaryKey = new DataColumn[] { leaseTable.Columns["LeaseCode"] };
            leaseTable.Columns.Add("Код Помещения", typeof(int));
            leaseTable.Columns.Add("Код арендатора", typeof(int));
            leaseTable.Columns.Add("Номер Договора", typeof(string));
            leaseTable.Columns.Add("Дата оформления договора", typeof(DateTime));
            leaseTable.Columns.Add("Дата начала аренды", typeof(DateTime));
            leaseTable.Columns.Add("Дата конца аренды", typeof(DateTime));

            DataRow row9 = leaseTable.NewRow();
            row9["Код Помещения"] = roomTable.Rows[0]["Код Помещения"];
            row9["Код арендатора"] = tenantTable.Rows[0]["Код арендатора"];
            row9["Номер Договора"] = "1536";
            row9["Дата оформления договора"] = new DateTime(2015, 7, 20);
            row9["Дата начала аренды"] = new DateTime(2015, 7, 20);
            row9["Дата конца аренды"] = new DateTime(2015, 7, 20);
            leaseTable.Rows.Add(row9);
            DataRow row10 = leaseTable.NewRow();
            row10["Код Помещения"] = roomTable.Rows[1]["Код Помещения"];
            row10["Код арендатора"] = tenantTable.Rows[1]["Код арендатора"];
            row10["Номер Договора"] = "1211";
            row10["Дата оформления договора"] = new DateTime(2016, 7, 20);
            row10["Дата начала аренды"] = new DateTime(2016, 8, 20);
            row10["Дата конца аренды"] = new DateTime(2016, 9, 20);
            leaseTable.Rows.Add(row10);
            DataRow row11 = leaseTable.NewRow();
            row11["Код Помещения"] = roomTable.Rows[2]["Код Помещения"];
            row11["Код арендатора"] = tenantTable.Rows[2]["Код арендатора"];
            row11["Номер Договора"] = "1987";
            row11["Дата оформления договора"] = new DateTime(2019, 5, 12);
            row11["Дата начала аренды"] = new DateTime(2023, 7, 20);
            row11["Дата конца аренды"] = new DateTime(2023, 9, 20);
            leaseTable.Rows.Add(row11);

            dataSet1.Tables.Add(buildingTable);
            dataSet1.Tables.Add(roomTable);
            dataSet1.Tables.Add(tenantTable);
            dataSet1.Tables.Add(leaseTable);
            
        }

        public DataSet DataSet1
        {
            set { dataSet1 = value; }
        }


        private void каскадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void горизонтальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void вертикальноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void зданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var ch in MdiChildren)
            {
                if(ch.Text == str)
                {
                    flag = false;
                    зданиеToolStripMenuItem.Checked = false;
                    ch.Close();
                    break;
                }
            }
            if (flag)
            {
                зданиеToolStripMenuItem.Checked = true;
                Form2 form1 = new Form2()
                {
                    MdiParent = this,
                    Text = str
                };
                form1.FormClosing += (s, e1) => { зданиеToolStripMenuItem.Checked = false; };
                form1.LoadData(dataSet1);
                form1.Show();
                form1.BringToFront();
            }
        }

        private void помещениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var ch in MdiChildren)
            {
                if (ch.Text == str)
                {
                    flag = false;
                    помещениеToolStripMenuItem.Checked = false;
                    ch.Close();
                    break;
                }
            }
            if (flag)
            {
                помещениеToolStripMenuItem.Checked = true;
                Form2 form1 = new Form2()
                {
                    MdiParent = this,
                    Text = str
                };
                form1.FormClosing += (s, e1) => { помещениеToolStripMenuItem.Checked = false; };
                form1.LoadData(dataSet1);
                form1.Show();
                form1.BringToFront();
            }
        }

        private void арендаторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var ch in MdiChildren)
            {
                if (ch.Text == str)
                {
                    flag = false;
                    арендаторToolStripMenuItem.Checked = false;
                    ch.Close();
                    break;
                }
            }
            if (flag)
            {
                арендаторToolStripMenuItem.Checked = true;
                Form2 form1 = new Form2()
                {
                    MdiParent = this,
                    Text = str
                };
                form1.FormClosing += (s, e1) => { арендаторToolStripMenuItem.Checked = false; };
                form1.LoadData(dataSet1);
                form1.Show();
                form1.BringToFront();
            }
            
        }

        private void арендаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String str = (sender as ToolStripMenuItem).Text;
            bool flag = true;
            foreach (var ch in MdiChildren)
            {
                if (ch.Text == str)
                {
                    flag = false;
                    арендаToolStripMenuItem.Checked = false;
                    ch.Close();
                    break;
                }
            }
            if (flag)
            {
                арендаToolStripMenuItem.Checked = true;
                Form2 form1 = new Form2()
                {
                    MdiParent = this,
                    Text = str
                };
                form1.FormClosing += (s, e1) => { арендаToolStripMenuItem.Checked = false; };
                form1.LoadData(dataSet1);
                form1.Show();
                form1.BringToFront();
            }
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataSet1.WriteXml("dataset.xml");
            dataSet1.WriteXmlSchema("Customers.xsd");
            MessageBox.Show("Данные и схема успешно сохранен в XML файл.");
        }


        private void создатьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataSet1.Clear();
            foreach (var ch in MdiChildren)
            {
                ch.Close();
            }
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                if (Path.GetExtension(filePath).Equals(".xml"))
                {
                    foreach (var ch in MdiChildren)
                    {
                        ch.Close();
                    }
                    dataSet1.Clear();
                    dataSet1.ReadXml(filePath);
                }
                else
                {
                    MessageBox.Show("Неподдерживаемый формат файла.");
                }
            }
        }
    }
}
