using Open.Infrastructure.Storage.S3.Models;

namespace Open.Infrastructure.Storage.S3;

public interface IS3StorageManager : IStorageManager
{
    /// <summary>
    /// Trả về tất cả file trong directory
    /// </summary>
    Task<List<DownloadResult>> DownloadDirectoryAsync(string directory, string version = "", CancellationToken cancellationToken = default);

    /// <summary>
    /// Trả về file paging trong directory
    /// </summary>
    Task<List<DownloadResult>> DownloadPagingAsync(string directory, int pageIndex, int pageSize, string version = "", CancellationToken cancellationToken = default);
}
