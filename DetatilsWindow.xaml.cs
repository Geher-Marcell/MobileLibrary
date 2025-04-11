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
            if (!CheckField(onePhone.Name, InputChecker.StringValueExp, PhoneValidationError.NameEmpty)) return false;

            if (!CheckField(onePhone.Display.Size, InputChecker.NumberValueExp, PhoneValidationError.DisplaySizeInvalid)) return false;

            if (!CheckField(onePhone.Display.Type, InputChecker.StringValueExp, PhoneValidationError.DisplayTypeEmpty)) return false;

            if (!CheckField(onePhone.Release, InputChecker.NumberValueExp, PhoneValidationError.ReleaseDateInvalid)) return false;

            if (!CheckField(onePhone.Battery, InputChecker.NumberValueExp, PhoneValidationError.BatterySizeInvalid)) return false;

            if (!CheckField(onePhone.Rom!.Type, InputChecker.StringValueExp, PhoneValidationError.RomTypeEmpty)) return false;

            if (!CheckField(onePhone.Rom.Version, InputChecker.NumberValueExp, PhoneValidationError.RomVersionInvalid)) return false;

            if (!CheckField(onePhone.MainCamera, InputChecker.NumberValueExp, PhoneValidationError.MainCameraInvalid)) return false;

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
                PhoneValidationError.NameEmpty => "Kérlek, add meg a telefon nevét!",
                PhoneValidationError.DisplaySizeInvalid => "Kérlek, adj meg egy 0-nál nagyobb számot a képernyő méretéhez (inch)!",
                PhoneValidationError.DisplayTypeEmpty => "Kérlek, add meg a képernyő technológiáját!",
                PhoneValidationError.ReleaseDateInvalid => "Kérlek, add meg a kiadás évét!",
                PhoneValidationError.BatterySizeInvalid => "Kérlek, add meg az akkumulátor méretét!",
                PhoneValidationError.RomTypeEmpty => "Kérlek, add meg az operációs rendszer típusát!",
                PhoneValidationError.RomVersionInvalid => "Kérlek, add meg az operációs rendszer verzióját!",
                PhoneValidationError.MainCameraInvalid => "Kérlek, add meg az adatok a fő kameráról (megapixel)!",
                _ => "Ismeretlen hiba történt.",
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
