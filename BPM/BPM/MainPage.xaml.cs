using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace BPM
{
    public partial class MainPage : ContentPage
    {
        private readonly List<DateTime> tapTimes;
        private readonly FontSizeConverter converter;
        
        public MainPage()
        {
            InitializeComponent();
            tapTimes = new List<DateTime>();
            converter = new FontSizeConverter();
        }

        public void BPM_Button_Click(object sender, EventArgs e)
        {
            tapTimes.Add(DateTime.Now);
            
            if (tapTimes.Count < 2)
                return;
            
            BpmLabel.FontSize = converter.ConvertFromInvariantString("Header") is double ? (double)converter.ConvertFromInvariantString("Header") : 0;
            
            var oldest = tapTimes.First();
            var newest = tapTimes.Last();
            var duration = newest - oldest;
            var average = new TimeSpan(duration.Ticks / tapTimes.Count);
            double bpm = 60 / average.TotalSeconds;
            BpmLabel.Text = Math.Round(bpm).ToString();
        }

        public void BPM_Reset_Click(object sender, EventArgs e)
        {
            tapTimes.Clear();
            BpmLabel.FontSize = 30;
            BpmLabel.Text = "Current beats per minute";
        }

        public void ComeAlive(string message)
        {
            BpmLabel.Text = message;
        }
    }
}
