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
        }

        private bool InputCheck()
        {
            if (!CheckField(onePhone.Name, string.IsNullOrWhiteSpace, PhoneValidationError.NameEmpty)) return false;

            if (!CheckField(onePhone.Display!.Size, val => val <= 0, PhoneValidationError.DisplaySizeInvalid)) return false;

            if (!CheckField(onePhone.Display.Type, string.IsNullOrWhiteSpace, PhoneValidationError.DisplayTypeEmpty)) return false;

            if (!CheckField(onePhone.Release, val => val <= 0, PhoneValidationError.ReleaseDateInvalid)) return false;

            if (!CheckField(onePhone.Battery, val => val <= 0, PhoneValidationError.BatterySizeInvalid)) return false;

            if (!CheckField(onePhone.Rom!.Type, string.IsNullOrWhiteSpace, PhoneValidationError.RomTypeEmpty)) return false;

            if (!CheckField(onePhone.Rom.Version, val => val <= 0, PhoneValidationError.RomVersionInvalid)) return false;

            if (!CheckField(onePhone.MainCamera, val => val <= 0, PhoneValidationError.MainCameraInvalid)) return false;

            return true;
        }

        private bool CheckField<T>(T value, Func<T, bool> condition, PhoneValidationError errorType)
        {
            if (condition(value))
            {
                string errorMessage = GetErrorMessage(errorType);
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private string GetErrorMessage(PhoneValidationError error)
        {
            return error switch
            {
                PhoneValidationError.NameEmpty => "Please, enter the name of the phone",
                PhoneValidationError.DisplaySizeInvalid => "Please, enter a number bigger than 0 for display size!",
                PhoneValidationError.DisplayTypeEmpty => "Please enter the display type!",
                PhoneValidationError.ReleaseDateInvalid => "Please enter the release date!",
                PhoneValidationError.BatterySizeInvalid => "Please enter the battery size",
                PhoneValidationError.RomTypeEmpty => "Please enter the ROM type",
                PhoneValidationError.RomVersionInvalid => "Please enter the version of the Rom",
                PhoneValidationError.MainCameraInvalid => "Please enter data about the main camera",
                _ => "Unknown error occurred",
            };
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (InputCheck())
            {
                DialogResult = true;
                Close();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }

    public enum PhoneValidationError
    {
        NameEmpty,
        DisplaySizeInvalid,
        DisplayTypeEmpty,
        ReleaseDateInvalid,
        BatterySizeInvalid,
        RomTypeEmpty,
        RomVersionInvalid,
        MainCameraInvalid


    }

}
