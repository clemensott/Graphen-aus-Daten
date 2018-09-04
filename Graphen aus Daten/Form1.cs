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
    public partial class Form1 : Form
    {
        Daten infos;

        Bitmap Bild;

        Point[][] pfeil_p = new Point[2][];
        Point[,] achsen_punkte = new Point[2, 2];
        Point[, ,] einteilungen_punkte = new Point[2, 2, 0];
        Point[][] graphen = new Point[0][];
        Rectangle[,] einteil_text = new Rectangle[2, 0];

        Pen stift_koor = new Pen(Color.Black, 1);
        Font schrift = new Font("Microsoft Sans Serif", 8);
        Brush farbe = new SolidBrush(Color.Black);

        Pen[] stift_graph = new Pen[0];

        bool[] pfeil_ein = new bool[2];
        string[,] text_einteilung;
        int oben = 20, unten = 60, rechts = 38, links = 20, ab = 30, la = 20, br = 7;
        int[] davor_ein = new int[2] { 0, 0 }, anzahl_einteilung = new int[2], text_anzahl = new int[2], ba_koor = new int[2];
        int[] koor = new int[2], anzeigen_einteilungen = new int[2], ur_wo = new int[2];
        int[,] lenght, verschiebung = new int[2, 2] { { 15, -26 }, { -15, 15 } };

        public Form1()
        {
            InitializeComponent();
            infos = new Daten(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            infos.ShowDialog();

            pfeil_p[0] = new Point[3];
            pfeil_p[1] = new Point[3];
            
            achsen_anpassen();
            graphen_anfertigen();
        }

        private void achsen_anpassen()
        {
            koor[0] = Size.Width - links - rechts + 1 - (Size.Width - links - rechts) % 2;
            koor[1] = Size.Height - oben - unten + 1 - (Size.Height - oben - unten) % 2;

            for (int i = 0, j = 12; i < 2; i++)
            {
                if ((infos.endtbx[i, 0] && infos.endtbx[i, 1] && infos.endwerte[i, 0] == infos.endwerte[i, 1]))
                    infos.endwerte[i, 1] += 10;

                while (infos.spttbx[i] && infos.endtbx[i, 0] && infos.endtbx[i, 1])
                {
                    if (dazwischen(infos.endwerte[i, 0], infos.endwerte[i, 1], infos.endwerte[i, 0] - infos.endwerte[i, 0] % infos.spt[i]) && dazwischen(infos.endwerte[i, 0], infos.endwerte[i, 1], infos.endwerte[i, 1] - infos.endwerte[i, 1] % infos.spt[i]))
                        anzahl_einteilung[i] = Convert.ToInt32(Math.Abs((infos.endwerte[i, 0] - infos.endwerte[i, 0] % infos.spt[i]) - (infos.endwerte[i, 1] - infos.endwerte[i, 1] % infos.spt[i])) / infos.spt[i]) + 1;
                    else
                        anzahl_einteilung[i] = Convert.ToInt32(Math.Abs((infos.endwerte[i, 0] - infos.endwerte[i, 0] % infos.spt[i]) - (infos.endwerte[i, 1] - infos.endwerte[i, 1] % infos.spt[i])) / infos.spt[i]);

                    i++;

                    if ((i == 1 && infos.vertbx) || i == 2)
                        break;
                }

                if ((i == 1 && infos.vertbx) || i == 2)
                    break;

                if (koor[i] / (j + 1) >= 30)
                {
                    anzahl_einteilung[i] = koor[i] / 30 + 1 + (koor[i] / 30) % 2 * Convert.ToInt32(infos.mittbx[i]);
                }
                else if (koor[i] / (j + 1) < 10)
                {
                    anzahl_einteilung[i] = koor[i] / 10 - 1 - (koor[i] / 10) % 2 * Convert.ToInt32(infos.mittbx[i]);
                }
                else
                {
                    anzahl_einteilung[i] = j + (-1 + 2 * Convert.ToInt32(koor[i] / (j + 1) >= 10)) * Convert.ToInt32(infos.mittbx[i]);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (!infos.endtbx[i, j] && infos.endtbx[i, 1 - j])
                        infos.endwerte[i, j] = infos.endwerte[i, 1 - j] + (j * 2 - 1) * infos.spt[i] * (anzahl_einteilung[i] - anzahl_einteilung[i] % 2);
                    else if (!infos.endtbx[i, j] && !(infos.endtbx[i, 1 - j] && infos.mittbx[i]))
                        infos.endwerte[i, j] = infos.mitte_wert[i] + (j * 2 - 1) * infos.spt[i] * (anzahl_einteilung[i] - anzahl_einteilung[i] % 2) / 2.0;
                }

                if (!infos.mittbx[i] && (i == 0 || !infos.vertbx))
                    infos.mitte_wert[i] = (infos.endwerte[i, 1] + infos.endwerte[i, 0]) / 2.0;

                if (!infos.spttbx[i] && (i == 1 || (infos.endtbx[1, 0] && infos.endtbx[1, 1])))
                    infos.spt[i] = (infos.endwerte[i, 1] - infos.endwerte[i, 0]) / Convert.ToDouble(anzahl_einteilung[i]);
            }

            if (infos.vertbx)
            {
                infos.spt[1] = infos.spt[0] * infos.ver_x_y;

                if (!infos.endtbx[1, 0] && !infos.endtbx[1, 1])
                {
                    infos.endwerte[1, 0] = infos.mitte_wert[1] - (infos.endwerte[0, 1] - infos.endwerte[0, 0]) / 2.0 / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]) * infos.spt[1] / infos.spt[0];
                    infos.endwerte[1, 1] = infos.mitte_wert[1] + (infos.endwerte[0, 1] - infos.endwerte[0, 0]) / 2.0 / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]) * infos.spt[1] / infos.spt[0];
                }
                else if (!infos.endtbx[0, 0] && !infos.mittbx[1])
                {
                    infos.endwerte[1, 0] = infos.endwerte[1, 1] - (infos.endwerte[0, 1] - infos.endwerte[0, 0]) / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]) * infos.spt[1] / infos.spt[0];
                    infos.mitte_wert[1] = infos.endwerte[1, 1] - (infos.endwerte[0, 1] - infos.endwerte[0, 0]) / 2.0 / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]);
                }
                else if (!infos.endtbx[1, 1] && !infos.mittbx[1])
                {
                    infos.endwerte[1, 1] = infos.endwerte[1, 0] + (infos.endwerte[0, 1] - infos.endwerte[0, 0]) / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]);
                    infos.mitte_wert[1] = infos.endwerte[1, 0] + (infos.endwerte[0, 1] - infos.endwerte[0, 0]) / 2.0 / Convert.ToDouble(koor[0]) * Convert.ToDouble(koor[1]);
                }

                anzahl_einteilung[1] = Convert.ToInt32((infos.endwerte[1, 1] - infos.endwerte[1, 0]) * infos.spt[1]);
            }

            for (int i = 0; i < 2; i++)
            {
                if (dazwischen(infos.endwerte[i, 0], infos.endwerte[i, 1], infos.endwerte[i, 0] - infos.endwerte[i, 0] % infos.spt[i]) && dazwischen(infos.endwerte[i, 0], infos.endwerte[i, 1], infos.endwerte[i, 1] - infos.endwerte[i, 1] % infos.spt[i]))
                    anzahl_einteilung[i] = Convert.ToInt32(Math.Abs(((infos.endwerte[i, 0] - infos.endwerte[i, 0] % infos.spt[i]) - (infos.endwerte[i, 1] - infos.endwerte[i, 1] % infos.spt[i])) / infos.spt[i])) + 1;
                else
                    anzahl_einteilung[i] = Convert.ToInt32(Math.Abs(((infos.endwerte[i, 0] - infos.endwerte[i, 0] % infos.spt[i]) - (infos.endwerte[i, 1] - infos.endwerte[i, 1] % infos.spt[i])) / infos.spt[i]));
            }

            int[] vari = new int[2]; ur_wo[0] = ur_wo[1] = -2;

            for (int i = 0; i < vari.Length; i++)
            {
                if (dazwischen(infos.endwerte[i, 0], infos.endwerte[i, 1], 0))
                {
                    ur_wo[i] = -1;
                    vari[i] = Convert.ToInt32(koor[i] / 2 + infos.mitte_wert[i] * koor[i] / (infos.endwerte[i, 0] - infos.endwerte[i, 1]));
                }
                else if (dazwischen(infos.endwerte[i, 0], Math.Sign(infos.endwerte[i, 0] - infos.endwerte[i, 1]) * Double.MaxValue, 0))
                    vari[i] = 0;
                else
                    vari[i] = koor[i];
            }

            achsen_punkte[0, 0] = new Point(links, koor[1] - vari[1] + oben);
            achsen_punkte[0, 1] = new Point(koor[0] + links, koor[1] - vari[1] + oben);

            achsen_punkte[1, 0] = new Point(vari[0] + links, oben);
            achsen_punkte[1, 1] = new Point(vari[0] + links, koor[1] + oben);

            if (achsen_punkte[1, 0].X + ab <= achsen_punkte[0, 1].X)
            {
                pfeil_ein[0] = true;

                pfeil_p[0][0] = new Point(achsen_punkte[0, 1].X - la, achsen_punkte[0, 1].Y - br);
                pfeil_p[0][1] = achsen_punkte[0, 1];
                pfeil_p[0][2] = new Point(achsen_punkte[0, 1].X - la, achsen_punkte[0, 1].Y + br);
            }
            else
                pfeil_ein[0] = false;

            if (achsen_punkte[0, 0].Y - ab >= achsen_punkte[1, 0].Y)
            {
                pfeil_ein[1] = true;

                pfeil_p[1][0] = new Point(achsen_punkte[1, 0].X - br, achsen_punkte[1, 0].Y + la);
                pfeil_p[1][1] = achsen_punkte[1, 0];
                pfeil_p[1][2] = new Point(achsen_punkte[1, 0].X + br, achsen_punkte[1, 0].Y + la);
            }
            else
                pfeil_ein[0] = false;

            einteilungen_machen();
        }

        private void einteilungen_machen()
        {
            bool[] richtigrum = new bool[2];
            int[,] endteilungen = new int[2, 2];
            double[] teilungen = new double[2] { koor[0] / (infos.endwerte[0, 1] - infos.endwerte[0, 0]), koor[1] / (infos.endwerte[1, 1] - infos.endwerte[1, 0]) };
            double[] drauf = new double[2];
            anzeigen_einteilungen[0] = anzeigen_einteilungen[1] = 0;

            einteilungen_punkte = new Point[2, 2, anzahl_einteilung.Max()];

            for (int i = 0; i < 2; i++)
            {
                if (dazwischen(infos.endwerte[i, 0], infos.endwerte[i, 1], 0))
                    drauf[i] = Math.Abs(infos.endwerte[i, 0] % infos.spt[i]);
                else
                    drauf[i] = infos.spt[i] - Math.Abs(infos.endwerte[i, 0] % infos.spt[i]);
            }

            for (int i = 0, j = -1; true; i++)
            {
                if (dazwischen(ab, koor[0] - ab, (drauf[0] + (i - 1) * Math.Abs(infos.spt[0])) * Math.Abs(teilungen[0])))
                {
                    einteilungen_punkte[0, 0, anzeigen_einteilungen[0]] = new Point(links + Convert.ToInt32((drauf[0] + (i - 1) * Math.Abs(infos.spt[0])) * Math.Abs(teilungen[0])), achsen_punkte[0, 0].Y - 10);
                    einteilungen_punkte[0, 1, anzeigen_einteilungen[0]] = new Point(einteilungen_punkte[0, 0, anzeigen_einteilungen[0]].X, einteilungen_punkte[0, 0, anzeigen_einteilungen[0]].Y + 20);

                    endteilungen[0, 0] = Convert.ToInt32((infos.endwerte[0, 0] + Math.Sign(infos.spt[0]) * (drauf[0] + (i - 1) * Math.Abs(infos.spt[0]))) / infos.spt[0]) * Convert.ToInt32(anzeigen_einteilungen[0] == 0) + endteilungen[0, 0] * Convert.ToInt32(anzeigen_einteilungen[0] != 0);
                    endteilungen[0, 1] = Convert.ToInt32((infos.endwerte[0, 0] + Math.Sign(infos.spt[0]) * (drauf[0] + (i - 1) * Math.Abs(infos.spt[0]))) / infos.spt[0]);

                    if (ur_wo[0] == -1 && drauf[0] + (i - 1) * Math.Abs(infos.spt[0]) == Math.Abs(infos.endwerte[0, 0]))
                        ur_wo[0] = anzeigen_einteilungen[0];

                    j = 2;

                    if (anzeigen_einteilungen[0] == 0 || (anzeigen_einteilungen[0] > 0 && einteilungen_punkte[0, 0, anzeigen_einteilungen[0]] != einteilungen_punkte[0, 0, anzeigen_einteilungen[0] - 1]))
                        anzeigen_einteilungen[0]++;
                }
                else if (j == 2)
                {
                    break;
                }
                else if ((drauf[0] + (i - 1) * Math.Abs(infos.spt[0])) * Math.Abs(teilungen[0]) < ab)
                {
                    j = 2 * Convert.ToInt32(j == 1);
                }
                else if ((drauf[0] + (i - 1) * Math.Abs(infos.spt[0])) * Math.Abs(teilungen[0]) > koor[0] - ab)
                {
                    j = 1 + Convert.ToInt32(j == 0);
                }
            }

            for (int i = 0, j = -1; true; i++)
            {
                if (dazwischen(ab, koor[1] - ab, (drauf[1] + (i - 1) * infos.spt[1]) * teilungen[1]))
                {
                    einteilungen_punkte[1, 0, anzeigen_einteilungen[1]] = new Point(achsen_punkte[1, 0].X + 10, oben + koor[1] - Convert.ToInt32((drauf[1] + (i - 1) * infos.spt[1]) * teilungen[1]));
                    einteilungen_punkte[1, 1, anzeigen_einteilungen[1]] = new Point(einteilungen_punkte[1, 0, anzeigen_einteilungen[1]].X - 20, einteilungen_punkte[1, 0, anzeigen_einteilungen[1]].Y);

                    endteilungen[1, 0] = Convert.ToInt32((infos.endwerte[1, 0] + Math.Sign(infos.spt[1]) * (drauf[1] + (i - 1) * Math.Abs(infos.spt[1]))) / infos.spt[1]) * Convert.ToInt32(anzeigen_einteilungen[1] == 0) + endteilungen[1, 0] * Convert.ToInt32(anzeigen_einteilungen[1] != 0);
                    endteilungen[1, 1] = Convert.ToInt32((infos.endwerte[1, 0] + Math.Sign(infos.spt[1]) * (drauf[1] + (i - 1) * Math.Abs(infos.spt[1]))) / infos.spt[1]);

                    if (ur_wo[1] == -1 && drauf[1] + (i - 1) * Math.Abs(infos.spt[1]) == Math.Abs(infos.endwerte[1, 0]))
                        ur_wo[1] = anzeigen_einteilungen[1];

                    j = 2;

                    if (anzeigen_einteilungen[1] == 0 || (anzeigen_einteilungen[1] > 0 && einteilungen_punkte[1, 0, anzeigen_einteilungen[1]] != einteilungen_punkte[1, 0, anzeigen_einteilungen[1] - 1]))
                        anzeigen_einteilungen[1]++;
                }
                else if (j == 2)
                {
                    break;
                }
                else if ((drauf[1] + (i - 1) * Math.Abs(infos.spt[1])) * Math.Abs(teilungen[1]) < ab)
                {
                    j = 2 * Convert.ToInt32(j == 1);
                }
                else if ((drauf[1] + (i - 1) * Math.Abs(infos.spt[1])) * Math.Abs(teilungen[1]) > koor[1] - ab)
                {
                    j = 1 + Convert.ToInt32(j == 0);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if ((infos.endwerte[i, 0] < infos.endwerte[i, 1] && endteilungen[i, 0] <= endteilungen[i, 1]) || (infos.endwerte[i, 0] > infos.endwerte[i, 1] && endteilungen[i, 0] >= endteilungen[i, 1]))
                    richtigrum[i] = true;
            }

            bemasung(teilungen, endteilungen, richtigrum);

            bitmap_erstellen();
        }

        private void bemasung(double[] teilung, int[,] endteilungen, bool[] richtigrum)
        {
            text_anzahl[0] = Convert.ToInt32(Math.Abs(auf_ab_runden(endteilungen[0, 0] / 5.0, false) - auf_ab_runden(endteilungen[0, 1] / 5.0, false)) + Convert.ToInt32(!dazwischen(endteilungen[0, 0], endteilungen[0, 1], 0)));
            text_anzahl[1] = Convert.ToInt32(Math.Abs(auf_ab_runden(endteilungen[1, 0] / 5.0, false) - auf_ab_runden(endteilungen[1, 1] / 5.0, false)) + Convert.ToInt32(!dazwischen(endteilungen[1, 0], endteilungen[1, 1], 0)));

            text_einteilung = new string[2, text_anzahl.Max()];
            lenght = new int[2, text_einteilung.Length];
            einteil_text = new Rectangle[2, text_einteilung.GetLength(1)];

            for (int i = 0; i < 2; i++)
            {
                bool ende_auf = infos.endwerte[i, 0] < infos.endwerte[i, 1];

                for (int j = 0, k = endteilungen[i, 0] / 5; true; k += Math.Sign(infos.endwerte[i, 1] - infos.endwerte[i, 0]), j++)
                {
                    k += Convert.ToInt32(k == 0) * Math.Sign(infos.endwerte[i, 1] - infos.endwerte[i, 0]);

                    if ((k * 5 > endteilungen[i, 1] && ende_auf) || (k * 5 * infos.spt[i] < endteilungen[i, 1] && !ende_auf))
                        break;

                    text_einteilung[i, j] = zahl_anpassen(infos.spt[i], k * 5);
                    char[] cache1 = text_einteilung[i, j].ToCharArray();

                    lenght[i, j] = 7;

                    for (int l = 0; l < cache1.Length; l++)
                        lenght[i, j] += 6 - 3 * Convert.ToInt32(cache1[l] == ',' || cache1[l] == '-') + Convert.ToInt32(cache1[l] == 'E');
                }
            }

            for (int j = endteilungen[1, 0] / 5, k = 0, l = 0; j <= endteilungen[1, 1] / 5; j++, k++, l++)
            {
                l += Convert.ToInt32(j == 0 || (j > 0 && k == 0));
                j += Convert.ToInt32(j == 0 || (j > 0 && k == 0));

                if (j > endteilungen[1, 1] / 5)
                    break;

                einteil_text[1, k] = ubereinander(1, k, achsen_punkte[1, 0].X - lenght[1, k] + verschiebung[1, 0], einteilungen_punkte[1, 0, (Convert.ToInt32(richtigrum[1]) * 2 - 1) * (endteilungen[1, 0] / 5 * 5 - endteilungen[1, 0]) + l * 5].Y - 6, lenght[1, k] + 2, 11);
            }

            for (int j = endteilungen[0, 0] / 5, k = 0, l = 0; j <= endteilungen[0, 1] / 5; j++, k++, l++)
            {
                l += Convert.ToInt32(j == 0);
                j += Convert.ToInt32(j == 0);

                if (j > endteilungen[0, 1] / 5)
                    break;

                einteil_text[0, k] = ubereinander(0, k, einteilungen_punkte[0, 0, (Convert.ToInt32(richtigrum[0]) * 2 - 1) * (endteilungen[0, 0] / 5 * 5 - endteilungen[0, 0]) + l * 5].X - lenght[0, k] / 2, achsen_punkte[0, 0].Y + verschiebung[0, 0], lenght[0, k] + 2, 11);
            }
        }

        private Rectangle ubereinander(int ein, int zwei, int x, int y, int width, int height)
        {
            int fehler = 0, x1 = x, x2 = x + width, y1 = y, y2 = y + height,
                xplus = Convert.ToInt32(ein == 1) * (-1 * verschiebung[1, 0] + verschiebung[1, 1] + lenght[ein, zwei]),
                yplus = Convert.ToInt32(ein == 0) * (-1 * verschiebung[0, 0] + verschiebung[0, 1]);

            Rectangle ausgabe = new Rectangle(0, 0, width, height);

            if ((ein == 1 && dazwischen(y1, y2, achsen_punkte[0, 0].Y)) || ((ein == 0 && dazwischen(x1, x2, achsen_punkte[1, 0].X))))
                fehler = 2;

            for (int i = 0; i < anzeigen_einteilungen[1 - ein] && fehler < 2; i++)
            {
                if ((ein == 1 && (dazwischen(einteilungen_punkte[0, 0, i].Y, einteilungen_punkte[0, 1, i].Y, y1) || dazwischen(einteilungen_punkte[0, 0, i].Y, einteilungen_punkte[0, 1, i].Y, y1)) && dazwischen(x1, x2, einteilungen_punkte[0, 0, i].X)) ||
                    (ein == 0 && (dazwischen(x1, x2, einteilungen_punkte[1, 0, i].X) || dazwischen(x1, x2, einteilungen_punkte[1, 1, i].X) || dazwischen(einteilungen_punkte[1, 0, i].X, einteilungen_punkte[1, 1, i].X, x1)) && dazwischen(y1, y2, einteilungen_punkte[1, 0, i].Y)))
                {
                    fehler = 2;
                }
            }

            for (int i = 0, f = 0; i < 2 && fehler < 2; i++, x1 += xplus, x2 += xplus, y1 += yplus, y2 += yplus, f = fehler)
            {
                if (!(dazwischen(links, links + koor[0], x1) && dazwischen(links, links + koor[0], x2) && dazwischen(oben, oben + koor[1], y1) && dazwischen(oben, oben + koor[1], y2)))
                    fehler++;

                for (int j = ein; j < 2 && fehler == f; j++)
                {
                    for (int k = 0; k < zwei && fehler == f; k++)
                    {
                        if ((dazwischen(x1, x2, einteil_text[j, k].X) || dazwischen(x1, x2, einteil_text[j, k].X + einteil_text[j, k].Width) || dazwischen(einteil_text[j, k].X, einteil_text[j, k].X + einteil_text[j, k].Width, x1))
                            && (dazwischen(y, y2, einteil_text[j, k].Y) || dazwischen(y, y2, einteil_text[j, k].Y + einteil_text[j, k].Height) || dazwischen(einteil_text[j, k].Y, einteil_text[j, k].Y + einteil_text[j, k].Height, y)))
                        {
                            fehler++;
                        }
                    }
                }

                if (fehler == f)
                    break;
            }

            if (fehler < 2)
            {
                ausgabe.X = x1;
                ausgabe.Y = y1;
            }

            return ausgabe;
        }

        private bool dazwischen(double erste, double zweite, double zahl)
        {
            bool passt;

            return passt = (erste >= zweite && erste >= zahl && zahl >= zweite) || (erste <= zweite && erste <= zahl && zahl <= zweite);
        }

        private double auf_ab_runden(double zahl, bool auf)
        {
            return zahl = Math.Round(zahl, 0) + Math.Sign(zahl) * (-1 * Convert.ToInt32(!auf && Math.Round(Math.Abs(zahl), 0) > Math.Abs(zahl)) + Convert.ToInt32(auf && Math.Round(Math.Abs(zahl), 0) < Math.Abs(zahl)));
        }

        private string zahl_anpassen(double zahl, int multi)
        {
            string text = "0";

            if (zahl != 0)
            {
                bool fehler_hier = false;
                int vorzeichen = Math.Sign(zahl * multi);
                double betrag = Math.Abs(zahl * multi);
                double fac = 10;

                if (betrag < 1)
                {
                    fac = 0.1;

                    if (betrag == 0)
                        betrag = Double.Epsilon;
                }
                else if (Double.IsInfinity(betrag))
                {
                    betrag = Double.MaxValue;
                }
                else if (Double.IsNaN(betrag))
                {
                    text = "0";
                    fehler_hier = true;
                }

                for (int m = 0; !fehler_hier; betrag /= fac, m++)
                {
                    if (betrag < 10 && 1 <= betrag)
                    {
                        if (fac == 10 && m > 6)
                        {
                            text = Convert.ToString(Math.Round(betrag, 3) * Convert.ToDouble(vorzeichen)) + "E" + Convert.ToString(m);
                        }
                        else if (fac == 0.1 && m > 3)
                        {
                            text = Convert.ToString(Math.Round(betrag, 3) * Convert.ToDouble(vorzeichen)) + "E-" + Convert.ToString(m);
                        }
                        else if (m > 3)
                        {
                            if (betrag * Math.Pow(fac, m) == Math.Round(betrag, m - 3) * Math.Pow(fac, m))
                            {
                                text = Convert.ToString(Math.Round(betrag, 3) * Convert.ToDouble(vorzeichen)) + "E" + Convert.ToString(m);
                            }
                            else
                            {
                                text = Convert.ToString(Math.Round(betrag * Math.Pow(fac, m), 0) * Convert.ToDouble(vorzeichen));
                            }
                        }
                        else
                        {
                            text = Convert.ToString(Math.Round(betrag * Math.Pow(fac, m), 3 - m) * Convert.ToDouble(vorzeichen));
                        }

                        break;
                    }
                }
            }

            return text;
        }

        private void bitmap_erstellen()
        {
            Bild = new Bitmap(koor[0], koor[1]);

            using (var graphics = Graphics.FromImage(Bild))
            {
                graphics.DrawLine(stift_koor, achsen_punkte[0, 0], achsen_punkte[0, 1]);
                graphics.DrawLine(stift_koor, achsen_punkte[1, 0], achsen_punkte[1, 1]);


                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < anzeigen_einteilungen[i] && !(j == ur_wo[i] && anzeigen_einteilungen[i] == 1); j++)
                    {
                        graphics.DrawLine(stift_koor, einteilungen_punkte[i, 0, j], einteilungen_punkte[i, 1, j]);
                        j += Convert.ToInt32(j + 1 == ur_wo[i]);
                    }


                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < text_anzahl[i]; j++)
                        if (einteil_text[i, j].X != 0)
                            graphics.DrawString(text_einteilung[i, j], schrift, farbe, einteil_text[i, j].X + 1, einteil_text[i, j].Y + 1);
            }

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(stift_koor, achsen_punkte[0, 0], achsen_punkte[0, 1]);
            e.Graphics.DrawLine(stift_koor, achsen_punkte[1, 0], achsen_punkte[1, 1]);

            if (pfeil_ein[0])
                e.Graphics.DrawLines(stift_koor, pfeil_p[0]);

            if (pfeil_ein[1])
                e.Graphics.DrawLines(stift_koor, pfeil_p[1]);

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < anzeigen_einteilungen[i] && !(j == ur_wo[i] && anzeigen_einteilungen[i] == 1); j++)
                {
                    e.Graphics.DrawLine(stift_koor, einteilungen_punkte[i, 0, j], einteilungen_punkte[i, 1, j]);
                    j += Convert.ToInt32(j + 1 == ur_wo[i]);
                }


            for (int i = 0; i < 2; i++)
                for (int j = 0; j < text_anzahl[i]; j++)
                    if (einteil_text[i, j].X != 0)
                        e.Graphics.DrawString(text_einteilung[i, j], schrift, farbe, einteil_text[i, j].X + 1, einteil_text[i, j].Y + 1);   //          */
            /*
            Graphics g = e.Graphics;
            g.DrawImage(Bild, 0, 0);
                                            //              */
            pbx.Invalidate();
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            infos.ShowDialog();

            achsen_anpassen();
            graphen_anfertigen();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            achsen_anpassen();
            graphen_anfertigen();
        }

        private void graphen_anfertigen()
        {
            int[] grose =new int[2]{pbx.Width,pbx.Height};
            graphen = new Point[infos.daten.Length][];

            for (int i = 0; i < infos.daten.Length; i++)
            {
                graphen[i] = new Point[0];

                for (int j = 0; j < infos.daten[i][0].Length; j++)
                {
                    if (!Double.IsNaN(infos.daten[i][0][j]) && !Double.IsNaN(infos.daten[i][1][j]))
                    {
                        Array.Resize(ref graphen[i], graphen[i].Length + 1);

                        graphen[i][graphen[i].Length - 1] = new Point(
                            Convert.ToInt32((infos.endwerte[0, 0] - infos.daten[i][0][j]) / (infos.endwerte[0, 0] - infos.endwerte[0, 1]) * grose[0]),
                            Convert.ToInt32((infos.endwerte[1, 1] - infos.daten[i][1][j]) / (infos.endwerte[1, 1] - infos.endwerte[1, 0]) * grose[1]));
                    }
                }
            }
        }

        private void pbx_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < graphen.Length; i++)
                if (graphen[i].Length > 1 && Convert.ToBoolean(infos.dgv_l[0, i].Value))
                    if (infos.dgv_l[1, i].Value.ToString() == "Linie")
                        e.Graphics.DrawLines(new Pen(new SolidBrush(infos.dgv_l[0, i].Style.BackColor)), graphen[i]);
                    else
                        e.Graphics.DrawCurve(new Pen(new SolidBrush(infos.dgv_l[0, i].Style.BackColor)), graphen[i]);
        }
    }
}
