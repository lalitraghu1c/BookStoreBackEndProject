using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreRepositoryLayer.Interface
{
    public interface IWishlistRL
    {
        public bool AddWishList(int Book_Id, int Id);
        public bool DeleteWishList(int WishListId, int Id);
        public IEnumerable<WishListModel> GetAllWishList(int Id);
    }
}
