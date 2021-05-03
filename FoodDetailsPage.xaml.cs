using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.IO;
using System.Reflection;
//System.Reflection is to allow us to read files that are embedded resources. System.IO lets us read and write files
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
    public partial class FoodDetailsPage : ContentPage
    {//This allows a list FoodItems to be created from class FoodItem
        List<FoodItem> FoodItems = new List<FoodItem>();
        public FoodDetailsPage()
        {
            InitializeComponent();
            //Access solution explorer. assembly is a variable that is used to explore the solution explorer
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(FoodDetailsPage)).Assembly;
            //Access food text file inside the solution explorer
            Stream stream = assembly.GetManifestResourceStream("SCFitnessApp3.food(1).txt");
            //Array to store each food item from the text file.
            string[] foodArray;
            //List for storing the foodNames so the picker can refer to it in the future.
            List<string> foodNames = new List<string>();

            //New instance of StreamReader to read each each line of the text file
            using (StreamReader reader = new StreamReader(stream))
            {//Read each line an return a string
                reader.ReadLine();
                //While not at the end of the stream...
                while (!reader.EndOfStream)
                {//foodArray will be made up of individual lines split up.
                    foodArray = reader.ReadLine().Split('\t');
                    //Create instance of FoodItem class called "food" and pass the foodArray through the FoodItem class
                    FoodItem food = new FoodItem(foodArray);
                    //Add the FoodName to the foodNames list
                    foodNames.Add(food.FoodName);
                    //Add variable food to FoodItems list
                    FoodItems.Add(food);
                }//Sort foodNames list by alphabetical order
                foodNames.Sort();
                //Make the picker only show the foodNames as options
                PckFood.ItemsSource = foodNames;
            }
        }
        /// <summary>
        /// Display the details of the food picked by the picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDetails_Clicked(object sender, EventArgs e)
        {//Create new instance of FoodItem called selectedFood in order to later display a message to the user.
            FoodItem selectedFood = new FoodItem();
            //For each food (from FoodItem) found in the FoodItems list...
            foreach (FoodItem food in FoodItems)
            {//Check whether the variable FoodName is equal to the users selected item.
                if (food.FoodName == PckFood.SelectedItem.ToString())
                {//If it is equal set variable food equal to selectedFood
                    selectedFood = food;
                }
            }
            //Display in an alert to the user the food, category, measurement, and calories.
            DisplayAlert(selectedFood.FoodName, $"Category: {selectedFood.Category}\n\n" +
                    $"Measurement: {selectedFood.Measurement}\n\n" +
                    $"Calories: {selectedFood.Calories.ToString("n0")}", "Close");
        }
        /// <summary>
        /// Display the details of the food picked by the picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PckFood_SelectedIndexChanged(object sender, EventArgs e)
        {//Create new instance of FoodItem called selectedFood in order to later display a message to the user.
            FoodItem selectedFood = new FoodItem();
            //For each food (from FoodItem) found in the FoodItems list...
            foreach (FoodItem food in FoodItems)
            {//Check whether the variable FoodName is equal to the users selected item.
                if (food.FoodName == PckFood.SelectedItem.ToString())
                {//If it is equal set variable food equal to selectedFood
                    selectedFood = food;
                }
            }
            //Display in an alert to the user the food, category, measurement, and calories.
            DisplayAlert(selectedFood.FoodName, $"Category: {selectedFood.Category}\n\n" +
                    $"Measurement: {selectedFood.Measurement}\n\n" +
                    $"Calories: {selectedFood.Calories.ToString("n0")}", "Close");

        }
    }
}