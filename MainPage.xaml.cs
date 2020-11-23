using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lottery
{
    public partial class MainPage : ContentPage
    {
        //create new array variable that contains 5 different integers
        int[] lottoArray = new int[5];
        // create a new instance of the Random function
        Random rand = new Random();

        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// we'll create 5 random numbers, display them, and then check to see if theyre the same as the entries.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPlay_Clicked(object sender, EventArgs e)
        {
            //use PopulateRandomNumbers() to give us 5 random numbers
            PopulateRandomNumbers();
            //use displaylottonumbers() to change the display text to the results of the last method
            DisplayLottoNumbers();
            //Check to see if the user lost and alert them.
            CheckForLoser();
        }
        /// <summary>
        /// we'll check to see if the user guessed the numbers correctly and then display the corresponding alert.
        /// </summary>
        private void CheckForLoser()
        {
            //if the random number is not equal to the text of the corresponding guess on any of the 5 numbers, then we alert the loser. Else we alert the winner.
            if (lotto1.Text != EntryGuess1.Text ||
                lotto2.Text != EntryGuess2.Text ||
                lotto3.Text != EntryGuess3.Text ||
                lotto4.Text != EntryGuess4.Text ||
                lotto5.Text != EntryGuess5.Text)
            {
                //if true, alert the loser to pay again
                DisplayAlert("Loser!", "Please pay $1 to play again.", "Close");
            }
            else
            {
                //if false, alert the winner of their winnings and pay to play again. 
                DisplayAlert("Winner!", "You just won $1 Billion. Please pay $1 to play again.", "Close");

            }
        }

        /// <summary>
        /// we will assign each of the lotto[num] texts to results from the PopulateRandomNumbers method/lottoArray values
        /// </summary>
        private void DisplayLottoNumbers()
        {
            //each value is an integer in the array so we convert it to a string before setting it to the corresponding lotto text.
            lotto1.Text = lottoArray[0].ToString();
            lotto2.Text = lottoArray[1].ToString();
            lotto3.Text = lottoArray[2].ToString();
            lotto4.Text = lottoArray[3].ToString();
            lotto5.Text = lottoArray[4].ToString();
        }

        /// <summary>
        /// create 5 random numbers by looping through the array and using the rand variable created above to create a random number. 
        /// </summary>
        private void PopulateRandomNumbers()
        {
            //create integer variable index that is initially set to 0 so we start at the beginning of the array.
            int index = 0;
            //while the index is less than 5 (0-4), run the function.           
            while (index < 5)
            {
                // we will assign the corresponding value at the current index to the random variable generated between 0 and 99
                lottoArray[index] = rand.Next(100);
                //increment the value of index so the loop can eventually end with a false value (5)
                index++;
            }
        }
    }
}
