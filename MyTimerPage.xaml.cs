//Name: (Steven Clark)
//Class: (INFO 1200)
//Section: (001)
//Professor: (Crandall)
//Date: April 30, 2021
//Project #: 9 Take 2
//I declare that the source code contained in this assignment was written solely by me.
//I understand that copying any source code, in whole or in part,
// constitutes cheating, and that I will receive a zero on this project
// if I am found in violation of this policy.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCFitnessApp3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTimerPage : ContentPage
    {
        private int lapCount;
        private int maxTime;

        public MyTimerPage()
        {
            InitializeComponent();
            lapCount = 1;
        }
        /// <summary>
        /// Start the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStart_Clicked(object sender, EventArgs e)
        {//If the user input can be parsed as an integer, store it in variable time.
            if (int.TryParse(EntryTime.Text, out int time))
            {//If the user selected something with the picker...
                if (PckDirection.SelectedIndex > -1)
                {//and if the user selected up...
                    if (PckDirection.SelectedItem.ToString() == "Up")
                    {   // Count Up
                        //Disable the start button for the user while the timer is running.
                        BtnStart.IsEnabled = false;
                        //Wait for time to be passed through the CountUp method.
                        await CountUp(time);
                        
                    }// If the user selected down, Count Down
                    else
                    {   //Disable the start button for the user while the timer is running.
                        BtnStart.IsEnabled = false;
                        //Wait for time to be passed through the CountDown method.
                        await CountDown(time);
                    }
                }//If the user didn't select whether to count down or up...
                else
                {//Display an error message
                    await DisplayAlert("Error", "Please select a counting direction.", "Close");
                }
            }//If the user didn't enter a valid integer
            else
            {//Display an error message
                await DisplayAlert("Invalid Input", "Please enter the time as an integer", "Close");
                //Reset the user time entry
                EntryTime.Text = "";
            }

        }
        /// <summary>
        /// Display time on timer
        /// </summary>
        /// <param name="time"></param>
        private void DisplayTime(int time)
        {//TimeSpan is a class that allows time to be displayed as mm:ss. The two zeros are for the minutes place
            TimeSpan currentTime = new TimeSpan(0, 0, time);
            //Display time as a string in LblTimers text 
            LblTimer.Text = currentTime.ToString(@"mm\:ss");
            //decrease variable time decrementally.
            time--;
        }


        /// <summary>
        /// Delays the timer start for 1 whole second.
        /// </summary>
        /// <returns></returns>
        private async Task StartTimer()
        {//Delays the task for 1 whole second
            await Task.Delay(1000);
        }


        /// <summary>
        /// Close the timer page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClsTimer_Clicked(object sender, EventArgs e)
        {//Take the user back to the mainpage
            Application.Current.MainPage.Navigation.PopModalAsync();
        }

        /// <summary>
        /// Allow clock to countdown using the time variable
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private async Task CountDown(int time)
        {//While time is greater than 0...
            while (time >= 0)
            {//Run time through the DisplayTime method
                DisplayTime(time);
                //set task variable equal to StartTimer method
                Task task = StartTimer();
                //await task
                await task;
                //decrease variable time decrementally
                time--;
            }
            //After timer is done, allow start button to be enabled again.
            BtnStart.IsEnabled = true;
        }

        /// <summary>
        /// Allows the timer to count up
        /// </summary>
        /// <returns></returns>
        private async Task CountUp(int time)
        {//sets maxTime equal to time.
            maxTime = time;
            //defaults time to 0
            time = 0;

            //While time is greater less than or equal to maxTime
            while (time <= maxTime)
            {//Run time through the DisplayTime method
                DisplayTime(time);
                //set task variable equal to StartTimer method
                Task task = StartTimer();
                //await variable task
                await task;
                //increase variable time incrementally
                time++;
            }
            //After timer is done, allow start button to be enabled again.
            BtnStart.IsEnabled = true;

        }

        /// <summary>
        /// Record and display time when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLapTime_Clicked(object sender, EventArgs e)
        {   //Display the lap result in addition to any other lap results during this timer session
            LblLapResult.Text = $"{LblLapResult.Text} [Lap #{lapCount} {LblTimer.Text}]";
            //Each time we press lap button, increase lap count incrementally
            lapCount++;

        }
    }
}