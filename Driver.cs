//Ryan Eakins
//Driver Class that encapsulates the encryptword class
//tests various encrypt functionality with console output
//after creation of the driver object all functions can be called in any order

using System;

public class Driver
{
    private int ENCRYPTORS = 3;
    int THREE = 3;
    private encryptWord[] encryptWords;
    public Driver()
	{

        encryptWords = new encryptWord[ENCRYPTORS];
        for (int i = 0; i < ENCRYPTORS; i++)
        {
            encryptWords[i] = new encryptWord();
        }
    }

    public void RunDriver() //displays the output of passing Hello to each encryptor
    {

        Console.Write("Encrypting Hello with "+ENCRYPTORS+" objects");
        Console.Write("\n");

        string encrypteda = encryptWords[0].encryptMyWord("Hello");
        string encryptedb = encryptWords[1].encryptMyWord("Hello");
        string encryptedc = encryptWords[2].encryptMyWord("Hello");

        Console.Write("1 " + encrypteda + ", 2 " + encryptedb + ", 3 " + encryptedc);


    }
    public void testShift(int guess) //displays the compariosn of the passed int and shift for each encryptor than again with the int plus 3 to increase the chance of an equality
    {
        Console.WriteLine("\nGuesing " + guess + " for each shift");
        for (int i = 0; i < ENCRYPTORS; i++)
        {
            Console.WriteLine((i + 1) + ", " + encryptWords[i].isShift(guess));
        }
        Console.WriteLine("\nGuesing " + (guess+3) + " for each shift");
        for (int i = 0; i < ENCRYPTORS; i++)
        {
            Console.WriteLine((i + 1) + ", " + encryptWords[i].isShift(guess+THREE));
        }
    }
    public void queryData()//prints all the data tracked related to guesses for each object
    {
        Console.WriteLine();
        for(int i=0; i<ENCRYPTORS; i++)
        {
            Console.Write((i + 1) + ", Guesses: " + encryptWords[i].numberOfQueries() + " Guesses under: " + encryptWords[i].underGuesses());
            Console.WriteLine(" Guesses over: " + encryptWords[i].overGuesses() + " Averge guess: " + encryptWords[i].averageGuess());
        }
    }
    public void changeOn()//turns all the encryptors on or off
    {
        for (int i = 0; i < ENCRYPTORS; i++)
        {
            encryptWords[i].toggleSwitch();
        }
    }
    public void reset() //resets all the encryptors
    {
        for (int i = 0; i < ENCRYPTORS; i++) {
            encryptWords[i].reset();

        }
    }
}
