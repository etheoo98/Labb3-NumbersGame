# Labb3-NumbersGame
C# console application made for yet another beginners programming course. 

## Assignment description
Now it's time to build your first real program that can actually be fun to use - a simpler game!

What you are going to create is a fairly simple game where the user has to guess a number. The user will be given some hints and has a limited number of attempts to guess.

* Create a new project in Visual Studio (Console Application → C# → .Net Core)
* Name the project "NumbersGame".
* When the program starts, the following should be printed in the console: "Welcome! I'm thinking of a number. Can you guess which one? You get five attempts."
* The program should randomly generate a number for the user to guess, but of course don't print out which number it is. For example, the program may generate a number between 1 and 20, but you decide.
* The user must then enter a number that they want to guess.
*  If the number is wrong, the program should respond with either "Sorry, you guessed too low!" or "Sorry, you guessed too high!" depending on whether the number guessed by the user was higher or lower than the correct one.
*  If the user guesses correctly, the program should print "Wohoo! You did it!"
*  If the user has guessed five (5) times and did not get the right number, the program should print "Sorry, you failed to guess the number in five attempts!" and the user may not guess any more.
*  Some part of your code should be in its own function/method. For example, you can have a function to check if the guess is right or wrong called CheckGuess()

### Tips
To have the program randomly generate a number, you can use the code below. It will randomly produce a number between 1 and 20, which is entered into the number variable.
```
Random random = new Random();
int number = random.Next(1,20);
```

### Examples
Below you will find some examples of game rounds as seen in the console.

* Example 1
```
Welcome! I'm thinking of a number. Can you guess which one? You get five attempts
2
Sorry, you guessed too low!
9
Sorry, you guessed too high!
7
Sorry, you guessed too high!
4
Sorry, you guessed too high!
5
Sorry, you guessed too high!
Sorry, you failed to guess the number in five attempts!
```

* Example 2
```
Welcome! I'm thinking of a number. Can you guess which one? You get five attempts
4
Sorry, you guessed too high!
2
Woohoo! You made it!
```

* Example 3
```
Welcome! I'm thinking of a number. Can you guess which one? You get five attempts
4
Woohoo! You made it!
```

## Extra challenge

Does the assignment feel too easy? Did you finish quickly?

Here you have some ideas on how you can make the assignment a little more advanced. Test as much as you want with these suggestions!

* Restart the game
  * As you can see, it is a bit sad that the game ends when you have guessed correctly or used all your attempts. Make it possible to restart the game without restarting the program! A neat way could be for the game at the end to ask something like "Do you want to play again?" and if the user types "yes" the game restarts.

* Select difficulty level
  * Let the game start with the program asking for a difficulty level. Either you can make it so that the user can choose different levels, for example by entering a number between 1 and 5, and then based on the answer the game varies in difficulty. Or maybe the user can enter how many possible numbers there should be. You can modify both how many numbers the program randomizes between and how many attempts the user should get. Easy level is maybe 10 numbers and 6 attempts. Intermediate level is maybe 25 numbers and 5 attempts. Hard level is maybe 50 numbers and 3 attempts.

* You're close!
  * Make the answers to the guesses a little more customized based on how close to the correct number the user guess! If the program thinks about e.g. the number 7 and the user guesses 6, it can instead say "You're close!". But if the user guesses 2, the program can answer, for example, "Oops, that was far from". Here you can be creative and come up with several different types of answers based on how close or far from the number the user guesses.
 
* Variations in answers
  * Surely it's boring that the program responds like a robot and says the same thing every time? Make it more fun! Come up with maybe four or five different variations of answers for, for example, "Unfortunately, you guessed too high!". Maybe the program can respond "Haha! That was too loud!" or "Good guess, but that was too high". Then let the program vary in answers. It should still tell you if it's too high or low but with a little variation in the language.
