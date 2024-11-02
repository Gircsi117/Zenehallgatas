using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zenehallgatas.Components;
using Zenehallgatas.Model;
using Zenehallgatas.Views;

namespace Zenehallgatas
{
    public partial class Form1 : Form
    {
        private MenuComponent menu;
        private UserControl control;
        private string title;

        public Form1()
        {
            InitializeComponent();

            this.BackColor = AppStyle.PRIMARY_COLOR;
            this.title = this.Text;

            Panel panel = new Panel();
            panel.BackColor = AppStyle.BORDER_COLOR;
            panel.Height = 1;
            panel.Dock = DockStyle.Top;
            this.Controls.Add(panel);

            this.menu = new MenuComponent();
            this.Controls.Add(this.menu);
            
            this.menu.newZeneItem.Click += (object sender, EventArgs e) => setControl(new NewZeneUserControl(), "Új Zene");
            this.menu.zeneListItem.Click += (object sender, EventArgs e) => setControl(new ZeneListUserControl(), "Zene Lista");

            

            setControl(new NewZeneUserControl(), "Új Zene");
        }

        private void setControl(UserControl newControl, string newTitle)
        {
            this.Text = $"{this.title} - {newTitle}";
            this.Controls.Remove(this.control);
            this.control = newControl;
            this.Controls.Add(this.control);

        }
    }
}
