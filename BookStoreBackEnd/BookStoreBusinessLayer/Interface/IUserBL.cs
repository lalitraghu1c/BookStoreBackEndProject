using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Modal;

namespace BookStoreBusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserRegistration UserRegister(UserRegistration userRegistration);
    }
}
