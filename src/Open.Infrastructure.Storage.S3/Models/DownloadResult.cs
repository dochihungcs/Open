namespace Open.Infrastructure.Storage.S3.Models;

public class DownloadResult
{
    public string PresignedUrl { get; set; }

    public int ExpiryTime { get; set; }

    public string FileName { get; set; }

    public MemoryStream MemoryStream { get; set; }
}
