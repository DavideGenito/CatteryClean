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
using Application.Dto;
using Application.Mappers;
using Application.UseCases;

namespace WPF
{
    /// <summary>
    /// Logica di interazione per Adopt.xaml
    /// </summary>
    public partial class Adopt : Window
    {
        AdopterService adopterService;
        CatteryService catteryService;
        private List<Application.Dto.CatDto> allCats;
        private List<Application.Dto.AdopterDto> allAdopters;
        public Adopt(AdopterService adopterService, CatteryService catteryService)
        {
            InitializeComponent();
            this.adopterService = adopterService;
            this.catteryService = catteryService;

            allCats = catteryService.GetAllCats().ToList();
            allAdopters = adopterService.GetAllAdopters().ToList();
            cbCats.ItemsSource = allCats;
            cbAdopters.ItemsSource = allAdopters;
            txtSearchCat.TextChanged += txtSearchCat_TextChanged;
            txtSearchAdopter.TextChanged += txtSearchAdopter_TextChanged;
        }

        private void txtSearchCat_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = txtSearchCat.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(query))
            {
                cbCats.ItemsSource = allCats;
            }
            else
            {
                var filtered = allCats.Where(c =>
                    c.Name.ToLower().Contains(query) ||
                    c.Id.Value.ToString().ToLower().Contains(query)
                ).ToList();
                cbCats.ItemsSource = filtered;
            }
        }

        private void txtSearchAdopter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = txtSearchAdopter.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(query))
            {
                cbAdopters.ItemsSource = allAdopters;
            }
            else
            {
                var filtered = adopterService.GetAllAdopters().Where(a =>
                    a.Name.ToLower().Contains(query) ||
                    a.Surname.ToLower().Contains(query) ||
                    a.TIN.ToString().ToLower().Contains(query)
                ).ToList();
                cbAdopters.ItemsSource = filtered;
            }
        }

        private void RemoveTextCat(object sender, EventArgs e)
        {
            if (txtSearchCat.Text == "Search by name or ID")
            {
                txtSearchCat.Text = "";
            }
        }

        private void RemoveTextAdopter(object sender, EventArgs e)
        {
            if (txtSearchAdopter.Text == "Search by name, surname or TIN")
            {
                txtSearchAdopter.Text = "";
            }
        }

        private void btnRegisterAdopter_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register(adopterService);
            register.ShowDialog();
            allAdopters = adopterService.GetAllAdopters().ToList();
            cbAdopters.ItemsSource = allAdopters;
        }

        private void btnAdoptCat_Click(object sender, RoutedEventArgs e)
        {
            if (cbCats.SelectedItem == null || cbAdopters.SelectedItem == null)
            {
                MessageBox.Show("Please select both a cat and an adopter.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            AdoptionDto adoption = new AdoptionDto(
                (CatDto)cbCats.SelectedItem,
                (AdopterDto)cbAdopters.SelectedItem,
                DateTime.Now
                );
            catteryService.RegisterAdoption(adoption);
            MessageBox.Show("Adoption registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
