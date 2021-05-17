using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Udemy_DAL;

namespace Udemy_UnitTests
{
    [TestClass]
    public class UdemyTests
    {
        [TestMethod]
        public void AanmakenGebruiker_IsGeldig()
        {
            //Arrange
            Gebruiker gebruiker = new Gebruiker();
            gebruiker.achternaam = "TestAchternaam";
            gebruiker.voornaam = "TestVoornaam";
            gebruiker.geboortedatum = new DateTime(2001, 1, 1);
            gebruiker.email = "testemail@test.com";
            gebruiker.geslacht = "Man";
            gebruiker.wachtwoord = "testwachtwoord";

            //Act
            bool uitkomst = gebruiker.IsGeldig();

            //Assert
            Assert.IsTrue(uitkomst);

        }

        [TestMethod]
        public void OphalenGebruiker_Test()
        {

            //Act
            bool uitkomst;
            Gebruiker testGebruiker = DatabaseOperations.OphalenGebruiker("janjanssens@gmail.com", "voorbeeldwachtwoord");
            if (testGebruiker != null)
            {
                uitkomst = true;
            }
            else
            {
                uitkomst = false;
            }

            //Assert
            Assert.IsTrue(uitkomst);
        }
    }
}
