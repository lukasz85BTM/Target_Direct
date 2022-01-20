using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.Native;
using Guna.UI2.WinForms;

namespace Target_Direct
{
    public partial class TargetDirect : Form
    {
        //Zegarek
        Timer t = new Timer();
        Timer tt = new Timer();

    public TargetDirect()
        {
            InitializeComponent();
            czas1.Start();
            Przelicznik();
            checked_OK.Visible = false;
            realne.Visible = false;
            tableLayoutPanel1.Visible = false;
            menu_left.Visible = false;
            
            /* Wyciągnięcie danych z komputera */
            string username = System.Windows.Forms.SystemInformation.UserName.ToString();
            string compname = System.Windows.Forms.SystemInformation.ComputerName.ToString();
            lab_username.Text = "Witaj " + username;
            lab_compname.Text = compname;
            
        }

        private void Przelicznik()
        {
            #region PRZELICZNIK SZTUK na CZAS
            //PRZELICZENIE SZTUK na DANY CZAS
            lab_target_12.Text = lab_targetCEL.Text;

            double target1 = Convert.ToDouble(float.Parse(lab_target_12.Text) / 12);
            lab_target_1.Text = Math.Ceiling(target1).ToString();
            lab_target_1.Text = target1.ToString("0.0");
            lab_sztukiGodzinne.Text = Math.Floor(target1).ToString("0");/* << Przeniesienie sztuki do osobnego labela*/

            lab_target_2.Text = (float.Parse(lab_target_1.Text) * 2).ToString();
            lab_target_3.Text = (float.Parse(lab_target_1.Text) * 3).ToString();
            lab_target_4.Text = (float.Parse(lab_target_1.Text) * 4).ToString();
            lab_target_5.Text = (float.Parse(lab_target_1.Text) * 5).ToString();
            lab_target_6.Text = (float.Parse(lab_target_1.Text) * 6).ToString();
            lab_target_7.Text = (float.Parse(lab_target_1.Text) * 7).ToString();
            lab_target_8.Text = (float.Parse(lab_target_1.Text) * 8).ToString();
            lab_target_9.Text = (float.Parse(lab_target_1.Text) * 9).ToString();
            lab_target_10.Text = (float.Parse(lab_target_1.Text) * 10).ToString();
            lab_target_11.Text = (float.Parse(lab_target_1.Text) * 11).ToString();

            // CZAS PONIŻEJ 1H
            double target030 = (float.Parse(lab_target_1.Text) / 2);
            lab_target_030.Text = ((float)target030).ToString();
            lab_target_030.Text = target030.ToString("0.0");

            double target015 = (float.Parse(lab_target_030.Text) / 2);
            lab_target_015.Text = ((float)target015).ToString();
            lab_target_015.Text = target015.ToString("0.0");

            double target010 = (float.Parse(lab_target_030.Text) / 3);
            lab_target_010.Text = ((float)target010).ToString();
            lab_target_010.Text = target010.ToString("0.0");

            double target05 = (float.Parse(lab_target_015.Text) / 3);
            lab_target_05.Text = ((float)target05).ToString();
            lab_target_05.Text = target05.ToString("0.0");

            double target01 = (float.Parse(lab_target_05.Text) / 5);
            lab_target_01.Text = ((float)target01).ToString();
            lab_target_01.Text = target01.ToString("0.0");
            lab_sztuka.Text = Math.Floor(target01).ToString("0"); /* << Przeniesienie sztuki do osobnego labela*/

            #endregion
        }

        private void TargetDirect_Load(object sender, EventArgs e)
        {
            /* CIEŃ OKNA */
            ShadowForm1.SetShadowForm(this);
            
            //Metoda Zegara
            t.Interval = 1000; // milisekundy
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();

        }

        private void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            string time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            // aktualizacja labela Zegar
            lab_czasACTUAL.Text = time;
        }

        private void tb_czasDostepny_TextChanged(object sender, EventArgs e)
        {
            try { lab_czasDostepny.Text = tb_czasDostepny.Text; }
            catch { lab_czasDostepny.Text = "0"; }
        }

