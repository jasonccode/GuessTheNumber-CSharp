string? player;
Random random = new Random();
int attemps = 0;
int highestScoreAttemps = 0;

List<int> attemptsList = new List<int>();

Console.WriteLine("Guess The Number");

StartGame();

void StartGame()
{
    Console.WriteLine("Hello! Welcome to the game....");
    Console.WriteLine("What is your name?");

    var randomNumber = random.Next(1, 10);
    player = Console.ReadLine();
    WantToPlay(randomNumber);
}

void WantToPlay(int randomNumber, bool playAgain = false)
{
    if (playAgain)
        Console.WriteLine($"Hi {player}, are you ready to play? (Enter Yes/No )");
    else
        Console.WriteLine($" {player}, are you ready to play again? (Enter Yes/No )");

    var wantToPlay = Console.ReadLine();

    switch (wantToPlay?.ToLower().Trim())
    {
        case "yes":
            Play(randomNumber);
            break;

        case "no":
            DontPlay();
            break;

        default:
            Console.WriteLine("That is not a valid option");
            WantToPlay(randomNumber);
            break;
    }
}
void Play(int randomNumber)
{
    try
    {
        Console.WriteLine("Pick a number between 1 and 10");
        var pickedNumber = Console.ReadLine();
        if (pickedNumber is null)
            throw new Exception("You need to pick a value!");
        if (int.Parse(pickedNumber) < 1 || int.Parse(pickedNumber) > 10)
            throw new Exception("Please pick a number between 1 and 10");

        if (int.Parse(pickedNumber) == randomNumber)
        {
            YouGuessed();
        }
        if (int.Parse(pickedNumber) < randomNumber)
        {
            Console.WriteLine("Try again! The number is higher...");
            attemps++;
            Play(randomNumber);
        }
        if (int.Parse(pickedNumber) > randomNumber)
        {
            Console.WriteLine("Try again! The number is lower...");
            attemps++;
            Play(randomNumber);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"There has been an error: {e.Message} ");
        Play(randomNumber);
    }
}

void DontPlay()
{
    Console.WriteLine("No worries! Have a good one! ");
}

void YouGuessed()
{
    Console.WriteLine("Nice! You guessed the number!");
    attemps++;

    attemptsList.Add(attemps);

    if (highestScoreAttemps == 0 || attemps < highestScoreAttemps)
        highestScoreAttemps = attemps;

    Console.WriteLine($"It has taken you {attemps} attemps to guess the number");
    ShowScore();
    attemps = 0;

    var randomNumber = random.Next(1, 10);
    WantToPlay(randomNumber, true);
}

void ShowScore()
{
    if (highestScoreAttemps == 0)
    {
        Console.WriteLine("There is currently no high score, it´s your for the taking!");
    }
    else
    {
        Console.WriteLine($"The current high score is {highestScoreAttemps} attempts");
    }
}