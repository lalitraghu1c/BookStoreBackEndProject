using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Modal;
using BookStoreCommonLayer.Model;

namespace BookStoreRepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserRegistration UserRegister(UserRegistration userRegistration);
        public string LoginUser(UserLogin userLogin);
        public string ForgetPassword(string email);
        public bool ResetPassword(string email, ResetPasswordModel resetPasswordModel);
        public UserRegistration UpdateUserDetail(UserRegistration userRegistration, long Id);

    }
}
