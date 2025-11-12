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
    /// Logica di interazione per UpdateCat.xaml
    /// </summary>
    public partial class UpdateCat : Window
    {
        CatteryService catteryService;
        CatDto? cat0;
        public UpdateCat(CatteryService catteryService, string id)
        {
            InitializeComponent();
            this.catteryService = catteryService;
            cat0 = catteryService.GetCatByID(id);
            if (cat0 == null) Close();

            txtName.Text = cat0.Name;
            txtRace.Text = cat0.Breed;
            chkIsMale.IsChecked = cat0.IsMale;
            dtpBirthDate.SelectedDate = cat0.BirthDate;
            txtDescription.Text = cat0.Description;
        }

        private void btnUpdateCat_Click(object sender, RoutedEventArgs e)
        {
            CatDto cat = new CatDto(
                txtName.Text,
                txtRace.Text,
                chkIsMale.IsChecked ?? false,
                cat0.ArrivalDate,
                cat0.AdoptionDate,
                dtpBirthDate.SelectedDate ?? null,
                txtDescription.Text.Trim(),
                cat0.Id
                );
            catteryService.UpdateCat(cat);
            Close();
        }
    }
}
