using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Modal;
using BookStoreCommonLayer.Model;

namespace BookStoreBusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserRegistration UserRegister(UserRegistration userRegistration);
        public string LoginUser(UserLogin userLogin);
        public string ForgetPassword(string email);
        public bool ResetPassword(string email, ResetPasswordModel resetPasswordModel);
    }
}
