namespace Sharpbox;

public class DisposePattern : IDisposable
{
    private bool disposed;

    /// <summary>
    /// Finalizes an instance of the <see cref="DisposePattern"/> class.
    /// </summary>
    ~DisposePattern() => this.Dispose(false);

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing"><c>True</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (this.disposed)
        {
            return;
        }

        if (disposing)
        {
            // called via myClass.Dispose().
            // OK to use any private object references
        }

        this.disposed = true;
    }
}