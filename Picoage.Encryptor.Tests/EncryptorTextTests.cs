using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Picoage.Encryptor.Tests
{
    [TestClass]
    public class EncryptorTextTests
    {
        //[TestMethod]
        //public void When_KeyIsNull_Then_ArgumentExceptionIsThrownWith_InvalidArgumentMessage()
        //{
        //    //Arrange 
        //    byte[] key = null;
        //    byte[] iv = { 15, 122, 132, 5, 93, 198, 44, 31, 9, 39, 241, 49, 250, 188, 80, 7 };
        //    string name = "Password";

        //    try
        //    {
        //        //Act
        //        string chiperText = TextEncryptor.EncryptPlainText(key, iv, name);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Assert
        //        Assert.AreEqual("Key is null",ex.Message);
        //    }
        //}

        [TestMethod]
        public void When_IvIsNull_Then_ArgumentExceptionIsThrownWith_InvalidArgumentMessage()
        {
            //Arrange 
            byte[] key = { 145, 12, 32, 245, 98, 132, 98, 214, 6, 77, 131, 44, 221, 3, 9, 50 };
            byte[] iv = null;
            string name = "Password";

            try
            {
                //Act
                string chiperText = TextEncryptor.EncryptPlainText(key, iv, name);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual(ex.Message, "Invalid Argument");
            }
        }

        [TestMethod]
        public void When_ValueIsNull_Then_ArgumentExceptionIsThrownWith_InvalidArgumentMessage()
        {
            //Arrange 
            byte[] key = { 145, 12, 32, 245, 98, 132, 98, 214, 6, 77, 131, 44, 221, 3, 9, 50 };
            byte[] iv = { 15, 122, 132, 5, 93, 198, 44, 31, 9, 39, 241, 49, 250, 188, 80, 7 };
            string name = null;

            try
            {
                //Act
                string chiperText = TextEncryptor.EncryptPlainText(key, iv, name);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.AreEqual(ex.Message, "Invalid Argument");
            }
        }

        [TestMethod]
        public void When_PlanTextIsGiven_Then_EncyptText()
        {
            //Arrange 
            byte[] key = { 145, 12, 32, 245, 98, 132, 98, 214, 6, 77, 131, 44, 221, 3, 9, 50 };
            byte[] iv = { 15, 122, 132, 5, 93, 198, 44, 31, 9, 39, 241, 49, 250, 188, 80, 7 };
            string name = "Password";

            //Act
            string chiperText = TextEncryptor.EncryptPlainText(key, iv, name);
            string plainText = TextEncryptor.DecryptChiperText(key, iv, chiperText);

            //Assert
            Assert.AreEqual(name, plainText);
        }
    }
}
