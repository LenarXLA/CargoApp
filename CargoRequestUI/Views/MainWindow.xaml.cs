using CargoRequestUI.Models;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace CargoRequestUI.Views
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            SetItems();
        }

        private async void SetItems()
        {
            DataService dataService = new DataService();
            dgCargoReequests.DataContext = await dataService.getCargoRequests();
        }

        private void btnCreateRequest_Click(object sender, RoutedEventArgs e)
        {
            CreateCargoRequest createWindow = new CreateCargoRequest();
            createWindow.Owner = this;
            createWindow.Show();
        }

        private void EditCargoRequest(object sender, RoutedEventArgs e)
        {
            EditCargoRequest editWindow = new EditCargoRequest(sender);
            editWindow.Owner = this;
            editWindow.Show();
        }

        private void DeleteCargoRequest(object sender, RoutedEventArgs e)
        {
            CargoRequestDto? cargoRequest = ((FrameworkElement)sender).DataContext as CargoRequestDto;

            if (cargoRequest != null)
            {
                DataService dataService = new DataService();
                dataService.deleteCargoRequests(cargoRequest.Id);
            }
            MessageBox.Show("Успешное удаление");
            SetItems();
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            SetItems();
        }

        private void txtRequestSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SearchItems(txtRequestSearch.Text);
        }

        private async void SearchItems(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                DataService dataService = new DataService();
                dgCargoReequests.DataContext = await dataService.searchCargoRequests(txt);
            } 
            else
            {
                SetItems();
            }
        }
    }
}