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
    public partial class FormInterestRate : Form
    {
        public FormInterestRate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Tenor_bol = double.TryParse(textBoxTeonr.Text, out double Tenor_text);
            bool Rate_bol = double.TryParse(textBoxInterestRate.Text, out double Rate_text);
            if (Tenor_bol & Rate_bol)
            {
                using (var db = new Model1Container())
                {


                    if (!db.InterestRates.Any(x => x.Tenor == Tenor_text))
                    {
                        db.InterestRates.Add(new InterestRate()
                        {
                            Tenor = Tenor_text,
                            Rate = Rate_text
                        });
                        MessageBox.Show("Instrument Type added Successfully!");

                        db.SaveChanges();

                    }
                    else
                    {
                        MessageBox.Show("This interested rate has existed!");
                    }

                }
            }
            else
            {
                MessageBox.Show("Please enter valid Tenor and Interest Rate!");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
