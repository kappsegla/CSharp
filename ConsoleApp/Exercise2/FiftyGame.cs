﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Exercise2
{
    public class FiftyGame
    {
        public static void Run()
        {
            Console.WriteLine("Welcome to Fifty Game");

            Random random = new Random();
            //Generate random number between 1-50
            int randomNumber = random.Next(1, 51);
            int numberOfGuesses = 0;
            //int[] guesses = new int[50];
            List<int> guesses = new List<int>();

            while (true)
            {
                Console.Write("Enter number between 1-50: ");
                int input = ReadNumber();

                if (AlreadyGuessed(input, guesses))
                {
                    Console.WriteLine($"Already guessed {input}");
                    continue;
                }

                //Add to array of guessed numbers
                //guesses[numberOfGuesses++] = input;
                guesses.Add(input);
                numberOfGuesses++;

                if (input < randomNumber)
                {
                    Console.WriteLine("Smaller than random.");
                }
                else if (input > randomNumber)
                {
                    Console.WriteLine("Larger than random");
                }
                else
                {
                    Console.WriteLine($"You guessed it! The number was {randomNumber}!");
                    Console.WriteLine("It took you {0} {1}.\n", numberOfGuesses,
                        numberOfGuesses == 1 ? "try" : "tries");
                    Console.Write("Your guesses: ");
                    for (int i = 0; i < numberOfGuesses; i++)
                    {
                        Console.Write(guesses[i] + " ");
                    }

                    Console.ReadLine();
                }
            }
        }

        private static bool AlreadyGuessed(int guess, List<int> guesses)
        {
            foreach (var oldGuess in guesses)
            {
                if (oldGuess == guess)
                    return true;
            }

            return false;
        }

        private static int ReadNumber()
        {
            while (true)
            {
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    if (number > 0 && number < 51)
                        return number;

                    Console.Write("You must enter a number between 1-50: ");
                }
                catch (FormatException)
                {
                    Console.Write("You must enter a number between 1-50: ");
                }
            }
        }
    }
}