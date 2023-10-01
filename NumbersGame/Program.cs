/*
 * Author: Theodor Hägg (.NET23)
 * Website: https://github.com/etheoo98/Labb3-NumbersGame
 * Date: October 1, 2023
 */

namespace NumbersGame;

internal static class Program
{
    private const int CloseGuess = 5;

    public static void Main()
    {
        PlayGame();
    }

    private static void PlayGame()
    {
        var previousGuesses = new List<int>();
        
        do
        {
            ResetGame(previousGuesses);
            var difficulty = SelectDifficulty();
            var (hiddenNumber, maxHiddenNumber, maxAllowedGuesses) = SetupSelectedDifficulty(difficulty);
            
            Console.WriteLine($"\nVälkommen! Jag tänker på ett nummer mellan 1 och {maxHiddenNumber}. Kan du gissa vilket? Du får {maxAllowedGuesses} försök.\n");
            // Console.WriteLine($"DEBUG: Talet är {hiddenNumber}"); // Uncomment for debugging purposes.
            
            var isGameWon = false;
            while (previousGuesses.Count != maxAllowedGuesses && !isGameWon)
            {
                var guess = GetUserGuess(previousGuesses, maxHiddenNumber);
                isGameWon = CheckGuess(guess, hiddenNumber);
            }
            
            EndGameMessage(isGameWon, hiddenNumber, maxAllowedGuesses);
            
            Console.Write("Vill du spela igen? [Y/n] ");
        } while (Console.ReadKey().KeyChar != 'n'); // User has to explicitly press "n" to exit program.
    }

    private static void ResetGame(List<int> previousGuesses)
    {
        Console.Clear();
        previousGuesses.Clear(); // Clear elements in list.
    }

    private static int SelectDifficulty()
    { 
        const int minDifficulty = 1;
        const int maxDifficulty = 3;
        
        while (true)
        {
            Console.Write($"Välj svårhetsgrad ({minDifficulty}-{maxDifficulty}): ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var selectedDifficulty)
                && selectedDifficulty is >= minDifficulty and <= maxDifficulty)
                return selectedDifficulty;
            
            Console.WriteLine($"Ett fel uppstod! Värdet måste vara ett heltal mellan {minDifficulty} och {maxDifficulty}\n");
        }
    }
    
    private static (int hiddenNumber, int maxHiddenNumber, int maxAllowedGuesses) SetupSelectedDifficulty(int difficulty)
    {
        var maxHiddenNumber = 0;
        var allowedGuesses = 0;
        
        switch (difficulty)
        {
            case 1:
                allowedGuesses = 6;
                maxHiddenNumber = 10;
                break;
            case 2:
                allowedGuesses = 5;
                maxHiddenNumber = 25;
                break;
            case 3:
                allowedGuesses = 3;
                maxHiddenNumber = 50;
                break;
        }
        
        var random = new Random();
        var hiddenNumber = random.Next(1, maxHiddenNumber + 1);

        return (hiddenNumber, maxHiddenNumber, allowedGuesses);
    }

    private static int GetUserGuess(List<int> previousGuesses, int maxHiddenNumber)
    {
        // Prompt user until they input an int that could be the hidden number, and doesn't already exist in the list.
        while (true)
        {
            if (previousGuesses is { Count: > 0 }) // Check if list contains elements.
            {
                var guessesString = string.Join(", ", previousGuesses) + "."; // Create a string of the elements.
                Console.WriteLine($"Tidigare gissningar: {guessesString}");
            }
            
            Console.Write("Skriv din gissning: ");
            var input = Console.ReadLine();

            // The user input is deemed valid if the string can be converted to int, and doesn't exist in the list.
            if (int.TryParse(input, out var guess) && !previousGuesses.Contains(guess)
                && guess > 0 && guess <= maxHiddenNumber)
            {
                previousGuesses.Add(guess); // Add current guess to list.
                return guess;
            }
            
            Console.Write("Fel vid inmatning! ");

            if (!int.TryParse(input, out _))
            {
                Console.WriteLine("Du måste ange ett heltal.");
            }
            else if (guess > maxHiddenNumber || guess < 1)
            {
                Console.WriteLine($"Du kan bara gissa mellan 1 och {maxHiddenNumber}.");
            }
            else if (previousGuesses.Contains(guess))
            {
                Console.WriteLine($"Du har redan gissat talet {guess}.");
            }
            
            Console.WriteLine("Din inmatning räknas därför inte som en gissning.\n");
        }
    }

    private static bool CheckGuess(int guess, int hiddenNumber)
    {
        if (guess == hiddenNumber)
        {
            return true; // Return true on correct guess.
        }
        
        switch (Math.Abs(guess - hiddenNumber))
        {
            case <= 1: // The guess is ± 1 of the hidden number.
                Console.WriteLine("Det bränns!\n");
                break;
            case <= CloseGuess: // The guess is within ± close guess of the hidden number.
                Console.WriteLine("Du är inte långt ifrån!\n");
                break;
            default:
            {
                if (guess > hiddenNumber)
                {
                    Console.WriteLine("Tyvärr, du gissade för högt.\n");
                }
                else if (guess < hiddenNumber)
                {
                    Console.WriteLine("Tyvärr, du gissade för lågt.\n");
                }

                break;
            }
        }
        
        return false; // Return false on incorrect guess.
    }

    private static void EndGameMessage(bool isGameWon, int hiddenNumber, int allowedGuesses)
    {
        Console.WriteLine(isGameWon
            ? "Wohoo! Du klarade det!"
            : $"Tyvärr, du lyckades inte gissa talet {hiddenNumber} på {allowedGuesses} försök.");
    }
}