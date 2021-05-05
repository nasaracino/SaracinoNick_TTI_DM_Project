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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Udemy_DAL;

namespace SaracinoNick_TTI_DM_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegistreren_Click(object sender, RoutedEventArgs e)
        {
            Window registeren = new Registratie();
            registeren.Show();
        }

        Gebruiker g = null;

        private void btnInloggen_Click(object sender, RoutedEventArgs e)
        {


            if (!string.IsNullOrWhiteSpace(txtGebruikersnaam.Text) && !string.IsNullOrWhiteSpace(txtWachtwoord.Password))
            {
                 g = DatabaseOperations.OphalenGebruiker(txtGebruikersnaam.Text, txtWachtwoord.Password);
                if (g != null)
                {
                    Window hoofdscherm = new Hoofdscherm_Student(g);
                    hoofdscherm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("De gegevens zijn onjuist. Probeer het opnieuw.");
                }
            }
            else
            {
                MessageBox.Show("Email en wachtwoord zijn verplicht in te vullen!");
            }

        }
    }
}
