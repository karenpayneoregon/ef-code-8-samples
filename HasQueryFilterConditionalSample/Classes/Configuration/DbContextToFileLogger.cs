using static System.DateTime;

namespace HasQueryFilterConditionalSample.Classes.Configuration;

/// <summary>
/// Provides a mechanism for logging Entity Framework Core (EF Core) database context activities to a file.
/// </summary>
/// <remarks>
/// This class is intended for development purposes only and should not be used in production environments.
/// It supports both asynchronous and synchronous logging of messages to a specified file.
/// </remarks>
public class DbContextToFileLogger
{
    private readonly string _fileName;
    private static readonly SemaphoreSlim _gate = new(1, 1);

    public DbContextToFileLogger(string fileName)
    {
        _fileName = fileName;
    }

    public DbContextToFileLogger()
    {
        var baseDir = AppDomain.CurrentDomain.BaseDirectory; // OK for local dev
        var folder = Path.Combine(baseDir, "LogFiles", $"{Now.Year}-{Now.Month:D2}-{Now.Day:D2}");
        _fileName = Path.Combine(folder, "EF_Log.txt");
    }

    /// <summary>
    /// Asynchronously logs a message to a file, ensuring thread-safe access and proper file handling.
    /// </summary>
    /// <param name="message">The message to log. This will be written to the log file.</param>
    /// <param name="ct">
    /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete. 
    /// Defaults to <see cref="CancellationToken.None"/> if not provided.
    /// </param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    /// <remarks>
    /// This method ensures that the log file's directory exists before attempting to write. 
    /// It uses a semaphore to synchronize access, preventing concurrent writes to the file.
    /// </remarks>
    public async Task LogAsync(string message, CancellationToken ct = default)
    {
        /*
         * Make sure the directory exists.
         * System.IO.FileSystem.CreateDirectory is called, which does a check first to see if the directory exists.
         */
        Directory.CreateDirectory(Path.GetDirectoryName(_fileName)!);

        await _gate.WaitAsync(ct).ConfigureAwait(false);
        
        try
        {
            // Single open, append mode, allow others to read/write if they also opt in
            await using var fs = new FileStream(
                _fileName,
                FileMode.Append,
                FileAccess.Write,
                FileShare.ReadWrite,     // <-- important
                bufferSize: 4096,
                FileOptions.Asynchronous | FileOptions.WriteThrough);

            await using var writer = new StreamWriter(fs);
            await writer.WriteLineAsync(message.AsMemory(), ct);
            await writer.WriteLineAsync(new string('-', 40).AsMemory(), ct);
            await writer.FlushAsync(ct);
        }
        finally
        {
            _gate.Release();
        }
    }

    // Optional sync shim 
    public void Log(string message) 
        => LogAsync(message).GetAwaiter().GetResult();
}
