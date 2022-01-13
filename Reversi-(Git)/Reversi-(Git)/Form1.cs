using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
// Ewoud ter Wee, Luka de Vrij
namespace Reversi__Git_
{
    public partial class Form1 : Form
    {
        int maxElementen;
        int[,] raster;
        bool speler1Zet = true;
        Panel speelveldPanel = new Panel();
        Panel scorePanel = new Panel();
        int speler1Stenen = 0;
        int speler2Stenen = 0;
        bool veranderingToegestaan = true;
        int zetSkipsStreak;
        bool eindeOverschreven;
        bool spelOver;
        bool alGeopend = false;

        //Kleuren
        SolidBrush speler1Kleur = new SolidBrush(Color.FromArgb(77, 69, 68));
        SolidBrush speler2Kleur = new SolidBrush(Color.FromArgb(212, 191, 188));

        public Form1()
        { 
            InitializeComponent();
            
            nieuwSpel();
            
        }

        private void nieuwSpel()
        {
            //Speelveld
            maxElementen = 6;
            raster = new int[maxElementen, maxElementen];
            this.Size = new Size(800, 800);

            this.Text = "Reversi";
            this.Controls.Add(speelveldPanel);
            speelveldPanel.Paint += this.TekenPionnen;
            speelveldPanel.Paint += this.Tekenen;
            speelveldPanel.MouseClick += this.Klik;

            speelveldPanel.Size = new Size(maxElementen * 100, maxElementen * 100);
            speelveldPanel.BackColor = Color.Gray;
            speelveldPanel.Location = new Point(0, 30);

            int rowWidth = speelveldPanel.Width / maxElementen;
            int rowHeight = speelveldPanel.Height / maxElementen;

            //Scorepanel 
            scorePanel.Size = new Size(maxElementen * 100, 100);
            scorePanel.Location = new Point(0, (maxElementen * 100) + 40);
            scorePanel.BackColor = Color.FromArgb(60, 19, 50, 80);
            scorePanel.Paint += this.TekenScorepanel;
            this.Controls.Add(scorePanel);
            //Array raster

            raster = new int[maxElementen, maxElementen];

            //Begin van speelveld met 2 stenen voor elk team
            raster[2, 2] = 1;
            raster[3, 3] = 1;
            raster[3, 2] = 2;
            raster[2, 3] = 2;

            bool spelOver = false;


            speelveldPanel.Invalidate();
            scorePanel.Invalidate();
        }

