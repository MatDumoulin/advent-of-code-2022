namespace Day2;

public enum Outcome
{
    Draw,
    Loss,
    Win
}

public static class OutcomeHelper
{
    public static Outcome GetOutcomeOfRound(char opponentMove, char myMove)
    {
        if (opponentMove == 'A' && myMove == 'X'
            || opponentMove == 'B' && myMove == 'Y'
            || opponentMove == 'C' && myMove == 'Z')
        {
            return Outcome.Draw;
        }

        if (opponentMove == 'A' && myMove == 'Z'
            || opponentMove == 'B' && myMove == 'X'
            || opponentMove == 'C' && myMove == 'Y')
        {
            return Outcome.Loss;
        }

        return Outcome.Win;
    }

    public static char GetMoveForOutcome(char opponentMove, Outcome desiredOutcome)
    {
        if (opponentMove == 'A' && desiredOutcome == Outcome.Loss)
        {
            return 'Z';
        }

        if (opponentMove == 'A' && desiredOutcome == Outcome.Win)
        {
            return 'Y';
        }

        if (opponentMove == 'B' && desiredOutcome == Outcome.Loss)
        {
            return 'X';
        }

        if (opponentMove == 'B' && desiredOutcome == Outcome.Win)
        {
            return 'Z';
        }

        if (opponentMove == 'C' && desiredOutcome == Outcome.Loss)
        {
            return 'Y';
        }

        if (opponentMove == 'C' && desiredOutcome == Outcome.Win)
        {
            return 'X';
        }

        return (char)(opponentMove + 23);
    }
}