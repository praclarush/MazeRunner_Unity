using UnityEngine;

public enum VictoryType
{
    Win,
    Lose,
    Unknown
}

public class GameWorld  {

    public const int PICKUP_WORTH = 1;

    static GameWorld() {
        TypeOfVictory = VictoryType.Unknown;
        StartingTime = 15.0f;
        MaxCoins = 25;
        CurrentLevel = 0;
        GameOver = false;
        CurrentCoins = 0;
        NumRows = 2;
        NumCols = 2;
    }

    public static bool GameOver { get; set; }
    public static int CurrentCoins { get; set; }
    public static int CurrentLevel { get; set; }
    public static int MaxCoins { get; set; }
    public static int NumRows { get; set; }
    public static int NumCols { get; set; }
    
    public static float StartingTime { get; set; }
    public static VictoryType TypeOfVictory { get; set; }
    
    public static void AdvanceLevel()
    {
        CurrentCoins = 0;
        CurrentLevel += 1;

        StartingTime = 60.0f;

        NumRows += 1;
        NumCols += 1;

        GameOver = false;

        Application.LoadLevel("GameScreen");
    }
}