        private void guna2Cykl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked == false)
            {
                /* Narzucenie Cyklu i liczenie targetu przy konkretnym OEE */
                if (guna2Cykl.Text == "3,1")
                {
                    lab_cykl.Text = "3,1";
                    lab_Oee.Text = "86,253";

                }
                if (guna2Cykl.Text == "3,2")
                {
                    lab_cykl.Text = "3,2";
                    lab_Oee.Text = "86,415";


                }
                if (guna2Cykl.Text == "3,4")
                {
                    lab_cykl.Text = "3,4";
                    lab_Oee.Text = "86,450";


                }
                if (guna2Cykl.Text == "3,6")
                {
                    lab_cykl.Text = "3,6";
                    lab_Oee.Text = "86,320";


                }
                if (guna2Cykl.Text == "3,8")
                {
                    lab_cykl.Text = "3,8";
                    lab_Oee.Text = "86,481";


                }
                if (guna2Cykl.Text == "4,0")
                {
                    lab_cykl.Text = "4,0";
                    lab_Oee.Text = "86,390";


                }
                if (guna2Cykl.Text == "5,0")
                {
                    lab_cykl.Text = "5,0";
                    lab_Oee.Text = "86,440";


                }

                /* Wyliczenie TARGETU */
                double target = (float.Parse(lab_Oee.Text) * (float.Parse(lab_czasDostepny.Text) / float.Parse(lab_cykl.Text) / 100));
                lab_targetCEL.Text = ((float)target).ToString();
                lab_targetCEL.Text = target.ToString("0");
            }
            else if (guna2ToggleSwitch1.Checked == true)
            {
                /* Narzucenie Cyklu i liczenie targetu przy konkretnym OEE */
                if (guna2Cykl.Text == "3,1")
                {
                    lab_cykl.Text = "3,1";
                    lab_Oee.Text = "100";

                }
                if (guna2Cykl.Text == "3,2")
                {
                    lab_cykl.Text = "3,2";
                    lab_Oee.Text = "100";


                }
                if (guna2Cykl.Text == "3,4")
                {
                    lab_cykl.Text = "3,4";
                    lab_Oee.Text = "100";


                }
                if (guna2Cykl.Text == "3,6")
                {
                    lab_cykl.Text = "3,6";
                    lab_Oee.Text = "100";


                }
                if (guna2Cykl.Text == "3,8")
                {
                    lab_cykl.Text = "3,8";
                    lab_Oee.Text = "100";


                }
                if (guna2Cykl.Text == "4,0")
                {
                    lab_cykl.Text = "4,0";
                    lab_Oee.Text = "100";


                }
                if (guna2Cykl.Text == "5,0")
                {
                    lab_cykl.Text = "5,0";
                    lab_Oee.Text = "100";


                }

                /* Wyliczenie TARGETU */
                double target = (float.Parse(lab_Oee.Text) * (float.Parse(lab_czasDostepny.Text) / float.Parse(lab_cykl.Text) / 100));
                lab_targetCEL.Text = ((float)target).ToString();
                lab_targetCEL.Text = target.ToString("0");
            }
            Przelicznik();
        }

        private void tb_plm_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void czas1_Tick(object sender, EventArgs e)
        {
            DateTime timeStart = dateTimePicker1.Value;     /* czas początkowy ustawiany ręcznie */
            DateTime timeStop = dateTimePicker2.Value;      /* czas aktualny systemowy */
                     timeStop = DateTime.Now;
            DateTime timeEnd = dateTimePicker3.Value;       /* czas końcowy automatycznie odliczający 12h */
            dateTimePicker3.Value = timeStart.AddHours(12); /* Dodanie 12h do czasu początkowego*/

            TimeSpan difference = timeStop - timeStart;     /* Bierzący czas pracy */
            lab_timeDiference.Text = difference.ToString(); /* Label wyświetlający aktualnie przepracowany czas */
            TimeSpan timeCountdown = timeStop - timeEnd;    /* Pozostały czas pracy */
            lab_timeCountdown.Text = timeCountdown.ToString(); /* Label wyświetlający pozostały czas pracy */

            /* Rożnica pomiędzy dwoma datami */
            lab_startTime.Text = dateTimePicker1.Value.ToString();
            lab_endTime.Text = dateTimePicker3.Value.ToString();

            lab_H.Text = "Godziny : " + difference.TotalHours.ToString("0");
            lab_M.Text = "Minuty : " + difference.TotalMinutes.ToString("0");

            double hour = difference.TotalHours;
            lab_hour.Text = ((int)hour).ToString();  /* RZUTOWANIE DO INT */
            lab_hour.Text = Math.Round(hour).ToString();
            lab_hour.Text = hour.ToString("0");

            /* CZAS PRACY */
            double Szacowany = (hour * 60 * 60);
            lab_czasBierzacy.Text = ((int)Szacowany).ToString();  /* RZUTOWANIE DO INT */
            lab_czasBierzacy.Text = Szacowany.ToString("0");
            lab_minutyBierzace.Text = (Szacowany % 3600 / 60).ToString("0");
            
            double czasPracy = (Szacowany / 60);
            lab_czasPracyMIN.Text = ((int)czasPracy).ToString();
            lab_czasPracyMIN.Text = czasPracy.ToString("0");

            try { lab_wykonano.Text = float.Parse(tb_plm2.Text).ToString(); } /* Przypadkowe skasowanie TextBoxa*/
            catch { lab_wykonano.Text = "0"; }

                try
                {   /* Przypadkowe skasowanie TextBoxa*/
                    double praca = (float.Parse(lab_wykonano.Text) + (float.Parse(lab_czasPozostalyMIN.Text) - float.Parse(tb_przerwa.Text)) * float.Parse(lab_target_01.Text));
                    lab_targetSymulacja.Text = ((int)praca).ToString();  /* RZUTOWANIE DO INT */
                    lab_targetSymulacja.Text = praca.ToString("0"/*+ " szt."*/);
                }
                catch { tb_przerwa.Text = "0"; MessageBox.Show("W tej komórce nie może pozostać puste pole!","Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

            /* Brakujące sztuki */
            lab_brakujaceSztuki.Text = (int.Parse(lab_targetCEL.Text) - int.Parse(lab_targetSymulacja.Text)).ToString();

            try /* W razie usunięcia wartości czasu dostępnego */
            { 
                lab_czasDostepny.Text = tb_czasDostepny.Text;
                lab_czasDostepny.ForeColor = Color.White;

            /* CZAS POZOSTAŁY */
            lab_czasPozostalySEK.Text = (int.Parse(lab_czasDostepny.Text) - (hour * 60 * 60)).ToString("0");
            lab_czasPozostalyMIN.Text = (float.Parse(lab_czasDostepny.Text) - (hour * 60 * 60)).ToString();
            double CzasPozostaly = (float.Parse(lab_czasPozostalyMIN.Text) / 60);
            lab_czasPozostalyMIN.Text = ((int)CzasPozostaly).ToString();  /* RZUTOWANIE DO INT */
            lab_czasPozostalyMIN.Text = CzasPozostaly.ToString("0");
            lab_minutyPozostale.Text = (float.Parse(lab_czasPozostalySEK.Text) % 3600 / 60).ToString("0"); /* Skasować pełne godziny tj 60 min. */
            
            }
            catch 
            { 
                lab_czasDostepny.Text = "0"; lab_czasDostepny.ForeColor = Color.Red;
            }

            //lab_czasPozostalyGODZ.Text = (float.Parse(lab_czasPozostalyMIN.Text) / 60).ToString("00.0");
            double godziny = (float.Parse(lab_czasPozostalyMIN.Text) / 60);
            lab_czasPozostalyGODZ.Text = ((int)godziny).ToString();
            lab_czasPozostalyGODZ.Text = Math.Ceiling(godziny).ToString("0.0");

            guna2CircleProgressBar1.Maximum = int.Parse(lab_targetCEL.Text);
            guna2CircleProgressBar1.Value = int.Parse(lab_targetSymulacja.Text);

            if (int.Parse(lab_targetSymulacja.Text) >= int.Parse(lab_targetCEL.Text))
            {
                Animacja1.ShowSync(checked_OK);
                checked_OK.Visible = true;
            }
            else if (int.Parse(lab_targetSymulacja.Text) < int.Parse(lab_targetCEL.Text))
            {
                Animacja1.HideSync(checked_OK);
                checked_OK.Visible = false;
            }

        }

        private void lab_czasBierzacy_TextChanged(object sender, EventArgs e)
        {
            guna2ProgressBar1.Value = int.Parse(lab_czasBierzacy.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked == false)
            {
                realne.Visible = false;
            }
            else if (guna2ToggleSwitch1.Checked == true)
            {
                realne.Visible = true;

            }
            
        }

        private void test_rotacja_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void menu_right_Click(object sender, EventArgs e)
        {
            Animacja1.ShowSync(tableLayoutPanel1);
            //Animacja1.ShowSync(panel1);
            tableLayoutPanel1.Visible = true;
            menu_left.Visible = true;
            menu_right.Visible = false;
        }

        private void menu_left_Click(object sender, EventArgs e)
        {
            Animacja1.HideSync(tableLayoutPanel1);
            //Animacja1.HideSync(panel1);
            tableLayoutPanel1.Visible = false;
            menu_left.Visible = false;
            menu_right.Visible = true;
        }
    }
}