        public void TekenScorepanel(object sender, PaintEventArgs pea)
        {
            //Tekent scorepaneel, is gekoppeld aan Paint event
            //Scorebord met score voor beide teams
            speler1Stenen = 0;
            speler2Stenen = 0;
            


            Graphics g = pea.Graphics;
            g.FillEllipse(speler1Kleur, 10, 10, scorePanel.Height - 20, scorePanel.Height - 20);
            g.DrawEllipse(Pens.Black, 10, 10, scorePanel.Height - 20, scorePanel.Height - 20);
            g.FillEllipse(speler2Kleur, scorePanel.Width - scorePanel.Height + 10, 10, scorePanel.Height - 20, scorePanel.Height - 20);
            g.DrawEllipse(Pens.Black, scorePanel.Width - scorePanel.Height + 10, 10, scorePanel.Height - 20, scorePanel.Height - 20);


            //Checkt hoeveel stenen elk team heeft door door de array te loopen en elke element te checken op 1 of 2
            for (int i = 0; i < maxElementen; i++)
            {
                for (int j = 0; j < maxElementen; j++)
                {
                    if (raster[i, j] == 1)
                    {
                        speler1Stenen++;
                    }
                    else if (raster[i, j] == 2)
                    {
                        speler2Stenen++;
                    }

                }
            }

            //Checkt de status van het spel; is er door iemand gewonnen na de laatste zet?
            //Check of spel klaar is of niet and handle accordingly
            StringFormat UitslagFormat = new StringFormat();
            UitslagFormat.Alignment = StringAlignment.Center;
            UitslagFormat.LineAlignment = StringAlignment.Center;
            SolidBrush UitslagKleur = new SolidBrush(Color.FromArgb(60, 19, 50, 80));

            switch (CheckSpelGewonnen())
            {
                case 0:

                    break;
                case 1:
                    spelOver = true;
                    g.FillRectangle(UitslagKleur, 700, 10, 400, 100);
                    g.DrawString("SPELER 1\n HEEFT GEWONNEN", new Font("Cascadia Mono SemiBold", 28), Brushes.Red, scorePanel.Width / 2, scorePanel.Height / 2, UitslagFormat);
                    break;
                case 2:
                    spelOver = true;
                    g.FillRectangle(UitslagKleur, 700, 10, 400, 100);
                    g.DrawString("SPELER 2\n HEEFT GEWONNEN", new Font("Cascadia Mono SemiBold", 28), Brushes.Red, scorePanel.Width / 2, scorePanel.Height / 2, UitslagFormat);
                    break;
                case 3:
                    spelOver = true;
                    g.FillRectangle(UitslagKleur, 700, 10, 400, 100);
                    g.DrawString("HET IS GELIJKSPEL", new Font("Cascadia Mono SemiBold", 28), Brushes.Red, scorePanel.Width / 2, scorePanel.Height / 2, UitslagFormat);
                    break;
                default:

                    break;
            }

            //Format voor score van stenen per team
            StringFormat scoreFormat = new StringFormat();
            scoreFormat.Alignment = StringAlignment.Center;
            scoreFormat.LineAlignment = StringAlignment.Center;
            Font arial16Font = new Font("Arial", 16);

            g.DrawString(speler1Stenen.ToString(), new Font("Arial", 32) ,Brushes.White, 50, scorePanel.Height /2 , scoreFormat);
            g.DrawString(speler2Stenen.ToString(), new Font("Arial", 32), Brushes.Black, scorePanel.Width - 50, scorePanel.Height / 2, scoreFormat);

            //Veranderd wie er aan de beurt is op grafisch niveau
            StringFormat teamAanZetFormat = new StringFormat();
            teamAanZetFormat.Alignment = StringAlignment.Center;
            teamAanZetFormat.LineAlignment = StringAlignment.Center;

            if (speler1Zet && !spelOver)
            {
                g.DrawString("SPELER 1 \nIS AAN ZET", new Font("Cascadia Mono SemiBold", 32), Brushes.Black, scorePanel.Width / 2, scorePanel.Height / 2, teamAanZetFormat);
            }
            else if (!spelOver)
            {
                g.DrawString("SPELER 2 \nIS AAN ZET", new Font("Cascadia Mono SemiBold", 32), Brushes.Black, scorePanel.Width / 2, scorePanel.Height / 2, teamAanZetFormat);

            }
            else if (spelOver)
            {

            }
            
        }

        public void TekenPionnen(object sender, PaintEventArgs pea)
        {
            //Waarde van array = 0; leeg. = 1 van sp1 = 2 van sp2.
            Graphics g = pea.Graphics;

            for (int i = 0; i < maxElementen; i++)
            {
                for (int j = 0; j < maxElementen; j++) 
                {                                    
                    switch(raster[i,j])
                    {
                        case 0:

                            break;
                        case 1:

                            Rectangle speler1 = new Rectangle( 100 * i + 10 , 100 * j + 10, 100 - 20, 100 - 20);
                            g.FillEllipse(speler1Kleur, speler1);
                            break;
                        case 2:

                            Rectangle speler2 = new Rectangle( 100 * i + 10 , 100 * j + 10, 100 - 20, 100 - 20);
                            g.FillEllipse(speler2Kleur, speler2);
                            break;
                    
                    }

                }
            }
            scorePanel.Invalidate();
        }
        public void Tekenen(object sender, PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            for(int i = 1; i <= maxElementen; i++ )
            {
                Point point1 = new Point(100 * i, 0);
                Point point2 = new Point(100 * i, maxElementen * 100);
                g.DrawLine(Pens.Black, point1, point2);
            }
            for(int i = 1; i <= maxElementen; i++ )
            {
                Point point1 = new Point(0, 100 * i);
                Point point2 = new Point(maxElementen * 100, 100 * i);
                g.DrawLine(Pens.Black, point1, point2);
            }
        }
        public void Klik(object sender, MouseEventArgs mea)
        {

            int KlikX = mea.X;
            int KlikY = mea.Y;
            int RasterX = KlikX / 100;
            int RasterY = KlikY / 100;
            Point klikPunt = new Point(RasterX, RasterY);

            if (CheckZetLegaal(klikPunt) && !spelOver)
            {

                if (speler1Zet)
                {
                    raster[RasterX, RasterY] = 1;
                    speler1Zet = false;
                    zetSkipsStreak = 0;
                    
                }
                else
                {
                    raster[RasterX, RasterY] = 2;
                    speler1Zet = true;
                    zetSkipsStreak = 0;
                    
                }
                
                speelveldPanel.Invalidate();
            } else {

                SoundPlayer soundPlayer = new SoundPlayer(Reversi__Git_.Properties.Resources.errorSoundReversi);
                soundPlayer.Play();
                //DialogResult res = MessageBox.Show("Zet kan niet!", "Zet kan niet!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                // Dialogbox is vooral irritant, sound werkt beter
            }
            
        }
        public int CheckSpelGewonnen()
        {
            int spelerGewonnen;
            //Bij 0; nog niet bepaald, bij 1: speler 1, bij 2: speler 2, bij 3: gelijkspel
            bool nulGevonden = false;
            int t = 0;

            //check of array helemaal gevuld is; anders is het spel nog bezig
            while ((!nulGevonden && t < maxElementen * 10))
            {
                for (int i = 0; i < maxElementen; i++)
                {
                    for (int j = 0; j < maxElementen; j++)
                    {
                        if (raster[i, j] == 0)
                        {
                            nulGevonden = true;
                            spelerGewonnen = 0;
                            
                        }
                        else
                        {
                            t++;
                        }
                    } 
                }
            } // Dit is scuffed maar het werkt oke

            spelerGewonnen = checkStenen(nulGevonden);

            return spelerGewonnen;
        }

