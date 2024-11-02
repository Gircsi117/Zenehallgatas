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
        public static UserControl content;

        // Form elmentése
        public static void init(Form1 initForm)
        {
            if(form != null) return;
            form = initForm;
        }
        
        // A form tartalmi részének módosítása
        public static void setContent(UserControl newContent, string title)
        {
            form.Controls.Remove(content);
            content = newContent;
            form.Text = $"{form.title} - {title}";
            form.Controls.Add(content);
        }

    }
}
