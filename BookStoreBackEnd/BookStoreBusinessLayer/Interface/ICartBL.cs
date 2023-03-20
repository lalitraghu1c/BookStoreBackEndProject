using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreBusinessLayer.Interface
{
    public interface ICartBL
    {
        public CartModel AddCart(CartModel cartModel, long UserId);
        public bool RemoveCart(int CartId);

    }
}
