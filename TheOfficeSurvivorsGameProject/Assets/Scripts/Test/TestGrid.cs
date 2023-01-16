using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TestGrid : MonoBehaviour
{

    private Grid<bool> grid;

    private void Start()
    {
        int width = 10;
        int height = 10;
        int cellSize = 1;
        Vector2 originPosition = new Vector2(-5, -5);

        grid = new Grid<bool>(width, height, cellSize, originPosition);

        for(int i = 0; i < grid.GridArray.GetLength(0); i++)
        {
            for(int j = 0; j < grid.GridArray.GetLength(1); j++)
            {
                Debug.DrawLine(grid.XYToWorldPosition(i, j), grid.XYToWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(grid.XYToWorldPosition(i, j), grid.XYToWorldPosition(i + 1, j), Color.white, 100f);
            }
        }

    }


}
