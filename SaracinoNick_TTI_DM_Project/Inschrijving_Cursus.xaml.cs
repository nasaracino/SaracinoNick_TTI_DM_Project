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
    /// Interaction logic for Inschrijving_Cursus.xaml
    /// </summary>
    public partial class Inschrijving_Cursus : Window
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);

        public event DataChangedEventHandler DataChanged;
        public Inschrijving_Cursus(Gebruiker g)
        {
            InitializeComponent();
            gebruiker = g;
            
        }
        Gebruiker gebruiker = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //List<Cursus> cursussen = DatabaseOperations.OphalenCursussen();
            List<Categorie> categorien = DatabaseOperations.OphalenCategorien();
            cmbCategorien.ItemsSource = categorien;        
            cmbCategorien.Items.Refresh();
        }

        private void cmbCategorien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categorie categorie = cmbCategorien.SelectedItem as Categorie;
            List<Cursus> cursussen = DatabaseOperations.OphalenCursussenPerCategorie(categorie);
            lbCursussen.ItemsSource = cursussen;
            lbCursussen.Items.Refresh();
        }

        private void btnInschrijven_Click(object sender, RoutedEventArgs e)
        {
            List<Cursus> lijst = DatabaseOperations.OphalenCursussenGebruiker(gebruiker);
            string foutmeldingen = Valideer("selectieCursus");
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                Cursus cursus = lbCursussen.SelectedItem as Cursus;
                if (!lijst.Contains(cursus))
                {
                    DatabaseOperations.ToevoegenCursusAanGebruiker(cursus, gebruiker);
                    MessageBox.Show("U bent succesvol ingechreven!");
                    DataChangedEventHandler handler = DataChanged;

                    if (handler != null)
                    {
                        handler(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("U heeft al bij deze cursus ingeschreven!");
                }
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }
        }

        public string Valideer(string columnNaam)
        {
            if (columnNaam == "selectieCursus" && lbCursussen.SelectedItem == null)
            {
                return "Selecteer een cursus!";
            }
            return "";
        }
    }
}
