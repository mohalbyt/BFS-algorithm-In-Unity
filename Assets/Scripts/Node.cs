using UnityEngine;

public class Node
{
    public Vector2Int cords;
    
    public bool walkable;
    
    
    public Node(Vector2Int cords, bool walkable)
    {
        this.cords = cords;
        this.walkable = walkable; 
    }
    
    
}
