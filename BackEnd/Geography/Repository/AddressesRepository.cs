namespace Geography.Repository;

using AutoMapper;
using Core;
using Geography.DataModel.Entities;
using Geography.DataModel.Models;
using Microsoft.AspNetCore.Http;

public class AddressesRepository : Repository<Address, FullAddressModel, ListAddressModel>, IAddressesRepository
{
    public AddressesRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(dbFactory, mapper, httpContextAccessor)
    {
    }
}
