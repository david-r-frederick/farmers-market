namespace Events.Repository;

using Core;
using Events.DataModel.Models;

public interface IVendorsRepository : IRepository<FullVendorModel, ListVendorModel>
{
    Task<int> RegisterVendor(RegisterAsVendorForm formData);
}
