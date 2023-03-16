using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreRepositoryLayer.Interface
{
    public interface IAdminRL
    {
        public string AdminLogin(AdminLogin adminLogin);
    }
}
