namespace Events.Repository;

using AutoMapper;
using Core;
using Customers.DataModel.Entities;
using Customers.DataModel.Models;
using Customers.Repository;
using Events.DataModel.Entities;
using Events.DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

public class VendorsRepository : Repository<Vendor, FullVendorModel, ListVendorModel>, IVendorsRepository
{
    private readonly IUsersRepository _usersRepository;
    private readonly UserManager<User> _userManager;

    public VendorsRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper,
        IUsersRepository usersRepository,
        IHttpContextAccessor httpContextAccessor,
        UserManager<User> userManager) : base(dbFactory, mapper, httpContextAccessor)
    {
        _usersRepository = usersRepository;
        _userManager = userManager;
    }

    public async Task<int> RegisterVendor(RegisterAsVendorForm formData)
    {
        using var context = _dbFactory.GetContext();
        var fullUser = MapRegistrationFormToFullUser(formData);
        var user = await _usersRepository.AddAsync(fullUser, formData.Password);
        await _userManager.AddToRoleAsync(user, "Vendor");
        return user.Id;
    }

    private FullUserModel MapRegistrationFormToFullUser(RegisterAsVendorForm formData)
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
