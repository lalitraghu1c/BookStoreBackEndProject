using System;
using System.Collections.Generic;
using System.Text;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;

namespace BookStoreBusinessLayer.Services
{
    public class WishlistBL : IWishlistBL
    {
        IWishlistRL IWishlistRL;
        public WishlistBL(IWishlistRL IWishlistRL)
        {
            this.IWishlistRL = IWishlistRL;
        }

        public bool AddWishList(int Book_Id, int Id)
        {
            try
            {
                return IWishlistRL.AddWishList(Book_Id, Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteWishList(int WishListId, int Id)
        {
            try
            {
                return IWishlistRL.DeleteWishList(WishListId, Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<WishListModel> GetAllWishList(int Id)
        {
            try
            {
                return IWishlistRL.GetAllWishList(Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}