using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FSE_Subscription_App.Models;

namespace FSE_Subscription_App.Tests.Models
{
    [TestClass]
    public class AccountModels
    {
        [TestMethod]
        public void Signup()
        {
            // arrange
            RegisterModel account = new RegisterModel();
            
            account.Password = "gunnar1";
            account.UserName = "gunnar";
            account.ConfirmPassword = "gunnar1";

            // act


            // assert

            Assert.AreEqual(account.Password, "gunnar1");
            Assert.AreEqual(account.ConfirmPassword, "gunnar1");
            Assert.AreEqual(account.UserName, "gunnar");
        }

        [TestMethod]
        public void LogIn()
        {
            // arrange
            LoginModel account = new LoginModel();
            account.Password = "gunnar1";
            account.UserName = "gunnar";
            account.RememberMe = true;

            // act


            // assert

            Assert.AreEqual(account.Password, "gunnar1");
            Assert.AreEqual(account.RememberMe, true);
            Assert.AreEqual(account.UserName, "gunnar");
        }

        [TestMethod]
        public void UserProfile()
        {
            // arrange
            UserProfile profile = new UserProfile();

            profile.UserId = 1;
            profile.UserName = "gunnar";

            // act


            // assert

            Assert.AreEqual(profile.UserId, 1);
            Assert.AreEqual(profile.UserName, "gunnar");

        }


        [TestMethod]
        public void ExternalLogin()
        {
            // arrange
            ExternalLogin login = new ExternalLogin();

            login.Provider = "provide";
            login.ProviderDisplayName = "pro";
            login.ProviderUserId = "1";

            // act


            // assert

            Assert.AreEqual(login.Provider, "provide");
            Assert.AreEqual(login.ProviderDisplayName, "pro");
            Assert.AreEqual(login.ProviderUserId, "1");
        }

        [TestMethod]
        public void localPasswordmodel()
        {
            // arrange
            LocalPasswordModel passwordChange = new LocalPasswordModel();

            passwordChange.OldPassword = "hawkeye12";
            passwordChange.NewPassword = "billyjones11";
            passwordChange.ConfirmPassword = "billyjones11";

            // act


            // assert

            Assert.AreEqual(passwordChange.OldPassword, "hawkeye12");
            Assert.AreEqual(passwordChange.NewPassword, "billyjones11");
            Assert.AreEqual(passwordChange.ConfirmPassword, "billyjones11");
        }


        [TestMethod]
        public void registerExternalLoginModel()
        {
            // arrange
            RegisterExternalLoginModel externalLogin = new RegisterExternalLoginModel();

            externalLogin.UserName = "hawkeye";
            externalLogin.ExternalLoginData = "data";
            

            // act


            // assert

            Assert.AreEqual(externalLogin.UserName, "hawkeye");
            Assert.AreEqual(externalLogin.ExternalLoginData, "data");
           
        }



    }
}
