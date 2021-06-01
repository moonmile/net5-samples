using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfControlSampleTest
{
    class MainViewModel : Prism.Mvvm.BindableBase
    {
        private int _count = 0;
        public int Count
        {
            get => _count;
            set
            {
                SetProperty(ref _count, value, nameof(Count));
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(CountText)));
            }
        }
        public string CountText
        {
            get => $"count: {_count}";
            set { }
        }
        public DelegateCommand Clicked { get; private set; }
        public MainViewModel()
        {
            Clicked = new DelegateCommand(
                () => { this.Count++; },
                () => true);
        }
    }
}
