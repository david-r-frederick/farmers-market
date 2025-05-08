namespace Media.Repository;

using AutoMapper;
using Core;
using Media.DataModel.Entities;
using Media.DataModel.Models;
using Microsoft.AspNetCore.Http;

public class MediaRepository : Repository<StoredFile, FullStoredFileModel, ListStoredFileModel>, IMediaRepository
{
    public MediaRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
        : base(dbFactory, mapper, httpContextAccessor)
    {
    }
}
