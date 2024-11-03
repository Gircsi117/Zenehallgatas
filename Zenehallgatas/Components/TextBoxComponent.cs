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
    internal class TextBoxComponent: TextBox
    {
        public TextBoxComponent()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Multiline = true;
            this.WordWrap = false;
            this.Size = new Size(100, AppStyle.INPUT_HEIGHT);
            this.BackColor = AppStyle.INPUT_COLOR;
            this.Font = AppStyle.INPUT_FONT;
            this.ForeColor = AppStyle.FONT_COLOR;  
        }
    }
}
