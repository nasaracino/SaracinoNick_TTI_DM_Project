using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy_DAL
{
    public partial class Hoofdstuk : Basisklasse
    {
        public override string this[string columnNaam]
        {
            get
            {
                if (columnNaam == nameof(id) && id < 0)
                {
                    return "Hoofdstuk id moet een positief getal zijn!";
                }
                if (columnNaam == nameof(omschrijving) && string.IsNullOrWhiteSpace(omschrijving))
                {
                    return "Hoofdstuk titel moet ingevuld zijn!";
                }
                if (columnNaam == nameof(tijdsduurInMinuten) && tijdsduurInMinuten < 0)
                {
                    return "Tijdsduur moet een positief getal zijn!";
                }
                if (columnNaam == nameof(Lezings) && Lezings == null)
                {
                    return "Lezings moet ingevuld zijn!";
                }
                if (columnNaam == nameof(Cursus) && Cursus == null)
                {
                    return "Cursus moet ingevuld zijn!";
                }
                return "";
            }
        }
    }
}
