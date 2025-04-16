namespace Geography.Repository;

using Geography.DataModel.Entities;
using Core;

public class AddressesRepository : Repository<Address>, IAddressesRepository
{
    public AddressesRepository(IDatabaseContext databaseContext)
            : base(databaseContext)
    {
    }
}
