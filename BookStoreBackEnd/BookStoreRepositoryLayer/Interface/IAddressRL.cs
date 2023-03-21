using System;
using System.Collections.Generic;
using System.Text;
using BookStoreCommonLayer.Model;

namespace BookStoreRepositoryLayer.Interface
{
    public interface IAddressRL
    {
        public AddressModel AddAddress(AddressModel addressModel, int Id);
        public bool DeleteAddress(AddressIdModel addressIdModel);
        public AddressModel UpdateAddress(AddressModel addressModel, int AddressId, int Id);
        public List<AddressModel> GetAddress();
    }
}
