﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreCommonLayer.Model
{
    public class GetCartByUser
    {
        public long CartId { get; set; }
        public long Id { get; set; }
        public long Book_Id { get; set; }
        public int BookCount { get; set; }
    }
}
