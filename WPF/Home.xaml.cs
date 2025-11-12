using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application.Dto;
using Application.UseCases;
using Infrastructure.Repositories;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        JsonCatRepository jsonCatRepository = new JsonCatRepository();
        JsonAdopterRepository jsonAdopterRepository = new JsonAdopterRepository();
        CatteryService catteryService;
        AdopterService adopterService;
        public Home()
        {
            InitializeComponent();
            string exePath = AppDomain.CurrentDomain.BaseDirectory;

            imgNewCat.Source = new BitmapImage(new Uri(System.IO.Path.Combine(exePath, "../../../Data/img/cat_plus.png"), UriKind.Absolute));

            Update();
        }

        private void btnNewCat_Click(object sender, RoutedEventArgs e)
        {
            AddCat addCatWindow = new AddCat(catteryService);
            addCatWindow.ShowDialog();
            Update();
        }

        private void btnManageCats_Click(object sender, RoutedEventArgs e)
        {
            ManageCats manageCats = new ManageCats(catteryService);
            manageCats.ShowDialog();
            Update();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register registerAdopter = new Register(adopterService);
            registerAdopter.ShowDialog();
            Update();
        }

        private void btnAdopt_Click(object sender, RoutedEventArgs e)
        {
            Adopt adoptWindow = new Adopt(adopterService, catteryService);
            adoptWindow.ShowDialog();
            Update();
        }

        private void btnFailed_Click(object sender, RoutedEventArgs e)
        {
            FailedAdoption failedAdoptionWindow = new FailedAdoption(catteryService);
            failedAdoptionWindow.ShowDialog();
            Update();
        }

        private void Update()
        {
            int maleCats = 0;
            int femaleCats = 0;
            int adoptedCats = 0;
            catteryService = new CatteryService(jsonCatRepository, jsonAdopterRepository);
            adopterService = new AdopterService(jsonAdopterRepository);
            var cats = catteryService.GetAllCats();
            foreach (var cat in cats)
            {
                if (cat.IsMale)
                    maleCats++;
                else
                    femaleCats++;

                if (cat.AdoptionDate != null)
                    adoptedCats++;
            }

            lblFemaleCats.Content = femaleCats.ToString();
            lblMaleCats.Content = maleCats.ToString();
            lblTotAdoption.Content = adoptedCats.ToString();
            lblTotCats.Content = cats.Count.ToString();
        }
    }
}