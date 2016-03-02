using System;
using UnityEngine;
using System.Collections;

public abstract class MazeGeneratorBase {
    public int RowCount { get; private set; }
    public int ColumnCount { get; private set; }    
    private MazeCell[,] _maze;

    public MazeGeneratorBase(int rows, int columns)
    {
        RowCount = Mathf.Abs(rows);
        ColumnCount = Mathf.Abs(columns);

        if (RowCount == 0)
        {
            RowCount = 1;   
        }

        if (ColumnCount == 0)
        {
            ColumnCount = 1;
        }

        _maze = new MazeCell[RowCount,ColumnCount];
        InitMaze();
    }

    private void InitMaze() {
        for (int row = 0; row < RowCount; row++) {
            for (int column = 0; column < ColumnCount; column++) {
                _maze[row, column] = new MazeCell();
            }
        }
    }

    public MazeCell GetMazeCell(int row, int column)
    {
        if (row >= 0 && column >= 0 && row < RowCount && column < ColumnCount)
        {
            return _maze[row, column];
        }
        else
        {
            Debug.Log(row + ", " + column);
            throw new IndexOutOfRangeException("Row or Column is outside the range of the Maze");
        }
    }

    public abstract void GenerateMaze();
}
