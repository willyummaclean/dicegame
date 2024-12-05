namespace ShootingDice;
// TODO: Complete this class

// A Player whose role will always be in the upper half of their possible rolls
public class UpperHalfPlayer : Player
{
    public override int Roll()
    {
        // Calculate the lower bound of the upper half
        int lowerBound = (DiceSize / 2) + 1;

        // Return a random number in the range [lowerBound, DiceSize]
        return new Random().Next(lowerBound, DiceSize + 1);
    }
}