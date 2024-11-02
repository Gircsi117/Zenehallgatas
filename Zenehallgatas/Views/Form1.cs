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
using Zenehallgatas.Controller;
using Zenehallgatas.Model;
using Zenehallgatas.Views;

namespace Zenehallgatas
{
    public partial class Form1 : Form
    {
        public string title; // Az eredetileg beállított form text

        public Form1()
        {
            InitializeComponent();

            // Form beállításai
            this.BackColor = AppStyle.PRIMARY_COLOR;
            this.title = this.Text;
                
            // Egy border a menü és a tartalom közé (az esztétika kedvéért)
            borderPanel.BackColor = AppStyle.BORDER_COLOR;

            // Navigációs modul beállítása
            ContentController.init(this);
            ContentController.setContent(new NewZeneUserControl(), "Új Zene");
        }
    }
}
