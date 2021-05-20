using OnlineGameStore.Models;
using System;
using Xunit;

namespace OnlineGameStore.Test
{
    public class ProfileTests
    {
        [Fact]
        public void ProfileName_IsFilledOut_ReturnValid()
        {
            //Arange
            string profileName = "Hank";
            string blankProfile = null;
            var doStuff = new Profile();

            //Act
            doStuff.ProfileName = "Hank";
            string result = doStuff.ProfileName;

            //Assert
            Assert.Equal(profileName, result);

        }

        [Fact]
        public void ProfileName_NotFilledOut_ReturnInvalid()
        {
            //Arange
            string profileName = "Hank";
            string blankProfile = null;
            var doStuff = new Profile();

            //Act
            doStuff.ProfileName = "Hank";
            string result = doStuff.ProfileName;

            //Assert
            Assert.Null(blankProfile);

        }

        [Fact]
        public void Gender_AcceptedType_ReturnValid()
        {
            //Arange
            string gender = "Female";            
            var doStuff = new Profile();

            //Act
            doStuff.Gender = "Female";
            string result = doStuff.Gender;

            //Assert
            Assert.Equal(gender, result);

        }


        [Fact]
        public void Gender_IncorrectType_ReturnInvalid()
        {
            //Arange
            string gender = "Robot";
            var doStuff = new Profile();

            //Act
            doStuff.Gender = "Female";
            string result = doStuff.Gender;

            //Assert
            Assert.NotEqual(gender, result);

        }
    }
}
