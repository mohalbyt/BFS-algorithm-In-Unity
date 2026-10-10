using System;
using TMPro;
using UnityEngine;
[ExecuteAlways]
public class Labeller : MonoBehaviour
{
    // private TextMeshPro label;
    // private Vector2Int cords;
    // GridManager gridManager;
    //
    //
    // private void Awake()
    // {
    //     gridManager = FindObjectOfType<GridManager>();
    //     label = GetComponent<TextMeshPro>();
    //     label = GetComponentInChildren<TextMeshPro>();
    //     
    //     DisplayCords();
    // }
    //
    // private void Update()
    // {
    //     DisplayCords();
    //     transform.name = cords.ToString();
    // }
    //
    // void DisplayCords()
    // {
    //     if (!gridManager)
    //     {
    //         Debug.LogError("GridManager not found");
    //     }
    //     cords.x = Mathf.FloorToInt(transform.position.x / gridManager.UnityGridSize);
    //     cords.y = Mathf.FloorToInt(transform.position.y / gridManager.UnityGridSize);
    //
    //     label.text = $"{cords.x}, {cords.y}";
    // }
}
