using System;
using System.Collections.Generic;
using System.IO;
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
using Application.UseCases;

namespace WPF
{
    /// <summary>
    /// Logica di interazione per Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        AdopterService adopterService;
        public Register(AdopterService adopterService)
        {
            InitializeComponent();
            this.adopterService = adopterService;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string adress = txtAdressStreet.Text.Trim() + " " + txtAdressCivicNumber.Text.Trim() + ", " + txtAdressCity.Text.Trim() + " " + txtAdressPostalCode.Text.Trim();
            AdopterDto adopter = new AdopterDto(
                txtName.Text.Trim(),
                txtSurname.Text.Trim(),
                txtPhone.Text.Trim(),
                txtEmail.Text.Trim(),
                adress,
                txtTIN.Text.Trim()
                );
            adopterService.RegisterAdopter(adopter);
            MessageBox.Show("Adopter registered successfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
