using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//^^^ System.IO is for writing and reading files

//Name: (Steven Clark)
//Class: (INFO 1200)
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

namespace SCFitnessApp3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyWaterPage : ContentPage
    {   //Set default value for maximum amount of recordable water glasses
        const int MAX_WATER = 8;
        //Set variable today with value of the current date
        string today = DateTime.Now.ToString("d");
        //Initialize docPath as an empty string
        string docPath = "";
        //Initialize fileName as an empty string
        string fileName = "";
        //Initialize waterFile as an empty string
        string waterFile = "";
        //Initialize watercount as 0
        int watercount = 0;
        public MyWaterPage()
        {//Start up
            InitializeComponent();
            //Run the GetFilePath method
            GetFilePath();
            //Check for the water file
            CheckWaterFile();
            //Display the amount of water for the current date.
            DisplayWater(watercount);
        }
        /// <summary>
        /// Creates file path for the file
        /// </summary>
        private void GetFilePath()
        {   
            //Sets variable today equal to todays date.
            string today = DateTime.Now.ToString("d");
            //This displays the current date at the top of the MyWaterPage. I wasn't sure where else I should put it.
            LblToday.Text = "Todays Date:" + today;
            //Replaces the slashes in the date with underscores to be ready for file storage.
            today = today.Replace('/', '_');
            //Stores the file path of the file.
            docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Determines the name of the file which would be the current date with water.txt behind it.
            fileName = $"{today}water5.txt";
            //Combines the file name with the file path so the app can find the file
            waterFile = Path.Combine(docPath, fileName);



        }/// <summary>
        /// See if the user already entered water for today
        /// </summary>
        private void CheckWaterFile()
        {
            //If there is a waterFile...
            if (File.Exists(waterFile))
            {//Convert the entry in the file to a string and set it equal to numWater
                var numWater = File.ReadAllText(waterFile).ToString();
                //Parse the string numWater for an integer and store it in watercount
                watercount = int.Parse(numWater);
            }
            //If there isn't a waterFile...
            else
            {   //Display that there is no water counted and...
                File.WriteAllText(waterFile, watercount.ToString());
                //Display an alert to the user
                DisplayAlert("No Water Found for Today", "There has been no water recorded for today", "Close");
            }
        }
        /// <summary>
        /// Display the watercount with the number of glasses
        /// </summary>
        /// <param name="watercount"></param>
        private void DisplayWater(int watercount)
        {   //Clear the previous images so that they don't add onto each other
            SLWater.Children.Clear();
            //Do this until i = watercount...
            for (int i = 0; i < watercount; i++)
            {//Image source and variable to put image into the stack layout
                Image image = new Image { Source = "Water.jpg" };
             //Add an image to the stacklayout
                SLWater.Children.Add(image);
            }//Display the water glass count
            LblWaterDisplay.Text = $"Water Count: {watercount}";
        }

        /// <summary>
        /// Add water to the water count by clicking the add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddWtr_Clicked(object sender, EventArgs e)
        {//If the watercount is less than the maximum amount...
            if (watercount < MAX_WATER)
            {//Increment variable watercount
                watercount++;
             //Write to the waterFile the watercount
                File.WriteAllText(waterFile, watercount.ToString());
             //Display the new watercount
                LblWaterDisplay.Text = watercount.ToString();
             //Pass watercount into the DisplayWater method
                DisplayWater(watercount);
            }//If watercount is >= MAX_WATER...
            else
            {//Tell the user they reached their goal
                DisplayAlert("Water Intake Complete", "You hit your goal of 8 glasses of water for today", "Close");
            }

        }
        /// <summary>
        /// Exit Water Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnWtrClose_Clicked(object sender, EventArgs e)
        {
            //Brings user to MainPage when the close button is clicked
            Navigation.PushModalAsync(new MainPage());
        }
    }
}