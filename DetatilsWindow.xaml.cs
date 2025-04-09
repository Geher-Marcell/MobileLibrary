using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_PROJECT
{
    /// <summary>
    /// Interaction logic for DetatilsWindow.xaml
    /// </summary>
    public partial class DetatilsWindow : Window
    {
        public Phone onePhone { get; set; }

        public DetatilsWindow()
        {
            InitializeComponent();
            onePhone = new Phone();
            DataContext = this;
        }


        public DetatilsWindow(Phone phone)
        {
            InitializeComponent();
            onePhone = phone;
            DataContext = this;
            MessageBox.Show(onePhone.MainCamera.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (InputCheck())
            {
                DialogResult = true;
                Close();
            }
        }

        private bool InputCheck()
        {
            if(String.IsNullOrWhiteSpace(onePhone.Name))
            {
                MessageBox.Show("Please, enter the name of the phone", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(String.IsNullOrWhiteSpace(onePhone.Display.Size.ToString()) || onePhone.Display.Size <= 0) {
                MessageBox.Show("Please, enter a number bigger than 0 for display size!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(String.IsNullOrWhiteSpace(onePhone.Display.Type))
            {
                MessageBox.Show("Please enter the display type!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrWhiteSpace(onePhone.Release.ToString()) || onePhone.Release <= 0)
            {
                MessageBox.Show("Please enter the release date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(String.IsNullOrWhiteSpace(onePhone.Battery.ToString()) || onePhone.Battery <= 0)
            {
                MessageBox.Show("Please enter the battery size", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrWhiteSpace(onePhone.Rom.Type))
            {
                MessageBox.Show("Please enter the ROM type", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(String.IsNullOrWhiteSpace(onePhone.Rom.Version.ToString()) || onePhone.Rom.Version <= 0)
            {
                MessageBox.Show("Please enter the version of the Rom", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(String.IsNullOrWhiteSpace(onePhone.MainCamera.ToString()) || onePhone.MainCamera <= 0)
            {
                MessageBox.Show("Please enter data about the main camera", "Error", MessageBoxButton.OK, MessageBoxImage.Error) ;
                return false;
            }
            return true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