        private int checkStenen(bool nulGevonden)
        {
            int spelerGewonnen = 0;
            if (!nulGevonden || eindeOverschreven)
            {
                if (speler1Stenen > speler2Stenen)
                {
                    spelerGewonnen = 1;
                    //Speler 1 heeft gewonnen
                    
                }
                else if (speler2Stenen > speler1Stenen)
                {
                    spelerGewonnen = 2;
                    //Speler 2 heeft gewonnen
                }
                else
                {
                    spelerGewonnen = 3;
                    //Gelijkspel
                }
            }
            return spelerGewonnen;
        }

        public bool CheckZetLegaal(Point klikPunt)
        {
            bool zetLegaal = false;
            // rijtje checks
            bool duplicateLocatieRegel = duplicateLocatieCheck(klikPunt);
            bool sluitInRegel = checkInsluit(klikPunt);
            
            if (duplicateLocatieRegel && sluitInRegel)
            {
                zetLegaal = true;
            }
            
            return zetLegaal;
        }

        public bool duplicateLocatieCheck(Point klikPunt)
        {
            bool zetLegaal = false;
            if (raster[klikPunt.X, klikPunt.Y] == 0 || raster[klikPunt.X, klikPunt.Y] == 3)
            {
                zetLegaal = true;
            }
            return zetLegaal;
        }
        public bool checkInsluit(Point klikPunt)
        {

            if (checkInsluitRichting(0, -1, klikPunt) | checkInsluitRichting(0, 1, klikPunt) | checkInsluitRichting(-1, 0, klikPunt) | checkInsluitRichting(1, 0, klikPunt) | 
                checkInsluitRichting(1, 1, klikPunt) | checkInsluitRichting(-1, -1, klikPunt) | checkInsluitRichting(-1, 1, klikPunt) | checkInsluitRichting(1, -1, klikPunt))
                // nested loop is beter die van -1 tot 1 gaat in x en y
            {
                return true;

            }
            else
            {
                return false;
            }
        
            //checkInsluitRichting(0, -1); //verticaal omhoog
            //checkInsluitRichting(0, 1); //verticaal omlaag
            //checkInsluitRichting(-1, 0); //horizontaal links
            //checkInsluitRichting(1, 0); //horizontaal rechts
            //checkInsluitRichting(1, 1); //diagonaalLBnaarRO
            //checkInsluitRichting(-1, -1); //diagonaalROnaarLB
            //checkInsluitRichting(-1, 1); //diagonaalRBnaarLO
            //checkInsluitRichting(1, -1); //diagonaalLOnaarRB

        }

