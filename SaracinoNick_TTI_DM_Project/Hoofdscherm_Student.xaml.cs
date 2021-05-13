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
            //ingelogde gebruiker doorgeven aan Inschrijven_Cursus window
            Inschrijving_Cursus inschrijven = new Inschrijving_Cursus(gebruiker);
            //Zorgt dat als Inschrijven_Cursus gesloten wordt, wordt lbIngeschrevenCursussen geupdate
            inschrijven.DataChanged += Inschrijven_Cursus_DataChanged;
            inschrijven.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Cursus> lijstCursussen = DatabaseOperations.OphalenCursussenGebruiker(gebruiker);
            lbIngeschrevenCursussen.ItemsSource = lijstCursussen;
            lbIngeschrevenCursussen.Items.Refresh();
            lblHuidigeBM.Content = "Huidige betalingsmethode is: " + gebruiker.betalingsmethode;
            txtEmail.Text = gebruiker.email;

            //combobox betalingsmethode invullen
            string[] betalingsmethodes = { "VISA", "KBC", "Proximus", "MisterCash", "PayPal" };
            cmbBetalingsmethode.ItemsSource = betalingsmethodes;

        }

        private void Inschrijven_Cursus_DataChanged(object sender, EventArgs e)
        {
            //Zorgt dat als Inschrijven_Cursus gesloten wordt, wordt lbIngeschrevenCursussen geupdate
            List<Cursus> lijstCursussen = DatabaseOperations.OphalenCursussenGebruiker(gebruiker);
            lbIngeschrevenCursussen.ItemsSource = lijstCursussen;
            lbIngeschrevenCursussen.Items.Refresh();
        }

        private string Valideer(string columnNaam)
        {
            if (columnNaam == "betalingsmethode" && cmbBetalingsmethode.SelectedItem == null)
            {
                return "Je moet een betalingsmethode kiezen!";
            }
            return "";
        }

        private void btnInstellen_Click(object sender, RoutedEventArgs e)
        {
            string foutmeldingen = Valideer("betalingsmethode");
            string nieuweBM = cmbBetalingsmethode.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(foutmeldingen))
            {
                DatabaseOperations.AanpassenBetalingsmethode(gebruiker, nieuweBM);
                lblHuidigeBM.Content = "Huidige betalingsmethode is: " + nieuweBM;
                MessageBox.Show("Je hebt je betalingsmethode succesvol aangepast!");
            }
            else
            {
                MessageBox.Show(foutmeldingen);
            }

        }
        private void btnEmailAanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                DatabaseOperations.AanpassenEmail(gebruiker, txtEmail.Text);
                MessageBox.Show("Je hebt je email succesvol aangepast!");
            }
            else
            {
                MessageBox.Show("Vul je nieuwe email in!");
            }
        }

        private void btnWachtwoordAanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWachtwoord.Password))
            {
                DatabaseOperations.AanpassenWachtwoord(gebruiker, txtWachtwoord.Password);
                MessageBox.Show("Je hebt je wachtwoord succesvol aangepast!");
            }
            else
            {
                MessageBox.Show("Vul je nieuwe wachtwoord in!");
            }
        }
    }
}
