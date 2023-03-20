using System;
using System.Collections.Generic;
using System.Text;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;
using BookStoreRepositoryLayer.Services;

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
        public bool RemoveCart(int CartId)
        {
            try
            {
                return icartRL.RemoveCart(CartId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CartModel UpdateCart(long CartId, CartModel cartModel, long UserId)
        {
            try
            {
                return icartRL.UpdateCart(CartId, cartModel, UserId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<GetCartByUser> GetCartByCartId(int UserId, int CartId)
        {
            try
            {
                return icartRL.GetCartByCartId(UserId, CartId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetCartByUser> GetCartByUserId(CartByUser cartByUser)
        {
            try
            {
                return icartRL.GetCartByUserId(cartByUser);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}