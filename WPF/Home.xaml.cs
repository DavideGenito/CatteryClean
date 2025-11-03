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
        Cattery cattery;
        public Home()
        {
            InitializeComponent();

            int maleCats = 0;
            int femaleCats = 0;
            int adoptedCats = 0;
            cattery = new Cattery(jsonCatRepository);
            var cats = jsonCatRepository.GetAllCats();
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