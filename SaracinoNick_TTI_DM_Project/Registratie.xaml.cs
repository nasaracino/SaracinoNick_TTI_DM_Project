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
            if (rbInstructeur.IsChecked == true)
            {
                Instructeur i = new Instructeur();
                i.achternaam = txtAchternaam.Text;
                i.voornaam = txtVoornaam.Text;
                i.email = txtEmail.Text;
                if (txtWachtwoord.Password == txtHerhaal.Password)
                {
                    i.wachtwoord = txtWachtwoord.Password;
                }
                else
                {
                    foutmeldingen += "De wachtwoorden moeten hetzelfde zijn!" + Environment.NewLine;
                }
                if (i.IsGeldig())
                {
                    DatabaseOperations.ToevoegenInstructeur(i);
                }
                else
                {
                    MessageBox.Show(foutmeldingen + Environment.NewLine + i.Error);
                }
            }
            else if (rbStudent.IsChecked == true)
            {
                Gebruiker g = new Gebruiker();
                foutmeldingen += Valideer("geboortedatum");
                g.geboortedatum = dpGeboortedatum.SelectedDate.Value.Date;
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
                    DatabaseOperations.ToevoegenGebruiker(g);
                }
                else
                {
                    MessageBox.Show(foutmeldingen + Environment.NewLine + g.Error);
                }

            }
            else
            {
                foutmeldingen += "Je moet een type gebruiker kiezen!";
                MessageBox.Show(foutmeldingen);
            }

        }

        //dit moet nog verbeterd worden
        private string Valideer(string columnNaam)
        {
            DateTime? datum = dpGeboortedatum.SelectedDate;
            if (columnNaam == "geboortedatum" && !datum.HasValue)
            {
                if (datum.Value > DateTime.Now || datum.Value == null)
                {
                    return "Selecteer een correcte datum!";
                }
            }
            return "";
        }

    }
}
