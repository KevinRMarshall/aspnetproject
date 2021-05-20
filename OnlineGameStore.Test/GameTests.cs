using OnlineGameStore.Models;
using System;
using Xunit;

namespace OnlineGameStore.Test
{
    public class GameTests
    {
        [Fact]
        public void GameName_ShouldReturnEmpty()
        {
            //Arange
            string gameEmpty =null;
            string gameFilled = "Super Mario 2: Electric Boogaloo";
            var doStuff = new Game();

            //Act
            string result = doStuff.GameName;

            //Assert
            Assert.Equal(gameEmpty, result);

        }

        [Fact]
        public void GameName_ShouldReturnFilled()
        {
            //Arange
            string gameEmpty = null;
            string gameFilled = "Legend of Call of War Duty";
            var doStuff = new Game();

            //Act
            doStuff.GameName = "Legend of Call of War Duty";
            string result = doStuff.GameName;            

            //Assert
            Assert.Equal(gameFilled, result);

        }

        [Fact]
        public void Downloadlink_Contains_ValidFile()
        {
            //Arange
            string xmlDownload= "gamefile.xml";            
            var doStuff = new Game();

            //Act
            doStuff.GameDownloadLink = "gamefile.xml";
            string result = doStuff.GameDownloadLink;

            //Assert
            Assert.Equal(xmlDownload, result);
        }

        [Fact]
        public void Downloadlink_Contains_InvalidFile()
        {
            //Arange
            string xmlDownload = "gamefileBROKEN.xml";
            var doStuff = new Game();

            //Act
            doStuff.GameDownloadLink = "gamefile.xml";
            string result = doStuff.GameDownloadLink;

            //Assert
            Assert.NotEqual(xmlDownload, result);
        }
    }
}
