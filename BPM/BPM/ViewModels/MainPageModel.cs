using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace BPM.ViewModels
{
    class MainPageModel : INotifyPropertyChanged
    {
        private readonly List<DateTime> tapTimes;
        private double bpm;

        public double BPM
        {
            get => bpm;
            private set
            {
                if (Equals(value, bpm))
                    return;
                
                bpm = value;
                OnPropertyChanged();
            }
        }

        public ICommand TapCommand { get; }
        public ICommand ResetCommand { get; }
        
        public MainPageModel()
        {
            tapTimes = new List<DateTime>();
            TapCommand = new Command(Tap);
            ResetCommand = new Command(Reset);
            bpm = 0;
        }

        private void Tap()
        {
            tapTimes.Add(DateTime.Now);

            if (tapTimes.Count < 2)
                return;

            var oldest = tapTimes.First();
            var newest = tapTimes.Last();
            var duration = newest - oldest;
            var average = new TimeSpan(duration.Ticks / tapTimes.Count);
            BPM = 60 / average.TotalSeconds;
        }

        private void Reset()
        {
            tapTimes.Clear();
            BPM = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}