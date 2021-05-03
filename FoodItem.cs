using System;
using System.Collections.Generic;
using System.Text;
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
    public class FoodItem
    {   //Public properties in order to declare their position in the array to make programming easier
        //Public property for Category
        public string Category { get; set; }
        //Public property for FoodName
        public string FoodName { get; set; }
        //Public property for Measurement
        public string Measurement { get; set; }
        //Public property for Calories
        public int Calories { get; set; }
        /// <summary>
        /// Parameterless constructor method
        /// </summary>
        public FoodItem()
        {//Category default value
            Category = "";
            //FoodName default value
            FoodName = "";
            //Measurement default value
            Measurement = "";
            //Calories default value
            Calories = 0;
        }
        /// <summary>
        /// Place the properties in an array
        /// </summary>
        /// <param name="foodArray"></param>
        public FoodItem(string[ ] foodArray)
        {//Place Category at position 0
            Category = foodArray[0];
            //Place FoodName at position 1
            FoodName = foodArray[1];
            //Place Measurement at position 2
            Measurement = foodArray[2];
            //Convert Calories and place them in position 3
            Calories = int.Parse(foodArray[3]);

        }
    }
}
