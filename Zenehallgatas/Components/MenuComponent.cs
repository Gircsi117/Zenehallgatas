using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zenehallgatas.Model;

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
    }

    internal class MenuComponent: MenuStrip
    {
        public MenuItemComponent newZeneItem;
        public MenuItemComponent zeneListItem;

        public MenuComponent()
        {
            // Stílus beállítása
            this.BackColor = AppStyle.SECONDARY_COLOR;
            this.Dock = DockStyle.Top;
            this.Padding = new Padding(8, 8, 8, 8);

            // Elemek létrehozása és hozzáadása
            this.newZeneItem = new MenuItemComponent("Új Zene");
            this.zeneListItem = new MenuItemComponent("Zenék listája");
            
            this.Items.Add(this.newZeneItem);
            this.Items.Add(this.zeneListItem);
            
            // Renderer módosítása
            this.Renderer = new CustomeToolStripRenderer();
        }
    }
}
