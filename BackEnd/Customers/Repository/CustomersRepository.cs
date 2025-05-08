namespace Customers.Repository;

using AutoMapper;
using Core;
using Customers.DataModel.Entities;
using Customers.DataModel.Models;
using Microsoft.AspNetCore.Http;

public class CustomersRepository : Repository<Customer, FullCustomerModel, ListCustomerModel>, ICustomersRepository
{
    public CustomersRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(dbFactory, mapper, httpContextAccessor)
    {
    }
}
