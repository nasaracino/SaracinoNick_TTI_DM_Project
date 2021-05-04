using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy_DAL
{
    public static class DatabaseOperations
    {
        public static Gebruiker OphalenGebruiker(string email, string wachtwoord)
        {
            using (UdemyEntities entities = new UdemyEntities())
            {
                var query = entities.Gebruikers
                    .Where(x => x.email == email && x.wachtwoord == wachtwoord);
                return query.SingleOrDefault();
            }
        }

    }
}
