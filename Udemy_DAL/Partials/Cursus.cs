using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy_DAL
{
    public partial class Cursus : Basisklasse
    {
        public override string this[string columnNaam]
        {
            get
            {
                if (columnNaam == nameof(id) && id < 0)
                {
                    return "Cursus id moet een positief getal zijn!";
                }
                if (columnNaam == nameof(omschrijving) && string.IsNullOrWhiteSpace(omschrijving))
                {
                    return "Cursus titel moet ingevuld zijn!";
                }
                if (columnNaam == nameof(categorieId) && id < 0)
                {
                    return "Categorie id moet een positief getal zijn!";
                }
                if (columnNaam == nameof(prijs) && prijs < 0)
                {
                    return "Prijs moet een positief getal zijn!";
                }
                if (columnNaam == nameof(kortingPercentage) && kortingPercentage < 0)
                {
                    return "Kortingpercentage moet een positief getal zijn!";
                }
                if (columnNaam == nameof(instructeurId) && instructeurId < 0)
                {
                    return "Instructeur id moet een positief getal zijn!";
                }
                if (columnNaam == nameof(aantalResources) && aantalResources < 0)
                {
                    return "Aantal resources moet een positief getal zijn!";
                }
                if (columnNaam == nameof(Categorie) && Categorie == null)
                {
                    return "Cursus moet een valide categorie hebben!";
                }
                if (columnNaam == nameof(Instructeur) && Instructeur == null)
                {
                    return "Cursus moet een valide instructeur hebben!";
                }
                if (columnNaam == nameof(Hoofdstuks) && Hoofdstuks == null)
                {
                    return "Cursus moet hoofdstuks hebben!";
                }
                return "";
            }
        }
    }
}
