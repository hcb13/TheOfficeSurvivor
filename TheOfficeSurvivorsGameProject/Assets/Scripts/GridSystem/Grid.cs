using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid<T>
{

    private int width;
    public int Width
    {
        get { return width; }
    }
    private int height;
    public int Height {
        get { return height; }
    }
    private float cellSize;
    public float CellSize
    {
        get { return cellSize; }
    }
    private Vector2 originPosition;
    public Vector2 OriginPosition
    {
        get { return originPosition; }
    }

    private T[,] gridArray; 
    public T[,] GridArray
    {
        get { return gridArray; }
    }

    public Grid(int width, int height, float cellSize, Vector2 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new T[width, height];
    }

    public Vector2 XYToWorldPosition(int x, int y)
    {
        return new Vector2(x, y) * cellSize + originPosition;
    }

    public void WorldPositionToXY(Vector2 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetGridObject(int x, int y, T value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
        }
    }

    public void SetGridObject(Vector3 worldPosition, T value)
    {
        int x, y;
        WorldPositionToXY(worldPosition, out x, out y);
        SetGridObject(x, y, value);
    }

    public T GetGridObject(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(T);
        }
    }

    public T GetGridObject(Vector3 worldPosition)
    {
        int x, y;
        WorldPositionToXY(worldPosition, out x, out y);
        return GetGridObject(x, y);
    }
}
