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
using Udemy_DAL;

namespace SaracinoNick_TTI_DM_Project
{
    /// <summary>
    /// Interaction logic for Hoofdscherm_Student.xaml
    /// </summary>
    public partial class Hoofdscherm_Student : Window
    {
        public Hoofdscherm_Student(Gebruiker g)
        {
            InitializeComponent();
            gebruiker = g;
        }

        Gebruiker gebruiker = null;
        private void btnInschrijvenCursus_Click(object sender, RoutedEventArgs e)
        {
            Window inschrijven = new Inschrijving_Cursus();
            inschrijven.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Cursus> lijstCursussen = DatabaseOperations.OphalenCursussen();
            List<string> lijst = new List<string>();
            lbIngeschrevenCursussen.ItemsSource = lijst;
            foreach (var cursus in lijstCursussen)
            {
                foreach (var item in cursus.Gebruikers)
                {
                    if (gebruiker.id == item.id)
                    {
                        lijst.Add(cursus.omschrijving);
                    }
                }
            }
            lbIngeschrevenCursussen.Items.Refresh();
        }
    }
}
