﻿using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreBusinessLayer.Interface
{
    public interface ICartBL
    {
        public CartModel AddCart(CartModel cartModel, long UserId);
        public bool RemoveCart(int CartId);
        public CartModel UpdateCart(long CartId, CartModel cartModel, long UserId);
        public IEnumerable<GetCartByUser> GetCartByUserId(CartByUser cartByUser);
        public IEnumerable<GetCartByUser> GetCartByCartId(int Id, int CartId);
    }
}
