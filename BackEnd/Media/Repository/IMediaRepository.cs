namespace Media.Repository;

using Core;
using Media.DataModel.Models;

public interface IMediaRepository : IRepository<FullStoredFileModel, ListStoredFileModel>
{
}
