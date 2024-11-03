using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zenehallgatas.Model;

namespace Zenehallgatas.Components
{
    internal class ButtonComponent: Button
    {
        public ButtonComponent()
        {
            // Gomb megjelenésének beállítása
            this.BackColor = AppStyle.BUTTON_COLOR;
            this.ForeColor = AppStyle.FONT_COLOR;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Height = AppStyle.INPUT_HEIGHT;
            this.Font = AppStyle.BUTTON_FONT;
        }
    }
}
