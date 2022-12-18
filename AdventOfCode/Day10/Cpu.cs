using Day10.Commands;

namespace Day10;

public class Cpu
{
    public readonly List<CpuCycleState> RegisterHistory;
    
    public Cpu()
    {
        RegisterHistory = new List<CpuCycleState> { new(1) };
    }

    public void Apply(CommandBase command)
    {
        var commandCycles = Enumerable
            .Range(0, command.CpuCyclesNeeded)
            .Select(_ => new CpuCycleState(this.RegisterHistory.Last().RegisterValue));
        
        this.RegisterHistory.AddRange(commandCycles);

        if (command.RegisterIncrement != 0)
        {
            var lastCycleState = this.RegisterHistory[^1];
            lastCycleState.RegisterValue += command.RegisterIncrement;
            lastCycleState.ChangedOnlyAtEndOfCycle = true;
        }
    }

    public int GetSignalStrength(int atCycle)
    {
        return atCycle * GetRegisterAtCycle(atCycle);
    }

    public int GetRegisterAtCycle(int cycle)
    {
        return this.RegisterHistory[cycle].ChangedOnlyAtEndOfCycle
            ? this.RegisterHistory[cycle - 1].RegisterValue
            : this.RegisterHistory[cycle].RegisterValue;
    }
}

public class CpuCycleState
{
    public int RegisterValue { get; set; }
    
    public bool ChangedOnlyAtEndOfCycle { get; set; }

    public CpuCycleState(int registerValue)
    {
        this.RegisterValue = registerValue;
        this.ChangedOnlyAtEndOfCycle = false;
    }
}