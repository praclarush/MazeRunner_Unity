using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class MazeGenerator : MonoBehaviour {

    public bool FullRandom = false;
	public int RandomSeed = 3;
    public GameObject FloorPrefab;
    public GameObject WallPrefab;
    public GameObject PointPrefab;
    public int Rows = 5;
    public int Columns = 5;
    public float CellWidth = 5;
    public float CellHeight = 5;    
    

    private MazeGeneratorBase _mazeGenerator;
    private int numGoals = 0;

    void Awake()
    {
        //TODO(Nathan): Set Rows and Columns based on difficulty level,
        Rows = GameWorld.NumRows;
        Columns = GameWorld.NumCols;

        GenerateMaze();

        GameWorld.MaxCoins = numGoals;
    }

    void Start () {

        
	}

    public void GenerateMaze()
    {
        ClearGameObject();

        if (!FullRandom)
        {
            Random.seed = RandomSeed;
        }

        _mazeGenerator = new TreeMazeGenerator(Rows, Columns);

        _mazeGenerator.GenerateMaze();

        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                float x = column * (CellWidth);
                float y = row * (CellHeight);
                MazeCell cell = _mazeGenerator.GetMazeCell(row, column);
                GameObject temp = Instantiate(FloorPrefab, new Vector3(x, y, 1), Quaternion.Euler(270, 0, 0)) as GameObject; ;

                temp.transform.parent = transform;
                if (cell.WallRight)
                {
                    WallPrefab.name = "WallRight";
                    temp = Instantiate(WallPrefab, new Vector3(x + CellWidth / 2, y, 1) + WallPrefab.transform.position, Quaternion.Euler(0, 90, -90)) as GameObject;// right
                    temp.transform.parent = transform;
                }
                if (cell.WallFront)
                {
                    WallPrefab.name = "WallFront";
                    temp = Instantiate(WallPrefab, new Vector3(x, y + CellHeight / 2, 1) + WallPrefab.transform.position, Quaternion.Euler(270, 0, 0)) as GameObject;// front
                    temp.transform.parent = transform;
                }
                if (cell.WallLeft)
                {
                    WallPrefab.name = "WallLeft";
                    temp = Instantiate(WallPrefab, new Vector3(x - CellWidth / 2, y, 1) + WallPrefab.transform.position, Quaternion.Euler(0, 270, 90)) as GameObject;// left
                    temp.transform.parent = transform;
                }
                if (cell.WallBack)
                {
                    WallPrefab.name = "WallBack";
                    temp = Instantiate(WallPrefab, new Vector3(x, y - CellHeight / 2, 1) + WallPrefab.transform.position, Quaternion.Euler(90, 180, 0)) as GameObject;// back
                    temp.transform.parent = transform;
                }
                if (cell.IsGoal && PointPrefab != null)
                {
                    numGoals += 1;
                    PointPrefab.name = "Coin";
                    temp = Instantiate(PointPrefab, new Vector3(x, y, 0.1f), Quaternion.Euler(0, 0, 0)) as GameObject;                    
                    temp.transform.parent = transform;
                }
            }
        }

       
    }

    private void ClearGameObject()
    {
        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }

    }
}
