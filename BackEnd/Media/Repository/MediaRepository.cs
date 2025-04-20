using Core;
using Media.DataModel.Entities;

namespace Media.Repository;

public class MediaRepository : Repository<StoredFile>, IMediaRepository
{
    public MediaRepository(IDbContextFactoryWrapper dbFactory)
        : base(dbFactory)
    {
    }
}
