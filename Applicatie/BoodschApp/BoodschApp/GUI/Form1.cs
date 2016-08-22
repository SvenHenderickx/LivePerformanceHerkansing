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
            //DatabaseManager.TestConnection();
            RefreshInfo();
        }

        private void lbGerechten_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RefreshInfo()
        {
            
            try
            {
                Administratie.ProductenDatabase();


                lbProducten.Items.Clear();
                foreach (Product p in Administratie.Producten)
                {
                    lbProducten.Items.Add(p.ToString());
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Error");
            }
        }
    }
}
