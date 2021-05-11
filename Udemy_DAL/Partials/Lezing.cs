using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy_DAL
{
    public partial class Lezing : Basisklasse
    {
        public override string this[string columnNaam]
        {
            get
            {
                if (columnNaam == nameof(id) && id < 0)
                {
                    return "Categorie id moet een positief getal zijn!";
                }
                if (columnNaam == nameof(omschrijving) && string.IsNullOrWhiteSpace(omschrijving))
                {
                    return "Categorie moet ingevuld zijn!";
                }
                if (columnNaam == nameof(tijdsduurInMinuten) && tijdsduurInMinuten < 0)
                {
                    return "Tijdsduur moet een positief getal zijn!";
                }
                if (columnNaam == nameof(hoofdstukId) && hoofdstukId < 0)
                {
                    return "Hoofdstuk id moet een positief getal zijn!";
                }
                if (columnNaam == nameof(Hoofdstuk) && Hoofdstuk == null)
                {
                    return "Hoofdstuk moet ingevuld zijn!";
                }
                return "";
            }
        }
    }
}
