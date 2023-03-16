using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreBusinessLayer.Interface
{
    public interface IAdminBL
    {
        public string AdminLogin(AdminLogin adminLogin);
    }
}
