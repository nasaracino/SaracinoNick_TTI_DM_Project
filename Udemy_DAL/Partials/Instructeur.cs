using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy_DAL
{
    public partial class Instructeur : Basisklasse
    {
        public override string this[string columnNaam]
        {
            get
            {
                if (columnNaam == nameof(id) && id < 0)
                {
                    return "Gebruiker id moet een positief getal zijn!";
                }
                if (columnNaam == nameof(achternaam) && string.IsNullOrWhiteSpace(achternaam))
                {
                    return "Achternaam moet ingevuld zijn!";
                }
                if (columnNaam == nameof(voornaam) && string.IsNullOrWhiteSpace(voornaam))
                {
                    return "Voornaam moet ingevuld zijn!";
                }
                if (columnNaam == nameof(email) && string.IsNullOrWhiteSpace(email))
                {
                    return "Email moet ingevuld zijn!";
                }
                if (columnNaam == nameof(wachtwoord) && string.IsNullOrWhiteSpace(wachtwoord))
                {
                    return "Wachtwoord moet ingevuld zinn!";
                }
                return "";
            }
        }
    }
}
