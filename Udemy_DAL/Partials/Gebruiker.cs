using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy_DAL
{
    public partial class Gebruiker : Basisklasse
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
                if (columnNaam == nameof(geboortedatum) && geboortedatum == null)
                {
                    return "Geboortedatum moet ingevuld zijn!";
                }
                if (columnNaam == nameof(geslacht) && string.IsNullOrWhiteSpace(geslacht))
                {
                    return "Geslacht moet gekozen worden!";
                }
                return "";
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Gebruiker gebruiker &&
                   email == gebruiker.email;
        }

        public override int GetHashCode()
        {
            int hashCode = -93531737;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(email);
            return hashCode;
        }
    }
}
