namespace ShootingDice;
// A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
public class CreativeSmackTalkingPlayer : Player
{

    public List<string> Taunts { get; set; } = new List<string>();

    public void ShowTaunt()
    {
        Random random = new Random();
        string randomTaunt = Taunts[random.Next(Taunts.Count)];
        Console.WriteLine($"{Name} says '{randomTaunt}'");

    }


}