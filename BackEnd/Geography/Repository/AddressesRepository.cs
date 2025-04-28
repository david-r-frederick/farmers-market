namespace Geography.Repository;

using Core;
using Geography.DataModel.Models;

public class AddressesRepository : Repository<AddressModel>, IAddressesRepository
{
    public AddressesRepository(IDbContextFactoryWrapper dbFactory)
            : base(dbFactory)
    {
    }
}
