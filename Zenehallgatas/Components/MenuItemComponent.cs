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

    internal class MenuItemComponent: ToolStripMenuItem
    {
        public MenuItemComponent(string text): base(text)
        {
            this.ForeColor = AppStyle.FONT_COLOR;
            this.Padding = new Padding(2);
        }
    }
}
