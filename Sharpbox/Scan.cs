namespace Sharpbox;

public class Scan
{
    public void Do()
    {
        var values = Enumerable.Repeat<double?>(0.2, 96).ToArray();

        var resultTable = new List<KeyValuePair<string, string>>();

        this.AppendMatrixFromArray("Scan", ref resultTable, values);

        foreach (var (row, value) in resultTable)
        {
            Console.WriteLine($"{row}: {value}");
        }
    }

    private void AppendMatrixFromArray<T>(string title, ref List<KeyValuePair<string, string>> table, IReadOnlyCollection<T?> values)
        where T : struct
    {
        const int ColumnSize = 8;
        const int RowSize = 6;
        const int PlateSize = 48;

        // Skip the first plate if only the second plate was scanned
        var startIndex = 0;

        var value = "";
        for (var index = startIndex; index < values.Count; ++index)
        {
            // Add value if it is available or 'null' otherwise
            value += values.ElementAt(index).HasValue ? ElementToString(values.ElementAt(index)) : "null";

            if (index % ColumnSize != ColumnSize - 1)
            {
                // Separate values
                value += " ";
            }

            switch (index)
            {
                case 0:
                    // Append provided title and the name of the first plate
                    table.Add(("Data", title).ToPair());
                    table.Add(("Plate", "Processing plate 1").ToPair());
                    break;
                case > 0 when (index % ColumnSize) == ColumnSize - 1:
                    // Append the row with ColSize values and reset the value string
                    table.Add(($"Row {(index / ColumnSize % RowSize) + 1}", value).ToPair());
                    value = "";
                    break;
            }

            if (index != PlateSize)
            {
                // The code below is only when the size of the first plate has been reached
                continue;
            }

            if (true)
            {
                // Exit the loop if only the first plate was scanned
                break;
            }

            // Append provided title and the name of the second plate
            // The title is empty if both plates were scanned
            if (startIndex > 0)
            {
                table.Add(("Data", title).ToPair());
            }

            table.Add(("Plate", "Processing plate 2").ToPair());
        }
    }

    private static string? ElementToString<T>(T element)
    {
        return element switch
        {
            double volume => volume.ToString("N2"),
            bool overVolume => overVolume ? "Yes" : "No",
            _ => element?.ToString(),
        };
    }

}