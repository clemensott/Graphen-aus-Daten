using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphen_aus_Daten
{
    public partial class Daten : Form
    {
        Form1 Haupt;
        Datei datei;

        ColorDialog farbe_wahlen = new ColorDialog();

        public bool vertbx;
        public bool[] mittbx = new bool[2], spttbx = new bool[2], grenzcbx = new bool[2];
        public bool[,] endtbx = new bool[2, 2];
        public double ver_x_y;
        public double[] mitte_wert = new double[2], spt = new double[2];
        public double[,] endwerte = new double[2, 2];
        public double[][][] daten = new double[0][][];

        public int nr = -1, pos = -1;
        int welche_lbx = 1, key_pressed, row_hight, hight_l, hight_k, width_k, width_l;
        double schritte;
        string[] x_wert, y_wert;


        public Daten(Form1 haupt)
        {
            InitializeComponent();
            Haupt = haupt;
            datei = new Datei(this);
        }

        private void Daten_Load(object sender, EventArgs e)
        {
            if (width_k == 0)
            {
                width_k = dgv_k.Columns[0].Width;
                width_l = dgv_l.Columns[2].Width;
            }

            tbx_x_achse_Leave(new object(), new EventArgs());
            ckb_e_x_manuell_CheckedChanged(new object(), new EventArgs());
            schritte = Convert.ToDouble(tbx_schritte.Text);

            lbx_fullen();
        }

        private void ckb_e_x_manuell_CheckedChanged(object sender, EventArgs e)
        {
            vertbx = tbx_verhaltnis.Enabled = ckb_x_y.Checked;

            ckb_b_y_von.Enabled = !ckb_b_y_bis.Checked || !ckb_x_y.Checked;
            ckb_b_y_bis.Enabled = !ckb_b_y_von.Checked || !ckb_x_y.Checked;

            ckb_e_y_manuell.Enabled = !ckb_x_y.Checked;

            mittbx[0] = tbx_null_x.Enabled = ckb_n_x_manuell.Checked && ckb_n_x_manuell.Enabled;
            mittbx[1] = tbx_null_y.Enabled = ckb_n_y_manuell.Checked && ckb_n_y_manuell.Enabled;

            spttbx[0] = tbx_x_achse.Enabled = ckb_e_x_manuell.Checked && ckb_e_x_manuell.Enabled;
            spttbx[1] = tbx_y_achse.Enabled = ckb_e_y_manuell.Checked && ckb_e_y_manuell.Enabled && !ckb_x_y.Checked;

            ckb_n_x_manuell.Enabled = !ckb_b_x_von.Checked || !ckb_b_x_bis.Checked;
            ckb_n_y_manuell.Enabled = (!ckb_b_y_von.Checked || !ckb_b_y_bis.Checked) && (!ckb_x_y.Checked || !ckb_b_y_von.Checked || ckb_b_y_bis.Checked);

            endtbx[0, 0] = tbx_x_von.Enabled = ckb_b_x_von.Checked;
            endtbx[0, 1] = tbx_x_bis.Enabled = ckb_b_x_bis.Checked;
            endtbx[1, 0] = tbx_y_von.Enabled = ckb_b_y_von.Checked && ckb_b_y_von.Enabled;
            endtbx[1, 1] = tbx_y_bis.Enabled = ckb_b_y_bis.Checked && ckb_b_y_bis.Enabled;

            ckb_x_grenz.Enabled = (!ckb_b_x_von.Checked || !ckb_b_x_bis.Checked) && !ckb_n_x_manuell.Checked;
            ckb_y_grenz.Enabled = (!ckb_b_y_von.Checked || !ckb_b_y_bis.Checked) && !ckb_n_y_manuell.Checked && !ckb_x_y.Checked;

            grenzcbx[0] = ckb_x_grenz.Checked && ckb_x_grenz.Enabled;
            grenzcbx[1] = ckb_y_grenz.Checked && ckb_y_grenz.Enabled;
        }

        private void werte_anpassen()
        {
            ver_x_y = Convert.ToDouble(tbx_verhaltnis.Text);

            spt[0] = Convert.ToDouble(tbx_x_achse.Text) * Convert.ToInt32(tbx_x_achse.Enabled);
            spt[1] = Convert.ToDouble(tbx_y_achse.Text) * Convert.ToInt32(tbx_y_achse.Enabled) + Convert.ToInt32(!ckb_x_y.Checked && !tbx_y_achse.Enabled && !(ckb_b_y_von.Checked && ckb_b_y_bis.Checked));

            endwerte[0, 0] = Convert.ToDouble(tbx_x_von.Text) * Convert.ToInt32(tbx_x_von.Enabled);
            endwerte[0, 1] = Convert.ToDouble(tbx_x_bis.Text) * Convert.ToInt32(tbx_x_bis.Enabled);
            endwerte[1, 0] = Convert.ToDouble(tbx_y_von.Text) * Convert.ToInt32(tbx_y_von.Enabled);
            endwerte[1, 1] = Convert.ToDouble(tbx_y_bis.Text) * Convert.ToInt32(tbx_y_bis.Enabled);

            mitte_wert[0] = Convert.ToDouble(tbx_null_x.Text) * Convert.ToInt32(ckb_n_x_manuell.Checked && ckb_n_x_manuell.Enabled);
            mitte_wert[1] = Convert.ToDouble(tbx_null_y.Text) * Convert.ToInt32(ckb_n_y_manuell.Checked && ckb_n_y_manuell.Enabled);

            if (tbx_x_von.Enabled && tbx_null_x.Enabled)
                endwerte[0, 1] = mitte_wert[0] * 2 - endwerte[0, 0];

            if (tbx_x_von.Enabled && tbx_null_x.Enabled)
                endwerte[0, 0] = mitte_wert[0] * 2 - endwerte[0, 1];

            if (tbx_y_von.Enabled && tbx_null_y.Enabled)
                endwerte[1, 1] = mitte_wert[1] * 2 - endwerte[1, 0];

            if (tbx_y_bis.Enabled && tbx_null_y.Enabled)
                endwerte[1, 0] = mitte_wert[1] * 2 - endwerte[1, 1];
        }

        private void grenzen_anpassen()
        {
            double[,] grenz = new double[2, 2] { { Double.MaxValue, Double.MinValue }, { Double.MaxValue, Double.MinValue } };

            for (int k = 0; k < 2; k++)
            {
                if (!grenzcbx[k] && !endtbx[k, 0])
                {
                    for (int i = 0; i < daten.Length; i++)
                    {
                        for (int j = 0; j < daten[i][0].Length; j++)
                        {
                            if (daten[i][k][j] < grenz[1, 0] && !Double.IsNaN(daten[i][k][j]))
                                grenz[k, 0] = daten[i][k][j];
                        }
                    }
                }

                if (!grenzcbx[k] && !endtbx[k, 1])
                {
                    for (int i = 0; i < daten.Length; i++)
                    {
                        if (daten[i][k].Length > 0 && daten[i][k].Max() > grenz[k, 1])
                            grenz[k, 1] = daten[i][k].Max();
                    }
                }
            }
        }

        private void Daten_FormClosing(object sender, FormClosingEventArgs e)
        {
            liste_richtig(nr);
            grenzen_anpassen();

            e.Cancel = true;
            Hide();
        }

        private void btn_sch_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btn_neu_Click(object sender, EventArgs e)
        {
            btn_loschen.Enabled = true;

            if (welche_lbx == 1)
            {
                nr++;
                pos = 0;

                Array.Resize(ref daten, daten.Length + 1);

                if (nr < dgv_l.Rows.Count)
                    Array.Copy(daten, nr + 1, daten, nr + 2, daten.Length - nr - 2);

                daten[nr] = new double[2][];
                daten[nr][0] = new double[1] { Double.NaN };
                daten[nr][1] = new double[1] { Double.NaN };

                bool[] cache3 = new bool[daten.Length];
                string[] cache = new string[daten.Length];
                string[] cache2 = new string[daten.Length];
                Color[] cache4 = new Color[daten.Length];

                for (int i = 0, j = 0; i < cache.Length - 1; i++, j = Convert.ToInt32(i == nr))
                {
                    cache3[i] = Convert.ToBoolean(dgv_l[0, i + j].Value);
                    cache2[i] = dgv_l[1, i + j].Value.ToString();
                    cache[i] = dgv_l[2, i + j].Value.ToString();
                    cache4[i] = dgv_l[0, i + j].Style.BackColor;
                }

                cache[nr] = "Neu";
                cache2[nr] = "Linie";
                cache3[nr] = true;
                cache4[nr] = Color.White;

                dgv_l.Rows.Add(1);

                for (int i = 0; i < daten.Length; i++)
                {
                    dgv_l[0, i].Value = cache3[i];
                    dgv_l[1, i].Value = cache2[i];
                    dgv_l[2, i].Value = cache[i];
                    dgv_l[0, i].Style.BackColor = dgv_l[1, i].Style.BackColor = dgv_l[2, i].Style.BackColor = dgv_l[3, i].Style.BackColor = cache4[i];
                }

                dgv_l.CurrentCell = dgv_l[2, nr];

                hight_l = 18 + dgv_l.Rows.Count * row_hight;

                if (hight_l > dgv_l.Height)
                    dgv_l.Columns[2].Width = width_l - 10;
                else
                    dgv_l.Columns[2].Width = width_l;

                tbx_contant.Text = dgv_l[2, nr].Value.ToString();
                tbx_contant.Focus();
                tbx_contant.SelectAll();

                row_hight = dgv_l.Rows[0].Height;

                if (farbe_wahlen.ShowDialog() == DialogResult.OK)
                    dgv_l[0, nr].Style.BackColor = dgv_l[1, nr].Style.BackColor = dgv_l[2, nr].Style.BackColor = dgv_l[3, nr].Style.BackColor = farbe_wahlen.Color;
            }
            else
            {
                Array.Resize(ref daten[nr][0], daten[nr][0].Length + 1);
                Array.Resize(ref daten[nr][1], daten[nr][1].Length + 1);

                if (pos + 2 < dgv_k.Rows.Count)
                {
                    Array.Copy(daten[nr][0], pos + 1, daten[nr][0], pos + 2, daten[nr][0].Length - pos - 2);
                    Array.Copy(daten[nr][1], pos + 1, daten[nr][1], pos + 2, daten[nr][1].Length - pos - 2);
                }

                pos++;
                daten[nr][0][pos] = Double.NaN;
                daten[nr][1][pos] = Double.NaN;

                if (cbx_auto.Checked && pos > 0 && !Double.IsNaN(daten[nr][0][pos - 1]))
                {
                    daten[nr][0][pos] = daten[nr][0][pos - 1] + schritte;
                    tbx_contant.Text = do_st(daten[nr][1][pos]);
                }
                else
                {
                    tbx_contant.Text = do_st(daten[nr][0][pos]);
                    welche_lbx = 2;
                }
            }
            
            lbx_fullen();
        }

        private void tbx_contant_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    key_pressed = 1;
                    break;

                case Keys.Escape:
                    key_pressed = 2;
                    break;

                case Keys.Down:
                    key_pressed = 3;
                    break;

                case Keys.Up:
                    key_pressed = 4;
                    break;

                case Keys.PageDown:
                    key_pressed = 5;
                    break;

                case Keys.PageUp:
                    key_pressed = 6;
                    break;

                case Keys.Home:
                    key_pressed = 7;
                    break;

                case Keys.End:
                    key_pressed = 8;
                    break;

                case Keys.Delete:
                    key_pressed = 9;
                    break;

                default:
                    key_pressed = 0;
                    break;
            }

            if (key_pressed != 0)
            {
                tim.Enabled = true;
                tim_Tick(new object(), new EventArgs());
            }
            else
                tim.Enabled = false;
        }

        private void tbx_contant_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (key_pressed == 1)
                        key_pressed = -1;
                    break;

                case Keys.Escape:
                    if (key_pressed == 2)
                        key_pressed = -1;
                    break;

                case Keys.Down:
                    if (key_pressed == 3)
                        key_pressed = -1;
                    break;

                case Keys.Up:
                    if (key_pressed == 4)
                        key_pressed = -1;
                    break;

                case Keys.PageDown:
                    if (key_pressed == 5)
                        key_pressed = -1;
                    break;

                case Keys.PageUp:
                    if (key_pressed == 6)
                        key_pressed = -1;
                    break;

                case Keys.Home:
                    if (key_pressed == 7)
                        key_pressed = -1;
                    break;

                case Keys.End:
                    if (key_pressed == 8)
                        key_pressed = -1;
                    break;

                case Keys.Delete:
                    if (key_pressed == 9)
                        key_pressed = -1;
                    break;

                default:
                    if (key_pressed == 0)
                        key_pressed = -1;
                    break;
            }

            if (key_pressed == -1)
                tim.Enabled = false;
        }

        private void tim_Tick(object sender, EventArgs e)
        {
            switch (key_pressed)
            {
                case 1:

                    if (welche_lbx == 1)
                    {
                        dgv_l[2, nr].Value = tbx_contant.Text;
                    }
                    else if (welche_lbx == 2)
                    {
                        try
                        {
                            if (pos == daten[nr][0].Length)
                            {
                                Array.Resize(ref daten[nr][0], daten[nr][0].Length + 1);
                                Array.Resize(ref daten[nr][1], daten[nr][1].Length + 1);

                                daten[nr][0][pos] = Double.NaN;
                                daten[nr][1][pos] = Double.NaN;
                            }

                            daten[nr][0][pos] = Convert.ToDouble(tbx_contant.Text);
                            welche_lbx = 3;

                            tbx_contant.Text = do_st(daten[nr][1][pos]);
                        }
                        catch
                        {
                            tbx_contant.Text = do_st(daten[nr][0][pos]);
                        }
                    }
                    else if (welche_lbx == 3)
                    {
                        try
                        {
                            daten[nr][1][pos] = Convert.ToDouble(tbx_contant.Text);

                            Array.Resize(ref daten[nr][0], daten[nr][0].Length + 1);
                            Array.Resize(ref daten[nr][1], daten[nr][1].Length + 1);

                            if (pos + 2 < dgv_k.Rows.Count)
                            {
                                Array.Copy(daten[nr][0], pos + 1, daten[nr][0], pos + 2, daten[nr][0].Length - pos - 2);
                                Array.Copy(daten[nr][1], pos + 1, daten[nr][1], pos + 2, daten[nr][1].Length - pos - 2);
                            }

                            pos++;
                            daten[nr][0][pos] = Double.NaN;
                            daten[nr][1][pos] = Double.NaN;

                            if (cbx_auto.Checked && pos > 0 && !Double.IsNaN(daten[nr][0][pos - 1]))
                            {
                                daten[nr][0][pos] = daten[nr][0][pos - 1] + schritte;
                                tbx_contant.Text = do_st(daten[nr][1][pos]);
                            }
                            else
                            {
                                tbx_contant.Text = do_st(daten[nr][0][pos]);
                                welche_lbx = 2;
                            }
                        }
                        catch
                        {
                            tbx_contant.Text = do_st(daten[nr][1][pos]);
                        }
                    }

                    break;

                case 2:

                    if (welche_lbx == 1)
                        tbx_contant.Text = dgv_l[2, nr].Value.ToString();
                    else if (daten[nr][0].Length > pos)
                        tbx_contant.Text = do_st(daten[nr][welche_lbx - 2][pos]);

                    break;

                case 3:

                    if (welche_lbx == 1)
                    {
                        dgv_l[2, nr].Value = tbx_contant.Text;

                        nr = (nr + 1) % daten.Length;
                        dgv_l.CurrentCell = dgv_l[2, nr];

                        tbx_contant.Text = dgv_l[2, nr].Value.ToString();
                    }
                    else if (welche_lbx == 2)
                    {
                        try
                        {
                            double cache = Convert.ToDouble(tbx_contant.Text);

                            if (daten[nr][0].Length <= pos)
                            {
                                Array.Resize(ref daten[nr][0], daten[nr][0].Length + 1);
                                Array.Resize(ref daten[nr][1], daten[nr][1].Length + 1);

                                daten[nr][0][pos] = Double.NaN;
                                daten[nr][1][pos] = Double.NaN;
                            }

                            daten[nr][0][pos] = cache;
                            welche_lbx = 3;

                            tbx_contant.Text = do_st(daten[nr][1][pos]);
                        }
                        catch
                        {
                            try
                            {
                                tbx_contant.Text = do_st(daten[nr][0][pos]);
                            }
                            catch
                            {
                                tbx_contant.Text = "";
                            }
                        }
                    }
                    else if (welche_lbx == 3)
                    {
                        try
                        {
                            double cache = Convert.ToDouble(tbx_contant.Text);

                            if (daten[nr][0].Length <= pos)
                            {
                                Array.Resize(ref daten[nr][0], daten[nr][0].Length + 1);
                                Array.Resize(ref daten[nr][1], daten[nr][1].Length + 1);

                                daten[nr][0][pos] = Double.NaN;
                                daten[nr][1][pos] = Double.NaN;
                            }

                            daten[nr][1][pos] = cache;
                            welche_lbx = 2;

                            pos = (pos + 1) % daten[nr][0].Length;

                            tbx_contant.Text = do_st(daten[nr][0][pos]);
                        }
                        catch
                        {
                            try
                            {
                                tbx_contant.Text = do_st(daten[nr][1][pos]);
                            }
                            catch
                            {
                                tbx_contant.Text = "";
                            }
                        }
                    }

                    break;

                case 4:

                    if (welche_lbx == 1)
                    {
                        dgv_l[2, nr].Value = tbx_contant.Text;

                        nr = (nr - 1 + daten.Length) % daten.Length;
                        dgv_l.CurrentCell = dgv_l[2, nr];
                    }
                    else if (welche_lbx == 2)
                    {
                        try
                        {
                            double cache = Convert.ToDouble(tbx_contant.Text);

                            if (daten[nr][0].Length <= pos)
                            {
                                Array.Resize(ref daten[nr][0], daten[nr][0].Length + 1);
                                Array.Resize(ref daten[nr][1], daten[nr][1].Length + 1);

                                daten[nr][0][pos] = Double.NaN;
                                daten[nr][1][pos] = Double.NaN;
                            }

                            daten[nr][0][pos] = cache;
                            welche_lbx = 3;

                            pos = (pos - 1 + daten[nr][0].Length) % daten[nr][0].Length;

                            tbx_contant.Text = do_st(daten[nr][1][pos]);
                        }
                        catch
                        {
                            try
                            {
                                tbx_contant.Text = do_st(daten[nr][0][pos]);
                            }
                            catch
                            {
                                tbx_contant.Text = "";
                            }
                        }
                    }
                    else if (welche_lbx == 3)
                    {
                        try
                        {
                            double cache = Convert.ToDouble(tbx_contant.Text);

                            if (daten[nr][0].Length <= pos)
                            {
                                Array.Resize(ref daten[nr][0], daten[nr][0].Length + 1);
                                Array.Resize(ref daten[nr][1], daten[nr][1].Length + 1);

                                daten[nr][0][pos] = Double.NaN;
                                daten[nr][1][pos] = Double.NaN;
                            }

                            daten[nr][1][pos] = cache;
                            welche_lbx = 2;

                            tbx_contant.Text = do_st(daten[nr][0][pos]);
                        }
                        catch
                        {
                            try
                            {
                                tbx_contant.Text = do_st(daten[nr][1][pos]);
                            }
                            catch
                            {
                                tbx_contant.Text = "";
                            }
                        }
                    }

                    break;

                case 5:

                    if (welche_lbx == 1)
                    {
                        string cache = dgv_l[2, nr].Value.ToString();
                        Color cache2 = dgv_l[2, nr].Style.BackColor;

                        dgv_l[2, nr].Value = dgv_l[2, (nr + 1) % daten.Length];
                        dgv_l[0, nr].Style.BackColor = dgv_l[1, nr].Style.BackColor = dgv_l[2, nr].Style.BackColor = dgv_l[3, nr].Style.BackColor = dgv_l[0, (nr + 1) % daten.Length].Style.BackColor;

                        nr = (nr + 1) % daten.Length;

                        dgv_l[2, nr].Value = cache;
                        dgv_l[0, nr].Style.BackColor = dgv_l[1, nr].Style.BackColor = dgv_l[2, nr].Style.BackColor = dgv_l[3, nr].Style.BackColor = cache2;

                        dgv_l.CurrentCell = dgv_l[2, nr];
                    }
                    else if (welche_lbx == 2 || welche_lbx == 3)
                    {
                        double cache0 = daten[nr][0][pos];
                        double cache1 = daten[nr][1][pos];

                        daten[nr][0][pos] = daten[nr][0][(pos + 1) % daten[nr][0].Length];
                        daten[nr][1][pos] = daten[nr][1][(pos + 1) % daten[nr][1].Length];

                        pos = (pos + 1) % daten[nr][0].Length;

                        daten[nr][0][pos] = cache0;
                        daten[nr][1][pos] = cache1;
                    }

                    break;

                case 6:

                    if (welche_lbx == 1)
                    {
                        string cache = dgv_l[2, nr].Value.ToString();
                        Color cache2 = dgv_l[0, nr].Style.BackColor;

                        dgv_l[2, nr].Value = dgv_l[2, (nr - 1 + daten.Length) % daten.Length].Value;
                        dgv_l[0, nr].Style.BackColor = dgv_l[1, nr].Style.BackColor = dgv_l[2, nr].Style.BackColor = dgv_l[3, nr].Style.BackColor = dgv_l[0, (nr - 1 + daten.Length) % daten.Length].Style.BackColor;

                        nr = (nr - 1 + daten.Length) % daten.Length;

                        dgv_l[2, nr].Value = cache;
                        dgv_l[0, nr].Style.BackColor = dgv_l[1, nr].Style.BackColor = dgv_l[2, nr].Style.BackColor = dgv_l[3, nr].Style.BackColor = cache2;

                        dgv_l.CurrentCell = dgv_l[2, nr];
                    }
                    else if (welche_lbx == 2 || welche_lbx == 3)
                    {
                        double cache0 = daten[nr][0][pos];
                        double cache1 = daten[nr][1][pos];

                        daten[nr][0][pos] = daten[nr][0][(pos - 1 + daten[nr][0].Length) % daten[nr][0].Length];
                        daten[nr][1][pos] = daten[nr][1][(pos - 1 + daten[nr][0].Length) % daten[nr][0].Length];

                        pos = (pos - 1 + daten[nr][0].Length) % daten[nr][0].Length;

                        daten[nr][0][pos] = cache0;
                        daten[nr][1][pos] = cache1;
                    }

                    break;

                case 7:

                    if (welche_lbx == 1)
                    {
                        string cache = dgv_l[2, nr].Value.ToString();
                        Color cache2 = dgv_l[2, nr].Style.BackColor;
                        bool cache3 = Convert.ToBoolean(dgv_l[0, nr].Value);

                        for (int i = nr - 1; i > 0; i--)
                        {
                            dgv_l[0, nr + 1].Value = dgv_l[0, nr].Value;
                            dgv_l[2, i + 1].Value = dgv_l[2, nr].Value;
                            dgv_l[0, nr + 1].Style.BackColor = dgv_l[1, nr + 1].Style.BackColor = dgv_l[2, nr + 1].Style.BackColor = dgv_l[3, nr + 1].Style.BackColor = dgv_l[0, nr].Style.BackColor;
                        }

                        dgv_l[0, nr].Value = cache3;
                        dgv_l[2, nr].Value = cache;
                        dgv_l[0, nr].Style.BackColor = dgv_l[1, nr].Style.BackColor = dgv_l[2, nr].Style.BackColor = dgv_l[3, nr].Style.BackColor = cache2;

                        nr = 0;
                        dgv_l.CurrentCell = dgv_l[2, nr];
                    }
                    else if (welche_lbx == 2 || welche_lbx == 3)
                    {
                        double cache0 = daten[nr][0][pos];
                        double cache1 = daten[nr][1][pos];

                        Array.Copy(daten[nr][0], 0, daten[nr][0], 1, pos);
                        Array.Copy(daten[nr][1], 0, daten[nr][1], 1, pos);

                        pos = 0;

                        daten[nr][0][0] = cache0;
                        daten[nr][1][0] = cache1;
                    }

                    break;

                case 8:

                    if (welche_lbx == 1)
                    {
                        string cache = dgv_l[2, nr].Value.ToString();

                        dgv_l[2, nr].Value = dgv_l[2, daten.Length - 1].Value;
                        nr = daten.Length - 1;                      
                        dgv_l[2, nr].Value = cache;
                        
                        dgv_l.CurrentCell = dgv_l[2, nr];
                    }
                    else if (welche_lbx == 2 || welche_lbx == 3)
                    {
                        if (pos + 1 < daten[nr][0].Length)
                        {
                            double cache0 = daten[nr][0][pos];
                            double cache1 = daten[nr][1][pos];

                            Array.Copy(daten[nr][0], pos + 1, daten[nr][0], pos, daten[nr][0].Length - 1 - pos);
                            Array.Copy(daten[nr][1], pos + 1, daten[nr][1], pos, daten[nr][0].Length - 1 - pos);

                            pos = daten[nr][0].Length - 1;

                            daten[nr][0][pos] = cache0;
                            daten[nr][1][pos] = cache1;
                        }
                    }

                    break;
            }

            if (key_pressed > 0)
            {
                if (welche_lbx > 1)
                {
                    btn_loschen.Enabled = daten[nr][0].Length > 1;
                    btn_neu.Enabled = pos < daten[nr][0].Length;
                }

                lbx_fullen();
            }
        }

        public string do_st(double zahl)
        {
            string aus;

            if (Double.IsNaN(zahl))
                return "";

            return aus = zahl.ToString();
        }

        private void lbx_fullen()
        {
            if (nr >= 0)
            {
                x_wert = new string[0];
                y_wert = new string[0];

                for (int i = 0; i < daten[nr][0].Length; i++)
                {
                    if (!Double.IsNaN(daten[nr][0][i]) || !Double.IsNaN(daten[nr][1][i]) || i == pos)
                    {
                        Array.Resize(ref x_wert, x_wert.Length + 1);
                        Array.Resize(ref y_wert, y_wert.Length + 1);

                        x_wert[x_wert.Length - 1] = do_st(daten[nr][0][i]);
                        y_wert[x_wert.Length - 1] = do_st(daten[nr][1][i]);
                    }
                }

                if (x_wert.Length < 1 || (x_wert[x_wert.Length - 1] != "" || y_wert[y_wert.Length - 1] != ""))
                {
                    Array.Resize(ref x_wert, x_wert.Length + 1);
                    Array.Resize(ref y_wert, y_wert.Length + 1);

                    x_wert[x_wert.Length - 1] = "";
                    y_wert[x_wert.Length - 1] = "";
                }

                dgv_k.Rows.Clear();

                dgv_k.Rows.Add(x_wert.Length);

                row_hight = dgv_k.Rows[0].Height;
                hight_k = 18 + x_wert.Length * row_hight;

                if (hight_k > dgv_k.Height)
                {
                    dgv_k.Columns[0].Width = width_k - 8;
                    dgv_k.Columns[1].Width = width_k - 9;
                }
                else
                    dgv_k.Columns[0].Width = dgv_k.Columns[1].Width = width_k;

                for (int i = 0; i < x_wert.Length; i++)
                {
                    dgv_k[0, i].Value = x_wert[i];
                    dgv_k[1, i].Value = y_wert[i];
                }

                if (pos == -1)
                    pos = 0;

                if (welche_lbx != 1)
                    dgv_k.CurrentCell = dgv_k[welche_lbx - 2, pos];
                else
                    dgv_k.CurrentCell = null;

                tbx_contant.Focus();
                tbx_contant.SelectAll();
            }
        }

        private void liste_richtig(int index)
        {
            for (int i = 0; index >= 0 && i < daten[index][0].Length; i++)
            {
                if (Double.IsNaN(daten[index][0][i]) && Double.IsNaN(daten[index][1][i]))
                {
                    Array.Copy(daten[index][0], i + 1, daten[index][0], i, daten[index][0].Length - i - 1);
                    Array.Copy(daten[index][1], i + 1, daten[index][1], i, daten[index][1].Length - i - 1);

                    Array.Resize(ref daten[index][0], daten[index][0].Length - 1);
                    Array.Resize(ref daten[index][1], daten[index][1].Length - 1);

                    pos -= Convert.ToInt32(i <= pos);
                    i--;
                }
            }
        }

        private void tbx_schritte_Leave(object sender, EventArgs e)
        {
            try
            {
                schritte = Convert.ToDouble(tbx_schritte.Text);
            }
            catch 
            {
                tbx_schritte.Text = schritte.ToString();
            }
        }

        private double eintragen(double org,string text)
        {
            try
            {
                org = Convert.ToDouble(text);
            }
            catch { }

            return org;
        }

        private void tbx_x_achse_Leave(object sender, EventArgs e)
        {
            endwerte[0, 0] = eintragen(endwerte[0, 0], tbx_x_von.Text);
            endwerte[0, 1] = eintragen(endwerte[0, 1], tbx_x_bis.Text);
            endwerte[1, 0] = eintragen(endwerte[1, 0], tbx_y_von.Text);
            endwerte[1, 1] = eintragen(endwerte[1, 1], tbx_y_bis.Text);

            mitte_wert[0] = eintragen(mitte_wert[0], tbx_null_x.Text);
            mitte_wert[1] = eintragen(mitte_wert[1], tbx_null_y.Text);

            spt[0] = eintragen(spt[0], tbx_x_achse.Text);
            spt[1] = eintragen(spt[1], tbx_y_achse.Text);

            ver_x_y = eintragen(ver_x_y, tbx_verhaltnis.Text);
        }

        private void dgv_l_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void dgv_k_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgv_k_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            welche_lbx = e.ColumnIndex + 2;
            pos = e.RowIndex;

            liste_richtig(nr);
            lbx_fullen();

            btn_loschen.Enabled = daten[nr][0].Length > 1;
            btn_neu.Enabled = pos < daten[nr][0].Length;

            dgv_k.CurrentCell = dgv_k[e.ColumnIndex, pos];

            tbx_contant.Text = dgv_k[welche_lbx - 2, pos].Value.ToString();
            tbx_contant.Focus();
            tbx_contant.SelectAll();
        }

        private void dgv_l_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_l.CurrentCell.ColumnIndex == 0)
                dgv_l[0, dgv_l.CurrentCell.RowIndex].Value = !Convert.ToBoolean(dgv_l[0, dgv_l.CurrentCell.RowIndex].Value);
        }

        private void dgv_l_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int backup = nr;
            nr = e.RowIndex;
            welche_lbx = 1;

            btn_loschen.Enabled = daten.Length > 0;
            btn_neu.Enabled = true;

            if (e.ColumnIndex == 3)
            {
                farbe_wahlen.Color = dgv_l[0, nr].Style.BackColor;

                if (farbe_wahlen.ShowDialog() == DialogResult.OK)
                    dgv_l[0, nr].Style.BackColor = dgv_l[1, nr].Style.BackColor = dgv_l[2, nr].Style.BackColor = dgv_l[3, nr].Style.BackColor = farbe_wahlen.Color;
            }
            else if (e.ColumnIndex == 2)
            {
                liste_richtig(backup);
                lbx_fullen();

                tbx_contant.Focus();
                tbx_contant.Text = dgv_l[2, nr].Value.ToString();
                tbx_contant.SelectAll();
            }
            else if (e.ColumnIndex == 1)
            {
                if (dgv_l[1, nr].Value.ToString() == "Linie")
                    dgv_l[1, nr].Value = "Kurve";
                else
                    dgv_l[1, nr].Value = "Linie";
            }
        }

        private void dgv_l_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            dgv_l.Rows[e.Row.Index].Height = row_hight;
        }

        private void dgv_k_RowHeightChanged(object sender, DataGridViewRowEventArgs e)
        {
            dgv_k.Rows[e.Row.Index].Height = row_hight;
        }

        private void cbx_auto_CheckedChanged(object sender, EventArgs e)
        {
            tbx_schritte.Enabled = cbx_auto.Checked;
        }

        private void btn_loschen_Click(object sender, EventArgs e)
        {
            if (welche_lbx == 1)
            {
                if (nr + 1 < daten.Length)
                    Array.Copy(daten, nr + 1, daten, nr, daten.Length - nr - 1);

                Array.Resize(ref daten, daten.Length - 1);

                bool[] cache3 = new bool[daten.Length];
                string[] cache = new string[daten.Length];
                string[] cache2 = new string[daten.Length];
                Color[] cache4 = new Color[daten.Length];

                for (int i = 0, j = 0; i < cache.Length; i++, j = Convert.ToInt32(i == nr))
                {
                    cache3[i] = Convert.ToBoolean(dgv_l[0, i + j].Value);
                    cache2[i] = dgv_l[1, i + j].Value.ToString();
                    cache[i] = dgv_l[2, i + j].Value.ToString();
                    cache4[i] = dgv_l[0, i + j].Style.BackColor;
                }
                
                if (daten.Length > 0)
                {
                    dgv_l.Rows.Clear();
                    dgv_l.Rows.Add(daten.Length);

                    for (int i = 0; i < daten.Length; i++)
                    {
                        dgv_l[0, i].Value = cache3[i];
                        dgv_l[1, i].Value = cache2[i];
                        dgv_l[2, i].Value = cache[i];
                        dgv_l[0, i].Style.BackColor = dgv_l[1, i].Style.BackColor = dgv_l[2, i].Style.BackColor = dgv_l[3, i].Style.BackColor = cache4[i];
                    }

                    nr = nr % daten.Length;

                    dgv_l.CurrentCell = dgv_l[2, nr];
                    tbx_contant.Text = dgv_l[2, nr].Value.ToString();
                }
                else
                {
                    nr = -1;
                    welche_lbx = 1;

                    dgv_l.Rows.Clear();
                    dgv_k.Rows.Clear();

                    btn_loschen.Enabled = false;

                    tbx_contant.Text = "";
                }
            }
            else if (welche_lbx == 2 || welche_lbx == 3)
            {
                if (pos + 1 < daten[nr][0].Length)
                {
                    Array.Copy(daten[nr][0], pos + 1, daten[nr][0], pos, daten[nr][0].Length - pos - 1);
                    Array.Copy(daten[nr][1], pos + 1, daten[nr][1], pos, daten[nr][1].Length - pos - 1);
                }

                Array.Resize(ref daten[nr][0], daten[nr][0].Length - 1);
                Array.Resize(ref daten[nr][1], daten[nr][1].Length - 1);

                if (daten[nr][0].Length > 0)
                    pos = pos % daten[nr][0].Length;
                else
                {
                    pos = -1;
                    btn_loschen.Enabled = false;
                }
            }
        }

        private void Daten_SizeChanged(object sender, EventArgs e)
        {
            hight_l = 18 + dgv_l.Rows.Count * row_hight;

            if (hight_l > dgv_l.Height)
                dgv_l.Columns[2].Width = width_l - 10;
            else
                dgv_l.Columns[2].Width = width_l;

            hight_k = 18 + x_wert.Length * row_hight;

            if (hight_k > dgv_k.Height)
            {
                dgv_k.Columns[0].Width = width_k - 8;
                dgv_k.Columns[1].Width = width_k - 9;
            }
            else
                dgv_k.Columns[0].Width = dgv_k.Columns[1].Width = width_k;
        }

        private void tbx_contant_DoubleClick(object sender, EventArgs e)
        {
            Random zuf = new Random();

            daten[nr][0] = daten[nr][1] = new double[zuf.Next(5, 50)];

            for (int i = 0; i < daten[nr][0].Length; i++)
            {
                daten[nr][0][i] = zuf.Next(-10, 10);
                daten[nr][1][i] = zuf.Next(-10, 10);
            }

            lbx_fullen();
        }

        private void btn_datei_Click(object sender, EventArgs e)
        {
            datei.ShowDialog();

            lbx_fullen();
        }
    }
}
