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
            DataContext = this;
            onePhone = new Phone();
        }

        public DetatilsWindow(Phone phone)
        {
            InitializeComponent();
            DataContext = this;
            onePhone = phone;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool InputCheck()
        {
            return true;
        }
    }
}
