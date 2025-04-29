namespace Geography.Repository;

using AutoMapper;
using Core;
using Geography.DataModel.Entities;
using Geography.DataModel.Models;

public class AddressesRepository : Repository<Address, FullAddressModel, ListAddressModel>, IAddressesRepository
{
    public AddressesRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper) : base(dbFactory, mapper)
    {
    }
}
