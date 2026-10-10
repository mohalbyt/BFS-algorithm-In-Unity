using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool blocked;

    public Vector2Int cords;

    GridManager gridManager;

   
    void Start()
    {
        SetCords();

        if(blocked)
        {
            gridManager.BlockNode(cords);
        }
    }

    private void SetCords()
    {
        gridManager = FindObjectOfType<GridManager>();
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        cords = new Vector2Int(x / gridManager.UnityGridSize, y / gridManager.UnityGridSize);
    }
}