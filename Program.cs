using ShootingDice;

Player player1 = new Player();
player1.Name = "Bob";

Player player2 = new Player();
player2.Name = "Sue";

player2.Play(player1);

Console.WriteLine("-------------------");

Player player3 = new Player();
player3.Name = "Wilma";

player3.Play(player2);

Console.WriteLine("-------------------");

Player large = new LargeDicePlayer();
large.Name = "Bigun Rollsalot";

player1.Play(large);

Console.WriteLine("-------------------");

SmackTalkingPlayer smackTalkingPlayer = new SmackTalkingPlayer();
smackTalkingPlayer.Name = "Humberton";
smackTalkingPlayer.Taunt = "You fools are bout to git schooled";
smackTalkingPlayer.ShowTaunt();

smackTalkingPlayer.Play(player3);

Console.WriteLine("-------------------");

OneHigherPlayer oneHigherPlayer = new OneHigherPlayer();
oneHigherPlayer.Name = "Johnny OneHigher";

oneHigherPlayer.Play(smackTalkingPlayer);

Console.WriteLine("-------------------");

HumanPlayer humanPlayer = new HumanPlayer();
humanPlayer.Name = "Bingo";

humanPlayer.Play(large);

Console.WriteLine("-------------------");

CreativeSmackTalkingPlayer creativeSmackTalkingPlayer = new CreativeSmackTalkingPlayer();
creativeSmackTalkingPlayer.Name = "Bongo";
creativeSmackTalkingPlayer.Taunts = ["Get Ready to Loose", "You don't stand a chance", "Watch this, chump   "];
creativeSmackTalkingPlayer.ShowTaunt();
creativeSmackTalkingPlayer.Play(oneHigherPlayer);

Console.WriteLine("-------------------");

SoreLoserPlayer soreLoserPlayer = new SoreLoserPlayer();
soreLoserPlayer.Name = "Whinny";



try
{
    // Try to make the players play against each other
    soreLoserPlayer.Play(large);
}
catch (Exception ex)
{
    // Catch and display the exception if a player loses badly
    Console.WriteLine($"An exception occurred: {ex.Message}");
}

Console.WriteLine("-------------------");

List<Player> players = new List<Player>() {
    player1, player2, player3, large, smackTalkingPlayer, oneHigherPlayer, creativeSmackTalkingPlayer, humanPlayer
};

PlayMany(players);

static void PlayMany(List<Player> players)
{
    Console.WriteLine();
    Console.WriteLine("Let's play a bunch of times, shall we?");

    // We "order" the players by a random number
    // This has the effect of shuffling them randomly
    Random randomNumberGenerator = new Random();
    List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

    // We are going to match players against each other
    // This means we need an even number of players
    int maxIndex = shuffledPlayers.Count;
    if (maxIndex % 2 != 0)
    {
        maxIndex = maxIndex - 1;
    }

    // Loop over the players 2 at a time
    for (int i = 0; i < maxIndex; i += 2)
    {
        Console.WriteLine("-------------------");

        // Make adjacent players play noe another
        Player player1 = shuffledPlayers[i];
        if (player1 is SmackTalkingPlayer smackTalkingPlayer1)
        {
            smackTalkingPlayer1.ShowTaunt();
        }
        else if (player1 is CreativeSmackTalkingPlayer creativeSmackTalkingPlayer1)
        {
            creativeSmackTalkingPlayer1.ShowTaunt();
        }
        Player player2 = shuffledPlayers[i + 1];
        if (player2 is SmackTalkingPlayer smackTalkingPlayer2)
        {
            smackTalkingPlayer2.ShowTaunt();
        }
        else if (player2 is CreativeSmackTalkingPlayer creativeSmackTalkingPlayer2)
        {
            creativeSmackTalkingPlayer2.ShowTaunt();
        }
        player1.Play(player2);
    }
}