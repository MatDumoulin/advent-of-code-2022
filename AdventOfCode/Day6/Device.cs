namespace Day6;

public class Device
{
    private readonly int _markerLength;

    public Device(int markerLength)
    {
        _markerLength = markerLength;
    }

    public int FindSubRoutine(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (!ContainsDuplicates(input.Substring(i, this._markerLength)))
            {
                return i + this._markerLength;
            }
        }

        throw new Exception("No solution found");
    }

    private bool ContainsDuplicates(string signal)
    {
        return signal.Distinct().Count() != signal.Length;
    }
}