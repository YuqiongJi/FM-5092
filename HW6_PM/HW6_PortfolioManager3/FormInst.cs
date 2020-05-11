﻿using System;
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
    public partial class FormInst : Form
    {
        string side;
        string barriertype;
        public FormInst()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            
            if (comboBoxInstType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Instrument Type!");

            }
            else
            {
                using (var db = new Model1Container())
                {
                    
                    if (comboBoxInstType.SelectedIndex == 0)//Stock
                    {

                        if (!db.Instruments.Any(x => x.InstrumentName == textBoxInstrumentName.Text))
                        {

                            db.Instruments.Add(new Instrument()
                            {
                                UnderlyingId = 0,
                                InstrumentName = textBoxInstrumentName.Text,
                                Exchange = textBoxExchange.Text,
                                InstTypeId = Convert.ToInt32(comboBoxInstType.SelectedIndex) + 1
                            });
                            MessageBox.Show("Instrument added Successfully!");

                        }
                        else
                        {
                            MessageBox.Show("This Instrument has existed!");
                        }

                    }

                    else if (comboBoxInstType.SelectedIndex == 3) // Digital Options
                    {
                        if (!db.Instruments.Any(x => x.InstrumentName == textBoxInstrumentName.Text))
                        {
                            if (radioButtonCall.Checked == true)
                            {
                                side = "Call";
                            }
                            else if (radioButtonPut.Checked == true)
                            {
                                side = "Put";
                            }
                            else if (radioButtonNeitherCallPut.Checked == true)
                            {
                                side = "Neither Call or Put";
                            }

                            bool rebate_bol = double.TryParse(textBoxRebate.Text, out double rebate_text);
                            
                            if (rebate_bol)
                            {
                           
                                db.Instruments.Add(new Instrument()
                                {
                                    Strike = Convert.ToDouble(textBoxStrike.Text),
                                    Tenor = Convert.ToDouble(textBoxTenor.Text),
                                    UnderlyingId = Convert.ToInt32(comboBoxUnderlying.SelectedValue),
                                    InstrumentName = textBoxInstrumentName.Text,
                                    Exchange = textBoxExchange.Text,
                                    InstTypeId = Convert.ToInt32(comboBoxInstType.SelectedIndex)+1,
                                    CallPut = side,
                                    Rebate = rebate_text

                                });

                            }
                            else
                            {
                                MessageBox.Show("Please enter a rebate!");
                            }



                            MessageBox.Show("Instrument added Successfully!");

                        }
                        else
                        {
                            MessageBox.Show("This Instrument has existed!");
                        }
                    }
                    else if (comboBoxInstType.SelectedIndex== 4) // Barrier Options
                    {
                        if (!db.Instruments.Any(x => x.InstrumentName == textBoxInstrumentName.Text))
                        {
                            if (radioButtonCall.Checked == true)
                            {
                                side = "Call";
                            }
                            else if (radioButtonPut.Checked == true)
                            {
                                side = "Put";
                            }
                            else if (radioButtonNeitherCallPut.Checked == true)
                            {
                                side = "Put";
                            }

                            if (comboBoxBarrierType.SelectedIndex == 0)
                            {
                                barriertype = "Up and In";
                                db.Instruments.Add(new Instrument()
                                {
                                    Strike = Convert.ToDouble(textBoxStrike.Text),
                                    Tenor = Convert.ToDouble(textBoxTenor.Text),
                                    UnderlyingId = Convert.ToInt32(comboBoxUnderlying.SelectedValue),
                                    InstrumentName = textBoxInstrumentName.Text,
                                    Exchange = textBoxExchange.Text,
                                    InstTypeId = Convert.ToInt32(comboBoxInstType.SelectedIndex) + 1,
                                    CallPut = side,
                                    Barrier = Convert.ToDouble(textBoxBarrier.Text),
                                    BarrierType = barriertype

                                });

                            }
                            else if (comboBoxBarrierType.SelectedIndex == 1)
                            {
                                barriertype = "Up and Out";
                                db.Instruments.Add(new Instrument()
                                {
                                    Strike = Convert.ToDouble(textBoxStrike.Text),
                                    Tenor = Convert.ToDouble(textBoxTenor.Text),
                                    UnderlyingId = Convert.ToInt32(comboBoxUnderlying.SelectedValue),
                                    InstrumentName = textBoxInstrumentName.Text,
                                    Exchange = textBoxExchange.Text,
                                    InstTypeId = Convert.ToInt32(comboBoxInstType.SelectedIndex) + 1,
                                    CallPut = side,
                                    Barrier = Convert.ToDouble(textBoxBarrier.Text),
                                    BarrierType = barriertype

                                });

                            }
                            else if (comboBoxBarrierType.SelectedIndex == 2)
                            {
                                barriertype = "Down and In";
                                db.Instruments.Add(new Instrument()
                                {
                                    Strike = Convert.ToDouble(textBoxStrike.Text),
                                    Tenor = Convert.ToDouble(textBoxTenor.Text),
                                    UnderlyingId = Convert.ToInt32(comboBoxUnderlying.SelectedValue),
                                    InstrumentName = textBoxInstrumentName.Text,
                                    Exchange = textBoxExchange.Text,
                                    InstTypeId = Convert.ToInt32(comboBoxInstType.SelectedIndex) + 1,
                                    CallPut = side,
                                    Barrier = Convert.ToDouble(textBoxBarrier.Text),
                                    BarrierType = barriertype

                                });

                            }
                            else if (comboBoxBarrierType.SelectedIndex == 3)
                            {
                                barriertype = "Down and Out";
                                db.Instruments.Add(new Instrument()
                                {
                                    Strike = Convert.ToDouble(textBoxStrike.Text),
                                    Tenor = Convert.ToDouble(textBoxTenor.Text),
                                    UnderlyingId = Convert.ToInt32(comboBoxUnderlying.SelectedValue),
                                    InstrumentName = textBoxInstrumentName.Text,
                                    Exchange = textBoxExchange.Text,
                                    InstTypeId = Convert.ToInt32(comboBoxInstType.SelectedIndex) + 1,
                                    CallPut = side,
                                    Barrier = Convert.ToDouble(textBoxBarrier.Text),
                                    BarrierType = barriertype

                                });

                            }
                            else
                            {
                                MessageBox.Show("Please select a Barrier Type!");
                            }

                            MessageBox.Show("Instrument added Successfully!");

                        }
                        else
                        {
                            MessageBox.Show("This Instrument has existed!");
                        }
                    }
                    else //European Options;Asian Options, LookBack Options,range options
                    {
                        if (!db.Instruments.Any(x => x.InstrumentName == textBoxInstrumentName.Text))
                        {
                            if (radioButtonCall.Checked == true)
                            {
                                side = "Call";
                            }
                            else if (radioButtonPut.Checked == true)
                            {
                                side = "Put";
                            }
                            else if (radioButtonNeitherCallPut.Checked == true)
                            {
                                side = "Neither Call or Put";
                            }

                            db.Instruments.Add(new Instrument()
                            {
                                Strike = Convert.ToDouble(textBoxStrike.Text),
                                Tenor = Convert.ToDouble(textBoxTenor.Text),
                                UnderlyingId = Convert.ToInt32(comboBoxUnderlying.SelectedValue),
                                InstrumentName = textBoxInstrumentName.Text,
                                Exchange = textBoxExchange.Text,
                                InstTypeId = Convert.ToInt32(comboBoxInstType.SelectedIndex)+1,
                                CallPut = side,


                            });
                            MessageBox.Show("Instrument added Successfully!");

                        }
                        else
                        {
                            MessageBox.Show("This Instrument has existed!");
                        }
                      
                    }
                    db.SaveChanges();
                }
                
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxUnderlying_Click(object sender, EventArgs e)
        {
            using (var db = new Model1Container())
            {
                comboBoxUnderlying.DataSource = (from x in db.Underlyings select x).ToList();
                comboBoxUnderlying.ValueMember = "Id";
                comboBoxUnderlying.DisplayMember = "Ticker";
            }
        }


        private void comboBoxInstType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxInstType.SelectedIndex == 0)//stock
            {
                textBoxRebate.Enabled = false;
                textBoxBarrier.Enabled = false;
                comboBoxBarrierType.Enabled = false;
                textBoxStrike.Enabled = false;
                textBoxTenor.Enabled = false;

            }

            else if (comboBoxInstType.SelectedIndex == 3)//Digital Options
            {
                textBoxRebate.Enabled = true;
                textBoxBarrier.Enabled = false;
                comboBoxBarrierType.Enabled = false;
                textBoxStrike.Enabled = true;
                textBoxTenor.Enabled = true;

            }
            else if (comboBoxInstType.SelectedIndex == 4)//Barrier Options
            {
                textBoxRebate.Enabled = false;
                textBoxBarrier.Enabled = true;
                comboBoxBarrierType.Enabled = true;
                textBoxStrike.Enabled = true;
                textBoxTenor.Enabled = true;
            }

            else//LookBack Options,EuropeanOptions,Asian Options,,Range Options
            {
                textBoxRebate.Enabled = false;
                textBoxBarrier.Enabled = false;
                comboBoxBarrierType.Enabled = false;
                textBoxStrike.Enabled = true;
                textBoxTenor.Enabled = true;
            }
        }
    }
}