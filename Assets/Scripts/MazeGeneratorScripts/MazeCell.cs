public class MazeCell {
    public bool IsVisited { get; set; }
    public bool IsGoal { get; set; }
    public bool WallRight { get; set; }
    public bool WallLeft { get; set; }
    public bool WallFront { get; set; }
    public bool WallBack { get; set; }

    public MazeCell()
    {
        IsVisited = false;
        IsGoal = false;
        WallRight = false;
        WallLeft = false;
        WallFront = false;
        WallBack = false;
    }
}

