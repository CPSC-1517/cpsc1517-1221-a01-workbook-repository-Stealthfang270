

using NhlSystemClassLibrary;

namespace NHLSystemTestProject
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        [DataRow(98, "Beandude", Position.Center)]
        [DataRow(1, "AAAA", Position.Defense)]
        [DataRow(50, "Fish", Position.Goalie)]
        public void Constructor_ValidData_ShouldPass(int playerNum, string playerName, Position playerPosition)
        {
            //Arrange and Act
            Player testPlayer = new Player(playerNum, playerName, playerPosition);
            //Assert
            Assert.AreEqual(playerNum, testPlayer.PlayerNum);
            Assert.AreEqual(playerName, testPlayer.Name);
            Assert.AreEqual(playerPosition, testPlayer.Position);
        }

        [TestMethod]
        [DataRow(99, "Beandude", Position.Center)]
        [DataRow(0, "AAAA", Position.Defense)]
        [DataRow(-50, "Fish", Position.Goalie)]
        [DataRow(-150, "Fish", Position.Goalie)]
        public void PlayerNum_InvalidValue_ThrowsArgumentException(int playerNum, string playerName, Position playerPosition)
        {
            //Arrange and Act
            try
            {
                Player testPlayer = new Player(playerNum, playerName, playerPosition);
                Assert.Fail("An argument exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "Number must be between 1 and 98");
            }
            catch (Exception ex)
            {
                Assert.Fail("Incorrect Exception Thrown");
            }
            
        }

        [TestMethod]
        [DataRow(50, "", Position.Center)]
        [DataRow(50, " ", Position.Defense)]
        [DataRow(50, null, Position.Goalie)]
        [DataRow(50, "           ", Position.Goalie)]
        public void PlayerName_InvalidValue_ThrowsArgumentException(int playerNum, string playerName, Position playerPosition)
        {
            //Arrange and Act
            try
            {
                Player testPlayer = new Player(playerNum, playerName, playerPosition);
                Assert.Fail("An argument exception should have been thrown");
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, "Name cannot be blank.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Incorrect Exception Thrown");
            }

        }
    }
}