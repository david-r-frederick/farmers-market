namespace Customers.Repository;

using Core;
using Customers.DataModel.Entities;
using Customers.DataModel.Models;

public class CustomersRepository : Repository<Customer, FullCustomerModel, ListCustomerModel>, ICustomersRepository
{
}
