using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zenehallgatas.Controller;
using Zenehallgatas.Model;

namespace Zenehallgatas.Views
{
    public partial class ZeneListUserControl : UserControl
    {
        private DataGridView dataTable = new DataGridView();
        private DataGridViewButtonColumn editBTN = new DataGridViewButtonColumn();
        private List<Zene> list = new List<Zene>();

        public ZeneListUserControl()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.Load += this.onLoad;
            this.Resize += this.onResize;
        }

        private void onLoad(object sender, EventArgs e)
        {
            // Oszlopok kitöltik a területet
            this.dataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Oszlopok beállítása
            this.dataTable.Columns.Add("ID", "ID");
            this.dataTable.Columns.Add("Cim", "Cím");
            this.dataTable.Columns.Add("Eloado", "Előadó");
            this.dataTable.Columns.Add("Kiadas", "Kiadás éve");
            this.dataTable.Columns.Add("Hossz", "Zene hossza");
            this.dataTable.Columns.Add("Prioritas", "Prioritás");

            foreach (DataGridViewColumn col in this.dataTable.Columns)
            {
                col.ReadOnly = true;
            }
            this.dataTable.Columns["Prioritas"].ReadOnly = false;

            // Teszt adatok
            this.list = new List<Zene> {
                new Zene(1, "Kiskacs fürdik", "Valami gyerek zenész", 2004, 30, 10),
                new Zene(2, "Kocsog kurva (török gyerekdal)", "Egy török zseni", 2018, 80, 15),
                new Zene(3, "Monster", "Egy Isten", 2012, 140, 20),
                new Zene(4, "Pedró Pedró", "Mosómaci", 2024, 10, 30),
            };
            //this.list = ZeneController.getInstance().getAllZene().ToList();

            // Sorok hozzáadása
            foreach (Zene zene in this.list)
            {
                this.dataTable.Rows.Add(zene.getTableData());
            }

            // Sor gombok hozzáadása
            this.editBTN.HeaderText = "";
            this.editBTN.Text = "Módosítás";
            this.editBTN.Name = "editBTN";
            this.editBTN.UseColumnTextForButtonValue = true;

            this.dataTable.CellClick += this.editZene;

            this.dataTable.Columns.Add(this.editBTN);
            this.Controls.Add(this.dataTable);
        }

        private void onResize(object sender, EventArgs e)
        {
            int width = this.Width - AppStyle.GAP_SIZE * 2;
            int height = this.Height- AppStyle.GAP_SIZE * 2;

            this.dataTable.Size = new Size(width, height);
            this.Location = new Point(AppStyle.GAP_SIZE, AppStyle.GAP_SIZE);
        }

        private void editZene(object sender, DataGridViewCellEventArgs e)
        {
            // Ellenőrizzük, hogy a gomb oszlopára kattintottunk-e
            if (e.RowIndex >= 0 && e.ColumnIndex == this.dataTable.Columns["editBTN"].Index)
            {
                DataGridViewRow selectedRow = this.dataTable.Rows[e.RowIndex];
                if (selectedRow == null || selectedRow.Cells.Count == 0)
                {
                    MessageBox.Show("Nincs kiválasztott sor!");
                    return;
                }

                string id = selectedRow.Cells[0].Value.ToString();
                Zene item = list.Find(x=> x.ID.ToString() == id);

                if (item == null)
                {
                    MessageBox.Show("Zene nem található!");
                    return;
                }

                ContentController.setContent(new NewZeneUserControl(item), "Zene módosítása");
            }
        }
    }
}
