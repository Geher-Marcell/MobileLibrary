using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_PROJECT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Phone> Phones = new ObservableCollection<Phone>();

        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Phone> _filteredPhones = new ObservableCollection<Phone>();

        private Phone _selectedItem;

        public bool HaveSelectedItem => SelectedItem != null;

        public Phone SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value;  OnPropertyChanged(nameof(SelectedItem)); OnPropertyChanged(nameof(HaveSelectedItem)); }
        }


        public string SearchString { get; set; } = string.Empty;

        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        };

        public ObservableCollection<Phone> FilteredPhones
        {
            get { return _filteredPhones; }
            set { _filteredPhones = value; OnPropertyChanged(nameof(FilteredPhones)); }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            FileRead();
            DataContext = this;
        }

        private void FileRead()
        {
            string jsonStr = File.ReadAllText("mobiles.json");
            Phones = JsonSerializer.Deserialize<ObservableCollection<Phone>>(jsonStr, options);
            _filteredPhones = new ObservableCollection<Phone>(Phones!);
        }

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            DetatilsWindow detatilsWindow = new DetatilsWindow();
            if(detatilsWindow.ShowDialog() == true)
            {
                Phones.Add(detatilsWindow.onePhone);
                Btn_Search_Click(sender, e);    
            }

        }

        private void Btn_Modify_Click(object sender, RoutedEventArgs e)
        {
            if (HaveSelectedItem)
            {
                Phone currPhone = SelectedItem.Clone();
                DetatilsWindow detatilsWindow = new DetatilsWindow(currPhone);
                if(detatilsWindow.ShowDialog() == true)
                {
                    int i = Phones.IndexOf(currPhone);
                    Phones[i] = detatilsWindow.onePhone;
                    Btn_Search_Click(sender, e);
                }
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (HaveSelectedItem)
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {SelectedItem.Name}?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Phones.Remove(SelectedItem);
                    FilteredPhones.Remove(SelectedItem);
                    SelectedItem = null;
                }
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            FilteredPhones = new ObservableCollection<Phone>(Phones.Where(x => x.Name.StartsWith(SearchString, StringComparison.OrdinalIgnoreCase)).ToList());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            string jsonStr = JsonSerializer.Serialize(Phones, options);
            File.WriteAllText("mobiles.json", jsonStr, Encoding.UTF8);
        }
    }
}