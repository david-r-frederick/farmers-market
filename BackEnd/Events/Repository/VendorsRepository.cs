namespace Events.Repository;

using AutoMapper;
using Core;
using Customers.DataModel.Models;
using Customers.Repository;
using Events.DataModel.Entities;
using Events.DataModel.Models;
using Microsoft.AspNetCore.Http;

public class VendorsRepository : Repository<Vendor, FullVendorModel, ListVendorModel>, IVendorsRepository
{
    private readonly IUsersRepository _usersRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public VendorsRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper,
        IUsersRepository usersRepository,
        IHttpContextAccessor httpContextAccessor) : base(dbFactory, mapper)
    {
        _usersRepository = usersRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<int> RegisterVendor(VendorRegistrationFormData formData)
    {
        using var context = _dbFactory.GetContext();
        var fullUser = MapRegistrationFormToFullUser(formData);
        var userId = await _usersRepository.AddAsync(fullUser, formData.Password);
        return userId;
    }

    private FullUserModel MapRegistrationFormToFullUser(VendorRegistrationFormData formData)
    {
        var fullUser = _mapper.Map<FullUserModel>(formData);
        fullUser.IsActive = true;
        fullUser.CreatedOn = DateTime.UtcNow;
        fullUser.CreatedBy = _httpContextAccessor.HttpContext?.User?.Identity?.Name
            ?? $"{formData.FirstName} {formData.LastName}";
        fullUser.IsDeleted = false;
        return fullUser;
    }
}
