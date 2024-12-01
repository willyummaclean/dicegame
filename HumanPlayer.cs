namespace ShootingDice;

// TODO: Complete this class

// A player the prompts the user to enter a number for a roll
public class HumanPlayer : Player
{
       public override int Roll()
    {
        Console.WriteLine("What is your Roll?");
        string roll = Console.ReadLine();
        int rollNum = Convert.ToInt32(roll);
        return rollNum;
    }

}