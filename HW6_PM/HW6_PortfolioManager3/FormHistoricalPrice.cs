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
    public partial class FormHistoricalPrice : Form
    {
        public FormHistoricalPrice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ClosingPrice_bol = double.TryParse(textBoxClosingPrice.Text, out double ClosingPrice_text);
            

            if (ClosingPrice_bol)
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a stock to add Prices");

                }
                else
                {
                    using (var db = new Model1Container())
                    {


                        if (!db.Prices.Any(x => x.Date == dateTimePicker1.Value.Date))
                        {
                            db.Prices.Add(new Price()
                            {
                                UnderlyingId = Convert.ToInt32(comboBox1.SelectedValue),
                                Date = dateTimePicker1.Value.Date,
                                ClosingPrice = ClosingPrice_text
                            }); ;
                            MessageBox.Show("Historical Price added Successfully!");

                            db.SaveChanges();

                        }
                        else
                        {
                            MessageBox.Show("This Historical Price has existed!");
                        }

                    }
                }

               
            }
            else
            {
                MessageBox.Show("Please enter valid Closing Price!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            using (var db = new Model1Container())
            {
                comboBox1.DataSource = (from x in db.Underlyings select x).ToList();
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "Ticker";
            }
           
        }
    }
}
