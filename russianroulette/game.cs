using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace russianroulette
{
    class Game
    {
                                                                    //initialising array as gun chamber
        public int[] gunBarrel = { 0, 0, 0, 0, 0, 0 };  if          //empty bullet space is 0 and with bullet it is 1
        public int chances = 2;                                     //Chances for the player
        public void start()                                         //Game Start
        {
            Random rand = new Random();                             //Using random function to place bullet in the gun
            int val = rand.Next(0, 5);
            gunBarrel[val] = 1;
            loadBarrel();                                           //to make chamber spin sound
        }

        public void loadBarrel()                                    //making chamber spin sound
        {
            SoundPlayer player = new SoundPlayer("loading_and_spinning.wav");
            player.Play();
        }

        public string fire()                                        //function for firing---- returning string to identify what happened on gun fire
        {
            if (gunBarrel[0] == 1)                                  //checking if bullets in place
            {
                SoundPlayer player = new SoundPlayer("gun_shot.wav");       //making gun shot fire sound 
                player.Play();
                return "killed";                                            //returning - the player is killed.
            }
            else                                                    //otherwise
            {
                SoundPlayer player = new SoundPlayer("gun_cock.wav");           //no bullet sound playing
                player.Play();
                gunBarrel = gunBarrel.Skip(1).ToArray();                        //removing one elemnt from array to make the bullet shift forward
                return "safe";
            }
        }

        public string fireAway()                                    //Firing away
        {
            chances--;                                              //reducing the chances player has
            if (chances == 0)                                           
            {   
                if (gunBarrel[0] == 1)                              //if chances becomes 0 and the bullet is in position - the player has survived
                {
                    return "bullet gone";                           //returning he won
                }
                else
                {
                    gunBarrel = gunBarrel.Skip(1).ToArray();        //removing element from array to show no bullet was there to fire and no chances are there. so player dies.
                    return "game end";
                }
            }
            else
            {
                if (gunBarrel[0] == 1)                              //on first chance if the bullet is in position - the player has survived
                {
                    return "You win";                               //returning - the player has won
                }
                else                                                //otherwise
                {
                    return "nothing";                               //the firing away was wasted.
                }
            }
        }

        public void end()                                           //when game ends
        {
            gunBarrel = new int[] { 0, 0, 0, 0, 0, 0 };             //setting up for next play.
            chances = 2;                                            //cahnces are 2

        }
    }
}
