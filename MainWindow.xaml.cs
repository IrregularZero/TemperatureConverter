using System.ComponentModel;
using System.Windows;

namespace temperatureConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const double KELVIN_TO_CELSIUS = -273.15;
        private const double KELVIN_TO_FARENHEIT = -459.67;

        private double kelvin = 0;
        private double celsius = -273.15;
        private double farenheit = -459.67;

        public event PropertyChangedEventHandler? PropertyChanged;
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }
        #region Properties

        public double Kelvin
        {
            get
            {
                return kelvin;
            }
            set
            {
                if (value >= 0)
                    kelvin = value;
                else
                    kelvin = 0;

                celsius = kelvin + KELVIN_TO_CELSIUS;
                farenheit = (kelvin + KELVIN_TO_CELSIUS) * 9/5 + 32;

                OnPropertyChanged("Kelvin");
                OnPropertyChanged("Celsius");
                OnPropertyChanged("Farenheit");
            }
        }
        public double Celsius
        {
            get
            {
                return celsius;
            }
            set
            {
                if (value >= -273.15)
                    celsius = value;
                else
                    celsius = -273.15;

                kelvin = celsius - KELVIN_TO_CELSIUS; 
                farenheit = (kelvin + KELVIN_TO_CELSIUS) * 9 / 5 + 32;

                OnPropertyChanged("Celsius");
                OnPropertyChanged("Kelvin");
                OnPropertyChanged("Farenheit");
            }
        }
        public double Farenheit
        {
            get
            {
                return farenheit;
            }
            set
            {
                if (value >= -459.67)
                    farenheit = value;
                else
                    farenheit = -459.67;

                kelvin = (farenheit - 32) * 5/9 + KELVIN_TO_CELSIUS;
                celsius = kelvin + KELVIN_TO_CELSIUS;

                OnPropertyChanged("Farenheit");
                OnPropertyChanged("Kelvin");
                OnPropertyChanged("Celsius");
            }
        }

        #endregion
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}