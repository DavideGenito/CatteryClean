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
using Application.UseCases;

namespace WPF
{
    /// <summary>
    /// Logica di interazione per ManageCats.xaml
    /// </summary>
    public partial class ManageCats : Window
    {
        private CatteryService cattery;
        private List<Application.Dto.CatDto> allCats;

        public ManageCats(CatteryService cattery)
        {
            InitializeComponent();
            this.cattery = cattery;

            allCats = cattery.GetAllCats().ToList();
            dgCats.ItemsSource = allCats;
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = txtSearch.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(query))
            {
                dgCats.ItemsSource = allCats;
            }
            else
            {
                var filtered = allCats.Where(c =>
                    c.Name.ToLower().Contains(query)
                ).ToList();

                dgCats.ItemsSource = filtered;
            }
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by name")
            {
                txtSearch.Text = "";
            }
        }

        private void ViewDescription_Click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button btn && btn.DataContext is Application.Dto.CatDto cat)
            {
                MessageBox.Show(
                    string.IsNullOrWhiteSpace(cat.Description) ? "Descrizione vuota" : cat.Description,
                    $"Description of {cat.Name}",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
        }

        private void EditCat_Click(object sender, RoutedEventArgs e)
        {
            if(e.Source is Button btn && btn.DataContext is Application.Dto.CatDto cat)
            {
                UpdateCat editCatWindow = new UpdateCat(cattery, cat.Id.Value);
                editCatWindow.ShowDialog();
                allCats = cattery.GetAllCats().ToList();
                dgCats.ItemsSource = null;
                dgCats.ItemsSource = allCats;
            }
        }

        private void DeleteCat_Click(object sender, RoutedEventArgs e)
        {
            if(e.Source is Button btn && btn.DataContext is Application.Dto.CatDto cat)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete {cat.Name}?",
                    "Confirm Deletion",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );
                if (result == MessageBoxResult.Yes)
                {
                    cattery.RemoveCat(cat);
                    allCats.Remove(cat);
                    dgCats.ItemsSource = null;
                    dgCats.ItemsSource = allCats;
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
