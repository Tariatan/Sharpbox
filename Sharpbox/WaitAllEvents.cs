namespace Sharpbox;

public class MessageRetranslation
{
    private readonly TaskCompletionSource<bool> allEventsReceived = new();
    private int expectedEventsCount;
    private int receivedEventsCount;

    public MessageRetranslation()
    {
        receivedEventsCount = 0;
    }

    public void Setup()
    {
    }

    public async Task TestMessageRetranslation()
    {
        // Arrange
        expectedEventsCount = 5;

        // Await the completion of all events
        await this.allEventsReceived.Task.WaitAsync(TimeSpan.FromSeconds(10));

    }

    private void OnEventReceived()
    {
        receivedEventsCount++;

        if (receivedEventsCount >= expectedEventsCount)
        {
            allEventsReceived.SetResult(true);
        }
    }
}