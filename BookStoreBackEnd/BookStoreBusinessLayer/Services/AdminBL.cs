using System;
using System.Collections.Generic;
using System.Text;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;

namespace BookStoreBusinessLayer.Services
{
    public class AdminBL : IAdminBL
    {
        IAdminRL iAdminRL;
        public AdminBL(IAdminRL iAdminRL)
        {
            this.iAdminRL = iAdminRL;
        }
        public string AdminLogin(AdminLogin adminLogin)
        {
            try
            {
                return iAdminRL.AdminLogin(adminLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
