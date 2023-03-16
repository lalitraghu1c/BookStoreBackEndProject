using System;
using System.Collections.Generic;
using System.Text;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Modal;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;

namespace BookStoreBusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL iUserRL;
        public UserBL(IUserRL iUserRL)
        {
            this.iUserRL = iUserRL;
        }
        public UserRegistration UserRegister(UserRegistration userRegistration)
        {
            try
            {
                return iUserRL.UserRegister(userRegistration);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string LoginUser(UserLogin userLogin)
        {
            try
            {
                return iUserRL.LoginUser(userLogin);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string ForgetPassword(string email)
        {
            try
            {
                return iUserRL.ForgetPassword(email);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ResetPassword(string email, ResetPasswordModel resetPasswordModel)
        {
            try
            {
                return iUserRL.ResetPassword(email, resetPasswordModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
