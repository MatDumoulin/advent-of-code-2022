namespace Day10.Commands;

public abstract record CommandBase(int CpuCyclesNeeded, int RegisterIncrement);
