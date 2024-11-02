using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zenehallgatas.Controller
{
    public static class ContentController
    {
        public static Form1 form;
        public static Panel contentPanel;
        public static UserControl content;

        // Form elmentése
        public static void init(Form1 initForm, Panel panel)
        {
            form = initForm;
            contentPanel = panel;
        }
        
        // A form tartalmi részének módosítása
        public static void setContent(UserControl newContent, string title)
        {
            contentPanel.Controls.Clear();
            content = newContent;
            form.Text = $"{form.title} - {title}";
            contentPanel.Controls.Add(content);
        }

    }
}
