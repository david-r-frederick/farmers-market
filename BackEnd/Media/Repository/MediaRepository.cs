namespace Media.Repository;

using Core;
using Media.DataModel.Entities;
using Media.DataModel.Models;

public class MediaRepository : Repository<StoredFile, FullStoredFileModel, ListStoredFileModel>, IMediaRepository
{
}
