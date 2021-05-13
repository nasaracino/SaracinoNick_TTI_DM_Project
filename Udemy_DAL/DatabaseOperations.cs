using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public static List<Gebruiker> OphalenGebruikers()
        {
            using (UdemyEntities entities = new UdemyEntities())
            {
                var query = entities.Gebruikers;
                return query.ToList();
            }
        }

        public static List<Cursus> OphalenCursussen()
        {
            using (UdemyEntities entities = new UdemyEntities())
            {
                var query = entities.Cursus.Include(x => x.Gebruikers).Include(c => c.Categorie);

                return query.ToList();
                    
            }
        }

        public static List<Cursus> OphalenCursussenPerCategorie(Categorie categorie)
        {
            using (UdemyEntities entities = new UdemyEntities())
            {
                var query = entities.Cursus.Where(x => x.categorieId == categorie.id);

                return query.ToList();
            }
        }

        public static List<Cursus> OphalenCursussenGebruiker(Gebruiker gebruiker)
        {
            using (UdemyEntities entities = new UdemyEntities())
            {
                var query = entities.Cursus.Include(ge => ge.Gebruikers).Where(x => x.Gebruikers.Any(g => g.id == gebruiker.id));
                return query.ToList();
            }
        }

        public static List<Categorie> OphalenCategorien()
        {
            using (UdemyEntities entities = new UdemyEntities())
            {
                var query = entities.Categories;
                return query.ToList();
            }
        }

        public static int ToevoegenGebruiker(Gebruiker gebruiker)
        {
            try
            {
                using (UdemyEntities entities = new UdemyEntities())
                {
                    entities.Gebruikers.Add(gebruiker);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int ToevoegenCursusAanGebruiker(Cursus cursus, Gebruiker gebruiker)
        {
            try
            {
                using (UdemyEntities entities = new UdemyEntities())
                {
                    entities.Gebruikers.Attach(gebruiker);
                    entities.Cursus.Attach(cursus);
                    gebruiker.Cursus.Add(cursus);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int AanpassenBetalingsmethode(Gebruiker gebruiker, string nieuwBM)
        {
            try
            {
                using (UdemyEntities entities = new UdemyEntities())
                {
                    var modify = entities.Gebruikers.SingleOrDefault(x => x.id == gebruiker.id);
                    modify.betalingsmethode = nieuwBM;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }
        public static int ToevoegenInstructeur(Instructeur instructeur)
        {
            try
            {
                using (UdemyEntities entities = new UdemyEntities())
                {
                    entities.Instructeurs.Add(instructeur);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int AanpassenEmail(Gebruiker gebruiker, string nieuweEmail)
        {
            try
            {
                using (UdemyEntities entities = new UdemyEntities())
                {
                    var modify = entities.Gebruikers.SingleOrDefault(x => x.id == gebruiker.id);
                    modify.email = nieuweEmail;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }

        public static int AanpassenWachtwoord(Gebruiker gebruiker, string nieuweWachtwoord)
        {
            try
            {
                using (UdemyEntities entities = new UdemyEntities())
                {
                    var modify = entities.Gebruikers.SingleOrDefault(x => x.id == gebruiker.id);
                    modify.wachtwoord = nieuweWachtwoord;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.FoutLoggen(ex);
                return 0;
            }
        }


    }
}
