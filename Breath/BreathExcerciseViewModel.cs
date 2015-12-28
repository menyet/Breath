using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Breath
{
    internal class BreathExcerciseViewModel : ViewModelBase
    {
        private int _takeLength;
        private int _holdLength;
        private int _outLength;
        private bool _isRunning;

        public BreathExcerciseViewModel()
        {
            Seconds = new ReadOnlyCollection<int>(Enumerable.Range(1, 60).ToList());

            TakeLength = 5;
            HoldLength = 1;
            OutLength = 1;

            StartCommand = new RelayCommand(() => IsRunning = true);
            StopCommand = new RelayCommand(() => IsRunning = false);
        }

        public IReadOnlyCollection<int> Seconds { get; }

        public int TakeLength
        {
            get { return _takeLength; }
            set { Set(() => TakeLength, ref _takeLength, value); }
        }

        public int HoldLength
        {
            get { return _holdLength; }
            set { Set(() => HoldLength, ref _holdLength, value); }
        }

        public int OutLength
        {
            get { return _outLength; }
            set { Set(() => OutLength, ref _outLength, value); }
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            private set { Set(() => IsRunning, ref _isRunning, value); }
        }

        public ICommand StartCommand { get; }

        public ICommand StopCommand { get; }


    }
}
