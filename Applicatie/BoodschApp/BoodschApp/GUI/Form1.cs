using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoodschApp.Classes;

namespace BoodschApp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Administratie.StartUp();
            RefreshInfo();
        }

        private void lbGerechten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbGerechten.SelectedIndex < 0)
                return;
            lbProductenGerechten.Items.Clear();
            foreach (Ingredrient i in Administratie.Gerechten[lbGerechten.SelectedIndex].Ingredrienten)
            {
                lbProductenGerechten.Items.Add(i.Product.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RefreshInfo()
        {
            try
            {
                Administratie.ProductenDatabase();
                Administratie.GerechtenDatabase();
                Administratie.WinkelsDatabase();

                lbProducten.Items.Clear();
                foreach (Product p in Administratie.Producten)
                {
                    lbProducten.Items.Add(p.ToString());
                }

                lbGerechten.Items.Clear();
                foreach (Gerecht g in Administratie.Gerechten)
                {
                    lbGerechten.Items.Add(g.ToString());
                }

                lbBoodschappen.Items.Clear();
                foreach (Boodschap b in Administratie.Boodschappenlijst.Boodschappen)
                {
                    lbBoodschappen.Items.Add(b.ToString());
                }

                cbWinkels.Items.Clear();
                foreach (Winkel w in Administratie.Winkels)
                {
                    cbWinkels.Items.Add(w.ToString());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lbProducten.SelectedIndex >= 0)
            {
                try
                {
                    Administratie.Boodschappenlijst.VoegBoodschapToe(new Boodschap(Administratie.Producten[lbProducten.SelectedIndex], Convert.ToInt32(numAantal.Value)));
                    RefreshInfo();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lbGerechten.SelectedIndex >= 0)
            {
                try
                {
                    Administratie.Boodschappenlijst.VoegGerechtToe(Administratie.Gerechten[lbGerechten.SelectedIndex]);
                    RefreshInfo();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void btnLooproute_Click(object sender, EventArgs e)
        {
            if (cbWinkels.SelectedIndex >= 0)
            {
                try
                {
                    Administratie.Boodschappenlijst.SorteerLoopRoute(Administratie.Winkels[cbWinkels.SelectedIndex]);
                    RefreshInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog opd = new FolderBrowserDialog())
                {
                    if (opd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Administratie.Boodschappenlijst.Exporteer(opd.SelectedPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClearBoodschappenlijst_Click(object sender, EventArgs e)
        {
            Administratie.Boodschappenlijst.VerwijderBoodschappen();
            Administratie.StartUp();
            RefreshInfo();
        }

        private void btnSorteerZuinig_Click(object sender, EventArgs e)
        {
            string alles = "";
            foreach (ZuinigeGerechten zg in Administratie.SorterenWeinigRestjes())
            {
                alles += zg.ToString() + "\r";
            }
        }
    }
}
