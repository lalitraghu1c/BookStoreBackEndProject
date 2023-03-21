using System;
using System.Collections.Generic;
using System.Text;
using BookStoreBusinessLayer.Interface;
using BookStoreCommonLayer.Model;
using BookStoreRepositoryLayer.Interface;

namespace BookStoreBusinessLayer.Services
{
    public class AddressBL : IAddressBL
    {
        IAddressRL iAddressRL;
        public AddressBL(IAddressRL iAddressRL)
        {
            this.iAddressRL = iAddressRL;
        }

        public AddressModel AddAddress(AddressModel addressModel, int Id)
        {
            try
            {
                return iAddressRL.AddAddress(addressModel, Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteAddress(AddressIdModel addressIdModel)
        {
            try
            {
                return iAddressRL.DeleteAddress(addressIdModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AddressModel> GetAddress()
        {
            try
            {
                return iAddressRL.GetAddress();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AddressModel UpdateAddress(AddressModel addressModel, int AddressId, int Id)
        {
            try
            {
                return iAddressRL.UpdateAddress(addressModel, AddressId, Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}