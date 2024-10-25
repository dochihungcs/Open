using Open.Infrastructure.Storage.S3.Models;

namespace Open.Infrastructure.Storage.S3;

public interface IStorageManager
{
    /// <summary>
    /// Upload file
    /// </summary>
    Task<UploadResult> UploadAsync(UploadRequest model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Upload multi files
    /// </summary>
    Task<List<UploadResult>> UploadAsync(List<UploadRequest> models, CancellationToken cancellationToken = default);

    /// <summary>
    /// Download file
    /// </summary>
    Task<DownloadResult> DownloadAsync(string fileName, string version = "", CancellationToken cancellationToken = default);

    /// <summary>
    /// Download file
    /// </summary>
    Task<List<DownloadResult>> DownloadAsync(List<string> fileNames, string version = "", CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove file
    /// </summary>
    Task DeleteAsync(string fileName, string version = "", CancellationToken cancellationToken = default);
}
