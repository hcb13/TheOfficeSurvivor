using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TestGrid : MonoBehaviour
{

    private Grid<bool> grid;

    [SerializeField]
    private GameObject player;

    private void Start()
    {
        int width = 3;
        int height = 3;
        int cellSize = 10;
        Vector2 originPosition = new Vector2(-1.5f * cellSize, -1.5f * cellSize );

        grid = new Grid<bool>(width, height, cellSize, originPosition);

        for(int i = 0; i < grid.GridArray.GetLength(0); i++)
        {
            for(int j = 0; j < grid.GridArray.GetLength(1); j++)
            {
                Debug.DrawLine(grid.XYToWorldPosition(i, j), grid.XYToWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(grid.XYToWorldPosition(i, j), grid.XYToWorldPosition(i + 1, j), Color.white, 100f);
            }
        }

        Debug.DrawLine(grid.XYToWorldPosition(0, height), grid.XYToWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(grid.XYToWorldPosition(width, 0), grid.XYToWorldPosition(width, height), Color.white, 100f);
    }


    private void Update()
    {
        int x, y;
        grid.WorldPositionToXY(player.transform.position, out x, out y);
        Debug.Log("("+x+","+y+")");

        //if (x == 0)
        //{
        //    x = 2;
        //}

        //player.transform.position = grid.XYToWorldPosition(x, y);
    }


}
