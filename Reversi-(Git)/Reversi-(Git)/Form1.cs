using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Reversi__Git_
{
    public partial class Form1 : Form
    {
        int maxElementen = 6;
        int[,] raster; 
        bool speler1Zet = true;
        Panel speelveldPanel = new Panel();
        Panel scorePanel = new Panel();
        int speler1Stenen = 0;
        int speler2Stenen = 0;
        bool spelVast = false;
        bool veranderingToegestaan = true;

        //Kleuren
        SolidBrush speler1Kleur = new SolidBrush(Color.FromArgb(77, 69, 68));
        SolidBrush speler2Kleur = new SolidBrush(Color.FromArgb(212, 191, 188));

        public Form1()
        {
           
            InitializeComponent();   
            //Speelveld 
            this.Size = new Size(800, 800);
            this.Controls.Add(speelveldPanel);
            speelveldPanel.Paint += this.TekenPionnen;
            speelveldPanel.Paint += this.Tekenen;
            speelveldPanel.MouseClick += this.Klik;

            speelveldPanel.Size = new Size(maxElementen * 100, maxElementen * 100);
            speelveldPanel.BackColor = Color.Gray;

            int rowWidth = speelveldPanel.Width / maxElementen;
            int rowHeight = speelveldPanel.Height / maxElementen;

            //Scorepanel 
            scorePanel.Size = new Size(maxElementen * 100, 100);
            scorePanel.Location = new Point(0, (maxElementen * 100) + 10);
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
            /*/Print mechanisme
            for (int i = 0; i < raster.GetLength(0); i++)
            {
                for (int j = 0; j < raster.GetLength(1); j++)
                {
                    Console.Write(raster[i, j].ToString() + " ");
                }
                Console.WriteLine("");
            }
            /*/
            //Menu
            
            //ToolStripMenuItem menu = new ToolStripMenuItem("Opties");
            //menu.DropDownItems.Add("Herstart", null, this.Herstart);
            

            speelveldPanel.Invalidate();
            scorePanel.Invalidate();
            
        }

        private void Herstart(object sender, EventArgs e)
        {
            Console.WriteLine("Restart");
            // zet alle items in 2d array naar 0
        }

        public void TekenScorepanel(object sender, PaintEventArgs pea)
        {
            //Tekent scorepaneel, is gekoppeld aan Paint event
            //Scorebord met score voor beide teams
            speler1Stenen = 0;
            speler2Stenen = 0;
            bool spelOver = false;


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
                    Console.WriteLine("Spel is nog bezig: geen winnaar");
                    break;
                case 1:
                    Console.WriteLine("Speler 1 heeft gewonnen!");
                    spelOver = true;
                    Console.WriteLine("Het is gelijkspel!");
                    g.FillRectangle(UitslagKleur, 700, 10, 400, 100);
                    g.DrawString("SPELER 1\n HEEFT GEWONNEN", new Font("Cascadia Mono SemiBold", 28), Brushes.Black, scorePanel.Width / 2, scorePanel.Height / 2, UitslagFormat);
                    break;
                case 2:
                    Console.WriteLine("Speler 2 heeft gewonnen!");
                    spelOver = true;
                    Console.WriteLine("Het is gelijkspel!");
                    g.FillRectangle(UitslagKleur, 700, 10, 400, 100);
                    g.DrawString("SPELER 2\n HEEFT GEWONNEN", new Font("Cascadia Mono SemiBold", 28), Brushes.Black, scorePanel.Width / 2, scorePanel.Height / 2, UitslagFormat);
                    break;
                case 3:
                    spelOver = true;
                    Console.WriteLine("Het is gelijkspel!");
                    g.FillRectangle(UitslagKleur, 700, 10, 400, 100);
                    g.DrawString("HET IS GELIJKSPEL", new Font("Cascadia Mono SemiBold", 28), Brushes.Black, scorePanel.Width / 2, scorePanel.Height / 2, UitslagFormat);
                    break;
                default:
                    Console.WriteLine("Shit gaat fout????!");
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
            Console.WriteLine("\n");
            for (int i = 0; i < maxElementen; i++)
            {
                for (int j = 0; j < maxElementen; j++) 
                {                                    
                    switch(raster[i,j])
                    {
                        case 0:
                            //Console.WriteLine("raster with " + i + "," + j + ": 0");
                            break;
                        case 1:
                            //Console.WriteLine("raster with " + i + "," + j + ": 1");
                            Rectangle speler1 = new Rectangle( 100 * i + 10 , 100 * j + 10, 100 - 20, 100 - 20);
                            g.FillEllipse(speler1Kleur, speler1);
                            break;
                        case 2:
                            //Console.WriteLine("raster with " + i + "," + j + ": 2");
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

            if (CheckZetLegaal(klikPunt))
            {

                if (speler1Zet)
                {
                    raster[RasterX, RasterY] = 1;
                    speler1Zet = false;
                    
                }
                else
                {
                    raster[RasterX, RasterY] = 2;
                    speler1Zet = true;
                    
                }
                
                speelveldPanel.Invalidate();
            } else {
                Console.WriteLine("Zet mag niet!");
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
            while (!nulGevonden && t < maxElementen * 10)
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
            if (!nulGevonden)
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
            int t = 0;
            // rijtje checks
            bool duplicateLocatieRegel = duplicateLocatieCheck(klikPunt);
            bool sluitInRegel = checkInsluit(klikPunt);
            
            if (duplicateLocatieRegel && sluitInRegel)
            {
                zetLegaal = true;
            }
            
            // Check die kijkt of er nog opties zijn voor speler die aan zet komt
            if (!duplicateLocatieRegel && !sluitInRegel)
            {
                /*/Console.WriteLine("Geen zetten meer te doen! AAAAAAAAAAAAAA\n\n\n\n\n\n\n");
                if (speler1Zet)
                {
                    vasteSpeler = 2;
                    spelVast = true;
                    DialogResult res = MessageBox.Show("Let op", "Er zijn geen zetten meer voor speler 2. Speler 1 is nu direct aan de beurt.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    vasteSpeler = 1;
                    spelVast = true;
                    DialogResult res = MessageBox.Show("Let op", "Er zijn geen zetten meer voor speler 1. Speler 2 is nu direct aan de beurt.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }/*/

            } //bs waarschijnlijk

            //check of array nog lege plekken heeft; checkt vervolgens deze plekken of ze legaal zijn
            /*/for (int i = 0; i < maxElementen; i++)
            {
                for (int j = 0; j < maxElementen; j++)
                {
                    if (raster[i, j] == 0)
                    {
                        CheckVastSpel(new Point(i,j));
                        //Toch maar even nieuwe functie aangezien de andere 1. dingen veranderd 2.de main steen niet meeneemt, deze moet juist ghecheckt worden
                    }
                }
            }
            /*/
            
            return zetLegaal;
        }

        public bool CheckVastSpel(Point klikPunt)
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
        }
        //Toch maar even nieuwe functie aangezien de andere 1. dingen veranderd 2.de main steen niet meeneemt, deze moet juist ghecheckt worden
        public bool CheckVastSpelInsluiting(int dx, int dy, Point klikPunt)
        {
            int zetPuntVanSpeler;
            int zetPuntVanSpelerInvers;
            bool andereSteenAanwezig = false;
            bool legaal = false;

            if (speler1Zet == true)
            {
                zetPuntVanSpeler = 2;
                zetPuntVanSpelerInvers = 1;
            }
            else
            {
                zetPuntVanSpeler = 1;
                zetPuntVanSpelerInvers = 2;
            }
            
            Point checkPunt = klikPunt;
            while (true)
            {
                
                if (checkPunt.X < 0 || checkPunt.X > 5 || checkPunt.Y < 0 || checkPunt.Y > 5)
                {
                    //Out of bounds check
                    Console.WriteLine("Out of bounds");

                    break;
                } //Out of bounds check
                else
                {
                    Console.WriteLine("NOT out of bounds");
                    if (raster[checkPunt.X, checkPunt.Y] == zetPuntVanSpelerInvers)
                    {
                        andereSteenAanwezig = true;

                        //Checkt voor een steen van andere team die ingesloten moet worden
                    }
                    if (raster[checkPunt.X, checkPunt.Y] == zetPuntVanSpeler && !andereSteenAanwezig)
                    {
                        //Er wordt wel ingesloten maar er is geen steen tussen van het andere team
                        break;
                    }
                    if (andereSteenAanwezig && raster[checkPunt.X, checkPunt.Y] == zetPuntVanSpeler)
                    {
                        //Checkt of de insluiting klaar is
                        Console.WriteLine("Insluiting van " + klikPunt + " tot " + checkPunt);

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
                
                
                Console.WriteLine("checking " + checkPunt);
                
                if(checkPunt.X < 0 || checkPunt.X > 5 || checkPunt.Y < 0 || checkPunt.Y > 5)
                {
                    //Out of bounds check
                    Console.WriteLine("Out of bounds");
                    running = false;
                    
                    break;
                } //Out of bounds check
                else
                {
                    Console.WriteLine("NOT out of bounds");
                    if (raster[checkPunt.X,checkPunt.Y] == zetPuntVanSpelerInvers)
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
                        Console.WriteLine("dab");
                        break;
                    }
                    if (andereSteenAanwezig && raster[checkPunt.X, checkPunt.Y] == zetPuntVanSpeler)
                    {
                        //Checkt of de insluiting klaar is
                        Console.WriteLine("Insluiting van " + zetPunt + " tot " + checkPunt);
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

                    checkPunt = new Point(checkPunt.X + dx,checkPunt.Y + dy);

                }
                
                
            }

            return legaal;
        }
    }
}
