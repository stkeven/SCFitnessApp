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
/// These frameworks are files that are available to be used in the program if necessary.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// <summary>
/// This namespace holds all the backend code for the program.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
namespace SCFitnessApp3
{///Determines the compilation options of the xaml files.
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// This class is called MyProfilePage and holds all the methods
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>


    public partial class MyProfilePage : ContentPage
    {
        /// <summary>
        ///  Defining all the constants
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        //constant for minimum weight is 50
        const double MIN_WEIGHT = 50;
        //constant for maximum weight is 1000
        const double MAX_WEIGHT = 1000;

        //constant for minimum height is 48
        const double MIN_HEIGHT = 48;
        //constant for maximum height is 96
        const double MAX_HEIGHT = 96;

        //constant for minimum age is 12
        const double MIN_AGE = 12;
        //constant for maximuma age is 120
        const double MAX_AGE = 120;

        public MyProfilePage()
        {///Finds all the controls and displays them on the form
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the close button on the MyProfilePage which returns the user
        /// to the BMRPage and stores the user's entries for Height, Weight, and Age.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClsMyPro_Clicked(object sender, EventArgs e)
        {//declare variable for weight
            double weight;
            //declare variable for height
            double height;
            //declare variable for age
            double age;

            //If the computer can parse a double value and store it in weight variable, and if that value is between the wieght min and weight max...
            if (double.TryParse(EntWeight.Text, out weight) && weight <= MAX_WEIGHT && weight >= MIN_WEIGHT)
            {//And if the computer can parse a value from the user entry and store it in variable height, AND if that value is between the max and min for height...
                if (double.TryParse(EntHeight.Text, out height) && height <= MAX_HEIGHT && height >= MIN_HEIGHT)
                {//and finally, if the computer can parse a value from the user entry and store it in variable age AND if that value is between the max and min for age...
                    if (double.TryParse(EntAge.Text, out age) && age <= MAX_AGE && age >= MIN_AGE)
                    {//Then set global variable for weight equal to local variable weight
                        FitnessGlobalVariables.ProfWeight = weight;
                        //set glbl variable for height equal to local variable height
                        FitnessGlobalVariables.ProfHeight = height;
                        //set glbl variable for age equal to local variable age
                        FitnessGlobalVariables.ProfAge = age;
                        //Also close the page
                        Application.Current.MainPage.Navigation.PopModalAsync();

                    }//If the user entry for age is invalid
                    else
                    {//displays error message for age
                        DisplayAlert("Input Error", $"Please enter age between {MIN_AGE} and {MAX_AGE}", "Close");
                        //reset user invalid user entry
                        EntAge.Text = "";
                    }
                }//if the user entry for height is invalid
                else
                {//display error message for height
                    DisplayAlert("Input Error", $"Please enter weight between {MIN_HEIGHT} and {MAX_HEIGHT}", "Close");
                    //reset user invalid user entry
                    EntHeight.Text = "";
                }
            }//if the user entry for weight is invalid
            else
            {//display user entry for weight
                DisplayAlert("Input Error", $"Please enter weight between {MIN_WEIGHT} and {MAX_WEIGHT}", "Close");
                //reset user invalid user entry
                EntWeight.Text = "";
            }           
        }

        /// <summary>
        /// Displays the Before image if the before button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBefore_Clicked(object sender, EventArgs e)
        {   ///Changes the source of the image control to before.jpg if the before button is clicked
            ImgProfile.Source = "before.jpg";
        }

        /// <summary>
        /// Displays the after image if the after button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAfter_Clicked(object sender, EventArgs e)
        {   ///Changes the source of the image control to after.jpg if the after button is clicked
            ImgProfile.Source = "after.jpg";
            ///Will display an alert that says "Good Job" at the top, "You're doing great" as the rest of the text and will have a close button.
            DisplayAlert("Good Job!", "You're doing great!", "Close");
        }

        /// <summary>
        /// This method is for the "CLEAR" button on the "MyProfilePage" which will clear the global variables and wipe the user's entries.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearAll_Clicked(object sender, EventArgs e)
        {   //This clears the user entry for First Name
            EntFirst.Text = "";
            //This clears the user entry for Last Name
            EntLast.Text = "";
            //This clears the user entry for Preferred Name
            EntPref.Text = "";
            //This clears the user entry for Weight
            EntWeight.Text = "";
            //This clears the user entry for Height
            EntHeight.Text = "";
            //This clears the user entry for Age
            EntAge.Text = "";

            //This clears the Weight value if the user clicks the clear button.
            FitnessGlobalVariables.ProfWeight = 0;
            //This clears the Height value if the user clicks the clear button
            FitnessGlobalVariables.ProfHeight = 0;
            //This clears the Age value if the user clicks the clear button
            FitnessGlobalVariables.ProfAge = 0;


        }
    }
}