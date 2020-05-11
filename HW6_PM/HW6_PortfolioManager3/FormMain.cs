using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HW6_PortfolioManager3
{
    public partial class FormMain : Form
    {
        static double vol_text, vol;



        public FormMain()
        {
            InitializeComponent();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'portfolioDataModelDataSet.Trades' table. You can move, or remove it, as needed.
            //this.tradesTableAdapter.Fill(this.portfolioDataModelDataSet.Trades);

            Model1Container db = new Model1Container();

            MakeSampleInstType(db);
            MakeSampleUnderlying(db);
            MakeSamplePrice(db);
            MakeSampleInstrument(db);
            MakeSampleTrade(db);
            MakeSampleInterestRate(db);

        }


       

        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            using (var db = new Model1Container())
            {
                var data = (from tt in db.Trades
                            join it in db.Instruments on tt.InstrumentId equals it.Id
                            join itt in db.InstTypes on it.InstTypeId equals itt.Id
                            orderby tt.Id
                            select new
                            {

                                TradeID = tt.Id,
                                BuySell = tt.BuySell,
                                TimeStamp = tt.TimeStamp,
                                Quantity = tt.Quantity,
                                InstrumentName= it.InstrumentName,
                                InstType = itt.TypeName,
                                TradePrice = tt.TradePrice

                            }).ToList();

                listView1.Items.Clear();

                for(int i =0; i<data.Count; i++)
                {
                    var d = data[i];
                    ListViewItem lv = new ListViewItem(d.TradeID.ToString());
                    lv.SubItems.Add(d.BuySell.ToString());
                    lv.SubItems.Add(d.TimeStamp.ToString());
                    lv.SubItems.Add(d.Quantity.ToString());
                    lv.SubItems.Add(d.InstrumentName.ToString());
                    lv.SubItems.Add(d.InstType.ToString());
                    lv.SubItems.Add(d.TradePrice.ToString());
                    lv.SubItems.Add(0.ToString());
                    lv.SubItems.Add(0.ToString());
                    lv.SubItems.Add(0.ToString());
                    lv.SubItems.Add(0.ToString());
                    lv.SubItems.Add(0.ToString());
                    lv.SubItems.Add(0.ToString());
                    lv.SubItems.Add(0.ToString());


                    listView1.Items.Add(lv);
                }
                ListViewItem lv2 = new ListViewItem(0.ToString());
                lv2.SubItems.Add(0.ToString());
                lv2.SubItems.Add(0.ToString());
                lv2.SubItems.Add(0.ToString());
                lv2.SubItems.Add(0.ToString());
                lv2.SubItems.Add(0.ToString());

                listView2.Items.Add(lv2);

                
            }
        }


        private void buttonDelete_Click_1(object sender, EventArgs e)// delete data from listview, also delete in database
        {
            
            if (MessageBox.Show("Are you sure to delete data?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                foreach (ListViewItem i in listView1.SelectedItems)
                {
                    int deleteId = Convert.ToInt32(i.SubItems[0].Text);

                    using (var db = new Model1Container())
                    {                       
                        var trade = db.Trades.FirstOrDefault(x => x.Id == deleteId);
                        db.Trades.Remove(trade);
                        db.SaveChanges();


                    }
                }                          
                
            }
        }



        private void removeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are you sure to delete data?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                foreach (ListViewItem i in listView1.SelectedItems)
                {
                    int deleteId = Convert.ToInt32(i.SubItems[0].Text);

                    using (var db = new Model1Container())
                    {
                        var trade = db.Trades.FirstOrDefault(x => x.Id == deleteId);
                        db.Trades.Remove(trade);
                        db.SaveChanges();
                    }
                }

            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            bool Volatility_bol = double.TryParse(textBoxVolatility.Text, out vol_text);

            if (Volatility_bol)
            {
                vol = vol_text / 100;
                using (var db = new Model1Container())
                {
                    var data = (from tt in db.Trades
                                join it in db.Instruments on tt.InstrumentId equals it.Id
                                join itt in db.InstTypes on it.InstTypeId equals itt.Id
                                orderby tt.Id
                                select new
                                {

                                    TradeID = tt.Id,
                                    BuySell = tt.BuySell,
                                    //TimeStamp = tt.TimeStamp,
                                    Quantity = tt.Quantity,
                                    //InstrumentName = it.InstrumentName,
                                    InstType = itt.TypeName,
                                    Strike = it.Strike,
                                    TradePrice = tt.TradePrice,
                                    //InstId = tt.InstrumentId,
                                    underlyid = it.UnderlyingId,
                                    tenor = it.Tenor,
                                    callput = it.CallPut,
                                    rebate = it.Rebate,
                                    barrier = it.Barrier,
                                    barriertype = it.BarrierType

                                }).ToList();

                    for (int i = 0; i < data.Count; i++)
                    {
                        var d = data[i];

                        #region Stock
                        if (d.InstType == "Stock")
                        {
                            var price = from tt in db.Prices
                                        where tt.UnderlyingId == d.underlyid
                                        orderby tt.Date descending
                                        select tt.ClosingPrice;


                            double SpotPrice = Convert.ToDouble(price.First());

                            double pl;
                            if (d.BuySell == "Buy")
                            {
                                pl = (SpotPrice - d.TradePrice) * d.Quantity;
                            }
                            else
                            {
                                pl = (SpotPrice - d.TradePrice) * d.Quantity * (-1);
                            }

                            double delta, gamma = 0, theta = 0, vega = 0, rho = 0;
                            if (d.BuySell == "Buy")
                            {
                                delta = 1 * d.Quantity;
                            }
                            else
                            {
                                delta = -1 * d.Quantity;
                            }
                            listView1.Items[i].SubItems[7].Text = SpotPrice.ToString();
                            listView1.Items[i].SubItems[8].Text = pl.ToString();
                            listView1.Items[i].SubItems[9].Text = delta.ToString();
                            listView1.Items[i].SubItems[10].Text = gamma.ToString();
                            listView1.Items[i].SubItems[11].Text = theta.ToString();
                            listView1.Items[i].SubItems[12].Text = vega.ToString();
                            listView1.Items[i].SubItems[13].Text = rho.ToString();
                        }
                        #endregion Stock
                        #region EuropeanOptions
                        else if (d.InstType == "European Options")
                        {

                            HW5_ExoticOptions.EuropeanOptions o = new HW5_ExoticOptions.EuropeanOptions();


                            o.SprikePrice = Convert.ToDouble(d.Strike);
                            o.Tenor = Convert.ToDouble(d.tenor);
                            o.Volatility = vol;
                            o.Multithreading = false;
                            o.StepNumber = 50;
                            o.TrialNumber = 5000;
                            o.Antithetic = false;
                            o.Delta_ControlVariate = false;
                            o.RandNumbers = o.GetRandMatrix();

                            if (d.callput == "Call")
                            {
                                o.Side = true;
                            }
                            else if (d.callput == "Put")
                            {
                                o.Side = false;
                            }

                            var price = from tt in db.Prices
                                        where tt.UnderlyingId == d.underlyid
                                        orderby tt.Date descending
                                        select tt.ClosingPrice;

                            o.SpotPrice = Convert.ToDouble(price.First());

                            var r = (from ir in db.InterestRates
                                     orderby ir.Tenor ascending
                                     select new
                                     {
                                         t = ir.Tenor,
                                         r = ir.Rate
                                     });

                            double Ta = 0, TA = 0, ra = 0, rA = 0, rm = 0;
                            double T = Convert.ToDouble(d.tenor);

                            if (r.Any(x => x.t == T))
                            {

                                double[] r1 = (from ir in db.InterestRates
                                               where ir.Tenor == T
                                               select ir.Rate).ToArray();
                                rm = r1[0];

                            }
                            else
                            {
                                foreach (var item in r)
                                {

                                    if (item.t < T)
                                    {
                                        if (item.t > Ta)
                                        {
                                            Ta = item.t;
                                            ra = item.r;
                                        }

                                    }
                                    else if (item.t > T)
                                    {
                                        if (item.t < TA)
                                        {
                                            TA = item.t;
                                            rA = item.r;
                                        }
                                    }
                                }
                                rm = ra + (rA - ra) * (T - Ta) / (TA - Ta);
                            }

                            o.Drift = rm;
                            double optionprice = o.OptionPrice();

                            listView1.Items[i].SubItems[7].Text = optionprice.ToString();

                            double pl;
                            if (d.BuySell == "Buy")
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity;
                            }
                            else
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity * (-1);
                            }

                            listView1.Items[i].SubItems[8].Text = pl.ToString();

                            double delta, gamma, theta, vega, rho;
                            if (d.BuySell == "Buy")
                            {
                                delta = Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }
                            else
                            {
                                delta = -Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = -Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = -Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = -Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = -Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }


                            //write into listview
                            listView1.Items[i].SubItems[9].Text = delta.ToString();
                            listView1.Items[i].SubItems[10].Text = gamma.ToString();
                            listView1.Items[i].SubItems[11].Text = theta.ToString();
                            listView1.Items[i].SubItems[12].Text = vega.ToString();
                            listView1.Items[i].SubItems[13].Text = rho.ToString();

                        }
                        #endregion EuropeanOptions
                        #region Asian Options
                        else if (d.InstType == "Asian Options")
                        {
                            HW5_ExoticOptions.AsianOptions o = new HW5_ExoticOptions.AsianOptions();


                            o.SprikePrice = Convert.ToDouble(d.Strike);
                            o.Tenor = Convert.ToDouble(d.tenor);
                            o.Volatility = vol;
                            o.Multithreading = false;
                            o.StepNumber = 50;
                            o.TrialNumber = 5000;
                            o.Antithetic = false;
                            o.Delta_ControlVariate = false;
                            o.RandNumbers = o.GetRandMatrix();

                            if (d.callput == "Call")
                            {
                                o.Side = true;
                            }
                            else if (d.callput == "Put")
                            {
                                o.Side = false;
                            }

                            var price = from tt in db.Prices
                                        where tt.UnderlyingId == d.underlyid
                                        orderby tt.Date descending
                                        select tt.ClosingPrice;

                            o.SpotPrice = Convert.ToDouble(price.First());

                            var r = (from ir in db.InterestRates
                                     orderby ir.Tenor ascending
                                     select new
                                     {
                                         t = ir.Tenor,
                                         r = ir.Rate
                                     });

                            double Ta = 0, TA = 0, ra = 0, rA = 0, rm = 0;
                            double T = Convert.ToDouble(d.tenor);

                            if (r.Any(x => x.t == T))
                            {

                                double[] r1 = (from ir in db.InterestRates
                                               where ir.Tenor == T
                                               select ir.Rate).ToArray();
                                rm = r1[0];

                            }
                            else
                            {
                                foreach (var item in r)
                                {

                                    if (item.t < T)
                                    {
                                        if (item.t > Ta)
                                        {
                                            Ta = item.t;
                                            ra = item.r;
                                        }

                                    }
                                    else if (item.t > T)
                                    {
                                        if (item.t < TA)
                                        {
                                            TA = item.t;
                                            rA = item.r;
                                        }
                                    }
                                }
                                rm = ra + (rA - ra) * (T - Ta) / (TA - Ta);
                            }

                            o.Drift = rm;
                            double optionprice = o.OptionPrice();

                            listView1.Items[i].SubItems[7].Text = optionprice.ToString();

                            double pl;
                            if (d.BuySell == "Buy")
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity;
                            }
                            else
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity * (-1);
                            }

                            listView1.Items[i].SubItems[8].Text = pl.ToString();

                            double delta, gamma, theta, vega, rho;
                            if (d.BuySell == "Buy")
                            {
                                delta = Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }
                            else
                            {
                                delta = -Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = -Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = -Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = -Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = -Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }


                            //write into listview
                            listView1.Items[i].SubItems[9].Text = delta.ToString();
                            listView1.Items[i].SubItems[10].Text = gamma.ToString();
                            listView1.Items[i].SubItems[11].Text = theta.ToString();
                            listView1.Items[i].SubItems[12].Text = vega.ToString();
                            listView1.Items[i].SubItems[13].Text = rho.ToString();
                        }
                        #endregion Asian Options


                        #region DgitalOptions
                        else if (d.InstType == "Digital Options")
                        {
                            HW5_ExoticOptions.DigitalOptions o = new HW5_ExoticOptions.DigitalOptions();

                            o.RebateValue = Convert.ToDouble(d.rebate);
                            o.SprikePrice = Convert.ToDouble(d.Strike);
                            o.Tenor = Convert.ToDouble(d.tenor);
                            o.Volatility = vol;
                            o.Multithreading = false;
                            o.StepNumber = 50;
                            o.TrialNumber = 5000;
                            o.Antithetic = false;
                            o.Delta_ControlVariate = false;
                            o.RandNumbers = o.GetRandMatrix();

                            if (d.callput == "Call")
                            {
                                o.Side = true;
                            }
                            else if (d.callput == "Put")
                            {
                                o.Side = false;
                            }

                            var price = from tt in db.Prices
                                        where tt.UnderlyingId == d.underlyid
                                        orderby tt.Date descending
                                        select tt.ClosingPrice;

                            o.SpotPrice = Convert.ToDouble(price.First());

                            var r = (from ir in db.InterestRates
                                     orderby ir.Tenor ascending
                                     select new
                                     {
                                         t = ir.Tenor,
                                         r = ir.Rate
                                     });

                            double Ta = 0, TA = 0, ra = 0, rA = 0, rm = 0;
                            double T = Convert.ToDouble(d.tenor);

                            if (r.Any(x => x.t == T))
                            {

                                double[] r1 = (from ir in db.InterestRates
                                               where ir.Tenor == T
                                               select ir.Rate).ToArray();
                                rm = r1[0];

                            }
                            else
                            {
                                foreach (var item in r)
                                {

                                    if (item.t < T)
                                    {
                                        if (item.t > Ta)
                                        {
                                            Ta = item.t;
                                            ra = item.r;
                                        }

                                    }
                                    else if (item.t > T)
                                    {
                                        if (item.t < TA)
                                        {
                                            TA = item.t;
                                            rA = item.r;
                                        }
                                    }
                                }
                                rm = ra + (rA - ra) * (T - Ta) / (TA - Ta);
                            }

                            o.Drift = rm;
                            double optionprice = o.OptionPrice();

                            listView1.Items[i].SubItems[7].Text = optionprice.ToString();

                            double pl;
                            if (d.BuySell == "Buy")
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity;
                            }
                            else
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity * (-1);
                            }

                            listView1.Items[i].SubItems[8].Text = pl.ToString();

                            double delta, gamma, theta, vega, rho;
                            if (d.BuySell == "Buy")
                            {
                                delta = Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }
                            else
                            {
                                delta = -Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = -Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = -Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = -Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = -Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }


                            //write into listview
                            listView1.Items[i].SubItems[9].Text = delta.ToString();
                            listView1.Items[i].SubItems[10].Text = gamma.ToString();
                            listView1.Items[i].SubItems[11].Text = theta.ToString();
                            listView1.Items[i].SubItems[12].Text = vega.ToString();
                            listView1.Items[i].SubItems[13].Text = rho.ToString();
                        }

                        #endregion Digital Options


                        #region Barrier Options
                        else if (d.InstType == "Barrier Options")
                        {
                            HW5_ExoticOptions.RangeOptions o = new HW5_ExoticOptions.RangeOptions();

                            // give value to properties.
                            o.BarrierPrice = Convert.ToDouble(d.barrier);
                            if (d.barriertype == "Up and In")
                            {
                                o.BarrierType = 0;
                            }
                            else if (d.barriertype == "Up and Out")
                            {
                                o.BarrierType = 1;
                            }
                            else if (d.barriertype == "Down and In")
                            {
                                o.BarrierType = 2;
                            }
                            else
                            {
                                o.BarrierType = 3;
                            }

                            o.SprikePrice = Convert.ToDouble(d.Strike);
                            o.Tenor = Convert.ToDouble(d.tenor);
                            o.Volatility = vol;
                            o.Multithreading = false;
                            o.StepNumber = 50;
                            o.TrialNumber = 5000;
                            o.Antithetic = false;
                            o.Delta_ControlVariate = false;
                            o.RandNumbers = o.GetRandMatrix();

                            if (d.callput == "Call")
                            {
                                o.Side = true;
                            }
                            else if (d.callput == "Put")
                            {
                                o.Side = false;
                            }

                            var price = from tt in db.Prices
                                        where tt.UnderlyingId == d.underlyid
                                        orderby tt.Date descending
                                        select tt.ClosingPrice;

                            o.SpotPrice = Convert.ToDouble(price.First());

                            var r = (from ir in db.InterestRates
                                     orderby ir.Tenor ascending
                                     select new
                                     {
                                         t = ir.Tenor,
                                         r = ir.Rate
                                     });

                            double Ta = 0, TA = 0, ra = 0, rA = 0, rm = 0;
                            double T = Convert.ToDouble(d.tenor);

                            if (r.Any(x => x.t == T))
                            {

                                double[] r1 = (from ir in db.InterestRates
                                               where ir.Tenor == T
                                               select ir.Rate).ToArray();
                                rm = r1[0];

                            }
                            else
                            {
                                foreach (var item in r)
                                {

                                    if (item.t < T)
                                    {
                                        if (item.t > Ta)
                                        {
                                            Ta = item.t;
                                            ra = item.r;
                                        }

                                    }
                                    else if (item.t > T)
                                    {
                                        if (item.t < TA)
                                        {
                                            TA = item.t;
                                            rA = item.r;
                                        }
                                    }
                                }
                                rm = ra + (rA - ra) * (T - Ta) / (TA - Ta);
                            }

                            o.Drift = rm;
                            double optionprice = o.OptionPrice();

                            listView1.Items[i].SubItems[7].Text = optionprice.ToString();

                            double pl;
                            if (d.BuySell == "Buy")
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity;
                            }
                            else
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity * (-1);
                            }

                            listView1.Items[i].SubItems[8].Text = pl.ToString();

                            double delta, gamma, theta, vega, rho;
                            if (d.BuySell == "Buy")
                            {
                                delta = Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }
                            else
                            {
                                delta = -Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = -Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = -Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = -Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = -Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }


                            //write into listview
                            listView1.Items[i].SubItems[9].Text = delta.ToString();
                            listView1.Items[i].SubItems[10].Text = gamma.ToString();
                            listView1.Items[i].SubItems[11].Text = theta.ToString();
                            listView1.Items[i].SubItems[12].Text = vega.ToString();
                            listView1.Items[i].SubItems[13].Text = rho.ToString();
                        }
                        #endregion Barrier Options


                        #region Range Options
                        else if (d.InstType == "Range Options")
                        {
                            HW5_ExoticOptions.RangeOptions o = new HW5_ExoticOptions.RangeOptions();


                            o.SprikePrice = Convert.ToDouble(d.Strike);
                            o.Tenor = Convert.ToDouble(d.tenor);
                            o.Volatility = vol;
                            o.Multithreading = false;
                            o.StepNumber = 50;
                            o.TrialNumber = 5000;
                            o.Antithetic = false;
                            o.Delta_ControlVariate = false;
                            o.RandNumbers = o.GetRandMatrix();

                            o.Side = true;

                            var price = from tt in db.Prices
                                        where tt.UnderlyingId == d.underlyid
                                        orderby tt.Date descending
                                        select tt.ClosingPrice;

                            o.SpotPrice = Convert.ToDouble(price.First());

                            var r = (from ir in db.InterestRates
                                     orderby ir.Tenor ascending
                                     select new
                                     {
                                         t = ir.Tenor,
                                         r = ir.Rate
                                     });

                            double Ta = 0, TA = 0, ra = 0, rA = 0, rm = 0;
                            double T = Convert.ToDouble(d.tenor);

                            if (r.Any(x => x.t == T))
                            {

                                double[] r1 = (from ir in db.InterestRates
                                               where ir.Tenor == T
                                               select ir.Rate).ToArray();
                                rm = r1[0];

                            }
                            else
                            {
                                foreach (var item in r)
                                {

                                    if (item.t < T)
                                    {
                                        if (item.t > Ta)
                                        {
                                            Ta = item.t;
                                            ra = item.r;
                                        }

                                    }
                                    else if (item.t > T)
                                    {
                                        if (item.t < TA)
                                        {
                                            TA = item.t;
                                            rA = item.r;
                                        }
                                    }
                                }
                                rm = ra + (rA - ra) * (T - Ta) / (TA - Ta);
                            }

                            o.Drift = rm;
                            double optionprice = o.OptionPrice();

                            listView1.Items[i].SubItems[7].Text = optionprice.ToString();

                            double pl;
                            if (d.BuySell == "Buy")
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity;
                            }
                            else
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity * (-1);
                            }

                            listView1.Items[i].SubItems[8].Text = pl.ToString();

                            double delta, gamma, theta, vega, rho;
                            if (d.BuySell == "Buy")
                            {
                                delta = Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }
                            else
                            {
                                delta = -Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = -Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = -Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = -Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = -Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }


                            //write into listview
                            listView1.Items[i].SubItems[9].Text = delta.ToString();
                            listView1.Items[i].SubItems[10].Text = gamma.ToString();
                            listView1.Items[i].SubItems[11].Text = theta.ToString();
                            listView1.Items[i].SubItems[12].Text = vega.ToString();
                            listView1.Items[i].SubItems[13].Text = rho.ToString();
                        }
                        #endregion Range Options

                        #region LookBack Options
                        else if (d.InstType == "Lookback Options")
                        {
                            HW5_ExoticOptions.LookbackOptions o = new HW5_ExoticOptions.LookbackOptions();


                            o.SprikePrice = Convert.ToDouble(d.Strike);
                            o.Tenor = Convert.ToDouble(d.tenor);
                            o.Volatility = vol;
                            o.Multithreading = false;
                            o.StepNumber = 50;
                            o.TrialNumber = 5000;
                            o.Antithetic = false;
                            o.Delta_ControlVariate = false;
                            o.RandNumbers = o.GetRandMatrix();

                            if (d.callput == "Call")
                            {
                                o.Side = true;
                            }
                            else if (d.callput == "Put")
                            {
                                o.Side = false;
                            }

                            var price = from tt in db.Prices
                                        where tt.UnderlyingId == d.underlyid
                                        orderby tt.Date descending
                                        select tt.ClosingPrice;

                            o.SpotPrice = Convert.ToDouble(price.First());

                            var r = (from ir in db.InterestRates
                                     orderby ir.Tenor ascending
                                     select new
                                     {
                                         t = ir.Tenor,
                                         r = ir.Rate
                                     });

                            double Ta = 0, TA = 0, ra = 0, rA = 0, rm = 0;
                            double T = Convert.ToDouble(d.tenor);

                            if (r.Any(x => x.t == T))
                            {

                                double[] r1 = (from ir in db.InterestRates
                                               where ir.Tenor == T
                                               select ir.Rate).ToArray();
                                rm = r1[0];

                            }
                            else
                            {
                                foreach (var item in r)
                                {

                                    if (item.t < T)
                                    {
                                        if (item.t > Ta)
                                        {
                                            Ta = item.t;
                                            ra = item.r;
                                        }

                                    }
                                    else if (item.t > T)
                                    {
                                        if (item.t < TA)
                                        {
                                            TA = item.t;
                                            rA = item.r;
                                        }
                                    }
                                }
                                rm = ra + (rA - ra) * (T - Ta) / (TA - Ta);
                            }

                            o.Drift = rm;
                            double optionprice = o.OptionPrice();

                            listView1.Items[i].SubItems[7].Text = optionprice.ToString();

                            double pl;
                            if (d.BuySell == "Buy")
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity;
                            }
                            else
                            {
                                pl = (optionprice - d.TradePrice) * d.Quantity * (-1);
                            }

                            listView1.Items[i].SubItems[8].Text = pl.ToString();

                            double delta, gamma, theta, vega, rho;
                            if (d.BuySell == "Buy")
                            {
                                delta = Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }
                            else
                            {
                                delta = -Math.Round(Math.Abs(o.GetDelta()), 5) * d.Quantity;
                                gamma = -Math.Round(Math.Abs(o.GetGamma()), 5) * d.Quantity;
                                theta = -Math.Round(Math.Abs(o.GetTheta()), 5) * d.Quantity;
                                vega = -Math.Round(Math.Abs(o.GetVega()), 5) * d.Quantity;
                                rho = -Math.Round(Math.Abs(o.GetRho()), 5) * d.Quantity;
                            }


                            //write into listview
                            listView1.Items[i].SubItems[9].Text = delta.ToString();
                            listView1.Items[i].SubItems[10].Text = gamma.ToString();
                            listView1.Items[i].SubItems[11].Text = theta.ToString();
                            listView1.Items[i].SubItems[12].Text = vega.ToString();
                            listView1.Items[i].SubItems[13].Text = rho.ToString();
                        }

                        #endregion Lookback Options

                    }


                }
            }
            else
            {
                MessageBox.Show("Please enter a volatility!");
            }

     

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double tpl = 0, tdelta = 0, tgamma = 0, tvega = 0, ttheta = 0, trho = 0;

            foreach (ListViewItem i in listView1.SelectedItems)
            {

                tpl += Convert.ToDouble(i.SubItems[8].Text);
                tdelta += Convert.ToDouble(i.SubItems[9].Text);
                tgamma += Convert.ToDouble(i.SubItems[10].Text);
                ttheta += Convert.ToDouble(i.SubItems[11].Text);
                tvega += Convert.ToDouble(i.SubItems[12].Text);
                trho += Convert.ToDouble(i.SubItems[13].Text);

            }
            listView2.Items[0].SubItems[0].Text = tpl.ToString();
            listView2.Items[0].SubItems[1].Text = tdelta.ToString();
            listView2.Items[0].SubItems[2].Text = tgamma.ToString();
            listView2.Items[0].SubItems[3].Text = ttheta.ToString();
            listView2.Items[0].SubItems[4].Text = tvega.ToString();
            listView2.Items[0].SubItems[5].Text = trho.ToString();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void instrumentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Necessary Instrument Types have existed!");
 

        }

        private void instrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInst i = new FormInst();
            i.ShowDialog();
        }


        private void tradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTrade t = new FormTrade();
            t.ShowDialog();
        }

        private void interestRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInterestRate ir = new FormInterestRate();
            ir.ShowDialog();
        }

        private void historicalPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistoricalPrice hp = new FormHistoricalPrice();

            hp.ShowDialog();
        }

        private void historicalPricesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewHistoricalPrice pa = new FormViewHistoricalPrice();
            pa.ShowDialog();
        }

  
        private void interestRatesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormViewInterestRate vit = new FormViewInterestRate();
            vit.ShowDialog();
           
        }
        private void underlyingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUnderlying u = new FormUnderlying();
            u.ShowDialog();

        }


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HW5_ExoticOptions.Form1 f = new HW5_ExoticOptions.Form1();
            f.ShowDialog();
        }


        //add sample data
        static void MakeSampleInstType(Model1Container db)
        {
            if (!db.InstTypes.Any())
            {
                db.InstTypes.Add(new InstType()
                {
                    TypeName = "Stock"
                });
                db.InstTypes.Add(new InstType()
                {
                    TypeName = "European Options"
                });
                db.InstTypes.Add(new InstType()
                {
                    TypeName = "Asian Options"
                });
                db.InstTypes.Add(new InstType()
                {
                    TypeName = "Digital Options"
                });
                db.InstTypes.Add(new InstType()
                {
                    TypeName = "Barrier Options"
                });
                db.InstTypes.Add(new InstType()
                {
                    TypeName = "Range Options"
                });
                db.InstTypes.Add(new InstType()
                {
                    TypeName = "Lookback Options"
                });


                db.SaveChanges();
            }

        }
        static void MakeSampleUnderlying(Model1Container db)
        {
            if (!db.Underlyings.Any())
            {
                db.Underlyings.Add(new Underlying()
                {
                    CompanyName = "Amazon",
                    Ticker = "AMZN",
                });

                db.Underlyings.Add(new Underlying()
                {
                    CompanyName = "Microsoft",
                    Ticker = "MSFT",
                });

                db.Underlyings.Add(new Underlying()
                {
                    CompanyName = "Apple",
                    Ticker = "APLE",
                });

                db.SaveChanges();
            }

        }
        //add sample data
        static void MakeSampleInstrument(Model1Container db)
        {
            if (!db.Instruments.Any())
            {
                db.Instruments.Add(new Instrument()
                {

                    Exchange = "NYSE",
                    CallPut = "Neither Call or Put",
                    InstrumentName ="Apple",
                    InstTypeId = 1,
                    UnderlyingId = 1
                });

                db.Instruments.Add(new Instrument()
                {
                    InstrumentName= "OptionA",
                    Exchange = "NYSE",
                    Strike = 60,
                    Tenor = 2,
                    CallPut = "Call",
                    InstTypeId = 2,
                    UnderlyingId = 2
                });

                db.Instruments.Add(new Instrument()
                {
                    InstrumentName="OptionB",
                    Exchange = "NASDAK",
                    Strike = 60,
                    Tenor = 2,
                    CallPut = "Call",
                    InstTypeId = 3,
                    UnderlyingId = 2
                });

                db.SaveChanges();
            }



        }
        //add sample data

        static void MakeSamplePrice(Model1Container db)
        {
            if (!db.Prices.Any())
            {
                db.Prices.Add(new Price()
                {
                    Date = DateTime.Now,
                    ClosingPrice = 95,
                    UnderlyingId = 1
                });
                db.Prices.Add(new Price()
                {
                    Date = DateTime.Now,
                    ClosingPrice = 105,
                    UnderlyingId = 3
                });
                db.Prices.Add(new Price()
                {
                    Date = DateTime.Now,
                    ClosingPrice = 120,
                    UnderlyingId = 2
                });
                db.SaveChanges();
            }


        }
        //add sample data

        static void MakeSampleTrade(Model1Container db)
        {
            if (!db.Trades.Any())
            {
                db.Trades.Add(new Trade()
                {
                    BuySell = "Buy",
                    Quantity = 50,
                    TradePrice = 100,
                    TimeStamp = DateTime.Now,
                    InstrumentId = 1
                });
                db.Trades.Add(new Trade()
                {
                    BuySell = "Buy",
                    Quantity = 30,
                    TradePrice = 70,
                    TimeStamp = DateTime.Now,
                    InstrumentId = 3
                });
                db.Trades.Add(new Trade()
                {
                    BuySell = "Sell",
                    Quantity = 89,
                    TradePrice = 50,
                    TimeStamp = DateTime.Now,
                    InstrumentId = 2
                });
                db.Trades.Add(new Trade()
                {
                    BuySell = "Sell",
                    Quantity = 30,
                    TradePrice = 100,
                    TimeStamp = DateTime.Now,
                    InstrumentId = 3
                });

                db.SaveChanges();
            }
        }

        //add sample data

        static void MakeSampleInterestRate(Model1Container db)
        {
            if (!db.InterestRates.Any())
            {
                db.InterestRates.Add(new InterestRate()
                {
                    Tenor = 0.3,
                    Rate = 0.03

                });
                db.InterestRates.Add(new InterestRate()
                {
                    Tenor = 0.5,
                    Rate = 0.05

                });
                db.InterestRates.Add(new InterestRate()
                {
                    Tenor = 1,
                    Rate = 0.07

                });
                db.InterestRates.Add(new InterestRate()
                {
                    Tenor = 2,
                    Rate = 0.12
                });
                db.InterestRates.Add(new InterestRate()
                {
                    Tenor = 5,
                    Rate = 0.2

                });
                db.SaveChanges();
            }

        }


    }

}
