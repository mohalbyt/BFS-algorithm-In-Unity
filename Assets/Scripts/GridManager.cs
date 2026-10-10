using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    
    [SerializeField] private Vector2Int gridSize;
    [SerializeField] private int unityGridSize;

    public int UnityGridSize
    {
        get { return unityGridSize; }
    }
    
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    
    public Dictionary<Vector2Int, Node> Grid {get{return grid;}}

    private void Awake()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int cords = new Vector2Int(x, y);
                grid.Add(cords, new Node(cords, true));
            }
        }        
    }

    public Node GetNode(Vector2Int cords)
    {
        if (grid.ContainsKey(cords))
        {
            return grid[cords];
        }
        return null;
    }

    public void BlockNode(Vector2Int cords)
    {
        if (grid.ContainsKey(cords))
        {
            grid[cords].walkable = false;
        }
    }

    public void ResetNodes()
    {
        foreach (KeyValuePair<Vector2Int, Node> entry in grid)
        {
            entry.Value.connectTo = null;
            entry.Value.explored = false;
            entry.Value.path = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector2 position)
    {
        int x = Mathf.RoundToInt(position.x / unityGridSize);
        int y = Mathf.RoundToInt(position.y / unityGridSize);

        return new Vector2Int(x, y);
    }

    public Vector2 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector2 position = new Vector2();
        position.x = coordinates.x * unityGridSize;
        position.y = coordinates.y *  unityGridSize;
        
        return position;
    }

    public Vector2 SetPositionFromCoordinates(Vector2Int coordinates, GameObject  gameObject)
    {
        Debug.Log(name);
        
        Vector2 position = new Vector2();
        position.x = coordinates.x * unityGridSize;
        position.y = coordinates.y * unityGridSize;
        
        gameObject.transform.position = position;
        return position;
    }
}
