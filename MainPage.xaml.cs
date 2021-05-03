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
/// <summary>
/// These frameworks are available to be used in the program
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

/// <summary>
/// This namespace holds all the backend code for the program.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
namespace SCFitnessApp3

{    /// <summary>
     /// This class is called MainPage and holds all the methods
     /// </summary>
     /// <param name="sender"></param>
     /// <param name="e"></param>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        ///  Gathers the materials and has the page startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public MainPage()
        {///Finds all the controls and displays them on the form
            InitializeComponent();
            ///This is what changes the LblCurDate date text to say the current date but leaves "Todays Date:"
            LblCurDate.Text = "Todays Date:" + DateTime.Now.ToString("d");
        }

        /// <summary>
        /// This allows the click of the "My Profile" button to navigate the user to "MyProfilePage."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMyProfile_Clicked(object sender, EventArgs e)
        {
            ///Navigates the user to MyProfilePage
            Navigation.PushModalAsync(new MyProfilePage());            
        }

        /// <summary>
        /// Allows the click of the My BMR button to direct the user to the MyBMRPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMyBMR_Clicked(object sender, EventArgs e)
        {//Navigate to the BMR page
            Navigation.PushModalAsync(new Page1());
        }

        /// <summary>
        /// Take user to Timer Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMyTimer_Clicked(object sender, EventArgs e)
        {
            //Loads a new MyTimer page
            Navigation.PushModalAsync(new MyTimerPage());
        }
        /// <summary>
        /// Open MyWaterPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMyWater_Clicked(object sender, EventArgs e)
        {
         //Loads a new MyWaterPage
            Navigation.PushModalAsync(new MyWaterPage());
        }
        /// <summary>
        /// Navigate to food page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFoodDetails_Clicked(object sender, EventArgs e)
        {//Navigate to food page
            Navigation.PushModalAsync(new FoodDetailsPage());
        }
    }
}
