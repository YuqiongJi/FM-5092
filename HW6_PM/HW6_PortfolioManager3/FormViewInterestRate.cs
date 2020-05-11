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

    public partial class FormViewInterestRate : Form
    {
        public FormViewInterestRate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new Model1Container())
            {
                var data = (from tt in db.InterestRates
                            select new
                            {
                                InterestRateId = tt.Id,
                                Tenor = tt.Tenor,
                                Rate = tt.Rate

                            }).ToList();

                listView1.Items.Clear();

                foreach (var d in data)
                {
                    ListViewItem lv = new ListViewItem(d.InterestRateId.ToString());
                    lv.SubItems.Add(d.Tenor.ToString());
                    lv.SubItems.Add(d.Rate.ToString());
                   
                    listView1.Items.Add(lv);
                }

            }
        }
    }
}
