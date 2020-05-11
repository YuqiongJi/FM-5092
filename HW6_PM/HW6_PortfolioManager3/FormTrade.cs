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
    public partial class FormTrade : Form
    {
        string direction;
        public FormTrade()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool TradePrice_bol = double.TryParse(textBoxPrice.Text, out double TradePrice_text);
            

            if (TradePrice_bol)
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an instrument!");

                }
                else
                {
                    using (var db = new Model1Container())
                    {


                        if (!db.Trades.Any(x => x.TimeStamp == dateTimePicker1.Value && x.InstrumentId == comboBox1.SelectedIndex))
                        {
                            if (radioButtonBuy.Checked == true)
                            {
                                direction = "Buy";
                            }
                            else if(radioButtonSell.Checked == true)
                            {
                                direction = "Sell";
                            }
                            db.Trades.Add(new Trade()
                            {
                                InstrumentId = Convert.ToInt32(comboBox1.SelectedValue),
                                TimeStamp = dateTimePicker1.Value,
                                TradePrice = TradePrice_text,
                                BuySell = direction,
                                Quantity = Convert.ToInt32(textBoxQuantity.Text)
                            }); 
                            MessageBox.Show("Trade added Successfully!");

                            db.SaveChanges();

                        }
                        else
                        {
                            MessageBox.Show("This Trade has existed!");
                        }

                    }
                }


            }
            else
            {
                MessageBox.Show("Please enter valid Trade Price!");
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
                comboBox1.DataSource = (from x in db.Instruments select x).ToList();
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "InstrumentName";
            }
        }
    }
}
