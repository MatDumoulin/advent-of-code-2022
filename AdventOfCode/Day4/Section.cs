namespace Day4;

public class Section
{
    public int Start { get; }

    public int End { get; }

    public Section(string elf)
    {
        var values = elf.Split('-');
        this.Start = Int32.Parse(values[0]);
        this.End = Int32.Parse(values[1]);
    }

    public bool Contains(Section other)
    {
        return this.Start <= other.Start && this.End >= other.End;
    }
    
    public bool Overlaps(Section other)
    {
        return !(this.End < other.Start || other.End < this.Start);
    }
}