using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TileSpawner : MonoBehaviour
{
    //ساختن تایل های بازی بر اساس گرید منیجر

    [SerializeField] private Transform tileParent;
    [SerializeField] private Tile tilePrefab;
    public Dictionary<Vector2Int, Tile> tiles = new Dictionary<Vector2Int, Tile>();
    private void Start()
    {
        var gridManager = FindFirstObjectByType<GridManager>();
        foreach (var item in gridManager.Grid)
        {
            var tile = Instantiate(tilePrefab, tileParent);
            tile.SetCords(item.Key);
            tiles[item.Key] = tile;
        }
    }
}
