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
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCFitnessApp3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //This also allows the user to navigate from the main page to the MyProfilePage
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
