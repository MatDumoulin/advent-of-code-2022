namespace Day10;

public class Crt
{
    private const int ScreenWidth = 40;
    private const int ScreenHeight = 6;
    private List<List<char>> _screen;

    public Crt()
    {
        _screen = Enumerable
            .Range(0, ScreenHeight)
            .Select(_ => Enumerable.Range(0, ScreenWidth).Select(_ => '?').ToList())
            .ToList();
    }

    public void BuildFinalScreen(Cpu cpu)
    {
        for (int cycle = 1; cycle < cpu.RegisterHistory.Count; cycle++)
        {
            var y = (cycle - 1) / ScreenWidth;
            var x = (cycle - 1) % ScreenWidth;

            var register = cpu.GetRegisterAtCycle(cycle);
            var pixel = Math.Abs(register - x) <= 1 ? '#' : '.';
            _screen[y][x] = pixel;
        }
    }

    public void Display()
    {
        foreach (var row in _screen)
        {
            Console.WriteLine(string.Join("", row));
        }
    }
}