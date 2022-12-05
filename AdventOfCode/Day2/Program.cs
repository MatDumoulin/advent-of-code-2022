using Day2;

var input = File.ReadAllLines(Directory.GetCurrentDirectory() + "/input.txt");

var scorePerMove = new Dictionary<char, int>
{
    { 'X', 1 },
    { 'Y', 2 },
    { 'Z', 3 },
};

var scorePerOutcome = new Dictionary<Outcome, int>
{
    { Outcome.Loss, 0 },
    { Outcome.Draw, 3 },
    { Outcome.Win, 6 },
};

var letterToOutcome = new Dictionary<char, Outcome>
{
    { 'X', Outcome.Loss },
    { 'Y', Outcome.Draw },
    { 'Z', Outcome.Win },
};

var totalScore = 0;

foreach (var line in input)
{
    var opponentMove = line[0];
    var myMove = line[2];

    var outcome = OutcomeHelper.GetOutcomeOfRound(opponentMove, myMove);
    totalScore += scorePerMove[myMove] + scorePerOutcome[outcome];
}

Console.WriteLine($"Answer 1: {totalScore}");

//////////////////////////////////////////////

totalScore = 0;

foreach (var line in input)
{
    var opponentMove = line[0];
    var desiredOutcome = letterToOutcome[line[2]];

    var myMove = OutcomeHelper.GetMoveForOutcome(opponentMove, desiredOutcome);
    totalScore += scorePerMove[myMove] + scorePerOutcome[desiredOutcome];
}

Console.WriteLine($"Answer 2: {totalScore}");

