//Ryan Eakins
//encryptWord.cs
//4.10.2018
//.0.0.1
//
//Description:
//This class is designed to perform a ceaser cipher on a string passed to it.
//The class encapsulates a hidden shift and some varibles for keeping track of guess data.
//a word passed to the encrypt function will be returned with each letter moved down the alphabet by hidden amount in shift
//the shift must be from 1-25 inculsive. All guess data should start at 0 and only increment (or be reset to 0)
//
//Assumptions:
//The input word is a string at least 4 chars long. Only A-Z upper and lower will be shifted any other chars will be left unchanged.
//guess data functionality are constant and do not change the state of the object
//when the object is off it should return the passed word.
//the object starts "on" and many words can passed to be encrypted
//when the correct value for the shift has been guessed the object as set to "off" as the code has been broken and is now useless




using System;

public class encryptWord
{
    int ALPHA = 26;
    private static Random rnd;
    private int shift;
    private bool isOn;
    private int queries;
    private int over;
    private int under;
    private double average;
    //Constructor for encryptWord
    //sets shift to a random number 1-25 and guess values to 0 and isOn to true
    //Preconditions: none
    //post: a valid encryptWord object
    public encryptWord()
    {
        System.Threading.Thread.Sleep(1);//before using random make sure it wont be in the same time as any previous calls
        rnd = new Random();
        shift = rnd.Next(1, ALPHA);
        isOn = true;
        queries = 0;
        over = 0;
        under = 0;
        average = 0;
    }

    //takes in a string(word) returns the encrypted version shifted based on the random shift if the encryption is "on" and the word is longer than 4 char
    //preconditions: none
    //postconditions: none

    public string encryptMyWord(string word)
    {

        if (!isOn)
        {
            return word;
        }
        if (word.Length < 4)
        {//could also be by contract so the the return doesnt apear like the encrypted word
            return "Word must be at least 4 characters long!";
        }
        string encrypted = string.Empty;
        foreach (char ch in word)
        {
            if (!char.IsLetter(ch))
            {
                encrypted += ch;
            }
            else {
                char d = char.IsUpper(ch) ? 'A' : 'a';
                encrypted += (char)((((ch + shift) - d) % ALPHA) + d);
            }
        }
        return encrypted;
    }

    //Returnd the object to its staring state
    //Pre and post: none can be done at any time
    public void reset()
    {
        System.Threading.Thread.Sleep(1);//before using random make sure it wont be in the same time as any previous calls
        Random rnd = new Random();
        shift = rnd.Next(1, ALPHA);
        isOn = true;
        queries = 0;
        over = 0;
        under = 0;
        average = 0;
    }
    //takes an interger(guess) and compares it to the shift. If they are the same returns true and sets to off
    //preconditions: the object is on
    //post: the object may be on or off
    public bool isShift(int guess)
    {
        queries++;
        average = average + (guess - average) / queries;
        if(guess>shift)
        {
            over++;
        }
        else if(guess<shift)
        {
            under++;
        }
        else
        {
            return true;
        }
        return false;
    }
    //Guess functions act as getters for the encapsulated guess data. All are constant and do not effect state.
    //Pre and Post: none
    public int numberOfQueries() {
        return queries;
    }
    public int overGuesses()
    {
        return over;
    }
    public int underGuesses()
    {
        return under;
    }
    public double averageGuess()
    {
        return average;
    }
    //logical nots the isOn. Should only really be used for debugging
    //preconditions: isOn is true or false
    //postconditions: isOn is in the opposite state
    public void toggleSwitch()
    {
        isOn = !isOn;
    }
}
