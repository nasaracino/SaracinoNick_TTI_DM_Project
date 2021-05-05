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
        public Inschrijving_Cursus()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> categorien = new List<string>();
            cmbCategorien.ItemsSource = categorien;
            foreach (var item in DatabaseOperations.OphalenCategorien())
            {
                categorien.Add(item.categorie1);
            }
            cmbCategorien.Items.Refresh();
        }

        private void cmbCategorien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> cursussen = new List<string>();
            if ((string)cmbCategorien.SelectedValue == "Development")
            {
                foreach (var cursus in DatabaseOperations.OphalenCursussen())
                {
                    if (cursus.categorieId == 1)
                    {
                        cursussen.Add(cursus.omschrijving);
                    }
                }
                lbCursussen.Items.Refresh();
            }
             if ((string)cmbCategorien.SelectedValue == "Business")
            {
                foreach (var cursus in DatabaseOperations.OphalenCursussen())
                {
                    if (cursus.categorieId == 2)
                    {
                        cursussen.Add(cursus.omschrijving);

                    }
                }
                lbCursussen.Items.Refresh();
            }
             if ((string)cmbCategorien.SelectedValue == "Finance & Accounting")
            {
                foreach (var cursus in DatabaseOperations.OphalenCursussen())
                {
                    if (cursus.categorieId == 3)
                    {
                        cursussen.Add(cursus.omschrijving);
                    }
                }
                lbCursussen.Items.Refresh();
            }
            lbCursussen.ItemsSource = cursussen;
            lbCursussen.Items.Refresh();
        }
    }
}