        private bool checkInsluitRichting(int dx, int dy, Point zetPunt)
        {
            bool legaal = false;
            int zetPuntVanSpeler;
            int zetPuntVanSpelerInvers;
            bool running = true;
            bool andereSteenAanwezig = false;


            if (speler1Zet == true)
            {
                zetPuntVanSpeler = 1;
                zetPuntVanSpelerInvers = 2;
            }
            else
            {
                zetPuntVanSpeler = 2;
                zetPuntVanSpelerInvers = 1;
            }

            Point checkPunt = new Point(zetPunt.X + dx, zetPunt.Y + dy);
            List<Point> checkList = new List<Point>();

            while (running)
            {




                if (checkPunt.X < 0 || checkPunt.X > 5 || checkPunt.Y < 0 || checkPunt.Y > 5)
                {
                    //Out of bounds check

                    running = false;

                    break;
                } //Out of bounds check
                else
                {

                    if (raster[checkPunt.X, checkPunt.Y] == zetPuntVanSpelerInvers)
                    {
                        andereSteenAanwezig = true;
                        checkList.Add(checkPunt);

                        //Checkt voor een steen van andere team die ingesloten moet worden
                    }
                    if (raster[checkPunt.X, checkPunt.Y] == 0 && veranderingToegestaan == false)
                    {

                        break;
                    }
                    if (raster[checkPunt.X, checkPunt.Y] == zetPuntVanSpeler && !andereSteenAanwezig)
                    {
                        
                        break;
                    }
                    if (andereSteenAanwezig && raster[checkPunt.X, checkPunt.Y] == zetPuntVanSpeler)
                    {
                        //Checkt of de insluiting klaar is

                        checkList.Add(checkPunt);
                        foreach (Point checkPoint in checkList)
                        {
                            if (veranderingToegestaan)
                            {
                                raster[checkPoint.X, checkPoint.Y] = zetPuntVanSpeler;
                            }
                        }

                        legaal = true;
                        break;
                    }
                    else
                    {

                    }

                    checkPunt = new Point(checkPunt.X + dx, checkPunt.Y + dy);

                }


            }

            return legaal;
        }

        private void RestartButton_ButtonClick(object sender, EventArgs e)
        {
            //Zorgt er voor dat er max 1 is
            if (alGeopend == false)
            {
                alGeopend = true;

                Form nieuwSpel = new Form1();
                nieuwSpel.Text = "Reversi [Nieuw spel]";
                Form oudSpel = this;

                this.Hide();
                nieuwSpel.ShowDialog();

                alGeopend = false;
                this.Show();
            }
            
        }

        private void GeenZettenButton_Click(object sender, EventArgs e)
        {
            //Beurt veranderen
            if (speler1Zet)
            {
                speler1Zet = false;
            }
            else
            {
                speler1Zet = true;
            }
            this.Invalidate();
            DialogResult res = MessageBox.Show("Aangezien je geen zetten meer kan doen, gaat de beurt naar de andere speler.", "Reversi - Geen zetten meer...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            zetSkipsStreak++;
            //Als 2x  achter elkaar dan ligt het spel plat
            if (zetSkipsStreak >= 2)
            {

                eindeOverschreven = true;
                DialogResult res2 = MessageBox.Show("Aangezien beide teams geen zetten meer kunnen doen is het spel beëindigd.", "Reversi - Geen zetten meer...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Invalidate();
            }
        }

        private void HulpButton_Click(object sender, EventArgs e)
        {
            String hulpText = "Reversi heeft twee teams, zwart en wit. Elk beschikken ze over stenen. Zwart begint. In de beginpositie zijn de vier velden in het centrum bezet. Een zet bestaat uit het neerleggen van een steen, op een leeg vakje. Alle stenen of series van stenen van de kleur van de tegenstander die tussen deze steen en een steen van de eigen kleur liggen(horizontaal, verticaal of schuin), worden omgedraaid van kleur. Men mag alleen een steen neerleggen indien daardoor minstens één steen wordt omgedraaid.Kan men dat niet, dan slaat men een beurt over.Kan men wel een zet doen, dan is dat verplicht. Het spel is voorbij als er geen stenen meer neergelegd kunnen worden, meestal doordat het bord vol is. De winnaar is de speler die de meeste stenen van zijn of haar kleur op het bord heeft. (nl.wikipedia.org/wiki/Reversi)";
            DialogResult res = MessageBox.Show(hulpText, "Hulp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
    }
}
