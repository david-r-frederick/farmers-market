namespace Customers.Repository;

using Core;
using Customers.DataModel.Entities;

public class CustomersRepository : Repository<Customer>, ICustomersRepository
{
    public CustomersRepository(IDatabaseContext databaseContext)
        : base(databaseContext)
    {
    }
}
