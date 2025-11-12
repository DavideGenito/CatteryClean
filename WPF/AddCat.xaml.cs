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
using Domain.Model.ValueObjects;
using Application.Mappers;
using Application.Dto;

namespace WPF
{
    /// <summary>
    /// Logica di interazione per AddCat.xaml
    /// </summary>
    public partial class AddCat : Window
    {
        CatteryService cattery;
        public AddCat(CatteryService cattery)
        {
            InitializeComponent();
            this.cattery = cattery;
        }

        private void btnAddCat_Click(object sender, RoutedEventArgs e)
        {
            CatDto cat = new CatDto(
                txtName.Text,
                txtRace.Text,
                chkIsMale.IsChecked ?? false,
                DateTime.Now,
                null,
                dtpBirthDate.SelectedDate ?? null,
                txtDescription.Text.Trim(),
                null
                );
            cattery.AddCat(cat);
            Close();
        }
    }
}
