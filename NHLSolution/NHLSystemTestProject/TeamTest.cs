namespace NHLSystemTestProject
{
    using NhlSystemClassLibrary;
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        [DataRow("Oilers")]
        [DataRow("Flames")]
        [DataRow("Canucks")]
        [DataRow("Maple Leafs")]
        [DataRow("Senators")]
        [DataRow("Canadiens")]
        public void Name_ValidName_ReturnName(string teamName)
        {
            //Arrange (Create data to test)
            Team currentTeam = new Team(teamName, "AAAA", "AAAA");
            //Act
            //Assert
            Assert.AreEqual(teamName, currentTeam.Name);
        }

        [TestMethod]
        [DataRow(null, "Name cannot be blank.")]
        [DataRow("", "Name cannot be blank.")]
        [DataRow("    ", "Name cannot be blank.")]
        public void Name_InvalidName_ThrowsArgumentNullException(string teamName, string exceptedErrorMessage)
        {
            try
            {
                Team currentTeam = new Team(teamName, "AAAA", "AAAA");
                Assert.Fail("An ArgumentNullException should have been thrown");
            }
            catch(ArgumentNullException ex)
            {
                StringAssert.Contains(ex.Message, exceptedErrorMessage);
            }
            
        }

        [TestMethod]
        [DataRow("Edmonton")]
        [DataRow("Calgary")]
        [DataRow("Vancouver")]
        [DataRow("Toronto")]
        [DataRow("Ottowa")]
        [DataRow("Montreal")]
        public void City_ValidCity_ReturnCity(string teamCity)
        {
            //Arrange (Create data to test)
            Team currentTeam = new Team("AAAA", teamCity, "AAAA");
            //Act
            //Assert
            Assert.AreEqual(teamCity, currentTeam.City);
        }

        [TestMethod]
        [DataRow(null, "City cannot be blank.")]
        [DataRow("", "City cannot be blank.")]
        [DataRow("    ", "City cannot be blank.")]
        [DataRow("a", "City must contain 3 or more characters.")]
        [DataRow("1234", "City must only contain english letters.")]
        public void City_InvalidCity_ThrowsArgumentNullException(string teamCity, string exceptedErrorMessage)
        {
            try
            {
                Team currentTeam = new Team("AAAA", teamCity, "AAAA");
                Assert.Fail("An ArgumentException or ArgumentNullException should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                StringAssert.Contains(ex.Message, exceptedErrorMessage);
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, exceptedErrorMessage);
            }
        }

        [TestMethod]
        [DataRow("Edmonton")]
        [DataRow("Calgary")]
        [DataRow("Vancouver")]
        [DataRow("Toronto")]
        [DataRow("Ottowa")]
        [DataRow("Montreal")]
        public void Arena_ValidArena_ReturnArena(string teamArena)
        {
            //Arrange (Create data to test)
            Team currentTeam = new Team("AAAA", "AAAA", teamArena);
            //Act
            //Assert
            Assert.AreEqual(teamArena, currentTeam.Arena);
        }

        [TestMethod]
        [DataRow(null, "Arena cannot be blank.")]
        [DataRow("", "Arena cannot be blank.")]
        [DataRow("    ", "Arena cannot be blank.")]
        public void Arena_InvalidArena_ThrowsArgumentNullException(string teamArena, string exceptedErrorMessage)
        {
            try
            {
                Team currentTeam = new Team("AAAA", "AAAA", teamArena);
                Assert.Fail("An ArgumentNullException should have been thrown");
            }
            catch (ArgumentNullException ex)
            {
                StringAssert.Contains(ex.Message, exceptedErrorMessage);
            }
        }
    }
}