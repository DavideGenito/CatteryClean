using Application.Dto;
using Application.UseCases;
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

namespace WPF
{
    /// <summary>
    /// Logica di interazione per FailedAdoption.xaml
    /// </summary>
    public partial class FailedAdoption : Window
    {
        CatteryService catteryService;
        private List<Application.Dto.CatDto> allCatAdopted;
        public FailedAdoption(CatteryService catteryService)
        {
            InitializeComponent();
            this.catteryService = catteryService;

            allCatAdopted = catteryService.GetAllAdoptions().ToList();
            cbCats.ItemsSource = allCatAdopted;
            txtSearchCat.TextChanged += txtSearchCat_TextChanged;
        }

        private void txtSearchCat_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = txtSearchCat.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(query))
            {
                cbCats.ItemsSource = allCatAdopted;
            }
            else
            {
                var filtered = allCatAdopted.Where(c =>
                    c.Name.ToLower().Contains(query) ||
                    c.Id.Value.ToString().ToLower().Contains(query)
                ).ToList();
                cbCats.ItemsSource = filtered;
            }
        }

        private void RemoveTextCat(object sender, EventArgs e)
        {
            if (txtSearchCat.Text == "Search by name or ID")
            {
                txtSearchCat.Text = "";
            }
        }

        private void btnFailAdoptCat_Click(object sender, RoutedEventArgs e)
        {
            var selectedCat = (CatDto)cbCats.SelectedItem;
            if (selectedCat != null) MessageBox.Show($"Adoption for {selectedCat.Name} has been cancelled.", "Adoption Cancelled", MessageBoxButton.OK, MessageBoxImage.Information);
            catteryService.CancelAdoption(selectedCat.Id.Value);
            MessageBox.Show("The cat is now available for adoption again.", "Cat Available", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
