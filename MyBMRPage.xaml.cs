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
using System.Threading;
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
    //Class for the page
    public partial class Page1 : ContentPage
        //This defines a constant for the big number added in the female BMR formula
    {   const double FEMALE_ADDER = 655;
        //This defines a constant for the number multiplied with the weight in the female BMR formula
        const double FEMALE_WEIGHT_MULTIPLIER = 4.35;
        //This defines a constant for the number multiplied with the height in the female BMR formula
        const double FEMALE_HEIGHT_MULTIPLIER = 4.7;
        //This defines a constant for the number multiplied with the age in the female BMR formula
        const double FEMALE_AGE_MULTIPLIER = 4.7;

        //This defines a constant for number added in the male BMR formula
        const double MALE_ADDER = 66;
        //This defines a constant for the number multiplied with the weight in the male BMR formula
        const double MALE_WEIGHT_MULTIPLIER = 6.23;
        //This defines a constant for the number multiplied with the height in the male BMR formula
        const double MALE_HEIGHT_MULTIPLIER = 12.7;
        //This defines a constant for the number multiplied with the age in the female BMR formula
        const double MALE_AGE_MULTIPLIER = 6.8;

        //Constant for the multiplier of a Very Light Activity level. 
        const double ACT_VLIGHT = 1.2;
        //Constant for the multiplier of a Light Activity level.
        const double ACT_LIGHT = 1.375;
        //Constant for the multiplier of a Moderate Activity level.
        const double ACT_MOD = 1.55;
        //Constant for the multiplier of a Heavy Activity level.
        const double ACT_HEAVY = 1.725;
        //Constant for the multiplier of a Very Heavy Activity level.
        const double ACT_VHEAVY = 1.9;

        public Page1()
        {
            InitializeComponent();
            //Sets default for activity to Very Light Activity
            PckActivity.SelectedIndex = 0;
            //Sets default for Gender to Male
            PckGender.SelectedIndex = 0;
        }
        /// <summary>
        /// Navigates the user back to the MainPage when the Close button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCloseBMR_Clicked(object sender, EventArgs e)
        {//Brings user to MainPage when the close button is clicked
            Navigation.PushModalAsync(new MainPage());
        }
        /// <summary>
        /// The clicked event for the Calculate button which will direct the user to the MyProfilePage and wait for the user to enter in height, weight and age, and then calculate those values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnCalculate_Clicked(object sender, EventArgs e)
        {   //This creates a modal page which is a page that stays open until it is closed and extracts any values from the closed page.
            var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            //Display the ProfilePage page as a modal until it ends.
            var modalPage = new MyProfilePage();
            //Tells the computer to wait until it disappears.
            modalPage.Disappearing += (sender2, e2) =>
            {//Another part that tells the computer to wait.
                waitHandle.Set();
            };//Tells the computer to push the page as a modal. "modalPage" is referring to the Payroll page
            await Navigation.PushModalAsync(modalPage);
            //Tells the computer to run this task on a new thread until its done.
            await Task.Run(() => waitHandle.WaitOne());

            //Declares variables for femaleBMR and maleBMR
            double femaleBMR, maleBMR;
            //Assigns value of maleBMR variable equal to the equation
            maleBMR = (MALE_ADDER + (MALE_WEIGHT_MULTIPLIER * FitnessGlobalVariables.ProfWeight) + (MALE_HEIGHT_MULTIPLIER * FitnessGlobalVariables.ProfHeight) - (MALE_AGE_MULTIPLIER * FitnessGlobalVariables.ProfAge));
            //Assigns value of femaleBMR variable equal to the equation
            femaleBMR = (FEMALE_ADDER + (FEMALE_WEIGHT_MULTIPLIER * FitnessGlobalVariables.ProfWeight) + (FEMALE_HEIGHT_MULTIPLIER * FitnessGlobalVariables.ProfHeight) - (FEMALE_AGE_MULTIPLIER * FitnessGlobalVariables.ProfAge));
            
            //If the user selected male this block with the maleBMR will activate
            if (PckGender.SelectedItem.ToString() == "Male")

            {//Calculates BMR with the user-entered activity level.
                switch (PckActivity.SelectedItem.ToString())

                {//If the user selected Very Light Activity...
                    case "Very Light Activity":
                        //Have the LblResults display the maleBMR times the very light multiplier
                        LblResults.Text = (maleBMR * ACT_VLIGHT).ToString("n2");
                        //end operation
                        break;

                    //If the user selected Light Activity...
                    case "Light Activity":
                        //Have the LblResults display the maleBMR times the light multiplier
                        LblResults.Text = (maleBMR * ACT_LIGHT).ToString("n2");
                        //end operation
                        break;

                    //If the user selected Moderate Activity...
                    case "Moderate Activity":
                        //Have the LblResults display the maleBMR times the moderate multiplier
                        LblResults.Text = (maleBMR * ACT_MOD).ToString("n2");
                        //end operation
                        break;

                    //If the user selected Heavy Activity...
                    case "Heavy Activity":
                        //Have the LblResults display the maleBMR times the heavy multiplier
                        LblResults.Text = (maleBMR * ACT_HEAVY).ToString("n2");
                        //end operation
                        break;

                    //If the user selected Very Heavy Activity...
                    case "Very Heavy Activity":
                        //Have the LblResults display the maleBMR times the very heavy multiplier
                        LblResults.Text = (maleBMR * ACT_VHEAVY).ToString("n2");
                        //end operation
                        break;
                }

            }
            //If the user selected female this block with the femaleBMR will activate
            else
            {//Calculates BMR with the user-entered activity level.
                switch (PckActivity.SelectedItem.ToString())
                {//If the user selected Very Light Activity...
                    case "Very Light Activity":
                        //Have the LblResults display the femaleBMR times the very light multiplier
                        LblResults.Text = (femaleBMR * ACT_VLIGHT).ToString("n2");
                        //end operation
                        break;

                    //If the user selected Light Activity...
                    case "Light Activity":
                        //Have the LblResults display the femaleBMR times the light multiplier
                        LblResults.Text = (femaleBMR * ACT_LIGHT).ToString("n2");
                        //end operation
                        break;

                    //If the user selected Moderate Activity...
                    case "Moderate Activity":
                        //Have the LblResults display the femaleBMR times the Moderate multiplier
                        LblResults.Text = (femaleBMR * ACT_MOD).ToString("n2");
                        //ends operation
                        break;

                    //If the user selected Heavy Activity...
                    case "Heavy Activity":
                        //Have the LblResults display the femaleBMR times the Heavy Multiplier
                        LblResults.Text = (femaleBMR * ACT_HEAVY).ToString("n2");
                        //end operation
                        break;

                    //If the user selected Very Heavy activity ...
                    case "Very Heavy Activity":
                    //Have the LblResults display the femaleBMR times the Very Heavy multiplier
                        LblResults.Text = (femaleBMR * ACT_VHEAVY).ToString("n2");
                        //end operation
                        break;


                }
            }
            

        }
    }
}