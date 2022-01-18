using System;
using System.Drawing;
using System.Windows.Forms;

namespace Taalherkenning
{
    public class Taal : Form
    {
        const int aantal = 10;
        TextBox   invoer;
        Label     uitvoer;
        TextBox[] taal;
        Label  [] score;
        TextBox[] url;
        TableLayoutPanel alles;
        
        void klik(object o, EventArgs ea)
        {
            RelTurfTab onbekend, voorbeeld;
            double kleinste, verschil;
            String naam, antwoord;

            onbekend = new RelTurfTab();
            onbekend.Turf(invoer.Text);

            kleinste = 1.0;
            antwoord = "onbekend";
            for (int t = 0; t < aantal; t++)
            {   naam = url[t].Text;
                if (naam != "")
                {   voorbeeld = new RelTurfTab();
                    try
                    {   voorbeeld.Lees(naam);
                        verschil = onbekend.Verschil(voorbeeld);
                        score[t].Text = ((int)(10000 * verschil)).ToString();

                        if (verschil < kleinste)
                        {   kleinste = verschil;
                            antwoord = taal[t].Text;
                        }
                    }
                    catch (Exception)
                    {   this.score[t].Text = "???";
                        Console.WriteLine(ea.ToString());
                    }
                }
            }
            uitvoer.Text = antwoord;
        }
        void vergroot(object o, EventArgs ea)
        {
            alles.Size = this.ClientSize;
        }

        public Taal(string[] startwaarde)
        {
            Button knop;
            TableLayoutPanel paneel, talen;

            this.Text = "Taalherkenning";
            this.Size = new Size(800, 300);
            this.Resize += vergroot;
            invoer = new TextBox();  invoer.Multiline = true;
            invoer.Font = new Font("Tahoma", 14);
            knop = new Button();     knop.Text = "Herken taal";
            knop.Font = new Font("Tahoma", 10);
            knop.Click += this.klik;
            uitvoer = new Label();
            uitvoer.Text = "Hallo";
            uitvoer.Dock = DockStyle.Fill;
            uitvoer.Font = new Font("Tahoma", 14);

            paneel = new TableLayoutPanel(); paneel.ColumnCount = 2;
            talen = new TableLayoutPanel();  talen.ColumnCount  = 3;
            alles = new TableLayoutPanel();  alles.ColumnCount  = 2;

            taal = new TextBox[aantal];
            url = new TextBox[aantal];
            score = new Label[aantal];
            for (int t = 0; t < aantal; t++)
            {
                taal[t] = new TextBox(); taal[t].Dock  = DockStyle.Fill;
                score[t] = new Label();  score[t].Dock = DockStyle.Fill;
                url[t] = new TextBox();  url[t].Dock   = DockStyle.Fill;
                score[t].TextAlign = ContentAlignment.MiddleRight;
                if (t < startwaarde.Length / 2)
                {   taal[t].Text = startwaarde[2 * t];
                    url[t].Text = startwaarde[2 * t + 1];
                }
                talen.Controls.Add(score[t]);
                talen.Controls.Add(taal[t]);
                talen.Controls.Add(url[t]);
            }
            paneel.Controls.Add(invoer); paneel.SetColumnSpan(invoer, 2);
            paneel.Controls.Add(knop);
            paneel.Controls.Add(uitvoer);
            alles.Controls.Add(paneel);
            alles.Controls.Add(talen);
            this.Controls.Add(alles);
            this.vergroot(null, null);

            // en nog wat regels om de kolombreedte van de TableLayoutPanels te zetten...
            invoer.Dock = DockStyle.Fill;
            knop.Dock = DockStyle.Fill;
            talen.Dock = DockStyle.Fill;
            paneel.Dock = DockStyle.Fill;
            talen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            talen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            talen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65));
            paneel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            paneel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            paneel.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
            paneel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            alles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            alles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
        }
    }
}