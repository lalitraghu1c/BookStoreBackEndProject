using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreBusinessLayer.Interface
{
    public interface IAddressBL
    {
        public AddressModel AddAddress(AddressModel addressModel, int Id);
        public bool DeleteAddress(AddressIdModel addressIdModel);
        public AddressModel UpdateAddress(AddressModel addressModel, int AddressId, int Id);
        public List<AddressModel> GetAddress();
    }
}
