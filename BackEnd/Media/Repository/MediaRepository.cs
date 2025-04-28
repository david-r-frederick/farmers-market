namespace Media.Repository;

using Core;
using Media.DataModel.Models;

public class MediaRepository : Repository<StoredFileModel>, IMediaRepository
{
    public MediaRepository(IDbContextFactoryWrapper dbFactory)
        : base(dbFactory)
    {
    }
}
