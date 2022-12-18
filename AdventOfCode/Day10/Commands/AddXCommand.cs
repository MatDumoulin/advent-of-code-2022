namespace Day10.Commands;

public record AddXCommand(int RegisterIncrement) : CommandBase(2, RegisterIncrement);
