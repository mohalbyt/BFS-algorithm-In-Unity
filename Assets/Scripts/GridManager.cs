using System;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    
    [SerializeField] private Vector2Int gridSize;
    [SerializeField] public int unityGridSize;

    public Dictionary<Vector2Int, Node> Grid = new Dictionary<Vector2Int, Node>();

    private void Awake()
    {
        CreateGrid();
        GenerateMaze();
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2Int cords = new Vector2Int(x, y);
                Grid.Add(cords, new Node(cords, true));
            }
        }        
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (Grid.ContainsKey(coordinates))
        {
            return Grid[coordinates];
        }
        return null;
    }

    public void BlockNode(Vector2Int coordinates)
    {
        if (Grid.ContainsKey(coordinates))
        {
            Grid[coordinates].walkable = false;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector2 position)
    {
        int x = Mathf.RoundToInt(position.x / unityGridSize);
        int y = Mathf.RoundToInt(position.y / unityGridSize);
        //I change 
        return new Vector2Int(x, y);
    }

    public Vector2 GetPositionFromCoordinates(Vector2Int coordinates)
    {
        Vector2 position = new Vector2();
        position.x = coordinates.x * unityGridSize;
        position.y = coordinates.y *  unityGridSize;
        
        return position;
    }
    
    
    public void GenerateMaze()
    {
        // 1. Block every node
        foreach (Node node in Grid.Values)
        {
            node.walkable = false;
        }

        // Maze generation works best with odd grid dimensions
        if (gridSize.x < 3 || gridSize.y < 3)
            return;

        Vector2Int start = new Vector2Int(1, 1);

        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

        stack.Push(start);
        visited.Add(start);
        Grid[start].walkable = true;

        Vector2Int[] directions =
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek();
            List<Vector2Int> neighbors = new List<Vector2Int>();

            foreach (Vector2Int dir in directions)
            {
                // Skip one cell to leave room for walls
                Vector2Int next = current + dir * 2;

                if (next.x <= 0 || next.x >= gridSize.x - 1 ||
                    next.y <= 0 || next.y >= gridSize.y - 1)
                    continue;

                if (!visited.Contains(next))
                    neighbors.Add(next);
            }

            if (neighbors.Count == 0)
            {
                // Backtrack
                stack.Pop();
                continue;
            }

            // Choose a random unvisited neighbor
            Vector2Int chosen =
                neighbors[UnityEngine.Random.Range(0, neighbors.Count)];

            // Open the wall between current and chosen
            Vector2Int middle = (current + chosen) / 2;
            Grid[middle].walkable = true;
            Grid[chosen].walkable = true;

            visited.Add(chosen);
            stack.Push(chosen);
        }
    }

}
