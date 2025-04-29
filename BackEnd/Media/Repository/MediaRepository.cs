namespace Media.Repository;

using AutoMapper;
using Core;
using Media.DataModel.Entities;
using Media.DataModel.Models;

public class MediaRepository : Repository<StoredFile, FullStoredFileModel, ListStoredFileModel>, IMediaRepository
{
    public MediaRepository(
        IDbContextFactoryWrapper dbFactory,
        IMapper mapper)
        : base(dbFactory, mapper)
    {
    }
}
