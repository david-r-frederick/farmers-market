namespace Customers.Repository;

using Core;
using Customers.DataModel.Models;

public class CustomersRepository : Repository<CustomerModel>, ICustomersRepository
{
    public CustomersRepository(IDbContextFactoryWrapper dbFactory)
        : base(dbFactory)
    {
    }
}
