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
        DataGridView dataTable = new DataGridView();

        public ZeneListUserControl()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;

            this.Load += this.onLoad;
            this.Resize += this.onResize;
        }

        private void onLoad(object sender, EventArgs e)
        {
            this.dataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dataTable.Columns.Add("Cim", "Cím");
            this.dataTable.Columns.Add("Eloado", "Előadó");
            this.dataTable.Columns.Add("Kiadas", "Kiadás éve");
            this.dataTable.Columns.Add("Hossz", "Zene hossza");
            this.dataTable.Columns.Add("Prioritas", "Prioritás");

            Zene[] list = new Zene[] {
                new Zene(1, "Kiskacs fürdik", "Valami gyerek zenész", 2004, 30, 10),
                new Zene(2, "Kocsog kurva (török gyerekdal)", "Egy török", 2018, 80, 15),
                new Zene(3, "Monster", "Isten", 2012, 140, 20),
            };
            //list = ZeneController.getInstance().getAllZene().ToArray();

            foreach (Zene zene in list)
            {
                this.dataTable.Rows.Add(zene.getTableData());
            }

            this.Controls.Add(this.dataTable);
        }

        private void onResize(object sender, EventArgs e)
        {
            int width = this.Width - AppStyle.GAP_SIZE * 2;
            int height = this.Height- AppStyle.GAP_SIZE * 2;

            this.dataTable.Size = new Size(width, height);
            this.Location = new Point(AppStyle.GAP_SIZE, AppStyle.GAP_SIZE);
        }
    }
}
