namespace Geography.Repository;

using Geography.DataModel.Entities;
using Core;

public class AddressesRepository : Repository<Address>, IAddressesRepository
{
    public AddressesRepository(IDbContextFactoryWrapper dbFactory)
            : base(dbFactory)
    {
    }
}
