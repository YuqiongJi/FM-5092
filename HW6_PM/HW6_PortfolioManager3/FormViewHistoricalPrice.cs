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
    public partial class FormViewHistoricalPrice : Form
    {
        public FormViewHistoricalPrice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(comboBox1.SelectedValue);
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Instrument!");
            }
            else
            {
                using (var db = new Model1Container())
                {
                    var data = (from tt in db.Prices
                                join it in db.Underlyings on tt.UnderlyingId equals it.Id
                                where tt.UnderlyingId == a
                                select new
                                {
                                    PriceId = tt.Id,
                                    Date = tt.Date,
                                    ClosingPrice = tt.ClosingPrice

                                }).ToList();

                    listView1.Items.Clear();

                    foreach (var d in data)
                    {
                        ListViewItem lv = new ListViewItem(d.PriceId.ToString());
                        lv.SubItems.Add(d.Date.ToString());
                        lv.SubItems.Add(d.ClosingPrice.ToString());

                        listView1.Items.Add(lv);
                    }

                }
            }
            
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
