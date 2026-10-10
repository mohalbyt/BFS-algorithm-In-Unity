using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private TextMeshPro lable;
    public SpriteRenderer spriteRenderer;
    public Vector2Int cords;

    GridManager gridManager;


    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public void Block()
    {
        gridManager.BlockNode(cords);
        spriteRenderer.color = Color.black;
    }

    public void SetCords(Vector2Int cords)
    {
        this.cords = cords;
        gridManager = FindFirstObjectByType<GridManager>();
        transform.position = gridManager.GetPositionFromCoordinates(cords);
        var node = gridManager.GetNode(cords);
        if (!node.walkable)
        {
            spriteRenderer.color = Color.black;
        }
        transform.name = cords.ToString();
        lable.text = cords.ToString();
    }
}