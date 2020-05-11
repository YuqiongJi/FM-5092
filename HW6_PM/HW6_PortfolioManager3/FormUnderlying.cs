using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6_PortfolioManager3
{
    public partial class FormUnderlying : Form
    {
        public FormUnderlying()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var db = new Model1Container())
            {

                if (!db.Underlyings.Any(x => x.Ticker == textBoxTicker.Text))
                {
                    db.Underlyings.Add(new Underlying()
                    {
                       CompanyName = textBoxCompanyName.Text,
                       Ticker = textBoxTicker.Text
                    });
                    MessageBox.Show("Underlying added Successfully!");

                    db.SaveChanges();

                }
                else
                {
                    MessageBox.Show("This underlying has existed!");
                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
