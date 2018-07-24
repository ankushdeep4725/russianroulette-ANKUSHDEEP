using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace russianroulette
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Game game = new Game();
        private void Form1_Load(object sender, EventArgs e)
        {
            end();                                  //make everything equal as after game ends.
        }

        public void start()                         //starting game looks       
        {
            button2.Enabled = false;                //setting everything
            label2.Text = "Gun Loaded and Spinned.";
            label2.Visible = true;
            button4.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
            label4.Text = "6";
            label5.Text = "5/6";
        }

        public void end()                                                   //on game end
        {
            game.end();                                                     //clear the gun and chances left
            button4.Text = "Fire Away (2)";                                 //resetting values to default
            button4.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);                    //to exit game
        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.start();                           //to set bullet and spinning
            start();                                //to show game has started
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fire = game.fire();                  //pressing trigger
            label4.Text = "" + game.gunBarrel.Length;   //getting left shots
            label5.Text = "" + (game.gunBarrel.Length - 1) + "/" + game.gunBarrel.Length;       //getting probability
            if (fire == "killed")                       //if bullet was there
            {
                end();                                  //end game
                label2.Text = "You are killed.";        //text to tell what happened.
            } else
            {
                label2.Text = "Lucky You.";             //player are safe.
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fireAway = game.fireAway();          //pressing the trigger but away this time.
            label4.Text = "" + game.gunBarrel.Length;   //again calculating stats
            label5.Text = "" + (game.gunBarrel.Length - 1) + "/" + game.gunBarrel.Length;
            if (fireAway == "bullet gone")                  //if bullet was fired away
            {
                label2.Text = "You Won! That was bullet! Play Again?";      //game ends - player wins
                end();                                                      //end game
            }
            else if (fireAway == "game end")                                //if chances are gone and bullet is still inside
            {
                end();                                                      //game ends - player lost
                label2.Text = "You are killed! Play Again?";
            }
            else
            {
                button4.Text = "Fire Away (" + game.chances + ")";          //reducing the chances. and telling nothing happened
                label2.Text = "Fired away nothing.";
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
