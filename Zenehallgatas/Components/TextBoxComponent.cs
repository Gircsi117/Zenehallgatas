using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Zenehallgatas.Model;

namespace Zenehallgatas.Components
{
    internal class TextBoxComponent: TextBox
    {
        public TextBoxComponent()
        {
            this.BackColor = AppStyle.INPUT_COLOR;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.ForeColor = AppStyle.FONT_COLOR;
        }

    }
}
