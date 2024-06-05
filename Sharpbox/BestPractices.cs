namespace Sharpbox;

public class BestPractices
{
    public int ConditionalReturn(int? offset)
    {
        int result;

        if (offset == null)
        {
            result = -1;
        }
        else
        {
            result = offset.Value;
        }

        return result;
    }

    public int ConditionalReturnNice(int? offset) => offset ?? -1;

    private DateTime? _firstJobStartedAt;

    public void ConditionalAssignment()
    {
        if (_firstJobStartedAt == null)
        {
            _firstJobStartedAt = DateTime.UtcNow;
        }
    }

    public void ConditionalAssignmentNice() => _firstJobStartedAt ??= DateTime.Now;

    public DateTime? ConditionalNullReturn()
    {
        if (_firstJobStartedAt != null)
        {
            return _firstJobStartedAt.Value.Date;
        }
        else
        {
            return null;
        }
    }

    public DateTime? ConditionalNullReturnNice() => _firstJobStartedAt?.Date;
}