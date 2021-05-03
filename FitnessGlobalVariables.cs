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
using System.Text;

namespace SCFitnessApp3
{/// <summary>
/// This is a class to store the variables the user will enter
/// </summary>
    public static class FitnessGlobalVariables
    {//Stores the user's entry for Weight on the MyProfilePage
            public static double ProfWeight { get; set; }
    
     //Stores the user's entry for Height on the MyProfilePage so that it is accessible throughout the project.
            public static double ProfHeight { get; set; }
    //Stores the user's entry for Age on the MyProfilePage so that it is accessible throughout the project.
            public static double ProfAge { get; set; }
    }
}
