using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            page.ComeAlive("yo");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
