using System;
using System.Collections.Generic;
using System.Text;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;

namespace BookStoreBusinessLayer.Services
{
    public class CartBL : ICartBL   
    {
        ICartRL icartRL;
        public CartBL(ICartRL icartRL)
        {
            this.icartRL = icartRL;
        }
        public CartModel AddCart(CartModel cartModel, long UserId)
        {
            try
            {
                return icartRL.AddCart(cartModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}