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
    /// Interaction logic for Registratie.xaml
    /// </summary>
    public partial class Registratie : Window
    {
        public Registratie()
        {
            InitializeComponent();
        }

        private void btnRegistreren_Click(object sender, RoutedEventArgs e)
        {
                
                string foutmeldingen = "";
                Gebruiker g = new Gebruiker();
                foutmeldingen += Valideer("geboortedatum");
                if (DateTime.TryParse(txtGeboortedatum.Text, out DateTime datum) && datum < DateTime.Today)
                {
                    g.geboortedatum = datum;
                }
                else
                {
                    foutmeldingen += "Vul aub een juiste datum in!";
                }
                g.achternaam = txtAchternaam.Text;
                g.voornaam = txtVoornaam.Text;
                g.email = txtEmail.Text;
                if (rbMan.IsChecked == true)
                {
                    g.geslacht = rbMan.Content.ToString();
                }
                else if (rbVrouw.IsChecked == true)
                {
                    g.geslacht = rbVrouw.Content.ToString();
                }
                if (txtWachtwoord.Password == txtHerhaal.Password)
                {
                    g.wachtwoord = txtWachtwoord.Password;
                }
                else
                {
                    foutmeldingen += "De wachtwoorden moeten hetzelfde zijn!" + Environment.NewLine;
                }
                if (g.IsGeldig())
                {
                    List<Gebruiker> gebruikers = DatabaseOperations.OphalenGebruikers();
                    if (gebruikers.Contains(g))
                    {
                        MessageBox.Show("Deze gebruiker bestaat al!");
                    }
                    else
                    {
                    DatabaseOperations.ToevoegenGebruiker(g);
                    MessageBox.Show("Je bent succesvol geregistreerd!");
                    }

                }
                else
                {
                    MessageBox.Show(foutmeldingen + Environment.NewLine + g.Error);
                }
        }

        //dit moet nog verbeterd worden
        private string Valideer(string columnNaam)
        {
            //DateTime? datum = (DateTime)dpGeboortedatum.SelectedDate;
            if (columnNaam == "geboortedatum" && string.IsNullOrWhiteSpace(txtGeboortedatum.Text))
            {
                return "Selecteer een correcte datum!";
            }
            return "";
        }

    }
}
