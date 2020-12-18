using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BPM.Views;

namespace BPM
{
    public partial class App : Application
    {
        private MainPage page;
        
        public App()
        {
            InitializeComponent();
            
            page = new MainPage();
            MainPage = page;
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
