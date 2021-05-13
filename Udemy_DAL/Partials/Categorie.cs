using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy_DAL
{
    public partial class Categorie : Basisklasse
    {
        public override string this[string columnNaam]
        {
            get
            {
                if (columnNaam == nameof(id) && id < 0)
                {
                    return "Categorie id moet een positief getal zijn!";
                }
                if (columnNaam == nameof(categorie1) && string.IsNullOrWhiteSpace(categorie1))
                {
                    return "Categorie moet ingevuld zijn!";
                }
                return "";
            }
        }

        public override string ToString()
        {
            return categorie1;
        }
    }
}
