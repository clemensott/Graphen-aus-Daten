using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Graphen_aus_Daten
{
    public partial class Datei : Form
    {
        Daten infos;


        public Datei(Daten Infos)
        {
            InitializeComponent();
            infos = Infos;
        }

        private void btn_offnen_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader lesen = new StreamReader(ofd.FileName);

                string[] gr_st = lesen.ReadToEnd().Split('\n');
                lesen.Close();

                bool[] cache3;
                string[] cache;
                string[] cache2;
                Color[] cache4;

                if (infos.dgv_l.Rows.Count > 0 && rbn_hinzu.Checked)
                {
                    int davor = infos.daten.Length;

                    Array.Resize(ref infos.daten, infos.daten.Length + gr_st.Length / 3);

                    cache3 = new bool[infos.daten.Length];
                    cache = new string[infos.daten.Length];
                    cache2 = new string[infos.daten.Length];
                    cache4 = new Color[infos.daten.Length];

                    for (int i = 0; i < davor; i++)
                    {
                        cache3[i] = Convert.ToBoolean(infos.dgv_l[0, i].Value);
                        cache2[i] = infos.dgv_l[1, i].Value.ToString();
                        cache[i] = infos.dgv_l[2, i].Value.ToString();
                        cache4[i] = infos.dgv_l[0, i].Style.BackColor;
                    }

                    for (int i = davor; i < cache.Length; i++)
                    {
                        string[] details = gr_st[(i - davor) * 3 + 1].Split(';');
                        string[] werte = gr_st[(i - davor) * 3 + 2].Split(';');

                        infos.daten[i] = new double[2][];
                        infos.daten[i][0] = new double[werte.Length / 2];
                        infos.daten[i][1] = new double[werte.Length / 2];

                        for (int j = 0; j < werte.Length / 2; j++)
                        {
                            infos.daten[i][0][j] = Convert.ToDouble(werte[j * 2]);
                            infos.daten[i][1][j] = Convert.ToDouble(werte[j * 2 + 1]);
                        }

                        cache3[i] = Convert.ToBoolean(details[0]);
                        cache2[i] = details[1];
                        cache[i] = gr_st[(i - davor) * 3];
                        cache4[i] = Color.FromArgb(Convert.ToInt32(details[2]));
                    }
                }
                else
                {
                    infos.nr = 0;
                    infos.pos = 0;
                    
                    infos.daten = new double[gr_st.Length / 3][][];
                
                    cache3 = new bool[infos.daten.Length];
                    cache = new string[infos.daten.Length];
                    cache2 = new string[infos.daten.Length];
                    cache4 = new Color[infos.daten.Length];

                    for (int i = 0; i < cache.Length; i++)
                    {
                        string[] details = gr_st[i * 3 + 1].Split(';');
                        string[] werte = gr_st[i * 3 + 2].Split(';');

                        infos.daten[i] = new double[2][];
                        infos.daten[i][0] = new double[werte.Length / 2];
                        infos.daten[i][1] = new double[werte.Length / 2];

                        for (int j = 0; j < werte.Length / 2; j++)
                        {
                            infos.daten[i][0][j] = Convert.ToDouble(werte[j * 2]);
                            infos.daten[i][1][j] = Convert.ToDouble(werte[j * 2 + 1]);
                        }

                        cache3[i] = Convert.ToBoolean(details[0]);
                        cache2[i] = details[1];
                        cache[i] = gr_st[i * 3];
                        cache4[i] = Color.FromArgb(Convert.ToInt32(details[2]));
                    }
                }

                infos.dgv_l.Rows.Clear();
                infos.dgv_l.Rows.Add(cache.Length);

                for (int i = 0; i < infos.daten.Length; i++)
                {
                    infos.dgv_l[0, i].Value = cache3[i];
                    infos.dgv_l[1, i].Value = cache2[i];
                    infos.dgv_l[2, i].Value = cache[i];
                    infos.dgv_l[0, i].Style.BackColor = infos.dgv_l[1, i].Style.BackColor = infos.dgv_l[2, i].Style.BackColor = infos.dgv_l[3, i].Style.BackColor = cache4[i];
                }
            }
        }

        private void btn_speichern_unter_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string aus = "";

                for (int i = 0; i < infos.dgv_l.Rows.Count; i++)
                {
                    aus += infos.dgv_l[2, i].Value.ToString() + "\r\n";
                    aus += infos.dgv_l[0, i].Value.ToString() + ";";
                    aus += infos.dgv_l[1, i].Value.ToString() + ";";
                    aus += infos.dgv_l[1, i].Style.BackColor.ToArgb().ToString() + "\r\n";

                    for (int j = 0; j < infos.daten[i][0].Length; j++)
                    {
                        aus += infos.do_st(infos.daten[i][0][j]) + ";" + infos.do_st(infos.daten[i][1][j]) + ";";
                    }

                    aus = aus.TrimEnd(';');
                    aus += "\r\n";
                }

                aus = aus.TrimEnd('\n');

                StreamWriter schreiben = new StreamWriter(sfd.FileName);
                schreiben.Write(aus);

                schreiben.Close();
            }
        }

        private void Datei_Load(object sender, EventArgs e)
        {

        }

        private void Datei_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
