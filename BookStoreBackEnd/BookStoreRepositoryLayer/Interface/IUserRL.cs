using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Modal;

namespace BookStoreRepositoryLayer.Interface
{
    public interface IUserRL
    {
        public UserRegistration UserRegister(UserRegistration userRegistration);
    }
}
