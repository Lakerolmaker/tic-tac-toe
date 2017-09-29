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

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {

        // : Håller koll på vems tur det är.
        bool turn = true;
        //: Håller koll på hur många  omgånger det har gått
        int turnCount = 0;

        string gamemode = "paper";

        Button changed = null;


        public Form1()
        {
            InitializeComponent();
              hidden.Select();
              
        }

       

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by: Jacob Olsson", "Creator");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button_click(object sender, EventArgs e)
        {

            Button b = (Button)sender;

            if (gamemode == "paper")
            {

                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";

                turn = !turn;

                turnCount++;


                b.Enabled = false;

            }
            else if (gamemode == "board")
            {

               


                //: Kollar om det är ett board game-mode
                if ((turnCount < 6))
                {


                    if (turn)
                        b.Text = "X";
                    else
                        b.Text = "O";


                    b.Enabled = false;

                    turn = !turn;

                    turnCount++;

                    if (turnCount == 6)
                    {

                        disableturn(1);
                    }
                   
                }
                else
                {


                    //: kollar att man har tryckt på en knapp tidigare


                    if (changed != null) {


                        if (turn)
                            b.Text = "X";
                        else
                            b.Text = "O";


                        changed.ForeColor = Color.Black;

                        changed.Text = "";

                        changed = null;

                    //: byter vems tur det är samtvhur många runder som har spelats
                    turn = !turn;

                    //: stänger av specifika kanppar
                    disableturn(1);

                }else if( !(b.Text == "") ){




                    changed = b;

                    changed.ForeColor = Color.White;

                    disableturn(2);

                  
  
                }


            }

          }// End board  

            //: selctar en gömd knapp
           hidden.Select();

            //: kollar om någon har vunnit
           winnerCheck();

        }//: end button click


        public void winnerCheck()
        {

            bool winner = false;
            


            //: kolla om någon har vunnit.
            //: verikal check
            if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && ((a1.Text == "X") || (a1.Text == "O")))
                winner = true;
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && ((b1.Text == "X") || (b1.Text == "O")))
                winner = true;
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && ((c1.Text == "X") || (c1.Text == "O")))
                winner = true;

            //: Horrisontel check
            else if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && ((a1.Text == "X") || (a1.Text == "O")))
                winner = true;
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && ((a2.Text == "X") || (a2.Text == "O")))
                winner = true;
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && ((c3.Text == "X") || (c3.Text == "O")))
                winner = true;

                // .Diagonal check
            else if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && ((a1.Text == "X") || (a1.Text == "O")))
                winner = true;
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && ((a3.Text == "X") || (a3.Text == "O"))){
                winner = true;
            }

            //: kollar om det är en draw
            if((winner == false) && (turnCount == 9)){

                disableButtons();

                MessageBox.Show( "Draw" , "The winner is");
            }




            string winingParty = "";

            if(winner)
            {

                if (turn)
                {
                    winingParty = "O";
                }else{
                    winingParty = "X";
                }

                disableButtons();

                MessageBox.Show(winingParty + " Wins", "The winner is");

            }


        }

        // : Stänger av alla knappar när någon har vunnit
        public void disableButtons()
        {

            foreach (Control c in Controls)
            {
                try { 

                Button b = (Button)c;

                b.Enabled = false;

                }
                catch { }
            }


        }


        // : Stänger av alla knapparsom inte ska spelas
        public void disableturn(double choice)
        {

            //: sätter på alla knappar
            foreach (Control c in Controls)
            {
                try
                {

                    Button B = (Button)c;

                    B.Enabled = true;

                }
                catch { }
            }


            foreach (Control c in Controls)
            {
                try
                {

                    Button b = (Button)c;

                    if ((choice == 1)) {

                    if (turn)
                    {

                        if ((b.Text == "O") || (b.Text == ""))
                        b.Enabled = false;
                    }

                    if (!turn)
                    {

                        if ((b.Text == "X") || (b.Text == ""))
                            b.Enabled = false;
                     }
                    }
                    else
                    {

                        if ((b.Text == "O") || (b.Text == "X"))
                            b.Enabled = false;

                    }

                }
                catch { }
            }

            hidden.Select();

        }

        //: startar om spelet
        public void newgame()
        {
            turn = true;

            turnCount = 0;

           

            foreach (Control c in Controls)
            {
                try
                {

                    Button b = (Button)c;

                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }

            hidden.Select();
        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            newgame();
        }

        //: Visar vems tur det är. genom att printe ut det på knappen när man hooverar på den.
        private void mouseEnter(object sender, EventArgs e)
        {

            if ((turnCount < 6) || (gamemode == "paper"))
            {


                Button b = (Button)sender;


                if (b.Enabled == true)
                {

                    if (turn)
                        b.Text = "X";
                    else
                        b.Text = "O";
                }

            }

        }

        //: tar bort tecknet när man tar bort musen.
        private void mouseLeave(object sender, EventArgs e)
        {
            if ((turnCount < 6) || (gamemode == "paper"))
            {


                Button b = (Button)sender;

                if (b.Enabled == true)
                {

                    b.Text = "";

                }
            }
        }


        //: Läser in data från ett txt doc
        public void data(object sender, EventArgs e)
        {

            StreamReader datadump = new StreamReader("data.txt");

            string data = datadump.ReadToEnd();

        }


        //: startar settings
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            var settings = new settings();
            settings.Closed += (s, args) => this.Close();
            settings.Show();

        }

       
      //: tar emot information från form1
        public Form1(string title)
    {
        InitializeComponent();

        gamemode = title;

        newgame();

    }


   

    


    }
}
