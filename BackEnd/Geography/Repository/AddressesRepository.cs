namespace Geography.Repository;

using Core;
using Geography.DataModel.Entities;
using Geography.DataModel.Models;

public class AddressesRepository : Repository<Address, FullAddressModel, ListAddressModel>, IAddressesRepository
{
}
