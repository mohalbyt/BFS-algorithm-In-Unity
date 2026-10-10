using System;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Vector2Int startCords;
    [SerializeField] Vector2Int endCords;

    [ContextMenu("Find")]
    public void Find()
    {
        var path = GetPath(startCords, endCords,new List<Node>());
        ShowPath(path);
    }


    public List<Node> GetPath(Vector2Int from, Vector2Int end,List<Node> currentPath)
    {
        Debug.Log(from);
        GridManager gridManager = FindObjectOfType<GridManager>();
        Node fromNode = gridManager.GetNode(from);
        currentPath.Add(fromNode);
        if (from == end)
        {
            return currentPath;
        }
        
        Node upNode = gridManager.GetNode(new Vector2Int(from.x, from.y + 1));
        Node downNode = gridManager.GetNode(new Vector2Int(from.x, from.y - 1));
        Node rightNode = gridManager.GetNode(new Vector2Int(from.x+ 1, from.y ));
        Node leftNode = gridManager.GetNode(new Vector2Int(from.x -1, from.y ));
        
        List<Node> forcheck = new List<Node>();
        if(upNode != null)
        forcheck.Add(upNode);
        if (rightNode != null)
        forcheck.Add(rightNode);
        if (downNode != null)
        forcheck.Add(downNode);
        if (leftNode != null)
        forcheck.Add(leftNode);
        
        forcheck.Sort((s1, s2) =>
            (s1.cords - end).sqrMagnitude.CompareTo(
                (s2.cords - end).sqrMagnitude
            )
        );

        foreach (var node in forcheck)
        {
            if(node != null)
                Debug.Log("check " + node.cords.ToString());
            
            if (node == null ||!node.walkable  ||   currentPath.Contains(node))
            {
                continue;   
            }
            Debug.Log("check! " + node.cords.ToString());

            var resultPath = GetPath(node.cords, end, new List<Node>(currentPath));
            if(resultPath == null)
                continue;
            return resultPath;
        }

        return null;
    }
    

    public void ShowPath(List<Node> path)
    {
        TileSpawner tileSpawner =  FindObjectOfType<TileSpawner>();
        foreach (var item in path)
        {
            tileSpawner.tiles[item.cords].SetColor(Color.green);
        }
    }
    //
    //
    // public Vector2Int StartCords
    // {
    //     get { return startCords; } 
    // }
    //
    // [SerializeField] Vector2Int targetCords;
    // public Vector2Int TargetCords 
    // {
    //     get { return targetCords; }
    // }
    //
    // Node startNode;
    // Node targetNode;
    // Node currentNode;
    //
    // Queue<Node> frontier  = new Queue<Node>();
    // Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    //
    // private GridManager gridManager;
    // private Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    //
    // Vector2Int[] searchOrder = {Vector2Int.right, Vector2Int.left,  Vector2Int.up, Vector2Int.down};
    //
    //
    // // private void Awake()
    // // {
    // //     gridManager = FindFirstObjectByType<GridManager>();
    // //     if (gridManager != null)
    // //     {
    // //         grid = gridManager.Grid;
    // //     }
    // // }
    // //
    // // public List<Node> GetNewPath(Vector2Int coordinates)
    // // {
    // //     //Reset 
    // //     //Search
    // // }
    
}
