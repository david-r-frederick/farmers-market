namespace Customers.Repository;

using AutoMapper;
using Core;
using Customers.DataModel.Entities;
using Customers.DataModel.Models;

public class CustomersRepository : Repository<Customer, FullCustomerModel, ListCustomerModel>, ICustomersRepository
{
    public CustomersRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper) : base(dbFactory, mapper)
    {
    }
}
