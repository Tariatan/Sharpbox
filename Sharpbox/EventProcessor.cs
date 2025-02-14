using System.Collections.Concurrent;
using System.ComponentModel;

namespace Sharpbox;

public class EventProcessor
{
    private readonly ConcurrentQueue<EventData> eventQueue = new();
    private Task lastTask = Task.CompletedTask;
    private readonly object lockObject = new();

    public void ReceiveEvent(EventData eventData)
    {
        eventQueue.Enqueue(eventData);

        lock (lockObject)
        {
            // Chain a new task to the last task, to ensure order is preserved.
            lastTask = lastTask.ContinueWith(_ =>
            {
                if (eventQueue.TryDequeue(out var currentEvent))
                {
                    ProcessEvent(currentEvent);
                }
            });
        }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public void HiddenMethod()
    {
        // to nothing
    }

    private static void ProcessEvent(EventData eventData)
    {
        // Simulate event processing and re-translation
        Console.WriteLine($"Processing event: {eventData.Name}");

        // Add your event re-translation logic here
    }
}

// Sample event data class
public abstract class EventData(string? name)
{
    public string? Name { get; } = name;
}