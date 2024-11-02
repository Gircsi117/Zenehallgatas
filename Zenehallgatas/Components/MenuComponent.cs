using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zenehallgatas.Controller;
using Zenehallgatas.Model;
using Zenehallgatas.Views;

namespace Zenehallgatas.Components
{
    public class CustomeToolStripRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            base.OnRenderMenuItemBackground(e);

            if (e.Item.Selected)
            {
                Rectangle fillRect = new Rectangle(0, 0, e.Item.Width, e.Item.Height);
                e.Graphics.FillRectangle(new SolidBrush(AppStyle.BUTTON_COLOR), fillRect);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);

            e.Item.ForeColor = AppStyle.FONT_COLOR;
            e.Item.Padding = new Padding(1);
        }
    }

    internal class MenuComponent: MenuStrip
    {
        public ToolStripMenuItem newZeneItem;
        public ToolStripMenuItem zeneListItem;

        public MenuComponent()
        {
            // Stílus beállítása
            this.BackColor = AppStyle.SECONDARY_COLOR;
            this.Dock = DockStyle.Top;
            this.Padding = new Padding(8);

            // Elemek létrehozása és hozzáadása
            this.newZeneItem = new ToolStripMenuItem("Új Zene");
            this.zeneListItem = new ToolStripMenuItem("Zenék listája");

            this.newZeneItem.Click += (object sender, EventArgs e) => ContentController.setContent(new NewZeneUserControl(), "Új Zene");
            this.zeneListItem.Click += (object sender, EventArgs e) => ContentController.setContent(new ZeneListUserControl(), "Zene Lista");

            this.Items.Add(this.newZeneItem);
            this.Items.Add(this.zeneListItem);
            
            // Renderer módosítása
            this.Renderer = new CustomeToolStripRenderer();
        }
    }
}
