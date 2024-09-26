using System.Collections.Concurrent;

namespace Sharpbox;

public class ThreadSafeEventHandling
{
    private readonly object accessSyncLock = new object();
    private Task processingTask = Task.CompletedTask;
    private readonly ConcurrentQueue<EventArgs> eventQueue = new ConcurrentQueue<EventArgs>();

    private void EventReceivedFromListeners(object? sender, EventArgs eventArgs)
    {
        this.eventQueue.Enqueue(eventArgs);
        lock (this.accessSyncLock)
        {
            this.processingTask = this.processingTask.ContinueWith(_ =>
            {
                if (this.eventQueue.TryDequeue(out var currentEvent))
                {
                    ProcessEventOfInterest(currentEvent);
                }
            }, TaskScheduler.Default);
        }
    }

    private static void ProcessEventOfInterest(EventArgs eventArgs)
    {
        // Do the job
        Console.WriteLine(eventArgs.ToString());
    }
}