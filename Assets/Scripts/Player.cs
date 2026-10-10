using System;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    GridManager gridManager;
    
    Vector2Int startPosition;
    
    private void Awake()
    {
        gridManager = FindFirstObjectByType<GridManager>();
        GameObject tiles = GameObject.Find("Tiles");
        Vector2 pos = gridManager.GetPositionFromCoordinates(new Vector2Int(0,0));
        
    }

    void Movement()
    {
        
    }
}
