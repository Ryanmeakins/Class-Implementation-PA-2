//Ryan Eakins
//Main class for calling the driver and later unit tests
//The entry point for execution of the program
//makes console out put indicating what will be run next

using System;


class Test
{
    static void Main()
    {
        Console.Write("Welcome to the cipher game! \n");
        Driver drive = new Driver();
        drive.RunDriver();
        int guess = 4;
        drive.testShift(guess);
        guess = 11;
        drive.testShift(guess);
        Console.Write("\nGetting guess data");
        drive.queryData();
        Console.WriteLine("\nturning encryptors off and trying to encrypt hello again");
        drive.changeOn();
        drive.RunDriver();
        Console.WriteLine("\nreseting and encryptors");
        drive.reset();
        drive.RunDriver();
        drive.testShift(guess);
        Console.Write("\nGetting guess data");
        drive.queryData();
    }
}


