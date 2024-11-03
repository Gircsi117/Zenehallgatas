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

namespace Zenehallgatas.Views
{
    public partial class NewZeneUserControl : UserControl
    {
        private TextBoxComponent cimTBOX = new TextBoxComponent();
        private Label cimLabel = new Label();

        private TextBoxComponent eloadoTBOX = new TextBoxComponent();
        private Label eloadoLabel = new Label();

        private TextBoxComponent kiadasTBOX = new TextBoxComponent();
        private Label kiadasLabel = new Label();

        private TextBoxComponent hosszTBOX = new TextBoxComponent();
        private Label hosszLabel = new Label();

        private TextBoxComponent prioritasTBOX = new TextBoxComponent();
        private Label prioritasLabel = new Label();

        private ButtonComponent saveBTN = new ButtonComponent();

        public NewZeneUserControl()
        {
            InitializeComponent();

            this.Dock = DockStyle.Fill;
            this.Load += this.onLoad;
            this.Resize += this.onResize;
        }

        public void onLoad(object sender, EventArgs e)
        {
            string[] titles = new string[5] { "Cím", "Előadó", "Kiadás éve", "Zene hossza", "Prioritás" };
            Label[] labels = this.getLabels();
            TextBoxComponent[] boxes = this.getTextBoxes();

            for (int i = 0; i < labels.Length; i++)
            {
                TextBoxComponent t = boxes[i];
                Label l = labels[i];
                Point p = new Point(-100, -100);

                t.Location = p;
                l.Location = p;

                l.Text = titles[i];
                l.Font = t.Font;
                l.ForeColor = AppStyle.FONT_COLOR;

                this.Controls.Add(t);
                this.Controls.Add(l);
            }

            this.saveBTN.Text = "Mentés";
            this.saveBTN.Click += this.saveZene; 

            this.Controls.Add(this.saveBTN);
        }

        private void onResize(object sender, EventArgs e)
        {
            int width = (this.Width / 2) - AppStyle.GAP_SIZE;

            // labelek és textboxok lekérése listaként
            Label[] labels = this.getLabels();
            TextBoxComponent[] boxes = this.getTextBoxes();

            for (int i = 0; i < labels.Length; i++)
            {
                TextBoxComponent t = boxes[i];
                Label l = labels[i];

                // TextBox beállítása
                t.Size = new Size(width, t.Height);
                t.Location = new Point(this.Width / 2, (AppStyle.GAP_SIZE + (t.Size.Height * i) + (i * AppStyle.GAP_SIZE)));

                // Label beállítása
                l.Size = t.Size;
                l.Location = new Point(AppStyle.GAP_SIZE, t.Location.Y);
            }

            // Mentés gomb beállítása
            this.saveBTN.Location = new Point(this.Width - this.saveBTN.Width - AppStyle.GAP_SIZE, this.Height - this.saveBTN.Height - AppStyle.GAP_SIZE);
        }

        private void saveZene(object sender, EventArgs e)
        {
            string cimSTR = this.cimTBOX.Text;
            string eloadoSTR = this.eloadoTBOX.Text;
            string kiadasSTR = this.kiadasTBOX.Text;
            string hosszSTR = this.hosszTBOX.Text;
            string piorSTR = this.prioritasTBOX.Text;

            // Adatmeglétel vizsgálat
            if(cimSTR == "" || eloadoSTR == "" || kiadasSTR == "" || hosszSTR == "" || piorSTR == "")
            {
                MessageBox.Show("Nem adtál meg minden adatot!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Szám-e a szám vizsgálat
            bool kiadasBOOL = int.TryParse(kiadasSTR, out int kiadasINT);
            bool hosszBOOL = int.TryParse(hosszSTR, out int hosszINT);
            bool priorBOOL = int.TryParse(piorSTR, out int priorINT);

            if (!kiadasBOOL) MessageBox.Show("A kiadás éve nem egy szám!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!hosszBOOL) MessageBox.Show("A hossz nem egy szám!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!priorBOOL) MessageBox.Show("A prioritás nem egy szám!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (!kiadasBOOL || !hosszBOOL || !priorBOOL) return;

            // A szám pozitív-e vizsgálat
            if (kiadasINT < 0) MessageBox.Show("A kiadás éve nem lehet negatív!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (hosszINT < 0) MessageBox.Show("A hossz nem lehet negatív!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (priorINT < 0) MessageBox.Show("A prioritás nem lehet negatív!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (kiadasINT < 0 || hosszINT < 0 || priorINT < 0) return;

            // Zene mentése
            Zene zene = new Zene(0, cimSTR, eloadoSTR, kiadasINT, hosszINT, priorINT);
            bool result = ZeneController.getInstance().addZene(zene);

            if (!result)
            {
                MessageBox.Show("A zene felvétele sikertelen!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("A zene felvétele sikeres!", "Siker!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // TextBox-ok visszaadása tömbként
        private TextBoxComponent[] getTextBoxes()
        {
            return new TextBoxComponent[5] { this.cimTBOX, this.eloadoTBOX, this.kiadasTBOX, this.hosszTBOX, this.prioritasTBOX };
        }

        // Label-ek visszaadása tömbként
        private Label[] getLabels()
        {
            return new Label[5] { this.cimLabel, this.eloadoLabel, this.kiadasLabel, this.hosszLabel, this.prioritasLabel};
        }
    }
}
