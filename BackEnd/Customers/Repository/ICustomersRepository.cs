namespace Customers.Repository;

using Core;
using Customers.DataModel.Models;

public interface ICustomersRepository : IRepository<FullCustomerModel, ListCustomerModel>
{
}
